<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrpcManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        ComboBox1 = New ComboBox()
        Button1 = New Button()
        Button2 = New Button()
        TextBox1 = New TextBox()
        Button3 = New Button()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(84, 87)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(151, 28)
        ComboBox1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(84, 174)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 1
        Button1.Text = "新建配置"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(266, 87)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 2
        Button2.Text = "使用配置"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(431, 87)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        TextBox1.Size = New Size(343, 297)
        TextBox1.TabIndex = 3
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(212, 174)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 29)
        Button3.TabIndex = 4
        Button3.Text = "编辑配置"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' FrpcManager
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(800, 450)
        Controls.Add(Button3)
        Controls.Add(TextBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(ComboBox1)
        Name = "FrpcManager"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button

End Class
