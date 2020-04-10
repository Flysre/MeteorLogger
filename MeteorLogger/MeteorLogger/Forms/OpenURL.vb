Imports System.Net

Public Class OpenURL
    Public targetIp As String
    Private Sub OpenURL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Open URL @ " & targetIp
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Enabled = TextBox1.Text.Trim <> ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=openURL&actioncontent=" & TextBox1.Text)
        MsgBox("Succesfully Send !")
    End Sub
End Class