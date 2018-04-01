'參考:http://big5.webasp.net/article/5/4098.htm
'原作者:未知
'2003-07-12
'-----------------------------
'Encryption Notepad v.3.0.0.0 Pre-Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Imports System.Security.Cryptography
Imports System.Text

Module DES

    Public Function DES_Encrypt(ByVal pToEncrypt As String, ByVal sKey As String) As String
        Dim des As New DESCryptoServiceProvider()
        Dim inputByteArray() As Byte
        inputByteArray = Encoding.Default.GetBytes(pToEncrypt)
        '建立加密對象的密鑰和偏移量
        'ASCIIEncoding.ASCII and GetBytes
        des.Key = Encoding.ASCII.GetBytes(sKey)
        des.IV = Encoding.ASCII.GetBytes(sKey)
        '寫二進制數組到加密流
        Dim ms As New IO.MemoryStream()
        Dim cs As New CryptoStream(ms, des.CreateEncryptor, CryptoStreamMode.Write)
        '寫二進制數組到加密流
        cs.Write(inputByteArray, 0, inputByteArray.Length)
        cs.FlushFinalBlock()

        '輸出
        Dim ret As New StringBuilder()
        Dim b As Byte
        For Each b In ms.ToArray()
            ret.AppendFormat("{0:X2}", b)
        Next

        Return ret.ToString()
    End Function

    '解密方法
    Public Function DES_Decrypt(ByVal pToDecrypt As String, ByVal sKey As String) As String
        Dim des As New DESCryptoServiceProvider()
        '把字符串放入byte數組
        Dim len As Integer
        len = pToDecrypt.Length / 2 - 1
        Dim inputByteArray(len) As Byte
        Dim x, i As Integer
        For x = 0 To len
            i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16)
            inputByteArray(x) = CType(i, Byte)
        Next
        '建立加密對象的密鑰和偏移量
        des.Key = Encoding.ASCII.GetBytes(sKey)
        des.IV = Encoding.ASCII.GetBytes(sKey)
        Dim ms As New IO.MemoryStream()
        Dim cs As New CryptoStream(ms, des.CreateDecryptor, CryptoStreamMode.Write)
        cs.Write(inputByteArray, 0, inputByteArray.Length)

        'Try
        cs.FlushFinalBlock()
        'Catch ex As Exception
        '    MessageBox.Show("無法進行解密" & vbNewLine & "可能金鑰錯誤或沒有金鑰", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return "解密失敗"
        'End Try

        Return Encoding.Default.GetString(ms.ToArray)

    End Function
End Module
