<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoteDownload
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
        Me.components = New System.ComponentModel.Container()
        Me.FilePathTB = New System.Windows.Forms.TextBox()
        Me.BrowseBTN = New System.Windows.Forms.Button()
        Me.ChangeFileNameCB = New System.Windows.Forms.CheckBox()
        Me.UploadBTN = New System.Windows.Forms.Button()
        Me.Upload_BTN_Availability_TM = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'FilePathTB
        '
        Me.FilePathTB.Location = New System.Drawing.Point(8, 6)
        Me.FilePathTB.Name = "FilePathTB"
        Me.FilePathTB.Size = New System.Drawing.Size(448, 20)
        Me.FilePathTB.TabIndex = 1
        '
        'BrowseBTN
        '
        Me.BrowseBTN.Location = New System.Drawing.Point(462, 6)
        Me.BrowseBTN.Name = "BrowseBTN"
        Me.BrowseBTN.Size = New System.Drawing.Size(75, 23)
        Me.BrowseBTN.TabIndex = 2
        Me.BrowseBTN.Text = "Browse"
        Me.BrowseBTN.UseVisualStyleBackColor = True
        '
        'ChangeFileNameCB
        '
        Me.ChangeFileNameCB.AutoSize = True
        Me.ChangeFileNameCB.Location = New System.Drawing.Point(117, 37)
        Me.ChangeFileNameCB.Name = "ChangeFileNameCB"
        Me.ChangeFileNameCB.Size = New System.Drawing.Size(169, 17)
        Me.ChangeFileNameCB.TabIndex = 3
        Me.ChangeFileNameCB.Text = "Change file name at execution"
        Me.ChangeFileNameCB.UseVisualStyleBackColor = True
        '
        'UploadBTN
        '
        Me.UploadBTN.Enabled = False
        Me.UploadBTN.Location = New System.Drawing.Point(8, 33)
        Me.UploadBTN.Name = "UploadBTN"
        Me.UploadBTN.Size = New System.Drawing.Size(103, 23)
        Me.UploadBTN.TabIndex = 4
        Me.UploadBTN.Text = "Upload"
        Me.UploadBTN.UseVisualStyleBackColor = True
        '
        'Upload_BTN_Availability_TM
        '
        Me.Upload_BTN_Availability_TM.Enabled = True
        '
        'RemoteDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 62)
        Me.Controls.Add(Me.UploadBTN)
        Me.Controls.Add(Me.ChangeFileNameCB)
        Me.Controls.Add(Me.BrowseBTN)
        Me.Controls.Add(Me.FilePathTB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "RemoteDownload"
        Me.Text = "Remote Execute @ "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FilePathTB As TextBox
    Friend WithEvents BrowseBTN As Button
    Friend WithEvents ChangeFileNameCB As CheckBox
    Friend WithEvents UploadBTN As Button
    Friend WithEvents Upload_BTN_Availability_TM As Timer
End Class
