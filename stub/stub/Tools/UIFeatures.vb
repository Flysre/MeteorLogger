Module UIFeatures
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As UInt32, ByVal hwndCallback As IntPtr) As UInt32

#Region "MCI"

    Private Sub CDOpenThread(amount As Integer)
        For i = 1 To amount
            Try
                mciSendString("set cdaudio door open", 0, 0, 0)
                mciSendString("set cdaudio door closed", 0, 0, 0)
            Catch ex As Exception
                Exit For
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Opens the CD (x amount of times) using the Media Control Interface
    ''' </summary>
    ''' <param name="amount"></param>
    Public Sub LoopOpenCD(amount As Integer)
        ' TODO : Too slow. Very big interval between MCI requests.
        Dim mciLoopThread As New Threading.Thread(Sub() CDOpenThread(amount))
        mciLoopThread.Start()
    End Sub

#End Region
End Module
