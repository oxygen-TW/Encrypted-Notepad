'-----------------------------
'Encryption Notepad v.3.0.1.4 Alpha
'Copyright(C) 2017-2018, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module language_tools
    Dim LanguageFile As String = "language\"
    Dim Current_Language As String

    Function ReadLanguageConfig(ByVal LanguageType)

        Dim LanguageConfig As String
        LanguageConfig = My.Computer.FileSystem.ReadAllText(LanguageFile + LanguageType,
        encoding:=Text.Encoding.UTF8)


        Dim Language_Json As JObject = JsonConvert.DeserializeObject(LanguageConfig)
        Return Language_Json
    End Function

    Function DefaultLanguage()
        Dim default_Language As String = Nothing
        FileOpen(3, LanguageFile + "default", OpenMode.Input)
        Input(3, default_Language)
        FileClose(3)

        Return default_Language
    End Function

    Sub ChangeLanguage(ByVal language)
        If language <> Current_Language Then
            Try
                Init_Language(ReadLanguageConfig(language))
            Catch ex As Exception
                MessageBox.Show("語言檔讀取錯誤", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Sub Init_Language_Menu()

        Dim LanguageList As String
        LanguageList = My.Computer.FileSystem.ReadAllText(LanguageFile + "Language.list",
        encoding:=Text.Encoding.UTF8)

        '建立已安裝語言檔JSON物件
        Dim List As JObject = JsonConvert.DeserializeObject(LanguageList)

        'WorkSpace.語言.Items.Add(New MyListItem("Text to be displayed", "value of the item"))
    End Sub
    Sub Init_Language(ByVal JsonData As JObject)
        '初始化語言選單(未完成)
        'Call Init_Language_Menu()

        '參數儲存進變數
        Current_Language = JsonData.Item("language").ToString

        'Login介面語言初始化
        login.Text = JsonData.Item("login")("title").ToString
        login.login_buttom.Text = JsonData.Item("login")("confirm").ToString
        login.login_err.Text = JsonData.Item("login")("login-error").ToString
        login.Label_enterpwd.Text = JsonData.Item("login")("enter-password").ToString
        login.PwdReset.Text = JsonData.Item("login")("reset-password").ToString

        'Workspace 語言介面初始化
        WorkSpace.TitleText = JsonData.Item("workspace")("title").ToString
        WorkSpace.Untitle = JsonData.Item("workspace")("untitle").ToString
        WorkSpace.檔案ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("index").ToString
        WorkSpace.開新檔案ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("new-file").ToString
        WorkSpace.開啟舊檔ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("open-file").ToString
        WorkSpace.儲存檔案ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("save-file").ToString
        WorkSpace.另存新檔ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("save-new-file").ToString
        WorkSpace.加密儲存ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("encrypt").ToString
        WorkSpace.解密開啟ToolStripMenuItem.Text = JsonData.Item("workspace")("file")("decrypt").ToString

        WorkSpace.內文ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("index").ToString
        WorkSpace.字型ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("font").ToString
        WorkSpace.顏色ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("color").ToString
        WorkSpace.自動換行ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("auto-NL").ToString
        WorkSpace.時間戳記ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("time").ToString
        WorkSpace.複製ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("copy").ToString
        WorkSpace.貼上ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("paste").ToString
        WorkSpace.全選ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("select-all").ToString
        WorkSpace.清除ToolStripMenuItem.Text = JsonData.Item("workspace")("text")("clean").ToString

        WorkSpace.鎖定ToolStripMenuItem.Text = JsonData.Item("workspace")("lock")("index").ToString
        WorkSpace.離開ToolStripMenuItem.Text = JsonData.Item("workspace")("exit")("index").ToString

        WorkSpace.設定ToolStripMenuItem.Text = JsonData.Item("workspace")("setting")("index").ToString
        WorkSpace.語言ToolStripMenuItem.Text = JsonData.Item("workspace")("setting")("language").ToString
        WorkSpace.關於ToolStripMenuItem.Text = JsonData.Item("workspace")("about")("index").ToString
        WorkSpace.AboutMsgBoxTitle = JsonData.Item("workspace")("about")("index").ToString
    End Sub
End Module
