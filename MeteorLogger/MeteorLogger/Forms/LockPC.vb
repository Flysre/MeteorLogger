Imports System.Net

Public Class LockPC
    Public targetIp
    Private Sub LockPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Lock PC @ " & targetIp
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=lockuser")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=unlockuser")

    End Sub
End Class