﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WorkSpace
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkSpace))
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.inputbox = New System.Windows.Forms.RichTextBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.檔案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開新檔案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開啟舊檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.儲存檔案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存新檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.預覽列印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.列印檔案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.加密儲存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.解密開啟ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.內文ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.字型ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.顏色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.自動換行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.時間戳記ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.複製ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.貼上ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全選ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.清除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.鎖定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.離開ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.語言ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.繁體中文ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.简体中文ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.英文ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EspañolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptAlgorismType = New System.Windows.Forms.ToolStripMenuItem()
        Me.DESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TripleDESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AESCBCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.自動儲存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.錯誤回報BetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllowEncryptAllFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.統計字數ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.關於ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.DESOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.DESSaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Testbutton = New System.Windows.Forms.Button()
        Me.TextLengthLabel = New System.Windows.Forms.Label()
        Me.AlgoTypeLabel = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "txt"
        Me.SaveFile.Filter = "文字文件|*.txt|所有檔案|*.*"
        '
        'OpenFile
        '
        Me.OpenFile.Filter = "文字文件|*.txt|MD文件|*md|所有檔案|*.*"
        '
        'inputbox
        '
        Me.inputbox.AcceptsTab = True
        Me.inputbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.inputbox.EnableAutoDragDrop = True
        Me.inputbox.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.inputbox.HideSelection = False
        Me.inputbox.Location = New System.Drawing.Point(14, 30)
        Me.inputbox.Margin = New System.Windows.Forms.Padding(5)
        Me.inputbox.Name = "inputbox"
        Me.inputbox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.inputbox.Size = New System.Drawing.Size(725, 329)
        Me.inputbox.TabIndex = 0
        Me.inputbox.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案ToolStripMenuItem, Me.內文ToolStripMenuItem, Me.鎖定ToolStripMenuItem, Me.離開ToolStripMenuItem, Me.設定ToolStripMenuItem, Me.關於ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(753, 29)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '檔案ToolStripMenuItem
        '
        Me.檔案ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.開新檔案ToolStripMenuItem, Me.開啟舊檔ToolStripMenuItem, Me.儲存檔案ToolStripMenuItem, Me.另存新檔ToolStripMenuItem, Me.預覽列印ToolStripMenuItem, Me.列印檔案ToolStripMenuItem, Me.ToolStripSeparator1, Me.加密儲存ToolStripMenuItem, Me.解密開啟ToolStripMenuItem})
        Me.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem"
        Me.檔案ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.檔案ToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.檔案ToolStripMenuItem.Text = "檔案"
        '
        '開新檔案ToolStripMenuItem
        '
        Me.開新檔案ToolStripMenuItem.Name = "開新檔案ToolStripMenuItem"
        Me.開新檔案ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.開新檔案ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.開新檔案ToolStripMenuItem.Text = "開新檔案"
        '
        '開啟舊檔ToolStripMenuItem
        '
        Me.開啟舊檔ToolStripMenuItem.Name = "開啟舊檔ToolStripMenuItem"
        Me.開啟舊檔ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.開啟舊檔ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.開啟舊檔ToolStripMenuItem.Text = "開啟舊檔"
        '
        '儲存檔案ToolStripMenuItem
        '
        Me.儲存檔案ToolStripMenuItem.Name = "儲存檔案ToolStripMenuItem"
        Me.儲存檔案ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.儲存檔案ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.儲存檔案ToolStripMenuItem.Text = "儲存檔案"
        '
        '另存新檔ToolStripMenuItem
        '
        Me.另存新檔ToolStripMenuItem.Name = "另存新檔ToolStripMenuItem"
        Me.另存新檔ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.另存新檔ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.另存新檔ToolStripMenuItem.Text = "另存新檔"
        '
        '預覽列印ToolStripMenuItem
        '
        Me.預覽列印ToolStripMenuItem.Name = "預覽列印ToolStripMenuItem"
        Me.預覽列印ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.預覽列印ToolStripMenuItem.Text = "預覽列印"
        '
        '列印檔案ToolStripMenuItem
        '
        Me.列印檔案ToolStripMenuItem.Name = "列印檔案ToolStripMenuItem"
        Me.列印檔案ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.列印檔案ToolStripMenuItem.Text = "列印檔案"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(206, 6)
        '
        '加密儲存ToolStripMenuItem
        '
        Me.加密儲存ToolStripMenuItem.Name = "加密儲存ToolStripMenuItem"
        Me.加密儲存ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.加密儲存ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.加密儲存ToolStripMenuItem.Text = "加密儲存"
        '
        '解密開啟ToolStripMenuItem
        '
        Me.解密開啟ToolStripMenuItem.Name = "解密開啟ToolStripMenuItem"
        Me.解密開啟ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.解密開啟ToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.解密開啟ToolStripMenuItem.Text = "解密開啟"
        '
        '內文ToolStripMenuItem
        '
        Me.內文ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.字型ToolStripMenuItem, Me.顏色ToolStripMenuItem, Me.ToolStripSeparator3, Me.自動換行ToolStripMenuItem, Me.時間戳記ToolStripMenuItem, Me.ToolStripSeparator4, Me.複製ToolStripMenuItem, Me.貼上ToolStripMenuItem, Me.全選ToolStripMenuItem, Me.清除ToolStripMenuItem})
        Me.內文ToolStripMenuItem.Name = "內文ToolStripMenuItem"
        Me.內文ToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.內文ToolStripMenuItem.Text = "內文"
        '
        '字型ToolStripMenuItem
        '
        Me.字型ToolStripMenuItem.Name = "字型ToolStripMenuItem"
        Me.字型ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.字型ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.字型ToolStripMenuItem.Text = "字型"
        '
        '顏色ToolStripMenuItem
        '
        Me.顏色ToolStripMenuItem.Name = "顏色ToolStripMenuItem"
        Me.顏色ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.顏色ToolStripMenuItem.Text = "顏色"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(196, 6)
        '
        '自動換行ToolStripMenuItem
        '
        Me.自動換行ToolStripMenuItem.Checked = True
        Me.自動換行ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.自動換行ToolStripMenuItem.Name = "自動換行ToolStripMenuItem"
        Me.自動換行ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.自動換行ToolStripMenuItem.Text = "自動換行"
        '
        '時間戳記ToolStripMenuItem
        '
        Me.時間戳記ToolStripMenuItem.Name = "時間戳記ToolStripMenuItem"
        Me.時間戳記ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.時間戳記ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.時間戳記ToolStripMenuItem.Text = "時間戳記"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(196, 6)
        '
        '複製ToolStripMenuItem
        '
        Me.複製ToolStripMenuItem.Name = "複製ToolStripMenuItem"
        Me.複製ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.複製ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.複製ToolStripMenuItem.Text = "複製"
        '
        '貼上ToolStripMenuItem
        '
        Me.貼上ToolStripMenuItem.Name = "貼上ToolStripMenuItem"
        Me.貼上ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.貼上ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.貼上ToolStripMenuItem.Text = "貼上"
        '
        '全選ToolStripMenuItem
        '
        Me.全選ToolStripMenuItem.Name = "全選ToolStripMenuItem"
        Me.全選ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.全選ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.全選ToolStripMenuItem.Text = "全選"
        '
        '清除ToolStripMenuItem
        '
        Me.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem"
        Me.清除ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.清除ToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.清除ToolStripMenuItem.Text = "清除"
        '
        '鎖定ToolStripMenuItem
        '
        Me.鎖定ToolStripMenuItem.Name = "鎖定ToolStripMenuItem"
        Me.鎖定ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.鎖定ToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.鎖定ToolStripMenuItem.Text = "鎖定"
        '
        '離開ToolStripMenuItem
        '
        Me.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem"
        Me.離開ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.離開ToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.離開ToolStripMenuItem.Text = "離開"
        '
        '設定ToolStripMenuItem
        '
        Me.設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.語言ToolStripMenuItem, Me.EncryptAlgorismType, Me.自動儲存ToolStripMenuItem, Me.錯誤回報BetaToolStripMenuItem, Me.AllowEncryptAllFileToolStripMenuItem, Me.統計字數ToolStripMenuItem})
        Me.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem"
        Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.設定ToolStripMenuItem.Text = "設定"
        '
        '語言ToolStripMenuItem
        '
        Me.語言ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.繁體中文ToolStripMenuItem, Me.简体中文ToolStripMenuItem, Me.英文ToolStripMenuItem, Me.EspañolToolStripMenuItem})
        Me.語言ToolStripMenuItem.Name = "語言ToolStripMenuItem"
        Me.語言ToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.語言ToolStripMenuItem.Text = "語言"
        '
        '繁體中文ToolStripMenuItem
        '
        Me.繁體中文ToolStripMenuItem.Name = "繁體中文ToolStripMenuItem"
        Me.繁體中文ToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.繁體中文ToolStripMenuItem.Text = "繁體中文"
        '
        '简体中文ToolStripMenuItem
        '
        Me.简体中文ToolStripMenuItem.Name = "简体中文ToolStripMenuItem"
        Me.简体中文ToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.简体中文ToolStripMenuItem.Text = "简体中文"
        '
        '英文ToolStripMenuItem
        '
        Me.英文ToolStripMenuItem.Name = "英文ToolStripMenuItem"
        Me.英文ToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.英文ToolStripMenuItem.Text = "English"
        '
        'EspañolToolStripMenuItem
        '
        Me.EspañolToolStripMenuItem.Name = "EspañolToolStripMenuItem"
        Me.EspañolToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.EspañolToolStripMenuItem.Text = "Español"
        '
        'EncryptAlgorismType
        '
        Me.EncryptAlgorismType.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DESToolStripMenuItem, Me.TripleDESToolStripMenuItem, Me.AESCBCToolStripMenuItem})
        Me.EncryptAlgorismType.Name = "EncryptAlgorismType"
        Me.EncryptAlgorismType.Size = New System.Drawing.Size(212, 26)
        Me.EncryptAlgorismType.Text = "加密演算法"
        '
        'DESToolStripMenuItem
        '
        Me.DESToolStripMenuItem.Checked = True
        Me.DESToolStripMenuItem.CheckOnClick = True
        Me.DESToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DESToolStripMenuItem.Name = "DESToolStripMenuItem"
        Me.DESToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.DESToolStripMenuItem.Text = "DES"
        '
        'TripleDESToolStripMenuItem
        '
        Me.TripleDESToolStripMenuItem.Name = "TripleDESToolStripMenuItem"
        Me.TripleDESToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.TripleDESToolStripMenuItem.Text = "Triple DES"
        '
        'AESCBCToolStripMenuItem
        '
        Me.AESCBCToolStripMenuItem.Name = "AESCBCToolStripMenuItem"
        Me.AESCBCToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.AESCBCToolStripMenuItem.Text = "AES CBC"
        '
        '自動儲存ToolStripMenuItem
        '
        Me.自動儲存ToolStripMenuItem.CheckOnClick = True
        Me.自動儲存ToolStripMenuItem.Name = "自動儲存ToolStripMenuItem"
        Me.自動儲存ToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.自動儲存ToolStripMenuItem.Text = "自動儲存"
        '
        '錯誤回報BetaToolStripMenuItem
        '
        Me.錯誤回報BetaToolStripMenuItem.Name = "錯誤回報BetaToolStripMenuItem"
        Me.錯誤回報BetaToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.錯誤回報BetaToolStripMenuItem.Text = "傳送建議"
        '
        'AllowEncryptAllFileToolStripMenuItem
        '
        Me.AllowEncryptAllFileToolStripMenuItem.CheckOnClick = True
        Me.AllowEncryptAllFileToolStripMenuItem.Name = "AllowEncryptAllFileToolStripMenuItem"
        Me.AllowEncryptAllFileToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.AllowEncryptAllFileToolStripMenuItem.Text = "允許加密非文字檔"
        '
        '統計字數ToolStripMenuItem
        '
        Me.統計字數ToolStripMenuItem.Checked = True
        Me.統計字數ToolStripMenuItem.CheckOnClick = True
        Me.統計字數ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.統計字數ToolStripMenuItem.Name = "統計字數ToolStripMenuItem"
        Me.統計字數ToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.統計字數ToolStripMenuItem.Text = "統計字數"
        '
        '關於ToolStripMenuItem
        '
        Me.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem"
        Me.關於ToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.關於ToolStripMenuItem.Text = "關於"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowSelection = True
        Me.PrintDialog1.AllowSomePages = True
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.ShowHelp = True
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'DESOpenFile
        '
        Me.DESOpenFile.DefaultExt = "ent"
        Me.DESOpenFile.Filter = "加密文件|*.ent"
        '
        'DESSaveFile
        '
        Me.DESSaveFile.DefaultExt = "ent"
        Me.DESSaveFile.Filter = "加密文件|*.ent"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 300000
        '
        'Testbutton
        '
        Me.Testbutton.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Testbutton.Location = New System.Drawing.Point(35, 293)
        Me.Testbutton.Name = "Testbutton"
        Me.Testbutton.Size = New System.Drawing.Size(75, 25)
        Me.Testbutton.TabIndex = 11
        Me.Testbutton.Text = "Test"
        Me.Testbutton.UseVisualStyleBackColor = True
        Me.Testbutton.Visible = False
        '
        'TextLengthLabel
        '
        Me.TextLengthLabel.AutoSize = True
        Me.TextLengthLabel.BackColor = System.Drawing.SystemColors.Window
        Me.TextLengthLabel.Location = New System.Drawing.Point(505, 4)
        Me.TextLengthLabel.Name = "TextLengthLabel"
        Me.TextLengthLabel.Size = New System.Drawing.Size(84, 25)
        Me.TextLengthLabel.TabIndex = 12
        Me.TextLengthLabel.Text = "字數：0"
        '
        'AlgoTypeLabel
        '
        Me.AlgoTypeLabel.BackColor = System.Drawing.SystemColors.Window
        Me.AlgoTypeLabel.Location = New System.Drawing.Point(652, 5)
        Me.AlgoTypeLabel.Name = "AlgoTypeLabel"
        Me.AlgoTypeLabel.Size = New System.Drawing.Size(89, 20)
        Me.AlgoTypeLabel.TabIndex = 13
        Me.AlgoTypeLabel.Text = "Triple DES"
        Me.AlgoTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WorkSpace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 364)
        Me.Controls.Add(Me.AlgoTypeLabel)
        Me.Controls.Add(Me.TextLengthLabel)
        Me.Controls.Add(Me.Testbutton)
        Me.Controls.Add(Me.inputbox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "WorkSpace"
        Me.Text = "加密記事本 Triple-DES Beta"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents inputbox As RichTextBox
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 檔案ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 開啟舊檔ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 儲存檔案ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 另存新檔ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 內文ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 時間戳記ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 字型ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 開新檔案ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 清除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 鎖定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 離開ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 加密儲存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents 解密開啟ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 自動換行ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 顏色ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents 複製ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 貼上ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全選ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 關於ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DESOpenFile As OpenFileDialog
    Friend WithEvents DESSaveFile As SaveFileDialog
    Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 語言ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 繁體中文ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 英文ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 錯誤回報BetaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 简体中文ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EspañolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllowEncryptAllFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 列印檔案ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents 預覽列印ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 自動儲存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoSaveTimer As Timer
    Friend WithEvents Testbutton As Button
    Friend WithEvents TextLengthLabel As Label
    Friend WithEvents EncryptAlgorismType As ToolStripMenuItem
    Friend WithEvents DESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TripleDESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlgoTypeLabel As Label
    Friend WithEvents AESCBCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 統計字數ToolStripMenuItem As ToolStripMenuItem
End Class
