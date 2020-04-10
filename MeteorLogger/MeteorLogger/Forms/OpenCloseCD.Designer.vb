<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenCloseCD
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
        Me.sendButton = New System.Windows.Forms.Button()
        Me.repeatAmountNUD = New System.Windows.Forms.NumericUpDown()
        Me.ActionPB = New System.Windows.Forms.ProgressBar()
        CType(Me.repeatAmountNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Repeat amount : "
        '
        'sendButton
        '
        Me.sendButton.Location = New System.Drawing.Point(231, 9)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(159, 20)
        Me.sendButton.TabIndex = 3
        Me.sendButton.Text = "SEND"
        Me.sendButton.UseVisualStyleBackColor = True
        '
        'repeatAmountNUD
        '
        Me.repeatAmountNUD.Location = New System.Drawing.Point(125, 9)
        Me.repeatAmountNUD.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.repeatAmountNUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.repeatAmountNUD.Name = "repeatAmountNUD"
        Me.repeatAmountNUD.Size = New System.Drawing.Size(88, 20)
        Me.repeatAmountNUD.TabIndex = 4
        Me.repeatAmountNUD.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ActionPB
        '
        Me.ActionPB.Location = New System.Drawing.Point(15, 35)
        Me.ActionPB.Name = "ActionPB"
        Me.ActionPB.Size = New System.Drawing.Size(375, 10)
        Me.ActionPB.TabIndex = 5
        '
        'OpenCloseCD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 51)
        Me.Controls.Add(Me.ActionPB)
        Me.Controls.Add(Me.repeatAmountNUD)
        Me.Controls.Add(Me.sendButton)
        Me.Controls.Add(Me.Label1)
        Me.Name = "OpenCloseCD"
        Me.Text = "Open Close CD @ "
        CType(Me.repeatAmountNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents sendButton As Button
    Friend WithEvents repeatAmountNUD As NumericUpDown
    Friend WithEvents ActionPB As ProgressBar
End Class
