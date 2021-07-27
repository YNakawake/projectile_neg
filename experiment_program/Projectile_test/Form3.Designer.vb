<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.SocialLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HunterAppearLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Button1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(418, 620)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(500, 54)
        Me.Button1.TabIndex = 128
        Me.Button1.Text = "あなたの家系の矢尻を継承し、狩りの旅に出る"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'SocialLabel
        '
        Me.SocialLabel.AutoSize = True
        Me.SocialLabel.BackColor = System.Drawing.SystemColors.Control
        Me.SocialLabel.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SocialLabel.Location = New System.Drawing.Point(332, 395)
        Me.SocialLabel.Name = "SocialLabel"
        Me.SocialLabel.Size = New System.Drawing.Size(683, 38)
        Me.SocialLabel.TabIndex = 133
        Me.SocialLabel.Text = "シーズン3では他のハンターの矢尻を見ることができます。"
        Me.SocialLabel.UseMnemonic = False
        Me.SocialLabel.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(514, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(252, 72)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "シーズン3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(319, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(692, 38)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "（そのため、新たな矢尻のデザインを探す必要があります）"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(303, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(692, 38)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "シーズンが変わると、狩場を移動するため環境が変わります"
        '
        'HunterAppearLabel
        '
        Me.HunterAppearLabel.AutoSize = True
        Me.HunterAppearLabel.BackColor = System.Drawing.SystemColors.Control
        Me.HunterAppearLabel.Font = New System.Drawing.Font("メイリオ", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HunterAppearLabel.Location = New System.Drawing.Point(380, 145)
        Me.HunterAppearLabel.Name = "HunterAppearLabel"
        Me.HunterAppearLabel.Size = New System.Drawing.Size(524, 38)
        Me.HunterAppearLabel.TabIndex = 129
        Me.HunterAppearLabel.Text = "シーズン2が終わり、シーズン3へと移ります"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 750)
        Me.Controls.Add(Me.SocialLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HunterAppearLabel)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents SocialLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents HunterAppearLabel As Label
End Class
