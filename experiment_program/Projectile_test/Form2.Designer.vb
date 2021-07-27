<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.HunterAppearLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SocialLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Button1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(420, 625)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(500, 54)
        Me.Button1.TabIndex = 117
        Me.Button1.Text = "あなたの家系の矢尻を継承し、狩りの旅に出る"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'HunterAppearLabel
        '
        Me.HunterAppearLabel.AutoSize = True
        Me.HunterAppearLabel.BackColor = System.Drawing.SystemColors.Control
        Me.HunterAppearLabel.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HunterAppearLabel.Location = New System.Drawing.Point(378, 141)
        Me.HunterAppearLabel.Name = "HunterAppearLabel"
        Me.HunterAppearLabel.Size = New System.Drawing.Size(542, 38)
        Me.HunterAppearLabel.TabIndex = 118
        Me.HunterAppearLabel.Text = "シーズン１が終わり、シーズン２へと移ります"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(301, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(692, 38)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "シーズンが変わると、狩場を移動するため環境が変わります"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(317, 217)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(692, 38)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "（そのため、新たな矢尻のデザインを探す必要があります）"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(512, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(270, 72)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "シーズン２"
        '
        'SocialLabel
        '
        Me.SocialLabel.AutoSize = True
        Me.SocialLabel.BackColor = System.Drawing.SystemColors.Control
        Me.SocialLabel.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SocialLabel.Location = New System.Drawing.Point(332, 497)
        Me.SocialLabel.Name = "SocialLabel"
        Me.SocialLabel.Size = New System.Drawing.Size(692, 38)
        Me.SocialLabel.TabIndex = 122
        Me.SocialLabel.Text = "シーズン２では他のハンターの矢尻を見ることができます。"
        Me.SocialLabel.UseMnemonic = False
        Me.SocialLabel.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(301, 327)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(742, 38)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "１回目の狩りでは、継承した矢尻を使うことしかできませんが、"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(332, 380)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(692, 38)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "２回目の狩りからは、矢尻をデザインすることができます。"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 750)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SocialLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HunterAppearLabel)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents HunterAppearLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SocialLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
