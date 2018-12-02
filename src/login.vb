'-----------------------------
'Encryption Notepad v.3.1.1.1 Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Public Class login

    ''' 重要! 版本號定義常數 '''
    Public Const Version = "3.1.2.0"

    Public password As String = "0000"
    Dim Old_pwd As String = Nothing
    Dim New_pwd As String = Nothing
    Dim NonEncryptedKey As String = Nothing
    Public WindowLocation = New Point(230, 130)

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Init_Language(ReadLanguageConfig(DefaultLanguage())) '設定語系
        'Console.WriteLine(SHA512hash_String("0000")) 'Debug only

        login_err.Visible = False
        Me.Location = New Point(230, 130) '初始化視窗位置

        'UI配置
        Dim objLen As Integer = pwd_input.Width + login_buttom.Width + 10
        pwd_input.Left = (Me.Width - objLen) / 2
        login_buttom.Left = (pwd_input.Left + pwd_input.Width) + 10
        login_err.Left = pwd_input.Left
        Label_enterpwd.Left = pwd_input.Left
        PwdReset.Left = login_buttom.Left

        'MsgBox(Application.UserAppDataPath)

        If Not GetCheckKeyFile() Then
            Dim result = GetNewKey()
            If result = 1 Then Application.Exit()
        End If

        '導入更新服務伺服器位置 Base64處理
        'Dim UpdateInfoBase64 As String = Nothing
        'FileOpen(4, Application.StartupPath + "\UpdateInfo.ini", OpenMode.Input)
        'Input(4, UpdateInfoBase64)
        'FileClose(4)

        'Dim UpdateInfo As String = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(UpdateInfoBase64))

        'MsgBox(UpdateInfo)

        'Dim IsUpdate = CheckUpdate(UpdateInfo)

        'If IsUpdate <> "0" Then
        '    Dim r = MessageBox.Show("加密記事本 v" + IsUpdate + "已經釋出，是否更新成最新版?", "有更新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        '    If r = DialogResult.OK Then
        '        '打開加密記事本官網
        '        Shell("Rundll32.exe url.dll, FileProtocolHandler " & UpdateInfo, vbNormalFocus)
        '    End If
        'End If
    End Sub

    Sub CheckPWD()

        '嘗試進行金鑰解密
        Try
            NonEncryptedKey = DecryptKey(ReadDESKey(), SHA512hash_String(password))
        Catch ex As Exception
            login_err.Visible = True
            pwd_input.Text = Nothing
            Exit Sub '離開登入程序
        End Try

        Hide()
        WorkSpace.Show()
        login_err.Visible = False
        pwd_input.Text = Nothing
        password = pwd_input.Text

    End Sub

    '取得非加密金鑰的函式(5,8)
    Public Function GetNonEncryptedKey()
        Return Mid(NonEncryptedKey, 5, 8)
    End Function

    Private Sub Login_buttom_Click(sender As Object, e As EventArgs) Handles login_buttom.Click
        password = pwd_input.Text
        Call CheckPWD()
    End Sub

    Private Sub Pwd_input_KeyDown(sender As Object, e As KeyEventArgs) Handles pwd_input.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            password = pwd_input.Text
            Call CheckPWD()
        End If
    End Sub



    Private Sub Login_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'WorkSpace.Close()
    End Sub

    Private Sub PwdReset_Click(sender As Object, e As EventArgs) Handles PwdReset.Click
        Old_pwd = InputBox("請輸入舊密碼", "輸入舊密碼", "Old password", 420, 220)

        If Old_pwd = Nothing Then
            Exit Sub
        End If

        Try
            NonEncryptedKey = DecryptKey(ReadDESKey(), SHA512hash_String(Old_pwd))
        Catch ex As Exception
            MessageBox.Show("密碼錯誤", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub '離開登入程序
        End Try

        New_pwd = InputBox("請輸入新密碼", "輸入新密碼", "New password", 420, 220)

        If New_pwd = Nothing Then
            Exit Sub
        End If

        If New_pwd = "New password" Then
            MessageBox.Show("新登入密碼不可為空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim New_pwd_chk As String = InputBox("重複輸入新登入密碼", "驗證新登入密碼", "New password", 420, 220)

        If New_pwd_chk = Nothing Then
            Exit Sub
        End If
        If New_pwd_chk <> New_pwd Then
            MessageBox.Show("新登入密碼驗證失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        '儲存新加密後金鑰(舊使用者密碼)
        Dim Tmp As String = DecryptKey(ReadDESKey(), SHA512hash_String(Old_pwd))

        FileOpen(2, Application.UserAppDataPath + "/app", OpenMode.Output)
        PrintLine(2, EncryptKey(Tmp, SHA512hash_String(New_pwd))) '新使用者密碼
        FileClose(2)

        MessageBox.Show("登入密碼重設成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Login_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        WindowLocation = Me.Location '紀錄視窗修改
        Label1.Text = WindowLocation.ToString
    End Sub
End Class