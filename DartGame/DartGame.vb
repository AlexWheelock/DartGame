'Alex Wheelock
'RCET 3371
'DartGame
'Fall 2024
'https://github.com/AlexWheelock/DartGame

Option Strict On
Option Explicit On

'TODO
'[X] Generate Random location
'[X] Have a turn be 3 darts then clear
'[X] Save turns to a file
'[ ] Play through those turns again using a replay mode

Public Class DartGame

    Dim previousThrows As New List(Of String)

    'Upon running the program, the previous dart throws are erased by writing nothing as OpenMode.Output.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileOpen(1, "DartThrows.txt", OpenMode.Output)
        Write(1)
        FileClose(1)
        ReadFromList(True)
    End Sub

    'Generates the x and y coordinates for the dart throw.
    Function GenerateRandomLocation() As Single
        Dim randomPoint As Single
        Randomize()
        'DartBoardPictureBox is 917x917 pixels, working for scaling both ways.
        randomPoint = Rnd() * 917

        Return randomPoint
    End Function

    'Draws the circle indicating where the dart landed.
    Sub DrawPoint(xCoord As Single, yCoord As Single)
        Dim g As Graphics = DartBoardPictureBox.CreateGraphics
        Dim pen As New Pen(Color.LimeGreen)
        pen.Width = 3
        Dim pen2 As New Pen(Color.Black)

        'Draws the green circle
        Try
            g.DrawEllipse(pen, xCoord, yCoord, 10, 10)
        Catch ex As Exception

        End Try

        'Draws the black circle for improved contrast.
        Try
            g.DrawEllipse(pen2, xCoord, yCoord, 10, 10)
        Catch ex As Exception

        End Try

        pen.Dispose()
        pen2.Dispose()
        g.Dispose()
    End Sub

    'Clears the dart throws from previous turns on DartBoardPictureBox
    Sub ClearBoard()
        DartBoardPictureBox.Refresh()
    End Sub

    'Writes the dart throw to a file in order to retrieve and replay previous turns.
    Sub AppendToFile(xCoord As Single, yCoord As Single)
        FileOpen(1, "DartThrows.txt", OpenMode.Append)
        Write(1, "^" & xCoord & "@" & yCoord & "^" & vbCrLf)
        FileClose(1)
    End Sub

    Sub ReadFromFile()
        Dim rawCoordinates As String
        Dim temp() As String
        Dim location As String

        FileOpen(1, "DartThrows.txt", OpenMode.Input)

        Do Until EOF(1)
            rawCoordinates = LineInput(1)
            temp = Split(rawCoordinates, "^")
            Try
                location = temp(1)
                Me.previousThrows.Add(location)
            Catch ex As Exception

            End Try
        Loop

        FileClose(1)

        ReadFromList(True)
    End Sub

    Function ReadFromList(restart As Boolean) As String
        Dim location As String
        Static tally As Integer

        If restart Then
            tally = 0
        Else
            Try
                location = previousThrows.Item(tally)
                tally += 1
            Catch ex As Exception
                MsgBox("There are no remaining turns to replay from. Please play more to add more turns.")
                tally = 0
            End Try
        End If

        Return location
    End Function

    Sub ThrowDart(play As Boolean)
        Dim xCoord As Single = 0
        Dim yCoord As Single = 0
        Static playThrow As Integer
        Static replayThrow As Integer
        Dim location As String
        Dim temp() As String

        If play Then
            If playThrow = 3 Then
                playThrow = 0
                ClearBoard()
            End If
            replayThrow = 0
            xCoord = GenerateRandomLocation()
            yCoord = GenerateRandomLocation()
            DrawPoint(xCoord, yCoord)
            AppendToFile(xCoord, yCoord)
            playThrow += 1
            TurnLabel.Text = ("Turn: " & playThrow & "/3")
        Else
            If replayThrow = 3 Then
                replayThrow = 0
                ClearBoard()
            End If
            playThrow = 0
            location = ReadFromList(False)
            temp = Split(location, "@")
            Try
                xCoord = CSng(temp(0))
                yCoord = CSng(temp(1))
                DrawPoint(xCoord, yCoord)
                replayThrow += 1
                TurnLabel.Text = ("Turn: " & replayThrow & "/3")
            Catch ex As Exception

            End Try
        End If
    End Sub

    'EVENT HANDLERS BELOW THIS POINT!!!

    'Put the player into the "Play" Mode where they can have new turns, returning from the "Replay" Mode.
    Private Sub PlayButton_KeyDown(sender As Object, e As KeyEventArgs) Handles PlayButton.KeyDown
        If e.KeyCode = Keys.Space Then
            ThrowDart(True)
        End If
    End Sub

    Private Sub ReplayButton_KeyDown(sender As Object, e As KeyEventArgs) Handles ReplayButton.KeyDown
        If e.KeyCode = Keys.Space Then
            ThrowDart(False)
        End If
    End Sub


    Private Sub PlayButton_GotFocus(sender As Object, e As EventArgs) Handles PlayButton.GotFocus
        ClearBoard()
        TurnLabel.Text = ("Turn: 0/3")
    End Sub

    Private Sub ReplayButton_GotFocus(sender As Object, e As EventArgs) Handles ReplayButton.GotFocus
        ClearBoard()
        TurnLabel.Text = ("Turn: 0/3")
        ReadFromFile()
    End Sub

End Class
