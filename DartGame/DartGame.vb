'Alex Wheelock
'RCET 3371
'DartGame
'Fall 2024
'https://github.com/AlexWheelock/DartGame

Option Strict On
Option Explicit On

'TODO
'[X] Generate Random dart location
'[X] Have a turn be 3 darts then clear
'[X] Save turns to a file
'[X] Play through those turns again using a replay mode

Public Class DartGame

    'list used to store previous throws when replay mode is active
    Dim previousThrows As New List(Of String)

    'Upon running the program, the previous dart throws are erased by writing nothing as OpenMode.Output.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileOpen(1, "DartThrows.txt", OpenMode.Output)
        Write(1)
        FileClose(1)
        ReadFromList(True)
    End Sub

    'Generates the random x and y coordinates for the dart throw.
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

    'Writes the dart throw to a file in order to retrieve later in "Replay" mode
    Sub AppendToFile(xCoord As Single, yCoord As Single)
        FileOpen(1, "DartThrows.txt", OpenMode.Append)
        Write(1, "^" & xCoord & "@" & yCoord & "^" & vbCrLf)
        FileClose(1)
    End Sub

    'Reads from the DartThrows.txt file when replay mode is entered in order to repopulate previousThrows list
    Sub ReadFromFile()
        Dim rawCoordinates As String
        Dim temp() As String
        Dim location As String

        FileOpen(1, "DartThrows.txt", OpenMode.Input)

        Do Until EOF(1)
            'Cleans up the strings so that they are easier to manipulate later
            rawCoordinates = LineInput(1)
            temp = Split(rawCoordinates, "^")
            Try
                location = temp(1)
                Me.previousThrows.Add(location)
            Catch ex As Exception

            End Try
        Loop

        FileClose(1)

        'Clears the tally in order to start from the beginning of the list when throwing in "Replay" mode
        ReadFromList(True)
    End Sub

    'Fetches previous coordinates from the previousThrows list when throwing darts in the replay mode
    Function ReadFromList(restart As Boolean) As String
        Dim location As String
        Static tally As Integer

        'Clears the tally when leaving/entering replay mode so that it restarts from the beginning each time
        If restart Then
            tally = 0
        Else
            'Fetches the previously thrown coordinates. If calls (tally) are greater than items in the list then it gives the user a message and resets tally
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

    'Handles the dart throwing when a dart is thrown by pressing the spacebar in either mode.
    'play as true indicates "Play" mode, false indicates "Replay" mode.
    Sub ThrowDart(play As Boolean)
        Dim xCoord As Single = 0
        Dim yCoord As Single = 0
        Static playThrow As Integer     'Tally for darts thrown in current turn
        Static replayThrow As Integer   'Tally for darts thrown in replayed turn
        Dim location As String
        Dim temp() As String

        If play Then
            'Determines the number of throws in the current turn and whether or not to start a new turn
            If playThrow = 3 Then
                'New turn
                playThrow = 0
                ClearBoard()
            End If
            'Resets the replayThrow count, and gets the randomly generated x/y coordinates, then draws at those points.
            replayThrow = 0
            xCoord = GenerateRandomLocation()
            yCoord = GenerateRandomLocation()
            DrawPoint(xCoord, yCoord)
            AppendToFile(xCoord, yCoord)
            playThrow += 1
            TurnLabel.Text = ("Turn: " & playThrow & "/3")
        Else
            'Replay mode
            'Determines the number of throws in the current replayed turn, and whether it needs to clear and reset the throws for a new turn
            If replayThrow = 3 Then
                replayThrow = 0
                ClearBoard()
            End If
            'Resets the playThrow count, reads from the previousThrows list coordinates and draws at those previous points
            playThrow = 0
            location = ReadFromList(False)
            temp = Split(location, "@")
            'Trys to convert the coordinates to a single in order to be drawn
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

    'Pressing the spacebar will throw a dart, the true indicating that it is in "Play" mode throwing new randomly generated darts.
    Private Sub PlayButton_KeyDown(sender As Object, e As KeyEventArgs) Handles PlayButton.KeyDown
        If e.KeyCode = Keys.Space Then
            ThrowDart(True)
        End If
    End Sub

    'Pressing the spacebar will throw a dart, the false indicating that it is in "Replay" mode throwing darts of previous turns.
    Private Sub ReplayButton_KeyDown(sender As Object, e As KeyEventArgs) Handles ReplayButton.KeyDown
        If e.KeyCode = Keys.Space Then
            ThrowDart(False)
        End If
    End Sub

    'Clear the board when the play button is highlighted again
    Private Sub PlayButton_GotFocus(sender As Object, e As EventArgs) Handles PlayButton.GotFocus
        ClearBoard()
        TurnLabel.Text = ("Turn: 0/3")
    End Sub

    'Resets the board when the replay button is highlighted, reads from the DartThrows.txt file to populate the previousThrows list
    Private Sub ReplayButton_GotFocus(sender As Object, e As EventArgs) Handles ReplayButton.GotFocus
        ClearBoard()
        TurnLabel.Text = ("Turn: 0/3")
        ReadFromFile()
    End Sub

End Class
