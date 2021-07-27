Public Class FirstSeasonExp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FirstSeasonExp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label3.Focus()

        If IfInputInitialSoc = 0 Then
            CondLabel.Text = "UIL"
        ElseIf IfInputInitialSoc = 1 Then
            CondLabel.Text = "USN"
        ElseIf IfInputInitialSoc = 2 Then
            CondLabel.Text = "USP"
        End If

        If SpeedMode = 1 Then
            CondLabel.Text = CondLabel.Text & "バグ取りモード(注意)”

        End If


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class