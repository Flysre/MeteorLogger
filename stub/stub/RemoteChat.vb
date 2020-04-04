Imports System.ComponentModel
Imports System.Net
Imports System.Text
Public Class RemoteChat
    Dim preventFormClosing As Boolean = False
    Dim firstIter As Boolean = True
    Dim messageList As New List(Of Tuple(Of String, Boolean)) ' Respectively : message and isAdmin

    Dim showInTB_param As Boolean = True
    Dim topMost_param As Boolean = True

    Private m_MyForm As MainForm
    Public ReadOnly Property MyForm() As MainForm
        Get
            If IsNothing(m_MyForm) Then m_MyForm = New MainForm
            Return m_MyForm
        End Get
    End Property

    Private Sub RemoteChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        msgReceiverBW.RunWorkerAsync()
    End Sub

    Private Sub AppendText(text As String, color As Color)
        chatWindow.SelectionStart = chatWindow.TextLength
        chatWindow.SelectionLength = 0
        chatWindow.SelectionColor = color
        chatWindow.AppendText(text)
        chatWindow.SelectionColor = chatWindow.ForeColor
    End Sub
    Private Sub refreshChat()
        Try

            chatWindow.Clear()

            For Each message In messageList
                AppendText("(", Color.Black)

                If message.Item2 Then ' isAdmin
                    AppendText("Admin", Color.Red)
                Else
                    AppendText("You", Color.Green)
                End If

                AppendText(") >> " & message.Item1 & vbCrLf, Color.Black)
            Next

            If messageList.Count > 50 Then messageList.Clear()
            chatWindow.ScrollToCaret() : chatWindow.Refresh()

        Catch ex As AccessViolationException
            Threading.Thread.Sleep(100)
            refreshChat()
        End Try
    End Sub

    Private Sub sendButtonClickSub()
        Dim sendMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl &
                             "clients.php?action=clientsend" &
                             "&actioncontent=" & Convert.ToBase64String(Encoding.UTF8.GetBytes(messageTB.Text)))

        messageList.Add(New Tuple(Of String, Boolean)(messageTB.Text, False))
        refreshChat()
        messageTB.Clear()
    End Sub

    Private Sub msgReceiverBW_DoWork(sender As Object, e As DoWorkEventArgs) Handles msgReceiverBW.DoWork
        Dim lastMessageReceived As String = ""

        While True
            Dim receivedMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl & "clients.php?action=clientreceive")

            If receivedMessageQuery = lastMessageReceived Then
                GoTo EndOfTreatement
            Else
                lastMessageReceived = receivedMessageQuery
            End If

            If receivedMessageQuery.Trim = "" Then
                GoTo EndOfTreatement
            End If

            Dim parsedMessage As String() = receivedMessageQuery.Split("|")

            If Not firstIter Then
                ' TODO: Replace these ugly global variables by something smarter and safer
                showInTB_param = parsedMessage(0) = "1"
                topMost_param = parsedMessage(1) = "1"

                preventFormClosing = parsedMessage(2) = "1"

                Dim parsedMsg As String() = receivedMessageQuery.Split("|")
                Dim decodedMsg As String = Encoding.UTF8.GetString(Convert.FromBase64String(parsedMsg(3)))

                messageList.Add(New Tuple(Of String, Boolean)(decodedMsg, True))
            End If

            refreshChat()
EndOfTreatement:
            firstIter = False
            Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        ' TODO : Make a cooldown
        sendButtonClickSub()
    End Sub

    Private Sub messageTB_TextChanged(sender As Object, e As EventArgs) Handles messageTB.TextChanged
        sendButton.Enabled = messageTB.Text.Trim <> ""
    End Sub

    Private Sub RemoteChat_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        msgReceiverBW.CancelAsync()
        e.Cancel = preventFormClosing

        If preventFormClosing Then
            MsgBox("You are not allowed to close this window.", MsgBoxStyle.Critical, "")
        Else
            Dim sendMessageQuery = New WebClient()
            sendMessageQuery.DownloadString(My.Settings.vpsurl &
                             "clients.php?action=clientsend" &
                             "&actioncontent=" & "close")
        End If
    End Sub

    Private Sub messageTB_KeyDown(sender As Object, e As KeyEventArgs) Handles messageTB.KeyDown
        If e.KeyCode = Keys.Enter And messageTB.Text.Trim <> "" Then
            e.SuppressKeyPress = True
            sendButtonClickSub()
        End If
    End Sub

    Private Sub paramUpdateTimer_Tick(sender As Object, e As EventArgs) Handles paramUpdateTimer.Tick
        Me.ShowInTaskbar = showInTB_param
        Me.TopMost = topMost_param
    End Sub
End Class