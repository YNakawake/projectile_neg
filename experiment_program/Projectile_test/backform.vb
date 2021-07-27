Public Class backform

    Public f0 As New config
    Public f1 As New Form1
    Private Sub backform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = False
        f0.Owner = Me
        f0.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        f1.Owner = Me
        f1.Show()
        Button1.Visible = False
    End Sub
End Class