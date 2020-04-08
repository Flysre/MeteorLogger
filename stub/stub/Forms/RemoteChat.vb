Imports System.ComponentModel
Imports System.Net
Imports System.Text
Public Class RemoteChat
    Dim preventFormClosing As Boolean = False
    Dim firstIter As Boolean = True
    Dim messageList As New List(Of Tuple(Of String, Boolean)) ' Respectively : message and isAdmin
    Dim sendMessageAllowed As Boolean = True

    Dim showInTB_param As Boolean = True
    Dim topMost_param As Boolean = True

    Private m_MyForm As MainForm
    Public ReadOnly Property MyForm() As MainForm
        Get
            If IsNothing(m_MyForm) Then m_MyForm = New MainForm
            Return m_MyForm
        End Get
    End Property

    Public Sub StartProcessingMessages()
        Control.CheckForIllegalCrossThreadCalls = False
        msgReceiverBW.RunWorkerAsync()
        paramUpdateTimer.Start()
        cooldownTimer.Start()
    End Sub

    Private Sub RemoteChat_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = preventFormClosing

        If preventFormClosing Then
            Dim myThread As New Threading.Thread(Sub() MsgBox("You are not allowed to close this window.", MsgBoxStyle.Critical, ""))
            myThread.Start()
            Exit Sub
        End If

        msgReceiverBW.CancelAsync()
        paramUpdateTimer.Stop()
        cooldownTimer.Stop()
    End Sub

    Private Sub RemoteChat_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim sendMessageQuery = New WebClient()
        sendMessageQuery.DownloadString(My.Settings.vpsurl &
                         "clients.php?action=clientsend" &
                         "&actioncontent=" & "close")
    End Sub

    Private Sub RefreshChat()
        Try
            chatWindow.Clear()

            For Each message In messageList
                chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = "("

                If message.Item2 Then ' isAdmin
                    chatWindow.SelectionColor = Color.Red : chatWindow.SelectedText = "Admin"
                Else
                    chatWindow.SelectionColor = Color.Green : chatWindow.SelectedText = "You"
                End If

                chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = ") >> " & message.Item1 & vbCrLf
            Next

            If messageList.Count > 100 Then messageList.Clear()
            chatWindow.ScrollToCaret() : chatWindow.Refresh()
        Catch ex As Exception When TypeOf ex Is AccessViolationException OrElse TypeOf ex Is ObjectDisposedException
            System.Threading.Thread.Sleep(500)
            Console.WriteLine("error")
            RefreshChat()
        End Try
    End Sub

    Private Sub StartCooldown(interval As Integer)
        sendMessageAllowed = False
        Threading.Thread.Sleep(interval)
        Invoke(Sub() messageTB.Clear())
        sendMessageAllowed = True
    End Sub

    Private Sub SendButtonClickSub()
        If messageTB.Text.Trim.Length = 0 Or Not sendMessageAllowed Then Exit Sub
        Dim sendMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl &
                             "clients.php?action=clientsend" &
                             "&actioncontent=" & Convert.ToBase64String(Encoding.UTF8.GetBytes(messageTB.Text)))

        messageList.Add(New Tuple(Of String, Boolean)(messageTB.Text, False))
        RefreshChat()
        messageTB.Clear()

        Dim cooldownThread As New Threading.Thread(Sub() StartCooldown(1000))
        cooldownThread.Start()
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

    Dim removeCooldownMsg As Boolean = False
    Private Sub cooldownTimer_Tick(sender As Object, e As EventArgs) Handles cooldownTimer.Tick
        If Not sendMessageAllowed Then
            sendButton.Enabled = False
            messageTB.ForeColor = Color.Gray
            messageTB.Text = "Cooldown..."
            messageTB.ReadOnly = True
            removeCooldownMsg = True

        ElseIf removeCooldownMsg Then
            removeCooldownMsg = False
            messageTB.ReadOnly = False
            messageTB.ForeColor = Color.Black
            sendButton.Enabled = True
        End If
    End Sub
End Class