Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 获取当前程序的目录
        Dim currentDirectory As String = Application.StartupPath
        ' 拼接 frp 文件夹的路径
        Dim frpDirectoryPath As String = Path.Combine(currentDirectory, "frp")
        ' 拼接 frpc.exe 文件的完整路径
        Dim frpcExePath As String = Path.Combine(frpDirectoryPath, "frpc.exe")
        ' 不存在 frpc.exe 的错误信息
        Dim errorOfExePath As String = String.Format("发生错误:{0}程序 {1} 不存在", vbCrLf, frpcExePath)

        ' 检测文件是否存在
        If Not File.Exists(frpcExePath) Then
            MessageBox.Show(errorOfExePath)
            End
        End If
    End Sub
End Class