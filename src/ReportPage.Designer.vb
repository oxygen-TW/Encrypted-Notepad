<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPage
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.userNameInput = New System.Windows.Forms.TextBox()
        Me.L_username = New System.Windows.Forms.Label()
        Me.userEmailInput = New System.Windows.Forms.TextBox()
        Me.L_userEmail = New System.Windows.Forms.Label()
        Me.userContentInput = New System.Windows.Forms.TextBox()
        Me.L_usercontent = New System.Windows.Forms.Label()
        Me.ReportSent = New System.Windows.Forms.Button()
        Me.CaptchaBox = New System.Windows.Forms.TextBox()
        Me.CaptchaUserInput = New System.Windows.Forms.TextBox()
        Me.L_userTopic = New System.Windows.Forms.Label()
        Me.userTopicInput = New System.Windows.Forms.TextBox()
        Me.L_Captcha = New System.Windows.Forms.Label()
        Me.ReportPageBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'userNameInput
        '
        Me.userNameInput.Location = New System.Drawing.Point(23, 32)
        Me.userNameInput.Name = "userNameInput"
        Me.userNameInput.Size = New System.Drawing.Size(158, 22)
        Me.userNameInput.TabIndex = 0
        '
        'L_username
        '
        Me.L_username.AutoSize = True
        Me.L_username.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_username.Location = New System.Drawing.Point(20, 12)
        Me.L_username.Name = "L_username"
        Me.L_username.Size = New System.Drawing.Size(60, 17)
        Me.L_username.TabIndex = 1
        Me.L_username.Text = "您的名字"
        '
        'userEmailInput
        '
        Me.userEmailInput.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.userEmailInput.Location = New System.Drawing.Point(23, 87)
        Me.userEmailInput.Name = "userEmailInput"
        Me.userEmailInput.Size = New System.Drawing.Size(158, 22)
        Me.userEmailInput.TabIndex = 1
        '
        'L_userEmail
        '
        Me.L_userEmail.AutoSize = True
        Me.L_userEmail.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_userEmail.Location = New System.Drawing.Point(20, 67)
        Me.L_userEmail.Name = "L_userEmail"
        Me.L_userEmail.Size = New System.Drawing.Size(40, 17)
        Me.L_userEmail.TabIndex = 3
        Me.L_userEmail.Text = "Email"
        '
        'userContentInput
        '
        Me.userContentInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.userContentInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.userContentInput.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.userContentInput.Location = New System.Drawing.Point(226, 87)
        Me.userContentInput.Multiline = True
        Me.userContentInput.Name = "userContentInput"
        Me.userContentInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.userContentInput.Size = New System.Drawing.Size(515, 265)
        Me.userContentInput.TabIndex = 3
        '
        'L_usercontent
        '
        Me.L_usercontent.AutoSize = True
        Me.L_usercontent.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_usercontent.Location = New System.Drawing.Point(223, 67)
        Me.L_usercontent.Name = "L_usercontent"
        Me.L_usercontent.Size = New System.Drawing.Size(34, 17)
        Me.L_usercontent.TabIndex = 5
        Me.L_usercontent.Text = "內文"
        '
        'ReportSent
        '
        Me.ReportSent.Location = New System.Drawing.Point(104, 175)
        Me.ReportSent.Name = "ReportSent"
        Me.ReportSent.Size = New System.Drawing.Size(91, 23)
        Me.ReportSent.TabIndex = 5
        Me.ReportSent.Text = "送出"
        Me.ReportSent.UseVisualStyleBackColor = True
        '
        'CaptchaBox
        '
        Me.CaptchaBox.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.CaptchaBox.Location = New System.Drawing.Point(129, 147)
        Me.CaptchaBox.Name = "CaptchaBox"
        Me.CaptchaBox.ReadOnly = True
        Me.CaptchaBox.Size = New System.Drawing.Size(66, 22)
        Me.CaptchaBox.TabIndex = 7
        '
        'CaptchaUserInput
        '
        Me.CaptchaUserInput.BackColor = System.Drawing.SystemColors.Window
        Me.CaptchaUserInput.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CaptchaUserInput.Location = New System.Drawing.Point(23, 147)
        Me.CaptchaUserInput.Name = "CaptchaUserInput"
        Me.CaptchaUserInput.Size = New System.Drawing.Size(96, 22)
        Me.CaptchaUserInput.TabIndex = 4
        '
        'L_userTopic
        '
        Me.L_userTopic.AutoSize = True
        Me.L_userTopic.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_userTopic.Location = New System.Drawing.Point(223, 12)
        Me.L_userTopic.Name = "L_userTopic"
        Me.L_userTopic.Size = New System.Drawing.Size(40, 17)
        Me.L_userTopic.TabIndex = 10
        Me.L_userTopic.Text = "Topic"
        '
        'userTopicInput
        '
        Me.userTopicInput.Location = New System.Drawing.Point(226, 32)
        Me.userTopicInput.Name = "userTopicInput"
        Me.userTopicInput.Size = New System.Drawing.Size(515, 22)
        Me.userTopicInput.TabIndex = 2
        '
        'L_Captcha
        '
        Me.L_Captcha.AutoSize = True
        Me.L_Captcha.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_Captcha.Location = New System.Drawing.Point(20, 127)
        Me.L_Captcha.Name = "L_Captcha"
        Me.L_Captcha.Size = New System.Drawing.Size(99, 17)
        Me.L_Captcha.TabIndex = 11
        Me.L_Captcha.Text = "請輸入右側文字"
        '
        'ReportPageBack
        '
        Me.ReportPageBack.Location = New System.Drawing.Point(23, 175)
        Me.ReportPageBack.Name = "ReportPageBack"
        Me.ReportPageBack.Size = New System.Drawing.Size(75, 23)
        Me.ReportPageBack.TabIndex = 6
        Me.ReportPageBack.Text = "取消"
        Me.ReportPageBack.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 122)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "感謝您的回報，您寶貴的資訊將會使我們讓加密記事本變得更好！" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "加密記事本開發團隊　敬上" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ReportPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 364)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportPageBack)
        Me.Controls.Add(Me.L_Captcha)
        Me.Controls.Add(Me.L_userTopic)
        Me.Controls.Add(Me.userTopicInput)
        Me.Controls.Add(Me.CaptchaUserInput)
        Me.Controls.Add(Me.CaptchaBox)
        Me.Controls.Add(Me.ReportSent)
        Me.Controls.Add(Me.L_usercontent)
        Me.Controls.Add(Me.userContentInput)
        Me.Controls.Add(Me.L_userEmail)
        Me.Controls.Add(Me.userEmailInput)
        Me.Controls.Add(Me.L_username)
        Me.Controls.Add(Me.userNameInput)
        Me.Name = "ReportPage"
        Me.Text = "我有話要說"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents userNameInput As TextBox
    Friend WithEvents L_username As Label
    Friend WithEvents userEmailInput As TextBox
    Friend WithEvents L_userEmail As Label
    Friend WithEvents userContentInput As TextBox
    Friend WithEvents L_usercontent As Label
    Friend WithEvents ReportSent As Button
    Friend WithEvents CaptchaBox As TextBox
    Friend WithEvents CaptchaUserInput As TextBox
    Friend WithEvents L_userTopic As Label
    Friend WithEvents userTopicInput As TextBox
    Friend WithEvents L_Captcha As Label
    Friend WithEvents ReportPageBack As Button
    Friend WithEvents Label1 As Label
End Class
