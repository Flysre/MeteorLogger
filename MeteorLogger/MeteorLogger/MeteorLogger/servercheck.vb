Imports System.Text.RegularExpressions
Imports System.Net
Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pattern As String = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
        If Regex.IsMatch(TextBox1.Text, pattern) Then
            Dim client As New WebClient
            Dim result As String = client.DownloadString(TextBox1.Text & "servercheck.php")
            If result = "success" Then MessageBox.Show("Server Configured Proprely.") : ratpannel.Show() : Me.Hide() Else MsgBox(result)
            My.Settings.vpsurl = TextBox1.Text
            My.Settings.Save()
        Else
            MsgBox("Invalid URL.")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.vpsurl = "" Then Return
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        ratpannel.Show()
    End Sub
End Class
