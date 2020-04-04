Public Class SmartFiles
    Public targetIp As String
    Private Sub SmartFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Smart File Stealer @ " & targetIp
    End Sub
End Class