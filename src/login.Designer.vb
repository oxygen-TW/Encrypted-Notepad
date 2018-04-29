<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.pwd_input = New System.Windows.Forms.TextBox()
        Me.login_buttom = New System.Windows.Forms.Button()
        Me.login_err = New System.Windows.Forms.Label()
        Me.Label_enterpwd = New System.Windows.Forms.Label()
        Me.PwdReset = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pwd_input
        '
        resources.ApplyResources(Me.pwd_input, "pwd_input")
        Me.pwd_input.Name = "pwd_input"
        '
        'login_buttom
        '
        resources.ApplyResources(Me.login_buttom, "login_buttom")
        Me.login_buttom.Name = "login_buttom"
        Me.login_buttom.UseVisualStyleBackColor = True
        '
        'login_err
        '
        resources.ApplyResources(Me.login_err, "login_err")
        Me.login_err.BackColor = System.Drawing.SystemColors.Control
        Me.login_err.ForeColor = System.Drawing.Color.Red
        Me.login_err.Name = "login_err"
        '
        'Label_enterpwd
        '
        resources.ApplyResources(Me.Label_enterpwd, "Label_enterpwd")
        Me.Label_enterpwd.Name = "Label_enterpwd"
        '
        'PwdReset
        '
        resources.ApplyResources(Me.PwdReset, "PwdReset")
        Me.PwdReset.Name = "PwdReset"
        Me.PwdReset.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'login
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PwdReset)
        Me.Controls.Add(Me.Label_enterpwd)
        Me.Controls.Add(Me.login_err)
        Me.Controls.Add(Me.login_buttom)
        Me.Controls.Add(Me.pwd_input)
        Me.Name = "login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pwd_input As TextBox
    Friend WithEvents login_buttom As Button
    Friend WithEvents login_err As Label
    Friend WithEvents Label_enterpwd As Label
    Friend WithEvents PwdReset As Button
    Friend WithEvents Label1 As Label
End Class
