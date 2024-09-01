'Alex Wheelock
'RCET 3371
'DartGame
'Fall 2024
'https://github.com/AlexWheelock/DartGame

Option Strict On
Option Explicit On

'TODO
'[X] Generate Random location
'[ ] Have a turn be 3 darts then clear
'[ ] Save turns to a file
'[ ] Play through those turns again using a replay mode

Public Class DartGame

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Function GenerateRandomLocation() As Single
        Dim randomPoint As Single
        Randomize()
        randomPoint = Rnd() * 917

        Return randomPoint
    End Function

    Sub DrawPoint(xCoord As Single, yCoord As Single)
        Dim g As Graphics = DartBoardPictureBox.CreateGraphics
        Dim pen As New Pen(Color.LimeGreen)
        pen.Width = 3
        Dim pen2 As New Pen(Color.Black)

        Try
            g.DrawEllipse(pen, xCoord, yCoord, 10, 10)
        Catch ex As Exception

        End Try

        Try
            g.DrawEllipse(pen2, xCoord, yCoord, 10, 10)
        Catch ex As Exception

        End Try

        pen.Dispose()
        pen2.Dispose()
        g.Dispose()
    End Sub

    Sub ClearBoard()
        DartBoardPictureBox.Refresh()
    End Sub

    Sub AppendToFile(xCoord As Single, yCoord As Single)
        FileOpen(1, "DartThrows.txt", OpenMode.Append)
        Write(1, xCoord & "," & yCoord)
        FileClose(1)
    End Sub



    Private Sub DartGame_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Space Then
        '    Dim xCoord As Single = 0
        '    Dim yCoord As Single = 0
        '    Dim dartThrow As Integer

        '    If dartThrow = 4 Then
        '        dartThrow = 0
        '        ClearBoard()
        '    End If

        '    xCoord = GenerateRandomLocation()
        '    yCoord = GenerateRandomLocation()
        '    DrawPoint(xCoord, yCoord)
        '    AppendToFile(xCoord, yCoord)
        '    dartThrow += 1
        'End If
    End Sub



    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click


    End Sub

    Private Sub ReplayButton_Click(sender As Object, e As EventArgs) Handles ReplayButton.Click

    End Sub

    Private Sub PlayButton_KeyDown(sender As Object, e As KeyEventArgs) Handles PlayButton.KeyDown
        If e.KeyCode = Keys.Space Then
            Dim xCoord As Single = 0
            Dim yCoord As Single = 0
            Static dartThrow As Integer

            If dartThrow = 3 Then
                dartThrow = 0
                ClearBoard()
            End If

            xCoord = GenerateRandomLocation()
            yCoord = GenerateRandomLocation()
            DrawPoint(xCoord, yCoord)
            AppendToFile(xCoord, yCoord)
            dartThrow += 1
        End If
    End Sub

    Private Sub ReplayButton_KeyDown(sender As Object, e As KeyEventArgs) Handles ReplayButton.KeyDown
        If e.KeyCode = Keys.Space Then
            Dim xCoord As Single = 0
            Dim yCoord As Single = 0
            Static dartThrow As Integer

            If dartThrow = 3 Then
                dartThrow = 0
                ClearBoard()
            End If

            xCoord = GenerateRandomLocation()
            yCoord = GenerateRandomLocation()
            DrawPoint(xCoord, yCoord)
            AppendToFile(xCoord, yCoord)
            dartThrow += 1
        End If
    End Sub
End Class
