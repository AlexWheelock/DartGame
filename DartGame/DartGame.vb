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

    Sub GenerateRandomLocation(xCoord As Single, yCoord As Single)

        Randomize()
        xCoord = (Rnd() * 917)
        yCoord = (Rnd() * 917)
    End Sub

    Private Sub DartGame_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Then
            GenerateRandomLocation(0, 0)

        End If
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click

    End Sub

    Private Sub ReplayButton_Click(sender As Object, e As EventArgs) Handles ReplayButton.Click

    End Sub

End Class
