Imports System.Text.RegularExpressions
Imports System.Net
Class ServerCheck
    Public isReinit As Boolean = False
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If My.Settings.vpsurl.Length = 0 Then Return
        'Me.Opacity = 0
        'Me.ShowInTaskbar = False
        'RatPanel.Show()

        If My.Settings.vpsurl.Length > 0 And Not isReinit Then
            RatPanel.Show()
            Me.Opacity = 0 : Me.ShowInTaskbar = False
        End If
    End Sub

    Public Sub DisplayServerError(ex As Exception)
        Dim errMessage = MsgBox("Unable to connect to the FTP server." & vbCrLf &
       "Details: " & ex.Message & vbCrLf &
       "FTP: " & My.Settings.vpsurl & vbCrLf & vbCrLf &
        "Do you want to modify it ?", MsgBoxStyle.YesNo)

        If errMessage = MsgBoxResult.Yes Then
            My.Settings.Reset()
            isReinit = True
        Else
            End
        End If
    End Sub

    Private Sub LaunchCheckBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchCheckBTN.Click
        Dim pattern As String = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"

        If Regex.IsMatch(TextBox1.Text, pattern) Then
            Dim client As New WebClient
            Dim result As String = client.DownloadString(TextBox1.Text & "servercheck.php")

            If result <> "success" Then
                MsgBox(result)
                Exit Sub
            End If

            My.Settings.vpsurl = TextBox1.Text.Trim
            My.Settings.Save()
        Else
            MsgBox("Invalid URL.")
        End If

        MsgBox("Server successfully configured", MsgBoxStyle.Information)

        My.Settings.Reload()
        RatPanel.Show()
        Me.Hide()
    End Sub
End Class
