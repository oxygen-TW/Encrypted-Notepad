'-----------------------------
'Encryption Notepad v.3.5.0 Alpha
'Copyright(C) 2017-2018, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------


Public Class WorkSpace
    '狀態變數
    Dim ChkFileName = Nothing
    Dim TextModify As Boolean = False
    Dim AutoNewLine As Boolean = True

    '語言設定變數
    Public TitleText As String
    Public Untitle As String
    Public AboutMsgBoxTitle As String

    '設定演算法變數 0=DES 1=3DES 2=AES CBC
    Public AlgoType = 0

    Sub SetTitle(ByVal _FileName)
        If ChkFileName = Nothing Then
            Me.Text = TitleText + " - " + Untitle
        Else
            Me.Text = TitleText & " - " & _FileName
        End If
    End Sub

    Private Sub WorkSpace_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        login.Close()
        Try
            ReportPage.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 開啟舊檔ToolStripMenuItem.Click
        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFunction(ChkFileName) Then
                    Exit Sub
                End If

                Call OpenFileFuntion(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.No Then
                Call OpenFileFuntion(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call OpenFileFuntion(ChkFileName)
            Call SetTitle(ChkFileName)
        End If

        TextModify = False
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 儲存檔案ToolStripMenuItem.Click
        Call SaveFileFunction(ChkFileName)
        Call SetTitle(ChkFileName)
        TextModify = False
    End Sub

    Private Sub SaveNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 另存新檔ToolStripMenuItem.Click
        Call SaveNewFileFunction(ChkFileName)
        Call SetTitle(ChkFileName)
        TextModify = True
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 開新檔案ToolStripMenuItem.Click

        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("即將離開程式，是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFunction(ChkFileName) Then
                    'Exit Sub
                End If

                Call NewFileFuntion(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.No Then
                Call NewFileFuntion(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call NewFileFuntion(ChkFileName)
            Call SetTitle(ChkFileName)
        End If

    End Sub

    Private Sub TimeStampToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 時間戳記ToolStripMenuItem.Click
        inputbox.Text += Now().ToString & vbNewLine
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 字型ToolStripMenuItem.Click
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            inputbox.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub LockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 鎖定ToolStripMenuItem.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 離開ToolStripMenuItem.Click

        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("即將離開程式，是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFunction(ChkFileName) Then
                    Exit Sub
                End If
                Application.Exit()

            ElseIf result = DialogResult.No Then
                Application.Exit()

            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Application.Exit()
        End If

    End Sub

    Private Sub DES_SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 加密儲存ToolStripMenuItem.Click
        Call Encrypt_SaveFileFunction(ChkFileName)
        Call SetTitle(ChkFileName)
        TextModify = False
    End Sub

    Private Sub DES_OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 解密開啟ToolStripMenuItem.Click
        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFunction(ChkFileName) Then
                    Exit Sub
                End If

                Call Decrypt_OpenFileFunction(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.No Then
                Call Decrypt_OpenFileFunction(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call Decrypt_OpenFileFunction(ChkFileName)
            Call SetTitle(ChkFileName)
        End If

        TextModify = False
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除ToolStripMenuItem.Click
        inputbox.Text = Nothing
    End Sub

    Private Sub AutoNewLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自動換行ToolStripMenuItem.Click
        AutoNewLine = Not AutoNewLine
        inputbox.WordWrap = AutoNewLine
        自動換行ToolStripMenuItem.Checked = AutoNewLine
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 顏色ToolStripMenuItem.Click
        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            inputbox.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub 全選ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全選ToolStripMenuItem.Click
        inputbox.SelectAll()
    End Sub

    Private Sub 複製ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 複製ToolStripMenuItem.Click
        inputbox.Copy()
    End Sub

    Private Sub 貼上ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 貼上ToolStripMenuItem.Click
        inputbox.Paste()
    End Sub

    Private Sub 關於ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 關於ToolStripMenuItem.Click
        Dim AboutText As String = $"加密書寫系統 v{login.Version} {login.SoftwareStatus}{vbNewLine}編譯日期 2019/10/10{vbNewLine}{vbNewLine}Copyright (C) 2017-2019, Oxygen Studio{vbNewLine}All rights reserved "
        MessageBox.Show(AboutText, AboutMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub

    Private Sub WorkSpace_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = login.WindowLocation
        LoadConfigFile() '讀取使用者設定

        '開始套用使用者設定
        Call SetTitle(ChkFileName)
        自動儲存ToolStripMenuItem.Checked = ConfigTools._autosaveFunction
        統計字數ToolStripMenuItem.Checked = ConfigTools._defaultCount
        TextLengthLabel.Visible = ConfigTools._defaultCount
        WriteConfigFile()

    End Sub

    Private Sub Inputbox_TextChanged(sender As Object, e As EventArgs) Handles inputbox.TextChanged
        TextModify = True
        TextLengthLabel.Text = "字數：" & Len(inputbox.Text).ToString
    End Sub

    Private Sub Inputbox_ImeChange(sender As Object, e As EventArgs) Handles inputbox.ImeChange
        inputbox.ImeMode = ImeMode.OnHalf
    End Sub

    Private Sub 繁體中文ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 繁體中文ToolStripMenuItem.Click
        Call ChangeLanguage("zh-tw")
        Call SetTitle(ChkFileName)
    End Sub

    Private Sub 英文ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 英文ToolStripMenuItem.Click
        Call ChangeLanguage("en-us")
        Call SetTitle(ChkFileName)
    End Sub

    Private Sub 錯誤回報BetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 錯誤回報BetaToolStripMenuItem.Click
        Hide()
        ReportPage.Show()
    End Sub

    Private Sub 简体中文ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 简体中文ToolStripMenuItem.Click
        Call ChangeLanguage("zh-cn")
        Call SetTitle(ChkFileName)
    End Sub

    'Private Sub WorkSpace_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
    '    login.WindowLocation = Me.Location '紀錄視窗修改
    '    Label1.Text = login.WindowLocation.ToString
    'End Sub

    Private Sub EspañolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspañolToolStripMenuItem.Click
        Call ChangeLanguage("es")
        Call SetTitle(ChkFileName)
    End Sub

    '允許加解密所有檔案格式(測試)
    Private Sub AllowEncryptAllFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllowEncryptAllFileToolStripMenuItem.Click

        If AllowEncryptAllFileToolStripMenuItem.Checked Then
            DESOpenFile.Filter = "加密文件|*.ent|所有檔案|*.*"
            DESSaveFile.Filter = "加密文件|*.ent|所有檔案|*.*"
        Else
            DESOpenFile.Filter = "加密文件|*.ent"
            DESSaveFile.Filter = "加密文件|*.ent"
        End If
    End Sub

    '列印參數相同於inputbox的字型、顏色
    'Ref: https://bbs.csdn.net/topics/240042309
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Static myBrush = New SolidBrush(inputbox.ForeColor)
        Static limit As Integer
        Dim n, L As Integer
        Dim sFmt As New StringFormat(StringFormatFlags.LineLimit)
        e.Graphics.MeasureString(Mid(inputbox.Text, limit + 1), inputbox.Font, e.MarginBounds.Size, sFmt, n, L)
        e.Graphics.DrawString(Mid(inputbox.Text, limit + 1, n), inputbox.Font, myBrush, e.MarginBounds)
        limit += n

        If limit < inputbox.Text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            limit = 0
        End If
    End Sub

    Private Sub 列印檔案ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 列印檔案ToolStripMenuItem.Click
        PrintDialog1.Document = PrintDocument1
        'PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        PrintDialog1.AllowSomePages = True

        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            '避免檔案無法寫入而程式崩潰
            Try
                PrintDocument1.Print()
            Catch ex As Exception
                MessageBox.Show("列印發生錯誤" + vbNewLine + "請檢查目標檔案是否已被開啟", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub 預覽列印ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 預覽列印ToolStripMenuItem.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub 自動儲存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自動儲存ToolStripMenuItem.Click
        AutoSaveTimer.Enabled = 自動儲存ToolStripMenuItem.Checked
        ConfigTools._autosaveFunction = 自動儲存ToolStripMenuItem.Checked
        ConfigTools.WriteConfigFile()
    End Sub

    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs) Handles AutoSaveTimer.Tick

        If ChkFileName <> Nothing Then
            Dim SubFileName As String = IO.Path.GetExtension(ChkFileName) 'Microsoft.VisualBasic.Strings.Right(ChkFileName, 3)

            '演算法選擇由FileProcess決定
            If SubFileName = ".ent" Or SubFileName = ".ENT" Then
                Call Encrypt_SaveFileFunction(ChkFileName)
                TextModify = False
                Console.WriteLine("Call Encrypted save")
            Else
                Call SaveFileFunction(ChkFileName)
                TextModify = False
                Console.WriteLine("Call Normal save")
            End If
        Else
            Console.WriteLine("Timer tick but no file name.")

        End If

    End Sub

    Private Sub DESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DESToolStripMenuItem.Click
        AlgoType = 0
        DESToolStripMenuItem.Checked = True
        TripleDESToolStripMenuItem.Checked = False
        AESCBCToolStripMenuItem.Checked = False
        AlgoTypeLabel.Text = "DES"
        _defaultAlgorism = "DES"
        WriteConfigFile() '修改演算法到config
    End Sub

    Private Sub TripleDESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TripleDESToolStripMenuItem.Click
        AlgoType = 1
        TripleDESToolStripMenuItem.Checked = True
        DESToolStripMenuItem.Checked = False
        AESCBCToolStripMenuItem.Checked = False
        AlgoTypeLabel.Text = "Triple DES"
        _defaultAlgorism = "TDES"
        WriteConfigFile() '修改演算法到config
    End Sub

    Private Sub AESCBCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AESCBCToolStripMenuItem.Click
        AlgoType = 2
        TripleDESToolStripMenuItem.Checked = False
        DESToolStripMenuItem.Checked = False
        AESCBCToolStripMenuItem.Checked = True
        AlgoTypeLabel.Text = "AES CBC"
        _defaultAlgorism = "AESCBC"
        WriteConfigFile() '修改演算法到config
    End Sub

    'DEVELOP ONLY! Invisible before release
    Private Sub Testbutton_Click(sender As Object, e As EventArgs) Handles Testbutton.Click
        inputbox.Rtf = inputbox.Text
    End Sub

    Private Sub 統計字數ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 統計字數ToolStripMenuItem.Click
        _defaultCount = Not (_defaultCount)

        If Not (_defaultCount) Then
            TextLengthLabel.Visible = False
        Else
            TextLengthLabel.Visible = True
        End If

        '寫入config
        WriteConfigFile()
    End Sub

    Private Sub 匯出金鑰ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 匯出金鑰ToolStripMenuItem1.Click
        Dim Passwd = ""
        Passwd = Interaction.InputBox("請輸入使用者密碼", "輸入使用者密碼", "User password", 420, 220)

        If Passwd = Nothing Then
            Exit Sub
        End If

        Dim NonEncryptedKey = ""
        Try
            NonEncryptedKey = DecryptKey(ReadDESKey(), SHA512hash_String(Passwd))
        Catch ex As Exception
            MessageBox.Show("密碼錯誤", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub '離開登入程序
        End Try

        If ExportKeyFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(ExportKeyFileDialog.FileName, NonEncryptedKey, False)
        End If

        MessageBox.Show("匯出完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub 匯入金鑰ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 匯入金鑰ToolStripMenuItem.Click

        Dim NonEncryptedKey = ""
        If ImportKeyFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            NonEncryptedKey = My.Computer.FileSystem.ReadAllText(ImportKeyFileDialog.FileName, System.Text.Encoding.Default)
        End If

        Dim Passwd = ""
        Passwd = Interaction.InputBox("請輸入使用者密碼", "輸入使用者密碼", "User password", 420, 220)

        If Passwd = Nothing Then
            Exit Sub
        End If

        If Not (login.CheckPWD(Passwd)) Then

        End If
    End Sub
End Class
