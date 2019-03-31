'-----------------------------
'Encryption Notepad v.3.1.0.0 Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------


Module FileProcess
    'Dim AES_Key As String = "12345678"
    Dim DES_Key As String = login.GetNonEncryptedKey(8)
    Dim TDES_Key As String = login.GetNonEncryptedKey(24)
    Dim AES_Key As String = login.GetNonEncryptedKey(50)
    Dim Encrypter As EncryptedCore = New EncryptedCore()


    Function SaveFileFunction(ByRef _FileName)
        If _FileName = Nothing Then
            If WorkSpace.SaveFile.ShowDialog <> DialogResult.Cancel Then
                My.Computer.FileSystem.WriteAllText(WorkSpace.SaveFile.FileName,
            WorkSpace.inputbox.Text, False)
                _FileName = WorkSpace.SaveFile.FileName
                Return True
            Else
                Return False
            End If

        Else
            If IO.Path.GetExtension(_FileName) = ".ent" Then
                Call SaveNewFileFunction(_FileName)
                Return True
            Else
                My.Computer.FileSystem.WriteAllText(_FileName,
                WorkSpace.inputbox.Text, False)

                Return True
            End If

            Return Nothing
        End If
        _FileName = WorkSpace.SaveFile.FileName
    End Function

    Sub SaveNewFileFunction(ByRef _FileName)
        If WorkSpace.SaveFile.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(WorkSpace.SaveFile.FileName,
            WorkSpace.inputbox.Text, False)

            _FileName = WorkSpace.SaveFile.FileName
        End If

    End Sub

    Sub OpenFileFuntion(ByRef _FileName)
        If WorkSpace.OpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            WorkSpace.inputbox.Text = My.Computer.FileSystem.ReadAllText(WorkSpace.OpenFile.
            FileName, System.Text.Encoding.Default)

            _FileName = WorkSpace.OpenFile.FileName
        End If
    End Sub

    Sub NewFileFuntion(ByRef _FileName)
        _FileName = Nothing
        WorkSpace.inputbox.Text = Nothing
    End Sub

    'Encrypt File Function
    '******************************************************
    '******************************************************
    '******************************************************

    Sub Encrypt_SaveFileFunction(ByRef _FileName)
        '處理加密演算法選擇，日後將移除
        Dim SaveText As String = Nothing
        If WorkSpace.AlgoType = 0 Then
            SaveText = DES_Encrypt(WorkSpace.inputbox.Text, DES_Key)
        ElseIf WorkSpace.AlgoType = 1 Then
            SaveText = TDES_Encrypt(WorkSpace.inputbox.Text, TDES_Key, GenerateIV())
        ElseIf WorkSpace.AlgoType = 2 Then
            SaveText = Encrypter.AESE_CBC(Encrypter.Base64E(WorkSpace.inputbox.Text), AES_Key)
        End If

        If _FileName = Nothing Then
            If WorkSpace.DESSaveFile.ShowDialog <> DialogResult.Cancel Then
                My.Computer.FileSystem.WriteAllText(WorkSpace.DESSaveFile.FileName,
           SaveText, False)

                My.Computer.FileSystem.WriteAllText(WorkSpace.DESSaveFile.FileName,
            SaveText, False)

                _FileName = WorkSpace.DESSaveFile.FileName
            End If

        Else
            If IO.Path.GetExtension(_FileName) = ".ent" Then
                My.Computer.FileSystem.WriteAllText(_FileName,
                 SaveText, False)
            Else
                If WorkSpace.DESSaveFile.ShowDialog() = DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(WorkSpace.DESSaveFile.FileName,
                    SaveText, False)

                    _FileName = WorkSpace.DESSaveFile.FileName
                End If
            End If
        End If
    End Sub

    Sub Decrypt_OpenFileFunction(ByRef _FileName)
        '處理加密演算法選擇，日後將移除

        If WorkSpace.AlgoType = 0 Then
            If WorkSpace.DESOpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Try
                    WorkSpace.inputbox.Text = DES_Decrypt(My.Computer.FileSystem.ReadAllText(WorkSpace.DESOpenFile.
            FileName, Text.Encoding.Default), DES_Key)

                    _FileName = WorkSpace.DESOpenFile.FileName
                Catch ex As Exception
                    MessageBox.Show("無法進行解密" & vbNewLine & "可能金鑰錯誤或沒有金鑰，請檢查加密演算法是否正確", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    WorkSpace.inputbox.Text = "解密失敗"
                    _FileName = Nothing
                End Try

            End If
        ElseIf WorkSpace.AlgoType = 1 Then
            If WorkSpace.DESOpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Try
                    WorkSpace.inputbox.Text = TDES_Decrypt(My.Computer.FileSystem.ReadAllText(WorkSpace.DESOpenFile.
            FileName, Text.Encoding.Default), TDES_Key, GenerateIV())

                    _FileName = WorkSpace.DESOpenFile.FileName
                Catch ex As Exception
                    MessageBox.Show("無法進行解密" & vbNewLine & "可能金鑰錯誤或沒有金鑰，請檢查加密演算法是否正確", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    WorkSpace.inputbox.Text = "解密失敗"
                    _FileName = Nothing
                End Try
            End If
        ElseIf WorkSpace.AlgoType = 2 Then
            If WorkSpace.DESOpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Try
                    WorkSpace.inputbox.Text = Encrypter.Base64D(Encrypter.AESD_CBC(My.Computer.FileSystem.ReadAllText(WorkSpace.DESOpenFile.
            FileName, Text.Encoding.Default), AES_Key))

                    _FileName = WorkSpace.DESOpenFile.FileName
                Catch ex As Exception
                    MessageBox.Show("無法進行解密" & vbNewLine & "可能金鑰錯誤或沒有金鑰，請檢查加密演算法是否正確", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    WorkSpace.inputbox.Text = "解密失敗"
                    _FileName = Nothing
                End Try
            End If
        End If
    End Sub
End Module
