'-----------------------------
'Encryption Notepad v.3.1.1.0 Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------


Module KeyTools

    Function GetNewKey()
        Dim CheckInput = Nothing
        Dim New_key As String = False

        MessageBox.Show($"非常重要！{vbNewLine}此版本加入了升級的Triple DES加密演算法，若使用Triple DES則即使金鑰與舊版本相同也無法解密由DES演算法加密的文件{vbNewLine}可從選單中選擇舊版的DES進行解密，但請盡速將舊版本的加密文件解密成明文，因為較不安全的DES加密可能在數個版本後會被移除。", "重要通知", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Do While Not (CheckInput)
InputCheckError:
            New_key = InputBox($"你好!{vbNewLine}看來您是初次使用本程式{vbNewLine}我們開始前必須設定加密金鑰{vbNewLine}{vbNewLine}注意! 此金鑰設定後不可修改", "設定加密金鑰", "New Key", 420, 220)

            If New_key = Nothing Then
                'MessageBox.Show("金鑰為必要設定", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 1

            ElseIf New_key = "New Key" Then
                MessageBox.Show("金鑰不可為空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CheckInput = False
            Else
                CheckInput = True
            End If

        Loop
        CheckInput = False

        Dim New_key_chk As String = InputBox("重複輸入金鑰", "驗證金鑰", "New key", 420, 220)

        If New_key_chk <> New_key Or New_key_chk = Nothing Then
            MessageBox.Show("金鑰驗證失敗", caption:="Error", buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Error)
            GoTo InputCheckError
        End If

        '直接讀取使用者輸入的使用者密碼
        Dim UserPwdSHA512 As String = SHA512hash_String(login.password)

        '寫入加密後金鑰至app
        FileOpen(2, "app", OpenMode.Output)
        PrintLine(2, EncryptKey(SHA512hash_String(New_key), UserPwdSHA512))
        FileClose(2)

        MsgBox($"金鑰設定完成{vbNewLine}{vbNewLine}讓我們開始吧!")
        ReadDESKey() '將金鑰載入程式中
        Return 0
    End Function

    Public Function GetCheckKeyFile() As Object
        Dim FileExist As Boolean = False
        If My.Computer.FileSystem.FileExists("app") Then
            FileExist = True
        End If
        Return FileExist
    End Function

    '讀取已被加密的金鑰
    Function ReadDESKey()
        Dim DESKey As String = Nothing
        FileOpen(2, "app", OpenMode.Input)
        Input(2, DESKey)
        FileClose(2)
        Return DESKey
    End Function

    '定義金鑰加解密
    Function EncryptKey(ByVal key, ByVal UserPassword)
        Dim KeysKey = Mid(UserPassword, 7, 8)
        Dim EncryptKeyString As String = DES_Encrypt(key, KeysKey)

        Return EncryptKeyString
    End Function

    Function DecryptKey(ByVal key, ByVal UserPassword)
        Dim KeysKey = Mid(UserPassword, 7, 8)
        Dim DecryptKeyString As String = DES_Decrypt(key, KeysKey)

        Return DecryptKeyString
    End Function

    Function GenerateIV()
        '建立一個隨機數
        Dim RD As New Random()
        Dim randonNum = RD.Next().ToString()
        '取得現在時間增加亂度
        Dim _time = Now().ToLongTimeString()
        '亂數與時間做成Hash
        Return Mid(SHA512hash_String(randonNum & _time), 20, 8)
    End Function
End Module
