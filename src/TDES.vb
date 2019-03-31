Imports System.Security.Cryptography
Imports System.Text

Module TDES
    '**********************************************************
    '3DES Algorism
    'http://sanity-free.org/131/triple_des_between_php_and_csharp.html
    'http://wthomasu.pixnet.net/blog/post/38017461-%5B.net%5D%E9%80%8F%E9%81%8Etriple-des%E5%9C%A8vb.net%E8%88%87php%E9%96%93%E4%BA%A4%E6%8F%9B%E8%B3%87%E6%96%99
    '**********************************************************

    Public Function TDES_Encrypt(ByVal OriginalText, ByVal _key, ByVal _IV)
        Dim data As Byte() = Encoding.Default.GetBytes(OriginalText)
        Dim tdes As TripleDES = TripleDES.Create()
        tdes.IV = Encoding.Default.GetBytes(_IV) '8 bytes
        tdes.Key = Encoding.Default.GetBytes(_key) '24 bytes
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.Zeros
        Dim ict As ICryptoTransform = tdes.CreateEncryptor()
        Dim enc As Byte() = ict.TransformFinalBlock(data, 0, data.Length)
        Return Convert.ToBase64String(enc)
    End Function

    Public Function TDES_Decrypt(ByVal ChiperText, ByVal _key, ByVal _IV)
        Dim data As Byte() = Convert.FromBase64String(ChiperText)
        Dim tdes As TripleDES = TripleDES.Create()
        tdes.IV = Encoding.ASCII.GetBytes(_IV)
        tdes.Key = Encoding.ASCII.GetBytes(_key)
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.Zeros
        Dim ict As ICryptoTransform = tdes.CreateDecryptor()
        Dim enc As Byte() = ict.TransformFinalBlock(data, 0, data.Length)
        Return Encoding.Default.GetString(enc)
    End Function
End Module
