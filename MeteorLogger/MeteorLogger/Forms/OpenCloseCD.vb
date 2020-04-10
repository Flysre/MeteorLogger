Imports System.Net

Public Class OpenCloseCD
    Public targetIp As String
    Private Sub OpenCloseCD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Open Close CD @" & targetIp
    End Sub
    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=cdopen&actioncontent=" & repeatAmountNUD.Text)

        Dim separateThreadMsg As New _
            Threading.Thread(Sub() MsgBox("Request successfully sent to " & targetIp & ".", MsgBoxStyle.Information))
        separateThreadMsg.Start()

        sendButton.Text = "Sending..." : sendButton.Enabled = False
        Utils.ResponsiveSleep(repeatAmountNUD.Value * 6000)
        sendButton.Enabled = True : sendButton.Text = "Send"
    End Sub
End Class