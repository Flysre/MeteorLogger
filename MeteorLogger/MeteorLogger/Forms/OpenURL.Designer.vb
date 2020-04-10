<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenURL
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
        Me.sendBTN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.urlTB = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'sendBTN
        '
        Me.sendBTN.Enabled = False
        Me.sendBTN.Location = New System.Drawing.Point(118, 51)
        Me.sendBTN.Name = "sendBTN"
        Me.sendBTN.Size = New System.Drawing.Size(71, 23)
        Me.sendBTN.TabIndex = 0
        Me.sendBTN.Text = "Send"
        Me.sendBTN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "URL To Open"
        '
        'urlTB
        '
        Me.urlTB.Location = New System.Drawing.Point(15, 25)
        Me.urlTB.Name = "urlTB"
        Me.urlTB.Size = New System.Drawing.Size(275, 20)
        Me.urlTB.TabIndex = 2
        '
        'OpenURL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 84)
        Me.Controls.Add(Me.urlTB)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sendBTN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "OpenURL"
        Me.Text = "Open URL @ "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sendBTN As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents urlTB As TextBox
End Class
