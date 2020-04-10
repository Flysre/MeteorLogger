<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScreenMonitor
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
        Me.Quality = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FPS = New System.Windows.Forms.ComboBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.Render = New System.Windows.Forms.PictureBox()
        Me.screenshotBTN = New System.Windows.Forms.Button()
        Me.WaitForConnectionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.remotecontrol = New System.Windows.Forms.CheckBox()
        CType(Me.Render, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Quality
        '
        Me.Quality.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Quality.FormattingEnabled = True
        Me.Quality.Items.AddRange(New Object() {"LOW", "MEDIUM", "HIGH"})
        Me.Quality.Location = New System.Drawing.Point(4, 336)
        Me.Quality.Name = "Quality"
        Me.Quality.Size = New System.Drawing.Size(70, 21)
        Me.Quality.TabIndex = 0
        Me.Quality.Text = "MEDIUM"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Quality"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FPS"
        '
        'FPS
        '
        Me.FPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FPS.FormattingEnabled = True
        Me.FPS.Items.AddRange(New Object() {"1", "2", "4", "8", "10"})
        Me.FPS.Location = New System.Drawing.Point(76, 337)
        Me.FPS.Name = "FPS"
        Me.FPS.Size = New System.Drawing.Size(36, 21)
        Me.FPS.TabIndex = 3
        Me.FPS.Text = "4"
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Location = New System.Drawing.Point(145, 324)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(100, 34)
        Me.StartButton.TabIndex = 4
        Me.StartButton.Text = "Start Monitoring"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StopButton.Enabled = False
        Me.StopButton.Location = New System.Drawing.Point(251, 324)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(100, 34)
        Me.StopButton.TabIndex = 5
        Me.StopButton.Text = "Stop Monitoring"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'Render
        '
        Me.Render.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Render.BackColor = System.Drawing.Color.Black
        Me.Render.Location = New System.Drawing.Point(4, 4)
        Me.Render.Name = "Render"
        Me.Render.Size = New System.Drawing.Size(646, 314)
        Me.Render.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Render.TabIndex = 6
        Me.Render.TabStop = False
        '
        'screenshotBTN
        '
        Me.screenshotBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.screenshotBTN.Location = New System.Drawing.Point(532, 324)
        Me.screenshotBTN.Name = "screenshotBTN"
        Me.screenshotBTN.Size = New System.Drawing.Size(108, 34)
        Me.screenshotBTN.TabIndex = 7
        Me.screenshotBTN.Text = "Take Screenshot"
        Me.screenshotBTN.UseVisualStyleBackColor = True
        '
        'WaitForConnectionTimer
        '
        Me.WaitForConnectionTimer.Enabled = True
        Me.WaitForConnectionTimer.Interval = 500
        '
        'remotecontrol
        '
        Me.remotecontrol.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.remotecontrol.AutoSize = True
        Me.remotecontrol.Location = New System.Drawing.Point(357, 334)
        Me.remotecontrol.Name = "remotecontrol"
        Me.remotecontrol.Size = New System.Drawing.Size(135, 17)
        Me.remotecontrol.TabIndex = 9
        Me.remotecontrol.Text = "Enable Remote Control"
        Me.remotecontrol.UseVisualStyleBackColor = True
        '
        'ScreenMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 372)
        Me.Controls.Add(Me.remotecontrol)
        Me.Controls.Add(Me.screenshotBTN)
        Me.Controls.Add(Me.Render)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.FPS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Quality)
        Me.Name = "ScreenMonitor"
        Me.Text = "Screen - Monitor @"
        CType(Me.Render, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Quality As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FPS As ComboBox
    Friend WithEvents StartButton As Button
    Friend WithEvents StopButton As Button
    Friend WithEvents Render As PictureBox
    Friend WithEvents screenshotBTN As Button
    Friend WithEvents WaitForConnectionTimer As Timer
    Friend WithEvents remotecontrol As CheckBox
End Class
