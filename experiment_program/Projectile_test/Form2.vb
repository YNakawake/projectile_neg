Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IfInputInitialSoc = 0 Then
            SocialLabel.Visible = False
        Else
            SocialLabel.Visible = True
        End If

    End Sub

    Private Sub HunterAppearLabel_Click(sender As Object, e As EventArgs) Handles HunterAppearLabel.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class