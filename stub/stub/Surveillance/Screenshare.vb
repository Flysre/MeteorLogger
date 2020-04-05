Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.InteropServices
Imports System.Threading


Module Screenshare
    Private Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As IntPtr)

    Private m_MyForm As MainForm
    Public ReadOnly Property MyForm() As MainForm
        Get
            If IsNothing(m_MyForm) Then m_MyForm = New MainForm
            Return m_MyForm
        End Get
    End Property

    Private Structure PointAPI
        Public x As Integer
        Public y As Integer
    End Structure
    Private Structure CursorInfo
        Public cbSize As Integer
        Public flags As Integer
        Public hCursor As IntPtr
        Public ptScreenPos As PointAPI
    End Structure

    Private Declare Function GetCursorInfo Lib "user32.dll" (<System.Runtime.InteropServices.OutAttribute()> ByRef pci As CursorInfo) As Boolean
    Private Declare Function DrawIcon Lib "user32.dll" (hDC As IntPtr, X As Integer, Y As Integer, hIcon As IntPtr) As Boolean
    Private Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    Private Const MOUSEEVENTF_LEFTUP = &H4 ' left button up
    Private Const MOUSEEVENTF_MIDDLEDOWN = &H20 ' middle button down
    Private Const MOUSEEVENTF_MIDDLEUP = &H40 ' middle button up
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8 ' right button down
    Private Const MOUSEEVENTF_RIGHTUP = &H10 ' right button up

    Private WithEvents screenshareBW As New BackgroundWorker
    Private screenshareQuality As Long = 25L
    Private screenshareFluxInterval As Integer = 500
    Private transmissionAllowed As Boolean = True

    Public Sub SetupFluxManager(quality As Long, fluxInterval As Integer)
        If Not screenshareBW.WorkerSupportsCancellation Then  ' TODO: Any better way ?
            screenshareBW.WorkerSupportsCancellation = True
        End If

        screenshareQuality = quality
        screenshareFluxInterval = fluxInterval

        If Not screenshareBW.IsBusy Then
            transmissionAllowed = True
            Screenshare.screenshareBW.RunWorkerAsync()
        End If
    End Sub

    Public Sub StopScreenshare()
        transmissionAllowed = False
        If screenshareBW.WorkerSupportsCancellation Then
            screenshareBW.CancelAsync()
        End If
    End Sub

    Public Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length - 1
            If encoders(j).MimeType = mimeType Then Return encoders(j)
        Next
        Return Nothing
    End Function

    Public Function TakeBitmapScreenshot() As Bitmap
        Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
        Try
            Dim bitmap As Bitmap = New Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppPArgb)
            Dim graphics As Graphics = Graphics.FromImage(bitmap)
            graphics.CopyFromScreen(0, 0, 0, 0, New Size(bitmap.Width, bitmap.Height), CopyPixelOperation.SourceCopy)

            ' Draw cursor
            Dim cursorInfo As CursorInfo : cursorInfo.cbSize = Marshal.SizeOf(GetType(CursorInfo))
            If GetCursorInfo(cursorInfo) AndAlso cursorInfo.flags = 1 Then
                DrawIcon(graphics.GetHdc(), cursorInfo.ptScreenPos.x, cursorInfo.ptScreenPos.y, cursorInfo.hCursor)
                graphics.ReleaseHdc()
            End If

            graphics.Dispose()
            Return bitmap
        Catch
            Return New Bitmap(bounds.Width, bounds.Height)
        End Try
    End Function
    Public Function ResizeConvertBMP(bitmapData As Bitmap, imgQuality As Long) As Byte()
        Dim myEncoderParameters = New EncoderParameters(1)
        myEncoderParameters.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, imgQuality)

        Dim MS As MemoryStream = New MemoryStream()
        Dim resizedBmp = New Bitmap(bitmapData, New Size(1600, 1050))
        resizedBmp.Save(MS, GetEncoderInfo("image/jpeg"), myEncoderParameters)

        Dim bmpBytes As Byte() = MS.GetBuffer()
        bitmapData.Dispose()
        MS.Close()

        Return bmpBytes
    End Function

    Function DeflateCompress(ByVal toCompress As Byte()) As Byte()
        Using outputStream As MemoryStream = New MemoryStream()

            Using compressionStream As DeflateStream =
                New DeflateStream(outputStream, CompressionMode.Compress)
                compressionStream.Write(toCompress, 0, toCompress.Length)
            End Using
            Return outputStream.ToArray()
        End Using
    End Function

    Private Sub screenshareBW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles screenshareBW.DoWork
        While transmissionAllowed
            Dim startTime = DateTime.Now

            MainForm.mainWebClient.UploadData(My.Settings.vpsurl & "clients.php?action=uploadimage",
                                              DeflateCompress(ResizeConvertBMP(TakeBitmapScreenshot(), screenshareQuality)))

            Dim cords As String() =
                MainForm.mainWebClient.DownloadString(My.Settings.vpsurl & "clients.php?action=getcords").Split("|")

            If cords.Length > 1 Then
                Cursor.Position = New Point(
                    (Convert.ToInt32(cords(0)) / 100) * My.Computer.Screen.Bounds.Size.Width, ' x position
                    (Convert.ToInt32(cords(1)) / 100) * My.Computer.Screen.Bounds.Size.Height ' y position
                )

                Select Case cords(2)
                    Case "1"
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) : mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                    Case "2"
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) : mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                        Thread.Sleep(20)
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) : mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                    Case "3"
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0) : mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
                End Select
            End If

            If screenshareFluxInterval > 100 Then
                Dim msTimeout As Integer =
                    screenshareFluxInterval - Date.Now.Subtract(startTime).TotalMilliseconds

                If msTimeout < 1 Then
                    GC.Collect()
                Else
                    Thread.Sleep(msTimeout)
                End If
            End If
        End While
    End Sub
End Module
