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

    Sub DrawPoint()
        Dim g As Graphics = DartBoardPictureBox.CreateGraphics

    End Sub

    Sub ClearBoard()

    End Sub

    Sub AppendToFile(xCoord As Single, yCoord As Single)
        FileOpen(1, "...\...\DartThrows.txt", OpenMode.Append)
        Write(1, xCoord & "," & yCoord)
    End Sub

    Private Sub DartGame_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Then
            Dim xCoord As Single = 0
            Dim yCoord As Single = 0
            Dim dartThrow As Integer

            If dartThrow = 4 Then
                dartThrow = 0
                ClearBoard()
            End If

            xCoord = GenerateRandomLocation()
            yCoord = GenerateRandomLocation()
            DrawPoint()
            AppendToFile(xCoord, yCoord)
            dartThrow += 1
        End If
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click

    End Sub

    Private Sub ReplayButton_Click(sender As Object, e As EventArgs) Handles ReplayButton.Click

    End Sub

End Class
