'-----------------------------
'Encryption Notepad v.3.3.0.0 Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module ConfigTools
    Private ConfigFilePath = "config.json"

    '共通變數區
    Public _autosaveFunction As Boolean
    Public _defaultLanguage As String
    Public _defaultAlgorism As String
    Public _defaultCount As Boolean

    Function ReadConfigFile()
        Dim ConfigFile As String
        ConfigFile = My.Computer.FileSystem.ReadAllText(ConfigFilePath,
        encoding:=Text.Encoding.UTF8)


        Dim Config_Json As JObject = JsonConvert.DeserializeObject(ConfigFile)
        Return Config_Json
    End Function
    Sub LoadConfigFile()
        Dim Config_Json = ReadConfigFile()

        _autosaveFunction = Convert.ToBoolean(Config_Json.Item("autosave"))
        _defaultLanguage = Config_Json.Item("language").ToString()
        _defaultAlgorism = Config_Json.Item("algorism").ToString()
        _defaultCount = Convert.ToBoolean(Config_Json.Item("count"))

    End Sub

    Sub WriteConfigFile()
        Dim ConfigJsonDict As New Dictionary(Of String, String)

        ConfigJsonDict.Add("autosave", _autosaveFunction)
        ConfigJsonDict.Add("language", _defaultLanguage)
        ConfigJsonDict.Add("algorism", _defaultAlgorism)
        ConfigJsonDict.Add("count", _defaultCount)
        Console.WriteLine(_defaultAlgorism)

        Dim ConfigJsonOutput = JsonConvert.SerializeObject(ConfigJsonDict, Formatting.Indented)
        Console.WriteLine(ConfigJsonOutput)

        '寫入Config.json
        FileOpen(3, ConfigFilePath, OpenMode.Output)
        Print(3, ConfigJsonOutput)
        FileClose(3)
    End Sub

End Module
