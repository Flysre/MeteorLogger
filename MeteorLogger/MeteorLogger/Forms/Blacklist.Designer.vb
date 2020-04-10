<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Blacklist
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.startupMsgCB = New System.Windows.Forms.CheckBox()
        Me.startupMsgTB = New System.Windows.Forms.TextBox()
        Me.blacklistBTN = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Blacklist user"
        '
        'startupMsgCB
        '
        Me.startupMsgCB.AutoSize = True
        Me.startupMsgCB.Location = New System.Drawing.Point(15, 25)
        Me.startupMsgCB.Name = "startupMsgCB"
        Me.startupMsgCB.Size = New System.Drawing.Size(168, 17)
        Me.startupMsgCB.TabIndex = 1
        Me.startupMsgCB.Text = "Message On Software Startup"
        Me.startupMsgCB.UseVisualStyleBackColor = True
        '
        'startupMsgTB
        '
        Me.startupMsgTB.Enabled = False
        Me.startupMsgTB.Location = New System.Drawing.Point(15, 42)
        Me.startupMsgTB.Multiline = True
        Me.startupMsgTB.Name = "startupMsgTB"
        Me.startupMsgTB.Size = New System.Drawing.Size(300, 51)
        Me.startupMsgTB.TabIndex = 2
        '
        'blacklistBTN
        '
        Me.blacklistBTN.Location = New System.Drawing.Point(15, 100)
        Me.blacklistBTN.Name = "blacklistBTN"
        Me.blacklistBTN.Size = New System.Drawing.Size(157, 23)
        Me.blacklistBTN.TabIndex = 3
        Me.blacklistBTN.Text = "Permanently Blacklist User"
        Me.blacklistBTN.UseVisualStyleBackColor = True
        '
        'Blacklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 135)
        Me.Controls.Add(Me.blacklistBTN)
        Me.Controls.Add(Me.startupMsgTB)
        Me.Controls.Add(Me.startupMsgCB)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Blacklist"
        Me.Text = "Victim Blacklist @ "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents startupMsgCB As CheckBox
    Friend WithEvents startupMsgTB As TextBox
    Friend WithEvents blacklistBTN As Button
End Class
