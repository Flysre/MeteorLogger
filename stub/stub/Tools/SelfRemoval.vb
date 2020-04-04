Module SelfRemoval
    Public Sub KillStub()
        ' TODO : Kill threads properly
        Environment.Exit(0)
    End Sub

    Public Sub RebootStub()
        Process.Start(Application.ExecutablePath)
        KillStub()
    End Sub
    Public Sub UninstallRAT()
        Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 1 & Del " + Application.ExecutablePath)
        KillStub()
    End Sub

    Public Sub BlacklistClient(message As String)
        My.Settings.bl = True
        My.Settings.blmsg = message ' <-- TODO: Is the blacklist message really useful ?
        My.Settings.Save()
        KillStub()
    End Sub

End Module
