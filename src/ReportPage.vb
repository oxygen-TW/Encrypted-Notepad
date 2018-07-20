'-----------------------------
'Encryption Notepad v.3.1.0.0 Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------


Imports System.Net.Mail
Imports System.Text

Public Class ReportPage

    Sub SendMailNew(ByVal Dest_Email_Address, ByVal User_Topic, ByVal User_Name, ByVal User_Content)
        'Dim SendEmailAddress As String = "encryptednotepad@support.oxygentw.pe.hu"
        Dim SendEmailAddress As String = "s10400067@nhsh.tp.edu.tw"
        Dim SendEmailPassword As String = "26534830"
        Dim SendEmailName_Dev As String = "Encrypted Notepad Report"
        Dim SendEmailName_User As String = "Encrypted Notepad Report"

        '回報
        Dim myMail As New MailMessage With {
            .From = New MailAddress(SendEmailAddress, SendEmailName_Dev) '發送者 	
            }
        'myMail.To.Add(SendEmailAddress)  '收件者
        myMail.Bcc.Add(SendEmailAddress) '隱藏收件者 

        myMail.SubjectEncoding = Encoding.UTF8  '主題編碼格式 
        myMail.Subject = "加密記事本使用者回報" '主題 
        myMail.IsBodyHtml = True    'HTML語法(true:開啟false:關閉) 	
        myMail.BodyEncoding = Encoding.UTF8 '內文編碼格式 
        myMail.Body = User_Name + vbNewLine + "Email：" + Dest_Email_Address + vbNewLine + "主旨：" + User_Topic _
        + vbNewLine + vbNewLine + "內文：" + vbNewLine + User_Content '內文 
        'If AttachmentsFile Then
        '    myMail.Attachments.Add(New System.Net.Mail.Attachment(Filename))
        'End If

        Dim mySmtp As New SmtpClient With {
            .Credentials = New System.Net.NetworkCredential(SendEmailAddress, SendEmailPassword),  '連線驗證 
            .Port = 587,   'SMTP Port 
            .Host = "smtp.gmail.com",  'SMTP主機名 	
            .EnableSsl = True '開啟SSL驗證 
            }  '建立SMTP連線 	

        Me.Cursor = Cursors.WaitCursor
        mySmtp.Send(myMail) '發送 
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub SendReport()
        Dim EmailChecker As New IsValidEmail
        Dim flag As Boolean
        If userNameInput.Text <> "" And userContentInput.Text <> "" And userTopicInput.Text <> "" Then
            If EmailChecker.CheckEmail(userEmailInput.Text) Then
                flag = True
                If CaptchaUserInput.Text = CaptchaBox.Text Then
                    SendMailNew(userEmailInput.Text, userTopicInput.Text, userNameInput.Text, userContentInput.Text)
                    MessageBox.Show("送出成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    login.Show()
                Else
                    MessageBox.Show("驗證碼不符，請重新輸入", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CaptchaBox.Text = CaptchaGenerator() '重新創建
                End If
            Else
                MessageBox.Show("請輸入正確的電子郵件", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                flag = False
            End If
        Else
            MessageBox.Show("請填寫所有欄位", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub ReportSent_Click(sender As Object, e As EventArgs) Handles ReportSent.Click
        Call SendReport()
    End Sub

    Private Function CaptchaGenerator()
        Dim validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"

        Dim sb As New StringBuilder()
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Return sb.ToString()
    End Function
    Private Sub ReportPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize
        userTopicInput.Text = ""
        userNameInput.Text = ""
        userEmailInput.Text = ""
        userContentInput.Text = ""
        CaptchaUserInput.Text = ""
        CaptchaBox.Text = CaptchaGenerator()
        Me.Location = login.WindowLocation
    End Sub

    Private Sub CaptchaBox_Click(sender As Object, e As EventArgs) Handles CaptchaBox.Click
        CaptchaBox.Text = CaptchaGenerator()
    End Sub

    Private Sub ReportPageBack_Click(sender As Object, e As EventArgs) Handles ReportPageBack.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub ReportPage_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            login.Close()
            'WorkSpace.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CaptchaUserInput_KeyDown(sender As Object, e As KeyEventArgs) Handles CaptchaUserInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Call SendReport()
        End If
    End Sub

    Private Sub ReportPage_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        login.WindowLocation = Me.Location '紀錄視窗修改
    End Sub
End Class