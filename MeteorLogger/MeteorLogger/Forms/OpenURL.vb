Imports System.Net

Public Class OpenURL
    Public targetIp As String
    Private Sub OpenURL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Open URL - " & targetIp
    End Sub

    Private Sub urlTB_TextChanged(sender As Object, e As EventArgs) Handles urlTB.TextChanged
        sendBTN.Enabled = urlTB.Text.Trim <> ""
    End Sub

    Private Sub sendBTN_Click(sender As Object, e As EventArgs) Handles sendBTN.Click
        Dim client As New WebClient
        'client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=openURL&actioncontent=" & urlTB.Text)
        If Utils.DirectPanelCommand(targetIp, New WebClient(), "Are you sure you want to open this url ?", "openURL", {urlTB.Text}) Then
            MsgBox("URL succesfully sent !", MsgBoxStyle.Information)
        End If
    End Sub
End Class