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
        Me.sendButton = New System.Windows.Forms.Button()
        Me.messageTB = New System.Windows.Forms.TextBox()
        Me.chatWindow = New System.Windows.Forms.RichTextBox()
        Me.msgReceiverBW = New System.ComponentModel.BackgroundWorker()
        Me.paramUpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'sendButton
        '
        Me.sendButton.Enabled = False
        Me.sendButton.Location = New System.Drawing.Point(357, 236)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(59, 23)
        Me.sendButton.TabIndex = 6
        Me.sendButton.Text = "Send"
        Me.sendButton.UseVisualStyleBackColor = True
        '
        'messageTB
        '
        Me.messageTB.Location = New System.Drawing.Point(13, 236)
        Me.messageTB.MaxLength = 150
        Me.messageTB.Name = "messageTB"
        Me.messageTB.Size = New System.Drawing.Size(338, 20)
        Me.messageTB.TabIndex = 5
        '
        'chatWindow
        '
        Me.chatWindow.Location = New System.Drawing.Point(12, 8)
        Me.chatWindow.Name = "chatWindow"
        Me.chatWindow.ReadOnly = True
        Me.chatWindow.Size = New System.Drawing.Size(403, 222)
        Me.chatWindow.TabIndex = 4
        Me.chatWindow.Text = ""
        '
        'msgReceiverBW
        '
        Me.msgReceiverBW.WorkerSupportsCancellation = True
        '
        'paramUpdateTimer
        '
        Me.paramUpdateTimer.Enabled = True
        '
        'RemoteChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 280)
        Me.Controls.Add(Me.sendButton)
        Me.Controls.Add(Me.messageTB)
        Me.Controls.Add(Me.chatWindow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RemoteChat"
        Me.Text = "Someone is chatting with you..."
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sendButton As Button
    Friend WithEvents messageTB As TextBox
    Friend WithEvents chatWindow As RichTextBox
    Friend WithEvents msgReceiverBW As System.ComponentModel.BackgroundWorker
    Friend WithEvents paramUpdateTimer As Timer
End Class
