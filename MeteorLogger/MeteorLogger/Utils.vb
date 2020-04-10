Imports System.IO
Imports System.Threading

Module Utils
    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer) ' by user408874 from stackoverflow
        Dim halfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To halfSeconds
            Thread.Sleep(500)
            Application.DoEvents()
        Next
    End Sub

    Public Function RandomString(length As Integer) As String
        If length > 11 Then Throw New ArgumentException("Argument value bigger than 11", "length")
        Return Path.GetRandomFileName().Split(".")(0).Substring(0, length)
    End Function
End Module
