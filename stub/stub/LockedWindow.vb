Public Class LockedWindow
    Private Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As IntPtr)
    Public Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    Public Const MOUSEEVENTF_LEFTUP = &H4 ' left button up

    Private Sub LockedWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.TopMost = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim xPos As Integer = (My.Computer.Screen.Bounds.Size.Width / 100)
        Dim yPos As Integer = (My.Computer.Screen.Bounds.Size.Height / 100)
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) : mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        Cursor.Position = New Point(xPos, yPos)
        Shell("shutdown /a")
        Threading.Thread.Sleep(50)
    End Sub

    Private Sub LockedWindow_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        BackgroundWorker1.CancelAsync()
    End Sub
End Class