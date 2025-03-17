Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ' 遍历 tomlFiles 数组
        For Each tomlFile As String In tomlFiles
            ' 获取文件名
            Dim fileName As String = Path.GetFileNameWithoutExtension(tomlFile)
            ' 将文件名添加到 ComboBox1 的 Items
            ComboBox1.Items.Add(fileName)
        Next
    End Sub
End Class