Public Class config
    ' Public form1_exp As New FirstSeasonExp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IDinput = TextBox1.Text

        If IndButton.Checked = True Then
            IfInputInitialSoc = 0
        ElseIf SocNegButton.Checked = True Then
            IfInputInitialSoc = 1
        ElseIf SocPosiButton.Checked = True Then
            IfInputInitialSoc = 2
        End If

        If UniButton.Checked = True Then
            IfInitialBimodalInput = 0
        Else
            IfInitialBimodalInput = 1
        End If


        If SppedButton.Checked = True Then

            SpeedMode = 1
        Else
            SpeedMode = 0
        End If

        Me.TopMost = False
        ' form1_exp.Owner = Me
        'form1_exp.Show()
        Me.Close()
    End Sub

    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SocPosiButton_CheckedChanged(sender As Object, e As EventArgs) Handles SocPosiButton.CheckedChanged

    End Sub

    Private Sub SocNegButton_CheckedChanged(sender As Object, e As EventArgs) Handles SocNegButton.CheckedChanged

    End Sub

    Private Sub IndButton_CheckedChanged(sender As Object, e As EventArgs) Handles IndButton.CheckedChanged

    End Sub
End Class