Public Class Form1


    '0928
    ' I did not use the first item of a array e.g. AnyVector(0) for the most case, in order to avoid cofusion
    Public ALength As Integer 'Height 250 pic = 100 thus 
    Public AWidth As Integer
    Public AThick As Integer
    Public CurrentImage As Image
    Public AColour As Integer : Public AShape As Integer
    Public BoxlocationX As Integer : Public BoxlocationY As Integer

    Public CurPoint As Integer : Public PrevPoint As Integer : Public SumPoint As Integer
    Public CurPointBeforeRand As Integer
    Public MaxDays As Integer
    Public Today As Integer

    Private f1 As New FirstSeasonExp
    Private f2 As New Form2
    Private f3 As New Form3
    ' Public backf As New backform

    'constant maltiplied to each weight
    Public bWl As Double : Public bWw As Double : Public bWt As Double : Public bWs As Double

    Public Ol1 As Integer : Public Ol2 As Integer
    Public Ow1 As Integer : Public Ow2 As Integer
    Public Ot1 As Integer : Public Ot2 As Integer
    Public Season As Integer = 1


    Public Wl1 As Double : Public Wl2 As Double : Public Wl As Double
    ' Note Height and Length used interchangeably
    Public Ww1 As Double : Public Ww2 As Double : Public Ww As Double
    Public Wt1 As Double : Public Wt2 As Double : Public Wt As Double
    Public tempRnd As Double

    Public SubOptimalCoef As Double = 0.66

    Public WsValue(4) As Double
    Public WsRank(4) As Integer
    Public tempRank As Integer
    Public Ws As Double
    Public OptShapeRank(4) As Integer
    Public CurShapeRank As Integer

    Public WSum As Double
    Public OtherPlayerVal(100, 5, 7) As Integer 'OtherPlay(time, PlayNum. (0,l,w,t,s,c,sum, witherror), value

    Public ChangeRate As Double
    Public ChangeSigma As Integer

    Public OutPutFileName As String
    Public LogFileName As String
    Public TidyDataName As String

    'Public OtherPicture() As System.Windows.Forms.PictureBox
    '    Private Vallab() As System.Windows.Forms.Label

    'Private OtherPicture() As ComboBox


    'to avoid being a magic number
    Public LENGTH_INDEX As Integer = 1 : Public WIDTH_INDEX As Integer = 2
    Public THICK_INDEX As Integer = 3 : Public SHAPE_INDEX As Integer = 4 : Public COLOUR_INDEX As Integer = 5

    Public WatchArrowNumbers(4) As Integer
    Public WatchArrowDuration(4) As TimeSpan
    Public LastViewArrow As Integer

    Public OtherHunterSwitch As Integer
    Public OpenTimeStr As String
    Public CurTimeStr As String

    Public TotalChange(5) As Integer


    Public Button_TimeKeeper As New System.Diagnostics.Stopwatch()
    Public Trial_TimeKeeper As New System.Diagnostics.Stopwatch()
    Public General_TimeKeeper As New System.Diagnostics.Stopwatch()
    Public HuntDuration As New TimeSpan

    Public IfBiModal As Integer = 0

    Public ParaChangeRecorder(5) As Integer

    Public WatchHunterCost As Integer = 5

    Public ID As String
    Public Pay2See As Integer

    Public gagecounter As Integer

    Public MaxPoint As Double


    Public SocLearningMean As Integer = 10
    Public SocLearningSD As Integer = 10
    Public SocLearningDirection As Integer = 0
    Public tempSocLearDirectionRnd As Integer = 0

    Public SocLearningOppt As Integer = 1





    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        ID = IDinput
        SocLearningOppt = IfInputInitialSoc
        'SocLearningOppt = 2 '0





        IfBiModal = IfInitialBimodalInput


        Button_TimeKeeper.Restart()


        'OtherPicture = {Me.MainPictureBox1, Me.OtherPicture1, Me.OtherPicture2, Me.OtherPicture3, Me.OtherPicture4}
        HiddingLabel.Text = ""

        ' backf.Owner = Me
        ' backf.Show()
        ' Me.Owner = Nothing
        Me.TopMost = True



        Me.TopMost = False


        OpenTimeStr = Format(Now, "yyyyMMddhhmmss")
        OutPutFileName = "..\..\OutData\" & OpenTimeStr & "_" & ID & ".txt"
        FileOpen(10, OutPutFileName, OpenMode.Output)
        FileClose(10)


        TidyDataName = "..\..\OutData\" & "T" & OpenTimeStr & "_" & ID & ".txt"
        FileOpen(20, TidyDataName, OpenMode.Output)
        FileClose(20)


        LogFileName = "..\..\Log\" & OpenTimeStr & "_" & ID & ".txt"
        FileOpen(15, LogFileName, OpenMode.Output)
        Write(15, OpenTimeStr)




        ChangeSigma = 5 '5 'should be 5
        ChangeRate = 0.4

        Write(15, "Season" & Season)
        Write(15, ChangeSigma)
        Write(15, ChangeRate)



        MaxDays = 30
        MaxPoint = 1000
        bWl = 0.275
        bWw = 0.25
        bWt = 0.35
        bWs = 0.125


        Write(15, MaxDays) : Write(15, MaxPoint)
        Write(15, "weight")
        Write(15, bWl) : Write(15, bWw) : Write(15, bWt) : Write(15, bWs)


        'Ol1 = 73
        'Ol2 = 33
        'Ow1 = 21
        'Ow2 = 60
        'Ot1 = 83
        'Ot2 = 12
        'OptShapeRank = {0, 3, 2, 1, 4}

        Ol1 = 30
        Ol2 = 71
        Ow1 = 63
        Ow2 = 7
        Ot1 = 34
        Ot2 = 60
        OptShapeRank = {0, 3, 4, 2, 1}


        Write(15, ID)
        Write(15, IfInputInitialSoc)
        Write(15, SocLearningOppt)

        Write(15, IfInitialBimodalInput)
        Write(15, IfBiModal)




        Write(15, "optima")
        Write(15, Ol1) : Write(15, Ol2) : Write(15, Ow1) : Write(15, Ow2) : Write(15, Ot1) : Write(15, Ot2)

        Write(15, "Shape")


        WsValue = {0, 1, 0.9, 0.66, 0.33} 'Mesoudi(2008), Ws[rank] give you the Ws[1] =1 , Ws[2] =0.9, Ws[3] = 0.66, Ws[4] =0.33

        Write(15, WsValue(1)) : Write(15, WsValue(2)) : Write(15, WsValue(3)) : Write(15, WsValue(4))
        Write(15, OptShapeRank(1)) : Write(15, OptShapeRank(2)) : Write(15, OptShapeRank(3)) : Write(15, OptShapeRank(4))

        Today = 1
        BoxlocationX = MainPictureBox1.Location.X
        BoxlocationY = MainPictureBox1.Location.Y
        SumPoint = 0




        FileClose(15)





        'Need to be channged later
        ShapeBox.SetSelected(0, True)
        ColourBox.SetSelected(0, True)

        MainPictureBox1.Visible = False
        NextButton.Enabled = False
        CurPointValueL.Visible = False
        PointGage.Visible = False
        GageBack.Visible = False


        HeightBox.Value = 52
        WidthBox.Value = 22
        ThickBox.Value = 75
        ShapeBox.SelectedIndex = 2 - 1
        ColourBox.SelectedIndex = 3 - 1
        HeightBox.Enabled = False
        WidthBox.Enabled = False
        ThickBox.Enabled = False
        ShapeBox.Enabled = False
        ColourBox.Enabled = False


        f1.Owner = Me
        f1.Show()

        redraw()
        MainPictureBox1.Visible = False

    End Sub



    Private Sub redraw()
        MainPictureBox1.Visible = True
        AShape = ShapeBox.SelectedIndex + 1
        AColour = ColourBox.SelectedIndex + 1


        ALength = HeightBox.Value
        AWidth = WidthBox.Value
        AThick = ThickBox.Value


        If AShape = 1 Then
            If AColour = 1 Then
                CurrentImage = My.Resources._1s
            ElseIf AColour = 2 Then
                CurrentImage = My.Resources._1h
            ElseIf AColour = 3 Then
                CurrentImage = My.Resources._1o
            ElseIf AColour = 4 Then
                CurrentImage = My.Resources._1w
            End If
        ElseIf AShape = 2 Then
            If AColour = 1 Then
                CurrentImage = My.Resources._2s
            ElseIf AColour = 2 Then
                CurrentImage = My.Resources._2h
            ElseIf AColour = 3 Then
                CurrentImage = My.Resources._2o
            ElseIf AColour = 4 Then
                CurrentImage = My.Resources._2w
            End If
        ElseIf AShape = 3 Then
            If AColour = 1 Then
                CurrentImage = My.Resources._3s
            ElseIf AColour = 2 Then
                CurrentImage = My.Resources._3h
            ElseIf AColour = 3 Then
                CurrentImage = My.Resources._3o
            ElseIf AColour = 4 Then
                CurrentImage = My.Resources._3w
            End If
        ElseIf AShape = 4 Then
            If AColour = 1 Then
                CurrentImage = My.Resources._4s
            ElseIf AColour = 2 Then
                CurrentImage = My.Resources._4h
            ElseIf AColour = 3 Then
                CurrentImage = My.Resources._4o
            ElseIf AColour = 4 Then
                CurrentImage = My.Resources._4w
            End If
        End If

        MainPictureBox1.Left = BoxlocationX - AWidth + 100
        MainPictureBox1.Top = BoxlocationY - ALength + 100


        MainPictureBox1.Height = 100 + ALength * 2
        MainPictureBox1.Width = 100 + AWidth * 2
        MainPictureBox1.Image = CurrentImage
        MainPictureBox1.Visible = True





    End Sub


    Private Sub HeightBox_ValueChanged_1(sender As Object, e As EventArgs) Handles HeightBox.ValueChanged
        ' redraw()
        ParaChangeRecorder(LENGTH_INDEX) = ParaChangeRecorder(LENGTH_INDEX) + 1
        tmplabel.Text = ParaChangeRecorder(LENGTH_INDEX)
    End Sub

    Private Sub WidthBox_ValueChanged(sender As Object, e As EventArgs) Handles WidthBox.ValueChanged
        '  redraw()
    End Sub
    Private Sub ThickBox_ValueChanged(sender As Object, e As EventArgs) Handles ThickBox.ValueChanged
        ' redraw()
    End Sub


    Private Sub ShapeBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ShapeBox.SelectedIndexChanged

        'redraw()
    End Sub

    Private Sub ColourBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColourBox.SelectedIndexChanged
        'redraw()
    End Sub


    Private Sub ShowButtonClick(sender As Object, e As EventArgs) Handles ShowButton.Click
        If Today = 1 Then
            MessageLabel.Text = "「狩りに行く」を押して受け継いだ矢尻を試してみてください。"
            HuntButton.Enabled = True
        End If
        redraw()
    End Sub



    Private Sub HuntButton_Click(sender As Object, e As EventArgs) Handles HuntButton.Click
        redraw()
        ShowButton.Enabled = False
        Me.Cursor = Cursors.WaitCursor



        HuntDuration = General_TimeKeeper.Elapsed


        'HunterAppearLabel.Visible = False


        HiddingLabel.Enabled = False
        HiddingLabel.Text = ""
        HiddingLabel.BackColor = Color.Gainsboro
        HiddingLabel.Visible = True


        'CalcPoint()
        CalcPoint_f(ALength, AWidth, AThick, AShape)
        CurPointBeforeRand = CalcPoint_f(ALength, AWidth, AThick, AShape)
        CurPoint = Int(CurPointBeforeRand + rnorm(0, ChangeSigma))
        CurPoint = CeilingFloor(CurPoint)

        'CurPointValueL.Text = Str(CurPoint)
        CurPointValueL.Text = "0"
        CurPointValueL.Visible = True
        CurPointLabel.Visible = True
        CurPointLabel2.Visible = True
        'PointGage.Width = 5 * CurPoint / 10
        PointGage.Visible = True

        CurPointValueL.Visible = True
        GageBack.Visible = True
        PointGage.Visible = True

        GageTimer.Interval = 10
        GageUp()
        gagecounter = 0

        HuntButton.Enabled = False

        HeightBox.Enabled = False
        WidthBox.Enabled = False
        ThickBox.Enabled = False
        ColourBox.Enabled = False
        ShapeBox.Enabled = False
        OtherPlayers()

        MessageLabel.Text = "狩りを行っています。お待ちください。"


        If SpeedMode = 1 Then
            Timer1.Interval = 1
        Else
            Timer1.Interval = 1200
        End If
        Timer1.Enabled = True
        ' For Other Players
    End Sub


    Private Sub GageUp()


        If gagecounter < (CurPoint - 30) Then
            GageTimer.Interval = 10
            GageTimer.Enabled = True
        Else
            CurPointValueL.Text = Str(CurPoint)
            PointGage.Width = 5 * CurPoint / 10
            gagecounter = 0
        End If

    End Sub

    Private Sub GageTimer_Tick(sender As Object, e As EventArgs) Handles GageTimer.Tick
        GageTimer.Enabled = False
        Dim r As New Random

        gagecounter = gagecounter + 30
        CurPointValueL.Text = Str(Int(CurPointValueL.Text) + 30 + r.Next(1, 9))
        'CurPointValueL.Text = Str(CurPoint)
        PointGage.Width = (CurPoint Mod 30) / 2 + 5 * gagecounter / 10
        GageUp()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        PrePointLabel.Visible = False
        PrevPointValueL.Visible = False
        CurPointLabel.Visible = True
        CurPointValueL.Visible = True
        CurPointLabel2.Visible = True
        Me.Cursor = Cursors.Default
        Timer1.Enabled = False
        NextButton.Enabled = True
        NextButton.BackColor = Color.AliceBlue
        MessageLabel.Text = "今回の狩りで稼いだカロリーが下に表示されています。" & Environment.NewLine & "また、シーズンの稼いで合計のカロリーも総得点として表示されています" & Environment.NewLine & Environment.NewLine & "「次の狩りへ」を押して、矢尻のデザインを開始してください"
    End Sub





    Private Sub OtherPlayers()
        Dim j As Integer
        Dim r As New Random
        Dim changeDimention As Integer
        Dim repeater As Integer
        Dim repeatNum As Integer
        Dim repeatEnd As Integer



        Dim ary(4) As Integer
        ary = {1, 2, 3, 4}

        'Fisher-Yates, Randomly Shuffle the array {1,2,3,4}
        Dim rng As New System.Random()
        Dim n As Integer = ary.Length
        While n > 1
            n -= 1
            Dim k As Integer = rng.Next(n + 1)
            Dim tmp As Integer = ary(k)
            ary(k) = ary(n)
            ary(n) = tmp
        End While



        For i = 1 To 4
            changeDimention = ary(i - 1)
            repeatNum = 0
            repeatEnd = 0


            While repeatEnd = 0
                OtherPlayerVal(Today, i, 1) = ALength  'OtherPlay(time, PlayNum. (l,w,t,s), value
                OtherPlayerVal(Today, i, 2) = AWidth
                OtherPlayerVal(Today, i, 3) = AThick
                OtherPlayerVal(Today, i, 4) = AShape
                OtherPlayerVal(Today, i, 5) = AColour

                tempSocLearDirectionRnd = r.Next(1, 3)
                If tempSocLearDirectionRnd = 1 Then
                    SocLearningDirection = -1
                Else
                    SocLearningDirection = 1
                End If

                If changeDimention < 4 Then
                    OtherPlayerVal(Today, i, changeDimention) = OtherPlayerVal(Today, i, changeDimention) + Int(rnorm(SocLearningMean, SocLearningSD)) * SocLearningDirection
                ElseIf changeDimention = 4 Then
                    OtherPlayerVal(Today, i, changeDimention) = r.Next(1, 5) 'randomly chose shape
                Else
                    OtherPlayerVal(Today, i, changeDimention) = r.Next(1, 5) 'randomly chose color
                End If

                For j = 1 To 3
                    If OtherPlayerVal(Today, i, j) > 100 Then
                        OtherPlayerVal(Today, i, j) = 100
                    ElseIf OtherPlayerVal(Today, i, j) < 1 Then
                        OtherPlayerVal(Today, i, j) = 1
                    End If
                Next j

                OtherPlayerVal(Today, i, 6) = CalcPoint_f(OtherPlayerVal(Today, i, 1), OtherPlayerVal(Today, i, 2), OtherPlayerVal(Today, i, 3), OtherPlayerVal(Today, i, 4))
                OtherPlayerVal(Today, i, 7) = OtherPlayerVal(Today, i, 6) + Int(rnorm(0, ChangeSigma))


                OtherPlayerVal(Today, i, 7) = CeilingFloor(OtherPlayerVal(Today, i, 7))

                ' If OtherPlayerVal(Today, i, 6) > CurPointBeforeRand Or OtherPlayerVal(Today, i, 7) > CurPoint Then


                If SocLearningOppt = 1 Then 'negatinve
                    If OtherPlayerVal(Today, i, 7) < CurPoint Then
                        If OtherPlayerVal(Today, i, 6) < CurPointBeforeRand Then
                            repeatEnd = 1
                        End If
                    End If
                Else 'positive
                    If OtherPlayerVal(Today, i, 7) > CurPoint Then
                        If OtherPlayerVal(Today, i, 6) > CurPointBeforeRand Then
                            repeatEnd = 1
                        End If
                    End If
                End If




                If repeatNum > 10000 Then
                    If SocLearningOppt = 1 Then 'negatinve
                        If OtherPlayerVal(Today, i, 7) <= CurPoint Then
                            If OtherPlayerVal(Today, i, 6) <= CurPointBeforeRand Then
                                repeatEnd = 1
                            End If
                        End If

                    Else
                        If OtherPlayerVal(Today, i, 7) >= CurPoint Then
                            If OtherPlayerVal(Today, i, 6) >= CurPointBeforeRand Then
                                repeatEnd = 1
                            End If
                        End If


                    End If

                End If


                If repeatNum > 100000 Then
                    OtherPlayerVal(Today, i, 1) = ALength  'OtherPlay(time, PlayNum. (l,w,t,s), value
                    OtherPlayerVal(Today, i, 2) = AWidth
                    OtherPlayerVal(Today, i, 3) = AThick
                    OtherPlayerVal(Today, i, 4) = AShape
                    OtherPlayerVal(Today, i, 5) = AColour
                    OtherPlayerVal(Today, i, 6) = CurPoint
                    OtherPlayerVal(Today, i, 7) = CurPointBeforeRand
                    repeatEnd = 1
                End If

                repeatNum = repeatNum + 1
            End While

        Next i
        'End If

        Dim sizev As Double
        sizev = 0.666

        OtherPicture1.Height = (100 + OtherPlayerVal(Today, 1, 1)) * sizev
        OtherPicture1.Width = (100 + OtherPlayerVal(Today, 1, 2)) * sizev
        Vallab11.Text = OtherPlayerVal(Today, 1, 1)
        Vallab12.Text = OtherPlayerVal(Today, 1, 2)
        Vallab13.Text = OtherPlayerVal(Today, 1, 3)
        Vallab14.Text = OtherPlayerVal(Today, 1, 4)
        Vallab15.Text = OtherPlayerVal(Today, 1, 5)
        Vallab16.Text = OtherPlayerVal(Today, 1, 7)
        OtherPicture1.Image = GetPicture(OtherPlayerVal(Today, 1, 4), OtherPlayerVal(Today, 1, 5))





        OtherPicture2.Height = (100 + OtherPlayerVal(Today, 2, 1)) * sizev
        OtherPicture2.Width = (100 + OtherPlayerVal(Today, 2, 2)) * sizev
        Vallab21.Text = OtherPlayerVal(Today, 2, 1)
        Vallab22.Text = OtherPlayerVal(Today, 2, 2)
        Vallab23.Text = OtherPlayerVal(Today, 2, 3)
        Vallab24.Text = OtherPlayerVal(Today, 2, 4)
        Vallab25.Text = OtherPlayerVal(Today, 2, 5)
        Vallab26.Text = OtherPlayerVal(Today, 2, 7)
        OtherPicture2.Image = GetPicture(OtherPlayerVal(Today, 2, 4), OtherPlayerVal(Today, 2, 5))



        OtherPicture3.Height = (100 + OtherPlayerVal(Today, 3, 1)) * sizev
        OtherPicture3.Width = (100 + OtherPlayerVal(Today, 3, 2)) * sizev
        Vallab31.Text = OtherPlayerVal(Today, 3, 1)
        Vallab32.Text = OtherPlayerVal(Today, 3, 2)
        Vallab33.Text = OtherPlayerVal(Today, 3, 3)
        Vallab34.Text = OtherPlayerVal(Today, 3, 4)
        Vallab35.Text = OtherPlayerVal(Today, 3, 5)
        Vallab36.Text = OtherPlayerVal(Today, 3, 7)
        OtherPicture3.Image = GetPicture(OtherPlayerVal(Today, 3, 4), OtherPlayerVal(Today, 3, 5))


        OtherPicture4.Height = (100 + OtherPlayerVal(Today, 4, 1)) * sizev
        OtherPicture4.Width = (100 + OtherPlayerVal(Today, 4, 2)) * sizev
        Vallab41.Text = OtherPlayerVal(Today, 4, 1)
        Vallab42.Text = OtherPlayerVal(Today, 4, 2)
        Vallab43.Text = OtherPlayerVal(Today, 4, 3)
        Vallab44.Text = OtherPlayerVal(Today, 4, 4)
        Vallab45.Text = OtherPlayerVal(Today, 4, 5)
        Vallab46.Text = OtherPlayerVal(Today, 4, 7)
        OtherPicture4.Image = GetPicture(OtherPlayerVal(Today, 4, 4), OtherPlayerVal(Today, 4, 5))

        Dim DefaultFont = New Font(Vallab11.Font.FontFamily, 14, FontStyle.Regular)
        Dim ChangeFont = New Font(Vallab11.Font.FontFamily, 15, FontStyle.Bold)

        If Vallab11.Text <> ALength Then Vallab11.ForeColor = Color.Red : Vallab11.Font = ChangeFont Else Vallab11.ForeColor = Color.Black : Vallab11.Font = DefaultFont
        If Vallab12.Text <> AWidth Then Vallab12.ForeColor = Color.Red : Vallab12.Font = ChangeFont Else Vallab12.ForeColor = Color.Black : Vallab12.Font = DefaultFont
        If Vallab13.Text <> AThick Then Vallab13.ForeColor = Color.Red : Vallab13.Font = ChangeFont Else Vallab13.ForeColor = Color.Black : Vallab13.Font = DefaultFont
        If Vallab14.Text <> AShape Then Vallab14.ForeColor = Color.Red : Vallab14.Font = ChangeFont Else Vallab14.ForeColor = Color.Black : Vallab14.Font = DefaultFont

        If Vallab21.Text <> ALength Then Vallab21.ForeColor = Color.Red : Vallab21.Font = ChangeFont Else Vallab21.ForeColor = Color.Black : Vallab21.Font = DefaultFont
        If Vallab22.Text <> AWidth Then Vallab22.ForeColor = Color.Red : Vallab22.Font = ChangeFont Else Vallab22.ForeColor = Color.Black : Vallab22.Font = DefaultFont
        If Vallab23.Text <> AThick Then Vallab23.ForeColor = Color.Red : Vallab23.Font = ChangeFont Else Vallab23.ForeColor = Color.Black : Vallab23.Font = DefaultFont
        If Vallab24.Text <> AShape Then Vallab24.ForeColor = Color.Red : Vallab24.Font = ChangeFont Else Vallab24.ForeColor = Color.Black : Vallab24.Font = DefaultFont

        If Vallab31.Text <> ALength Then Vallab31.ForeColor = Color.Red : Vallab31.Font = ChangeFont Else Vallab31.ForeColor = Color.Black : Vallab31.Font = DefaultFont
        If Vallab32.Text <> AWidth Then Vallab32.ForeColor = Color.Red : Vallab32.Font = ChangeFont Else Vallab32.ForeColor = Color.Black : Vallab32.Font = DefaultFont
        If Vallab33.Text <> AThick Then Vallab33.ForeColor = Color.Red : Vallab33.Font = ChangeFont Else Vallab33.ForeColor = Color.Black : Vallab33.Font = DefaultFont
        If Vallab34.Text <> AShape Then Vallab34.ForeColor = Color.Red : Vallab34.Font = ChangeFont Else Vallab34.ForeColor = Color.Black : Vallab34.Font = DefaultFont

        If Vallab41.Text <> ALength Then Vallab41.ForeColor = Color.Red : Vallab41.Font = ChangeFont Else Vallab41.ForeColor = Color.Black : Vallab41.Font = DefaultFont
        If Vallab42.Text <> AWidth Then Vallab42.ForeColor = Color.Red : Vallab42.Font = ChangeFont Else Vallab42.ForeColor = Color.Black : Vallab42.Font = DefaultFont
        If Vallab43.Text <> AThick Then Vallab43.ForeColor = Color.Red : Vallab43.Font = ChangeFont Else Vallab43.ForeColor = Color.Black : Vallab43.Font = DefaultFont
        If Vallab44.Text <> AShape Then Vallab44.ForeColor = Color.Red : Vallab44.Font = ChangeFont Else Vallab44.ForeColor = Color.Black : Vallab44.Font = DefaultFont




    End Sub
    Function GetPicture(ByVal tAShape As Integer, tAColour As Integer)
        Dim tempImage As Image
        If tAShape = 1 Then
            If tAColour = 1 Then
                tempImage = My.Resources._1s
            ElseIf tAColour = 2 Then
                tempImage = My.Resources._1h
            ElseIf tAColour = 3 Then
                tempImage = My.Resources._1o
            ElseIf tAColour = 4 Then
                tempImage = My.Resources._1w
            End If
        ElseIf tAShape = 2 Then
            If tAColour = 1 Then
                tempImage = My.Resources._2s
            ElseIf tAColour = 2 Then
                tempImage = My.Resources._2h
            ElseIf tAColour = 3 Then
                tempImage = My.Resources._2o
            ElseIf tAColour = 4 Then
                tempImage = My.Resources._2w
            End If
        ElseIf tAShape = 3 Then
            If tAColour = 1 Then
                tempImage = My.Resources._3s
            ElseIf tAColour = 2 Then
                tempImage = My.Resources._3h
            ElseIf tAColour = 3 Then
                tempImage = My.Resources._3o
            ElseIf tAColour = 4 Then
                tempImage = My.Resources._3w
            End If
        ElseIf tAShape = 4 Then
            If tAColour = 1 Then
                tempImage = My.Resources._4s
            ElseIf tAColour = 2 Then
                tempImage = My.Resources._4h
            ElseIf tAColour = 3 Then
                tempImage = My.Resources._4o
            ElseIf tAColour = 4 Then
                tempImage = My.Resources._4w
            End If
        End If

        Return tempImage
    End Function



    'Sub CalcPoint()

    '    Wl1 = exp_distance(ALength, Ol1)
    '    Wl2 = SuboptimalCoef * exp_distance(ALength, Ol2)
    '    Wl = Math.Max(Wl1, Wl2)

    '    Ww1 = exp_distance(AWidth, Ow1)
    '    Ww2 = SuboptimalCoef * exp_distance(AWidth, Ow2)
    '    Ww = Math.Max(Ww1, Ww2)


    '    Wt1 = exp_distance(AThick, Ot1)
    '    Wt2 = SuboptimalCoef * exp_distance(AThick, Ot2)
    '    Wt = Math.Max(Wt1, Wt2)


    '    Ws = 0.25 * OptShapeRank(AShape)
    '    tempRank = OptShapeRank(AShape)
    '    Ws = WsValue(tempRank)

    '    Ws = WsValue[AShape]
    '    tempRnd = rnorm(0, 5)

    '    WSum = 1000 * ((bWl * Wl) + (bWw * Ww) + (bWt * Wt) + (bWs * Ws)) + tempRnd

    '    CurPoint = Int(WSum) '= 3 * ALength + 2 * AWidth + AThick + 100 * AShape

    '    Label1.Text = Ww1 & Ww2 & Ww

    'End Sub
    Function CalcPoint_f(ByVal Alengthv As Double, AWidthv As Double, AThickv As Integer, Ashapev As Integer)
        Dim tWl1, tWl2, tWl, tWw1, tWw2, tWw, tWt1, tWt2, tWt, tWs As Double
        Dim tSum As Double

        tWl1 = exp_distance(Alengthv, Ol1)
        tWl2 = SubOptimalCoef * exp_distance(Alengthv, Ol2)
        tWl = Math.Max(tWl1, tWl2)

        tWw1 = exp_distance(AWidthv, Ow1)
        tWw2 = SubOptimalCoef * exp_distance(AWidthv, Ow2)
        tWw = Math.Max(tWw1, tWw2)


        tWt1 = exp_distance(AThickv, Ot1)
        tWt2 = SubOptimalCoef * exp_distance(AThickv, Ot2)

        If IfBiModal = 1 Then
            tWl = Math.Max(tWl1, tWl2)
            tWw = Math.Max(tWw1, tWw2)
            tWt = Math.Max(tWt1, tWt2)
        Else
            tWl = tWl1
            tWw = tWw1
            tWt = tWt1
        End If

        Dim temprank As Integer
        For i As Integer = 1 To 4
            If OptShapeRank(i) = Ashapev Then
                temprank = i
            End If
        Next

        ' tWs = 0.25 * Ashapev
        ' tempRank = OptShapeRank(Ashapev)
        tWs = WsValue(temprank)

        ' Ws = WsValue[AShape]


        tSum = 1000 * ((bWl * tWl) + (bWw * tWw) + (bWt * tWt) + (bWs * tWs))
        Return Int(tSum)

    End Function




    Function CeilingFloor(ByVal indata As Integer)
        Dim tempCFNum As Integer

        If indata > 1000 Then
            tempCFNum = 1000
        ElseIf indata < 1 Then
            tempCFNum = 0
        Else
            tempCFNum = indata
        End If
        Return (tempCFNum)
    End Function





    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        Me.Cursor = Cursors.WaitCursor
        WriteText()
        NextButton.BackColor = Color.White
        OtherHunterSwitch = 0
        LastViewArrow = 0
        Pay2See = 0

        LeftDayValueL.Text = MaxDays - Today
        Today = Today + 1

        PrevPointValueL.Text = CurPoint
        SumPoint = SumPoint + CurPoint
        SumPointValueL.Text = SumPoint

        NextButton.Enabled = False
        PrePointLabel.Visible = False
        PrevPointValueL.Visible = False
        CurPointLabel.Visible = True
        CurPointValueL.Visible = True
        CurPointLabel2.Visible = True


        If SpeedMode = 1 Then
            NextRoundTeller.Interval = 1
        Else
            NextRoundTeller.Interval = 1000
        End If
        NextRoundTeller.Enabled = True
        MessageLabel.Text = "次の狩りの準備中です。少々お待ちください。”


    End Sub



    Private Sub NextRoundTeller_Tick(sender As Object, e As EventArgs) Handles NextRoundTeller.Tick
        Me.Cursor = Cursors.Default
        NextRoundTeller.Enabled = False



        NextButton.Enabled = False
        PrePointLabel.Visible = True
        PrevPointValueL.Visible = True
        CurPointLabel.Visible = False
        CurPointValueL.Visible = False
        CurPointLabel2.Visible = False
        CurPointValueL.Visible = False

        GageBack.Visible = False
        PointGage.Visible = False

        MessageLabel.Text = "長さ・幅広さ・厚さ・形・色を変更できます。" & Environment.NewLine & Environment.NewLine & "「矢尻を表示」を押すとデザインを確認できます。" &
            Environment.NewLine & Environment.NewLine & "準備ができたら「狩りに行く」を押してください。"

        HuntButton.Enabled = True
        ShowButton.Enabled = True

        HeightBox.Enabled = True
        WidthBox.Enabled = True
        ThickBox.Enabled = True
        ColourBox.Enabled = True
        ShapeBox.Enabled = True

        If Season > 1 Then

            If SocLearningOppt > 0 Then

                If Today Mod 3 = 0 Then

                    If Season = 99 Then
                        HiddingLabel.Text = "5カロリーを払って他のハンターの矢尻を見に行く"
                        HiddingLabel.BackColor = Color.LightBlue
                        HiddingLabel.Enabled = True
                        MessageLabel.Text = "ハンターがやってきました。5カロリーを払い、矢尻を見るには画面右側をクリックしてください。"
                    Else
                        HiddingLabel.Visible = False
                        MessageLabel.Text = "他のハンターがやってきました。他のハンターの矢尻を観察しながら矢尻をデザインできます（クリックで観察）。" & Environment.NewLine & Environment.NewLine & "前回のあなたの矢尻と変化している数値を強調しています"

                    End If
                    'MsgBox("他のハンターがやってきました。他のハンターの矢尻を観察することができます。")
                    MessageLabel.Visible = True
                    OtherHunterSwitch = 1

                End If
            End If
        End If






        'Reset Value

        For cPlayer As Integer = 1 To 4
            WatchArrowDuration(cPlayer) = Nothing
            WatchArrowNumbers(cPlayer) = Nothing
        Next

        If Today = MaxDays + 1 Then
            Today = 1
            Season = Season + 1
            SeasonLabel.Text = Season

            CurPointValueL.Text = "0"
            CurPoint = 0
            PrevPointValueL.Text = CurPoint

            NextSeason()

            SumPoint = 0
            SumPointValueL.Text = SumPoint
        End If
    End Sub


    Private Sub NextSeason()
        If Season = 2 Then
            Season1Score = SumPoint

            SocLearningOppt = IfInputInitialSoc
            Ol1 = 36
            Ol2 = 76
            Ow1 = 4
            Ow2 = 85
            Ot1 = 57
            Ot2 = 26
            OptShapeRank = {0, 1, 2, 3, 4}


            f2.Owner = Me
            f2.Show()


            HeightBox.Value = 58
            WidthBox.Value = 73
            ThickBox.Value = 82
            ShapeBox.SelectedIndex = 3 - 1
            ColourBox.SelectedIndex = 1 - 1
            HeightBox.Enabled = False
            WidthBox.Enabled = False
            ThickBox.Enabled = False
            ShapeBox.Enabled = False
            ColourBox.Enabled = False
            HuntButton.Enabled = False


            MessageLabel.Text = "「矢尻を表示」ボタンを押し、受け継いだ矢尻を確認してください"
            MainPictureBox1.Visible = False
        ElseIf Season = 3 Then

            Season2Score = SumPoint
            Ol1 = 39
            Ol2 = 9
            Ow1 = 17
            Ow2 = 91
            Ot1 = 84
            Ot2 = 50
            OptShapeRank = {0, 1, 3, 2, 4}



            HeightBox.Value = 61
            WidthBox.Value = 79
            ThickBox.Value = 38
            ShapeBox.SelectedIndex = 2 - 1
            ColourBox.SelectedIndex = 1 - 1
            HeightBox.Enabled = False
            WidthBox.Enabled = False
            ThickBox.Enabled = False
            ShapeBox.Enabled = False
            ColourBox.Enabled = False



            f3.Owner = Me
            f3.Show()
            HuntButton.Enabled = False


            MessageLabel.Text = "「矢尻を表示」ボタンを押し、受け継いだ矢尻を確認してください"
            MainPictureBox1.Visible = False

        ElseIf Season = 4 Then

            Season3Score = SumPoint
            Dim EarnedMoney As Integer
            EarnedMoney = (((Season1Score + Season2Score + Season3Score) / 3) / MaxDays) / 10
            EarnedMoney = EarnedMoney * 10

            MessageLabel.Text = WatchHunterCost & "各シーズンの最初の１回だけはデザインせず、受け継いだ矢尻で狩りに行ってください"
            MessageLabel.Text = WatchHunterCost & "実験終了です、ありがとうございました。実験者が来るまでお待ちください” & "S1:" & Season1Score & ", S2:" & Season2Score & ", S3:" & Season3Score &
                Environment.NewLine & Environment.NewLine & "追加金額" & EarnedMoney &
                Environment.NewLine & Environment.NewLine & "合計金額" & (EarnedMoney + 700)

            Me.BackColor = Color.AliceBlue


            FileOpen(10, OutPutFileName, OpenMode.Append)
            Write(10, EarnedMoney)
            FileClose(10)


            FileOpen(15, LogFileName, OpenMode.Append)
            Write(15, EarnedMoney)
            FileClose(15)


            FileOpen(20, TidyDataName, OpenMode.Append)
            Write(20, EarnedMoney)
            FileClose(20)



            HeightBox.Enabled = False
            WidthBox.Enabled = False
            ThickBox.Enabled = False
            ShapeBox.Enabled = False
            ColourBox.Enabled = False
            HuntButton.Enabled = False
            ShowButton.Enabled = False


        End If
    End Sub


    Private Sub WriteText()


        FileOpen(10, OutPutFileName, OpenMode.Append)


        'Write(10, "Ind") : Write(10, Season) :Write(10, Today)
        Write(10, "Ind") : Write(10, ID) : Write(10, Season) : Write(10, SocLearningOppt) : Write(10, IfBiModal) : Write(10, Today)
        Write(10, ALength) : Write(10, AWidth) : Write(10, AThick) : Write(10, AShape) : Write(10, AColour)
        Write(10, CurPointBeforeRand) : Write(10, CurPoint)
        Write(10, "Soc") : Write(10, OtherHunterSwitch)




        For cPlayer As Integer = 1 To 4
            Write(10, cPlayer)
            For cDimention As Integer = 1 To 7
                Write(10, OtherPlayerVal(Today, cPlayer, cDimention))
            Next
        Next

        For cPlayer As Integer = 1 To 4
            Write(10, WatchArrowDuration(cPlayer).TotalSeconds.ToString("0.00"))
        Next

        For cPlayer As Integer = 1 To 4
            Write(10, WatchArrowNumbers(cPlayer))
        Next

        Write(10, LastViewArrow)
        Write(10, Pay2See)
        Write(10, HuntDuration.TotalSeconds.ToString("0.00"))


        CurTimeStr = Format(Now, "yyyyMMddhhmmss")
        Write(10, CurTimeStr)


        FileClose(10)












    End Sub

    Private Sub PointGage_Click(sender As Object, e As EventArgs) Handles PointGage.Click

    End Sub
    'rnorm

    Private Function exp_distance(ByVal X As Integer, ByVal O As Integer) As Double
        Dim ans As Double
        Dim sigma As Double
        Dim dist As Double
        dist = (-1) * ((X / 100) - (O / 100)) ^ 2
        sigma = 0.035

        ans = Math.Exp(dist / (2 * sigma))
        Return ans
    End Function


    'Box-Muller
    Private Function rnorm(ByVal mean As Double, ByVal sd As Double) As Double
        Dim alpha As Double
        Dim beta As Double
        Dim x As Double
        alpha = Rnd()
        beta = Rnd()
        x = Math.Sqrt(-2 * Math.Log(alpha)) * Math.Sin(2 * Math.PI * beta)
        x = sd * x + mean
        Return x
    End Function





    Private Sub Hide1_MouseDown(sender As Object, e As MouseEventArgs) Handles Hide1.MouseDown
        Hide1.Visible = False
        WatchArrowNumbers(1) = WatchArrowNumbers(1) + 1
        Button_TimeKeeper.Restart()
    End Sub

    Private Sub Hide1_MouseUp(sender As Object, e As MouseEventArgs) Handles Hide1.MouseUp
        Hide1.Visible = True
        LastViewArrow = 1
        Button_TimeKeeper.Stop()
        WatchArrowDuration(1) = WatchArrowDuration(1) + Button_TimeKeeper.Elapsed
        tmplabel.Text = WatchArrowDuration(1).TotalSeconds.ToString("0.00")
        tmplabel2.Text = Str(WatchArrowNumbers(1))
    End Sub

    Private Sub Hide2_MouseDown(sender As Object, e As MouseEventArgs) Handles Hide2.MouseDown
        Hide2.Visible = False
        LastViewArrow = 2
        WatchArrowNumbers(2) = WatchArrowNumbers(2) + 1
        Button_TimeKeeper.Restart()
    End Sub

    Private Sub Hide2_MouseUp(sender As Object, e As MouseEventArgs) Handles Hide2.MouseUp
        Hide2.Visible = True
        Button_TimeKeeper.Stop()
        WatchArrowDuration(2) = WatchArrowDuration(2) + Button_TimeKeeper.Elapsed
        tmplabel.Text = WatchArrowDuration(2).TotalSeconds
        tmplabel2.Text = Str(WatchArrowNumbers(2))
    End Sub
    Private Sub Hide3_MouseDown(sender As Object, e As MouseEventArgs) Handles Hide3.MouseDown
        Hide3.Visible = False
        LastViewArrow = 3
        WatchArrowNumbers(3) = WatchArrowNumbers(3) + 1
        Button_TimeKeeper.Restart()

    End Sub
    Private Sub Hide3_MouseUp(sender As Object, e As MouseEventArgs) Handles Hide3.MouseUp
        Hide3.Visible = True
        WatchArrowDuration(3) = WatchArrowDuration(3) + Button_TimeKeeper.Elapsed
        tmplabel.Text = WatchArrowDuration(3).TotalSeconds
    End Sub
    Private Sub Hide4_MouseDown(sender As Object, e As MouseEventArgs) Handles Hide4.MouseDown
        Hide4.Visible = False
        LastViewArrow = 4
        WatchArrowNumbers(4) = WatchArrowNumbers(4) + 1
        Button_TimeKeeper.Restart()
    End Sub
    Private Sub Hide4_MouseUp(sender As Object, e As MouseEventArgs) Handles Hide4.MouseUp
        Hide4.Visible = True
        WatchArrowDuration(4) = WatchArrowDuration(4) + Button_TimeKeeper.Elapsed
        tmplabel.Text = WatchArrowDuration(4).TotalSeconds
    End Sub

    Private Sub MainPictureBox1_Click(sender As Object, e As EventArgs) Handles MainPictureBox1.Click

    End Sub

    Private Sub HiddingLabel_Click(sender As Object, e As EventArgs) Handles HiddingLabel.Click

        'If Season = 3 Then
        '    Pay2See = 1
        '    If OtherHunterSwitch = 1 Then
        '        HiddingLabel.Visible = False
        '        HunterAppearLabel.Text = "5ポイントを消費しました"
        '    End If
        '    SumPoint = SumPoint - 5
        '    SumPointValueL.Text = SumPoint
        'End If
    End Sub

    Private Sub MessageLabel_Click(sender As Object, e As EventArgs) Handles MessageLabel.Click

    End Sub











    'Private Function OtherPicture(ByVal index As Integer) As PictureBox
    '    Return DirectCast(Me.Controls("OtherPicture" & 2), PictureBox)
    'End Function
    'Private Function Vallab(ByVal Hunter As Integer, ByVal Dimention As Integer) As Label
    '    Return DirectCast(Me.Controls("Vallab" & Hunter.ToString & Dimention.ToString), Label)
    'End Function


End Class
