<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.UniButton = New System.Windows.Forms.RadioButton()
        Me.BiButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SocPosiButton = New System.Windows.Forms.RadioButton()
        Me.SocNegButton = New System.Windows.Forms.RadioButton()
        Me.IndButton = New System.Windows.Forms.RadioButton()
        Me.SppedButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(425, 275)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 50)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(101, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(101, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mod."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(101, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "InSo"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(157, 59)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(156, 26)
        Me.TextBox1.TabIndex = 7
        '
        'UniButton
        '
        Me.UniButton.AutoSize = True
        Me.UniButton.Checked = True
        Me.UniButton.Location = New System.Drawing.Point(12, 8)
        Me.UniButton.Name = "UniButton"
        Me.UniButton.Size = New System.Drawing.Size(29, 16)
        Me.UniButton.TabIndex = 8
        Me.UniButton.TabStop = True
        Me.UniButton.Text = "1"
        Me.UniButton.UseVisualStyleBackColor = True
        '
        'BiButton
        '
        Me.BiButton.AutoSize = True
        Me.BiButton.Enabled = False
        Me.BiButton.Location = New System.Drawing.Point(12, 30)
        Me.BiButton.Name = "BiButton"
        Me.BiButton.Size = New System.Drawing.Size(29, 16)
        Me.BiButton.TabIndex = 9
        Me.BiButton.TabStop = True
        Me.BiButton.Text = "2"
        Me.BiButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BiButton)
        Me.GroupBox1.Controls.Add(Me.UniButton)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(110, 60)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SocPosiButton)
        Me.GroupBox2.Controls.Add(Me.SocNegButton)
        Me.GroupBox2.Controls.Add(Me.IndButton)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 186)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(110, 72)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'SocPosiButton
        '
        Me.SocPosiButton.AutoSize = True
        Me.SocPosiButton.Location = New System.Drawing.Point(12, 50)
        Me.SocPosiButton.Name = "SocPosiButton"
        Me.SocPosiButton.Size = New System.Drawing.Size(61, 16)
        Me.SocPosiButton.TabIndex = 10
        Me.SocPosiButton.Text = "PosSoc"
        Me.SocPosiButton.UseVisualStyleBackColor = True
        '
        'SocNegButton
        '
        Me.SocNegButton.AutoSize = True
        Me.SocNegButton.Location = New System.Drawing.Point(12, 30)
        Me.SocNegButton.Name = "SocNegButton"
        Me.SocNegButton.Size = New System.Drawing.Size(62, 16)
        Me.SocNegButton.TabIndex = 9
        Me.SocNegButton.Text = "NegSoc"
        Me.SocNegButton.UseVisualStyleBackColor = True
        '
        'IndButton
        '
        Me.IndButton.AutoSize = True
        Me.IndButton.Location = New System.Drawing.Point(12, 8)
        Me.IndButton.Name = "IndButton"
        Me.IndButton.Size = New System.Drawing.Size(38, 16)
        Me.IndButton.TabIndex = 8
        Me.IndButton.Text = "Ind"
        Me.IndButton.UseVisualStyleBackColor = True
        '
        'SppedButton
        '
        Me.SppedButton.AutoSize = True
        Me.SppedButton.Location = New System.Drawing.Point(573, 36)
        Me.SppedButton.Name = "SppedButton"
        Me.SppedButton.Size = New System.Drawing.Size(82, 16)
        Me.SppedButton.TabIndex = 10
        Me.SppedButton.Text = "DebugMode"
        Me.SppedButton.UseVisualStyleBackColor = True
        '
        'config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.SppedButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "config"
        Me.Opacity = 0.7R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FirstScreen"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents UniButton As RadioButton
    Friend WithEvents BiButton As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SocNegButton As RadioButton
    Friend WithEvents IndButton As RadioButton
    Friend WithEvents SocPosiButton As RadioButton
    Friend WithEvents SppedButton As RadioButton
End Class
