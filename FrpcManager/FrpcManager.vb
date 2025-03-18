Imports System.IO
Imports System.Threading

Public Class FrpcManager
    Private frpcProcess As Process
    ' 处理窗口加载事件
    Private Sub FrpcManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 定义窗口名称
        Me.Text = "FrpcManager"
        ' 获取当前程序的目录
        Dim currentDirectory As String = Application.StartupPath
        ' 拼接 config 文件夹的路径
        Dim configDirectoryPath As String = Path.Combine(currentDirectory, "config")
        ' 拼接 frp 文件夹的路径
        Dim frpDirectoryPath As String = Path.Combine(currentDirectory, "frp")
        ' 拼接 frpc.exe 文件的完整路径
        Dim frpcExePath As String = Path.Combine(frpDirectoryPath, "frpc.exe")

        ' 如果不存在 frpc.exe，则输出错误信息并终止程序
        If Not File.Exists(frpcExePath) Then
            MessageBox.Show($"发生错误：{vbCrLf}程序 {frpcExePath} 不存在")
            End
        End If

        ' 检测 config 目录是否存在，不存在则创建
        If Not Directory.Exists(configDirectoryPath) Then
            Try
                Directory.CreateDirectory(configDirectoryPath)
            Catch ex As Exception
                MessageBox.Show($"创建 'config' 文件夹时出错：{ex.Message}")
                End
            End Try
        End If

        ' 查找 config 目录下所有后缀名为 .toml 的文件
        Dim tomlFiles() As String = Directory.GetFiles(configDirectoryPath, "*.toml")

        ' 清空 ComboBox1 的 Items
        ComboBox1.Items.Clear()

        ' 如果存在 frp\frpc.toml，增加第一个选项：默认配置
        Dim defaultTomlPath As String = Path.Combine(frpDirectoryPath, "frpc.toml")
        If File.Exists(defaultTomlPath) Then
            ComboBox1.Items.Add("默认配置")
        End If
        ' 如果 ComboBox1 的 Items 不为空，则默认选中第一项
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If

        ' 遍历 tomlFiles 数组
        For Each tomlFile As String In tomlFiles
            ' 获取文件名
            Dim fileName As String = Path.GetFileNameWithoutExtension(tomlFile)
            ' 将文件名添加到 ComboBox1 的 Items
            ComboBox1.Items.Add(fileName)
        Next

    End Sub

    ' 处理窗口关闭事件
    Private Sub FrpcManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' 如果 frpcProcess 不为空，则关闭进程
        If frpcProcess IsNot Nothing AndAlso Not frpcProcess.HasExited Then
            Dim closeThread As New Thread(Sub()
                                              Try
                                                  ' 停止异步读取输出
                                                  frpcProcess.CancelOutputRead()

                                                  If frpcProcess.CloseMainWindow() Then
                                                      If Not frpcProcess.WaitForExit(5000) Then
                                                          frpcProcess.Kill()
                                                          frpcProcess.WaitForExit()
                                                      End If
                                                  Else
                                                      frpcProcess.Kill()
                                                      frpcProcess.WaitForExit()
                                                  End If
                                              Catch ex As Exception
                                                  MessageBox.Show($"关闭 frpc.exe 时出错：{ex.Message}")
                                              End Try
                                          End Sub)
            closeThread.Start()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 定义启动参数
        Dim currentDirectory As String = Application.StartupPath
        Dim frpExePath As String = Path.Combine(currentDirectory, "frp", "frpc.exe")
        Dim arguments As String

        ' 定义默认配置
        If ComboBox1.Text = "默认配置" Then
            arguments = $"-c {Path.Combine(currentDirectory, "frp", "frpc.toml")}"
        Else
            arguments = $"-c {Path.Combine(currentDirectory, "config", ComboBox1.Text)}.toml"
        End If

        frpcProcess = New Process()
        frpcProcess.StartInfo.FileName = frpExePath
        frpcProcess.StartInfo.Arguments = arguments
        frpcProcess.StartInfo.UseShellExecute = False
        frpcProcess.StartInfo.RedirectStandardOutput = True
        frpcProcess.StartInfo.CreateNoWindow = True
        frpcProcess.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8

        AddHandler frpcProcess.OutputDataReceived, AddressOf process_OutputDataReceived

        Try
            frpcProcess.Start()
            frpcProcess.BeginOutputReadLine()
        Catch ex As Exception
            MessageBox.Show($"启动 frpc.exe 时出错，{ex.Message}")
        End Try
    End Sub

    Private Sub process_OutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then
            If e.Data.Contains("start proxy success") Then
                If Me.InvokeRequired Then
                    Me.Invoke(Sub()
                                  MessageBox.Show("启动成功！")
                              End Sub)
                Else
                    MessageBox.Show("启动成功！")
                End If
            End If

            If Not Me.IsDisposed AndAlso consoleLog.InvokeRequired Then
                consoleLog.Invoke(Sub()
                                      consoleLog.AppendText(e.Data & vbCrLf)
                                  End Sub)
            Else
                consoleLog.AppendText(e.Data & vbCrLf)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim editor As New ConfigureFileEditor With {
            .IsNewFile = True,
            .IsDefaultFile = False
        }
        editor.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim currentDirectory As String = Application.StartupPath
        Dim selectedConfigPath As String
        If ComboBox1.Text = "默认配置" Then
            selectedConfigPath = Path.Combine(currentDirectory, "frp", "frpc.toml")
        Else
            selectedConfigPath = Path.Combine(currentDirectory, "config", ComboBox1.Text & ".toml")
        End If

        Dim editor As New ConfigureFileEditor With {
            .FilePath = selectedConfigPath,
            .IsNewFile = False,
            .IsDefaultFile = False
        }
        If ComboBox1.Text = "默认配置" Then
            editor.IsDefaultFile = True
        End If
        editor.Show()
    End Sub
End Class