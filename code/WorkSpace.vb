'-----------------------------
'Encryption Notepad v.3.0.0.0 Pre-Alpha
'Copyright(C) 2017, 劉子豪
'All rights reserved   
'著作權所有，侵害必究
'-----------------------------

Public Class WorkSpace
    Dim ChkFileName = Nothing
    Dim TextModify As Boolean = False
    Dim AutoNewLine As Boolean = True

    '語言設定變數
    Public TitleText As String
    Public Untitle As String
    Public AboutMsgBoxTitle As String

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
                If Not SaveFileFuntion(ChkFileName) Then
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
        Call SaveFileFuntion(ChkFileName)
        Call SetTitle(ChkFileName)
        TextModify = False
    End Sub

    Private Sub SaveNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 另存新檔ToolStripMenuItem.Click
        Call SaveNewFileFuntion(ChkFileName)
        Call SetTitle(ChkFileName)
        TextModify = True
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 開新檔案ToolStripMenuItem.Click

        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("即將離開程式，是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFuntion(ChkFileName) Then
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
        Login.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 離開ToolStripMenuItem.Click

        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("即將離開程式，是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFuntion(ChkFileName) Then
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
        Call Encrypt_SaveFileFuntion(ChkFileName)
        Call SetTitle(ChkFileName)
        TextModify = False
    End Sub

    Private Sub DES_OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 解密開啟ToolStripMenuItem.Click
        If TextModify Then
            Dim result As DialogResult = Nothing
            result = MessageBox.Show("是否存儲存修改?", "存檔?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

            If result = DialogResult.Yes Then
                If Not SaveFileFuntion(ChkFileName) Then
                    Exit Sub
                End If

                Call Decrypt_OpenFileFuntion(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.No Then
                Call Decrypt_OpenFileFuntion(ChkFileName)
                Call SetTitle(ChkFileName)

            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call Decrypt_OpenFileFuntion(ChkFileName)
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
        Dim AboutText As String = $"加密書寫系統 v3.0.1.3 Pre-Alpha{vbNewLine}編譯日期 2018/4/19{vbNewLine}{vbNewLine}Copyright (C) 2017-2018, 劉子豪{vbNewLine}All rights reserved "
        MessageBox.Show(AboutText, AboutMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub

    Private Sub WorkSpace_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = login.WindowLocation

        Call SetTitle(ChkFileName)
    End Sub

    Private Sub Inputbox_TextChanged(sender As Object, e As EventArgs) Handles inputbox.TextChanged
        TextModify = True
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

    Private Sub WorkSpace_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        login.WindowLocation = Me.Location '紀錄視窗修改
        Label1.Text = login.WindowLocation.ToString
    End Sub
End Class
