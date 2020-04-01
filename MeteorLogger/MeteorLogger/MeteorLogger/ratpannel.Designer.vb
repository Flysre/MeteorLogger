<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ratpannel
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
        Me.clientlist = New System.ComponentModel.BackgroundWorker()
        Me.clientlist_loop = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.clients_list = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTIVEWINDOW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UPTIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'clientlist
        '
        '
        'clientlist_loop
        '
        Me.clientlist_loop.Interval = 10000
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(733, 330)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(725, 304)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clients"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(725, 304)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Builder"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 332)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(734, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'clients_list
        '
        Me.clients_list.AutoSize = True
        Me.clients_list.Location = New System.Drawing.Point(1, 336)
        Me.clients_list.Name = "clients_list"
        Me.clients_list.Size = New System.Drawing.Size(53, 13)
        Me.clients_list.TabIndex = 4
        Me.clients_list.Text = "Clients : 0"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IP, Me.CPU, Me.RAM, Me.PING, Me.ACTIVEWINDOW, Me.UPTIME})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(719, 298)
        Me.DataGridView1.TabIndex = 0
        '
        'IP
        '
        Me.IP.HeaderText = "IP"
        Me.IP.Name = "IP"
        Me.IP.ReadOnly = True
        Me.IP.Width = 113
        '
        'CPU
        '
        Me.CPU.HeaderText = "CPU"
        Me.CPU.Name = "CPU"
        Me.CPU.ReadOnly = True
        Me.CPU.Width = 113
        '
        'RAM
        '
        Me.RAM.HeaderText = "RAM"
        Me.RAM.Name = "RAM"
        Me.RAM.ReadOnly = True
        Me.RAM.Width = 113
        '
        'PING
        '
        Me.PING.HeaderText = "Ping"
        Me.PING.Name = "PING"
        Me.PING.ReadOnly = True
        Me.PING.Width = 113
        '
        'ACTIVEWINDOW
        '
        Me.ACTIVEWINDOW.HeaderText = "Active Window"
        Me.ACTIVEWINDOW.Name = "ACTIVEWINDOW"
        Me.ACTIVEWINDOW.ReadOnly = True
        Me.ACTIVEWINDOW.Width = 113
        '
        'UPTIME
        '
        Me.UPTIME.HeaderText = "Up-Time"
        Me.UPTIME.Name = "UPTIME"
        Me.UPTIME.ReadOnly = True
        Me.UPTIME.Width = 113
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(643, 278)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "BUILD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ratpannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 354)
        Me.Controls.Add(Me.clients_list)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ratpannel"
        Me.Text = "MeteorLogger - PANNEL"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clientlist As System.ComponentModel.BackgroundWorker
    Friend WithEvents clientlist_loop As System.Windows.Forms.Timer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents clients_list As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PING As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACTIVEWINDOW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UPTIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
