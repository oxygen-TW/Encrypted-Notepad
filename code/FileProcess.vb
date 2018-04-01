'-----------------------------
'Encryption Notepad v.3.0.0.0 Pre-Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Module FileProcess
    'Dim AES_Key As String = "12345678"
    Dim DES_Key As String = login.GetNonEncryptedKey()

    Function SaveFileFuntion(ByRef _FileName)
        If _FileName = Nothing Then
            If WorkSpace.SaveFile.ShowDialog <> DialogResult.Cancel Then
                My.Computer.FileSystem.WriteAllText(WorkSpace.SaveFile.FileName,
            WorkSpace.inputbox.Text, False)

                Return True
            Else
                Return False
            End If

        Else
            If Right(_FileName, 3) = "ent" Then
                Call SaveNewFileFuntion(_FileName)
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

    Sub SaveNewFileFuntion(ByRef _FileName)
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

    'Encrypt File Funtion
    '******************************************************
    '******************************************************
    '******************************************************

    Sub Encrypt_SaveFileFuntion(ByRef _FileName)
        If _FileName = Nothing Then
            If WorkSpace.DESSaveFile.ShowDialog <> DialogResult.Cancel Then
                My.Computer.FileSystem.WriteAllText(WorkSpace.DESSaveFile.FileName,
           DES_Encrypt(WorkSpace.inputbox.Text, DES_Key), False)

                My.Computer.FileSystem.WriteAllText(WorkSpace.DESSaveFile.FileName,
            DES_Encrypt(WorkSpace.inputbox.Text, DES_Key), False)

                _FileName = WorkSpace.DESSaveFile.FileName
            End If

        Else
            If Right(_FileName, 3) = "ent" Then
                My.Computer.FileSystem.WriteAllText(_FileName,
                 DES_Encrypt(WorkSpace.inputbox.Text, DES_Key), False)
            Else
                If WorkSpace.DESSaveFile.ShowDialog() = DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(WorkSpace.DESSaveFile.FileName,
                    DES_Encrypt(WorkSpace.inputbox.Text, DES_Key), False)

                    _FileName = WorkSpace.DESSaveFile.FileName
                End If
            End If
        End If
    End Sub

    Sub Decrypt_OpenFileFuntion(ByRef _FileName)
        If WorkSpace.DESOpenFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Try
                WorkSpace.inputbox.Text = DES_Decrypt(My.Computer.FileSystem.ReadAllText(WorkSpace.DESOpenFile.
            FileName, Text.Encoding.Default), DES_Key)

                _FileName = WorkSpace.DESOpenFile.FileName
            Catch ex As Exception
                MessageBox.Show("無法進行解密" & vbNewLine & "可能金鑰錯誤或沒有金鑰", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                WorkSpace.inputbox.Text = "解密失敗"
                _FileName = Nothing
            End Try

        End If
    End Sub
End Module
