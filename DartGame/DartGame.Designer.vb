<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DartGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.ReplayButton = New System.Windows.Forms.Button()
        Me.DartBoardPictureBox = New System.Windows.Forms.PictureBox()
        Me.InformationalLabel = New System.Windows.Forms.Label()
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlayButton
        '
        Me.PlayButton.Location = New System.Drawing.Point(12, 12)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(75, 23)
        Me.PlayButton.TabIndex = 0
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'ReplayButton
        '
        Me.ReplayButton.Location = New System.Drawing.Point(93, 12)
        Me.ReplayButton.Name = "ReplayButton"
        Me.ReplayButton.Size = New System.Drawing.Size(75, 23)
        Me.ReplayButton.TabIndex = 2
        Me.ReplayButton.Text = "Replay"
        Me.ReplayButton.UseVisualStyleBackColor = True
        '
        'DartBoardPictureBox
        '
        Me.DartBoardPictureBox.BackgroundImage = Global.DartGame.My.Resources.Resources.Target2
        Me.DartBoardPictureBox.Location = New System.Drawing.Point(12, 41)
        Me.DartBoardPictureBox.Name = "DartBoardPictureBox"
        Me.DartBoardPictureBox.Size = New System.Drawing.Size(917, 917)
        Me.DartBoardPictureBox.TabIndex = 3
        Me.DartBoardPictureBox.TabStop = False
        '
        'InformationalLabel
        '
        Me.InformationalLabel.AutoSize = True
        Me.InformationalLabel.Location = New System.Drawing.Point(183, 17)
        Me.InformationalLabel.Name = "InformationalLabel"
        Me.InformationalLabel.Size = New System.Drawing.Size(666, 13)
        Me.InformationalLabel.TabIndex = 4
        Me.InformationalLabel.Text = "Press the space bar to throw a dart. Throw 3 darts per turn. Press Replay"" to go " &
    "through previous turns. To go back to playing, press ""Play""."
        '
        'DartGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 970)
        Me.Controls.Add(Me.InformationalLabel)
        Me.Controls.Add(Me.DartBoardPictureBox)
        Me.Controls.Add(Me.ReplayButton)
        Me.Controls.Add(Me.PlayButton)
        Me.Name = "DartGame"
        Me.Text = "Dart Game"
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PlayButton As Button
    Friend WithEvents ReplayButton As Button
    Friend WithEvents DartBoardPictureBox As PictureBox
    Friend WithEvents InformationalLabel As Label
End Class
