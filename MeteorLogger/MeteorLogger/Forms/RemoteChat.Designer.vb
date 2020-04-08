<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RemoteChat
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.chatWindow = New System.Windows.Forms.RichTextBox()
        Me.messageTB = New System.Windows.Forms.TextBox()
        Me.sendButton = New System.Windows.Forms.Button()
        Me.topMostCB = New System.Windows.Forms.CheckBox()
        Me.showIconCB = New System.Windows.Forms.CheckBox()
        Me.allowCloseChatCB = New System.Windows.Forms.CheckBox()
        Me.chatFluxManager = New System.ComponentModel.BackgroundWorker()
        Me.cooldownTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'chatWindow
        '
        Me.chatWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chatWindow.Location = New System.Drawing.Point(12, 12)
        Me.chatWindow.Name = "chatWindow"
        Me.chatWindow.ReadOnly = True
        Me.chatWindow.Size = New System.Drawing.Size(420, 222)
        Me.chatWindow.TabIndex = 0
        Me.chatWindow.Text = ""
        '
        'messageTB
        '
        Me.messageTB.Location = New System.Drawing.Point(12, 240)
        Me.messageTB.MaxLength = 150
        Me.messageTB.Name = "messageTB"
        Me.messageTB.Size = New System.Drawing.Size(355, 20)
        Me.messageTB.TabIndex = 1
        '
        'sendButton
        '
        Me.sendButton.Enabled = False
        Me.sendButton.Location = New System.Drawing.Point(373, 240)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(59, 23)
        Me.sendButton.TabIndex = 2
        Me.sendButton.Text = "Send"
        Me.sendButton.UseVisualStyleBackColor = True
        '
        'topMostCB
        '
        Me.topMostCB.AutoSize = True
        Me.topMostCB.Checked = True
        Me.topMostCB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.topMostCB.Location = New System.Drawing.Point(163, 290)
        Me.topMostCB.Name = "topMostCB"
        Me.topMostCB.Size = New System.Drawing.Size(92, 17)
        Me.topMostCB.TabIndex = 13
        Me.topMostCB.Text = "Always on top"
        Me.topMostCB.UseVisualStyleBackColor = True
        '
        'showIconCB
        '
        Me.showIconCB.AutoSize = True
        Me.showIconCB.Location = New System.Drawing.Point(12, 266)
        Me.showIconCB.Name = "showIconCB"
        Me.showIconCB.Size = New System.Drawing.Size(125, 17)
        Me.showIconCB.TabIndex = 12
        Me.showIconCB.Text = "Show icon in taskbar"
        Me.showIconCB.UseVisualStyleBackColor = True
        '
        'allowCloseChatCB
        '
        Me.allowCloseChatCB.AutoSize = True
        Me.allowCloseChatCB.Location = New System.Drawing.Point(163, 266)
        Me.allowCloseChatCB.Name = "allowCloseChatCB"
        Me.allowCloseChatCB.Size = New System.Drawing.Size(176, 17)
        Me.allowCloseChatCB.TabIndex = 11
        Me.allowCloseChatCB.Text = "Prevent victim from closing chat"
        Me.allowCloseChatCB.UseVisualStyleBackColor = True
        '
        'cooldownTimer
        '
        Me.cooldownTimer.Enabled = True
        '
        'RemoteChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 314)
        Me.Controls.Add(Me.topMostCB)
        Me.Controls.Add(Me.showIconCB)
        Me.Controls.Add(Me.allowCloseChatCB)
        Me.Controls.Add(Me.sendButton)
        Me.Controls.Add(Me.messageTB)
        Me.Controls.Add(Me.chatWindow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "RemoteChat"
        Me.ShowIcon = False
        Me.Text = "Remote Chat @ "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chatWindow As RichTextBox
    Friend WithEvents messageTB As TextBox
    Friend WithEvents sendButton As Button
    Friend WithEvents topMostCB As CheckBox
    Friend WithEvents showIconCB As CheckBox
    Friend WithEvents allowCloseChatCB As CheckBox
    Friend WithEvents chatFluxManager As System.ComponentModel.BackgroundWorker
    Friend WithEvents cooldownTimer As Timer
End Class
