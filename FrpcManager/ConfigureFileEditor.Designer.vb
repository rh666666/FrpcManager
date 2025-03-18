<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigureFileEditor
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        userName = New TextBox()
        serverAddr = New TextBox()
        localIP = New TextBox()
        serverPort = New NumericUpDown()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        localPort = New NumericUpDown()
        Label6 = New Label()
        Label7 = New Label()
        remoteAddr = New TextBox()
        Label8 = New Label()
        remotePort = New NumericUpDown()
        save = New Button()
        cancel = New Button()
        fileName = New TextBox()
        Label9 = New Label()
        CType(serverPort, ComponentModel.ISupportInitialize).BeginInit()
        CType(localPort, ComponentModel.ISupportInitialize).BeginInit()
        CType(remotePort, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' userName
        ' 
        userName.Location = New Point(72, 25)
        userName.Name = "userName"
        userName.Size = New Size(125, 27)
        userName.TabIndex = 0
        ' 
        ' serverAddr
        ' 
        serverAddr.Location = New Point(72, 75)
        serverAddr.Name = "serverAddr"
        serverAddr.Size = New Size(141, 27)
        serverAddr.TabIndex = 1
        ' 
        ' localIP
        ' 
        localIP.Location = New Point(72, 127)
        localIP.Name = "localIP"
        localIP.Size = New Size(141, 27)
        localIP.TabIndex = 3
        localIP.Text = "127.0.0.1"
        ' 
        ' serverPort
        ' 
        serverPort.Location = New Point(264, 75)
        serverPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        serverPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        serverPort.Name = "serverPort"
        serverPort.Size = New Size(71, 27)
        serverPort.TabIndex = 5
        serverPort.Value = New Decimal(New Integer() {7000, 0, 0, 0})
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 20)
        Label1.TabIndex = 6
        Label1.Text = "用户名"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(2, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 20)
        Label2.TabIndex = 7
        Label2.Text = "服务器IP"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(14, 129)
        Label3.Name = "Label3"
        Label3.Size = New Size(52, 20)
        Label3.TabIndex = 8
        Label3.Text = "本地IP"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(219, 77)
        Label4.Name = "Label4"
        Label4.Size = New Size(39, 20)
        Label4.TabIndex = 9
        Label4.Text = "端口"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(219, 129)
        Label5.Name = "Label5"
        Label5.Size = New Size(39, 20)
        Label5.TabIndex = 10
        Label5.Text = "端口"
        ' 
        ' localPort
        ' 
        localPort.Location = New Point(264, 127)
        localPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        localPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        localPort.Name = "localPort"
        localPort.Size = New Size(71, 27)
        localPort.TabIndex = 11
        localPort.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(365, 130)
        Label6.Name = "Label6"
        Label6.Size = New Size(26, 20)
        Label6.TabIndex = 12
        Label6.Text = "->"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(409, 130)
        Label7.Name = "Label7"
        Label7.Size = New Size(52, 20)
        Label7.TabIndex = 13
        Label7.Text = "远程IP"
        ' 
        ' remoteAddr
        ' 
        remoteAddr.Location = New Point(467, 127)
        remoteAddr.Name = "remoteAddr"
        remoteAddr.ReadOnly = True
        remoteAddr.Size = New Size(141, 27)
        remoteAddr.TabIndex = 15
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(614, 130)
        Label8.Name = "Label8"
        Label8.Size = New Size(39, 20)
        Label8.TabIndex = 16
        Label8.Text = "端口"
        ' 
        ' remotePort
        ' 
        remotePort.Location = New Point(659, 127)
        remotePort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        remotePort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        remotePort.Name = "remotePort"
        remotePort.Size = New Size(71, 27)
        remotePort.TabIndex = 17
        remotePort.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' save
        ' 
        save.Location = New Point(44, 234)
        save.Name = "save"
        save.Size = New Size(94, 29)
        save.TabIndex = 18
        save.Text = "保存"
        save.UseVisualStyleBackColor = True
        ' 
        ' cancel
        ' 
        cancel.Location = New Point(164, 234)
        cancel.Name = "cancel"
        cancel.Size = New Size(94, 29)
        cancel.TabIndex = 19
        cancel.Text = "取消"
        cancel.UseVisualStyleBackColor = True
        ' 
        ' fileName
        ' 
        fileName.Location = New Point(307, -1)
        fileName.Name = "fileName"
        fileName.Size = New Size(125, 27)
        fileName.TabIndex = 20
        fileName.Text = "新配置"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(241, 2)
        Label9.Name = "Label9"
        Label9.Size = New Size(69, 20)
        Label9.TabIndex = 21
        Label9.Text = "配置名称"
        ' 
        ' ConfigureFileEditor
        ' 
        AutoScaleDimensions = New SizeF(9.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label9)
        Controls.Add(fileName)
        Controls.Add(cancel)
        Controls.Add(save)
        Controls.Add(remotePort)
        Controls.Add(Label8)
        Controls.Add(remoteAddr)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(localPort)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(serverPort)
        Controls.Add(localIP)
        Controls.Add(serverAddr)
        Controls.Add(userName)
        Name = "ConfigureFileEditor"
        Text = "ConfigureFileEditor"
        CType(serverPort, ComponentModel.ISupportInitialize).EndInit()
        CType(localPort, ComponentModel.ISupportInitialize).EndInit()
        CType(remotePort, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents userName As TextBox
    Friend WithEvents serverAddr As TextBox
    Friend WithEvents localIP As TextBox
    Friend WithEvents serverPort As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents localPort As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents remoteAddr As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents remotePort As NumericUpDown
    Friend WithEvents save As Button
    Friend WithEvents cancel As Button
    Friend WithEvents fileName As TextBox
    Friend WithEvents Label9 As Label
End Class
