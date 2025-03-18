Imports Tomlyn
Imports System.IO

Public Class ConfigureFileEditor
    Private configPath As String
    Private isNew As Boolean
    Private isDefault As Boolean
    Private configData As Object
    Public Event ConfigurationSaved()

    ' 添加新文件判断属性
    Public Property IsNewFile As Boolean
        Get
            Return isNew
        End Get
        Set(value As Boolean)
            isNew = value
        End Set
    End Property

    ' 添加默认文件判断属性
    Public Property IsDefaultFile As Boolean
        Get
            Return IsDefault
        End Get
        Set(value As Boolean)
            isDefault = value
        End Set
    End Property

    ' 添加文件路径属性
    Public Property FilePath As String
        Get
            Return configPath
        End Get
        Set(value As String)
            configPath = value
            LoadConfiguration()
        End Set
    End Property

    Private Sub LoadConfiguration()
        If File.Exists(configPath) Then
            Try
                Dim tomlContent = File.ReadAllText(configPath)
                configData = Toml.ToModel(tomlContent)

                ' 读取服务器配置
                serverAddr.Text = configData("serverAddr").ToString()
                serverPort.Value = Decimal.Parse(configData("serverPort").ToString())

                ' 读取代理配置（第一个代理）
                Dim proxiesArray = TryCast(configData("proxies"), Tomlyn.Model.TomlTableArray)
                If proxiesArray IsNot Nothing AndAlso proxiesArray.Count > 0 Then
                    Dim firstProxyTable = proxiesArray(0)
                    If firstProxyTable.ContainsKey("name") Then
                        userName.Text = firstProxyTable("name").ToString()
                    End If
                    If firstProxyTable.ContainsKey("localIP") Then
                        localIP.Text = firstProxyTable("localIP").ToString()
                    End If
                    If firstProxyTable.ContainsKey("localPort") Then
                        localPort.Value = Decimal.Parse(firstProxyTable("localPort").ToString())
                    End If
                    If firstProxyTable.ContainsKey("remotePort") Then
                        remotePort.Value = Decimal.Parse(firstProxyTable("remotePort").ToString())
                    End If
                    remoteAddr.Text = serverAddr.Text
                Else
                    MessageBox.Show("未找到有效的代理配置。")
                End If

                ' 显示配置文件名称
                fileName.Text = Path.GetFileNameWithoutExtension(configPath)
                If Not isNew Then
                    fileName.ReadOnly = True
                End If
            Catch ex As Exception
                MessageBox.Show($"加载配置文件时出错：{ex.Message}")
            End Try
        End If
    End Sub

    Public Sub SaveConfiguration()
        Dim currentDirectory = Path.GetDirectoryName(Application.ExecutablePath)
        Dim configDirectory = Path.Combine(currentDirectory, "config")
        If Not Directory.Exists(configDirectory) Then
            Directory.CreateDirectory(configDirectory)
        End If
        Dim proxyData As New Dictionary(Of String, Object) From {
            {"name", userName.Text},
            {"type", "tcp"},
            {"localIP", localIP.Text},
            {"localPort", CInt(localPort.Value)},
            {"remotePort", CInt(remotePort.Value)}
        }

        configData = New Dictionary(Of String, Object) From {
            {"serverAddr", serverAddr.Text},
            {"serverPort", CInt(serverPort.Value)},
            {"proxies", New List(Of Object) From {proxyData}}
        }

        Dim tomlContent = Toml.FromModel(configData)
        If isNew Then
            If fileName.Text = "" Then
                MessageBox.Show("文件名不能为空！")
                Exit Sub
            ElseIf fileName.Text = "默认配置" Then
                MessageBox.Show("你起这个名字有意义吗？")
                Exit Sub
            End If

            Dim newConfigPath = Path.Combine(configDirectory, fileName.Text & ".toml")

            If File.Exists(newConfigPath) Then
                MessageBox.Show($"保存失败， 配置'{fileName.Text}'已存在")
                Exit Sub
            End If
            File.WriteAllText(newConfigPath, tomlContent)
        Else
            File.WriteAllText(configPath, tomlContent)
        End If

        MessageBox.Show("保存成功")
        ' 保存成功提示之后触发事件
        RaiseEvent ConfigurationSaved()
        Me.Close()
    End Sub

    Private Sub serverAddr_TextChanged(sender As Object, e As EventArgs) Handles serverAddr.TextChanged
        remoteAddr.Text = serverAddr.Text
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        SaveConfiguration()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        Me.Close()
    End Sub
End Class