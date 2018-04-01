'Source from https://dotblogs.com.tw/eaglewolf/2011/06/26/29960

'-----------------------------
'Encryption Notepad v.3.0.0.0 Pre-Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Imports System.Security.Cryptography
Imports System.Text

Module AES
    Public Function AES_Encrypt(ByVal plainText As String, ByVal key As String) As String
        Dim AES As New RijndaelManaged()
        Dim MD5 As New MD5CryptoServiceProvider()
        Dim plainTextData As Byte() = Encoding.Unicode.GetBytes(plainText)
        Dim keyData As Byte() = MD5.ComputeHash(Encoding.Unicode.GetBytes(key))
        Dim IVData As Byte() = MD5.ComputeHash(Encoding.Unicode.GetBytes("!#JKD45@"))
        Dim transform As ICryptoTransform = AES.CreateEncryptor(keyData, IVData)
        Dim outputData As Byte() = transform.TransformFinalBlock(plainTextData, 0, plainTextData.Length)
        AES_Encrypt = Convert.ToBase64String(outputData)
    End Function

    Public Function AES_Decrypt(ByVal cipherTextData As Byte(), ByVal key As String) As String
        Dim AES As New RijndaelManaged()
        Dim MD5 As New MD5CryptoServiceProvider()
        Dim keyData As Byte() = MD5.ComputeHash(Encoding.Unicode.GetBytes(key))
        Dim IVData As Byte() = MD5.ComputeHash(Encoding.Unicode.GetBytes("!#JKD45@"))
        Dim transform As ICryptoTransform = AES.CreateDecryptor(keyData, IVData)
        Dim outputData As Byte() = transform.TransformFinalBlock(cipherTextData, 0, cipherTextData.Length)
        AES_Decrypt = Encoding.Unicode.GetString(outputData)
    End Function

End Module
