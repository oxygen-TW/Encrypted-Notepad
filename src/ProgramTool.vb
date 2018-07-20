'-----------------------------
'Encryption Notepad v.3.1.0.0 Alpha
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

    Function CheckUpdate(ByVal UpdateServerURL)
        Dim webClient As New System.Net.WebClient
        Dim VersionFromServer As String = login.Version

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
