'-----------------------------
'Encryption Notepad v.3.0.1.7 Pre-Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Imports System.Security.Cryptography
Imports Rework

Module ProgramTool
    Dim saltA As String = "GDEEq4R9@$1wSq#$"
    Dim saltB As String = "15fEq#4aE45z3!s4"

    Public Function SHA512hash_String(ByVal InputString As String) As String
        InputString = saltA & InputString & saltB
        Dim code = Nothing, SHA512 = Nothing
        SHA512 = InputString.ToSHA(Crypto.SHA_Type.SHA512) 'Make Hash
        Return SHA512
    End Function

    Function ReadUserPassword() '從System.ini讀取使用者密碼雜湊
        Dim TruePwdSHA512 = Nothing
        FileOpen(1, "Sysinfo.ini", OpenMode.Input)
        Input(1, TruePwdSHA512)
        FileClose(1)

        Return TruePwdSHA512
    End Function

    Function CheckPwdSHA512(ByVal pwd)
        Dim PwdMD5 = SHA512hash_String(pwd)
        Dim TruePwdSHA512 = ReadUserPassword()

        'login.Label1.Text = TruePwdMD5
        If PwdMD5 = TruePwdSHA512.ToString Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub SavePwdSHA512(ByVal New_pwd)
        FileOpen(1, "Sysinfo.ini", OpenMode.Output)
        PrintLine(1, """" & SHA512hash_String(New_pwd) & """")
        FileClose(1)
    End Sub

    Function CheckUpdate(ByVal UpdateServerURL)
        Dim webClient As New System.Net.WebClient
        Dim VersionFromServer As String = Nothing

        Try
            VersionFromServer = webClient.DownloadString(UpdateServerURL + "/CurrentVersion")
        Catch ex As Exception
        End Try

        'MsgBox(VersionFromServer)

        If login.Version & vbLf = VersionFromServer Then
            Return "0"
        Else
            Return VersionFromServer
        End If
    End Function
End Module
