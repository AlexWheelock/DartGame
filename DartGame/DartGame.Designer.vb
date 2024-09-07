<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DartGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DartGame))
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.ReplayButton = New System.Windows.Forms.Button()
        Me.InformationalLabel = New System.Windows.Forms.Label()
        Me.TurnLabel = New System.Windows.Forms.Label()
        Me.DartBoardPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlayButton
        '
        Me.PlayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PlayButton.Location = New System.Drawing.Point(12, 12)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(75, 23)
        Me.PlayButton.TabIndex = 0
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = False
        '
        'ReplayButton
        '
        Me.ReplayButton.BackColor = System.Drawing.Color.Red
        Me.ReplayButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ReplayButton.Location = New System.Drawing.Point(93, 12)
        Me.ReplayButton.Name = "ReplayButton"
        Me.ReplayButton.Size = New System.Drawing.Size(75, 23)
        Me.ReplayButton.TabIndex = 2
        Me.ReplayButton.Text = "Replay"
        Me.ReplayButton.UseVisualStyleBackColor = False
        '
        'InformationalLabel
        '
        Me.InformationalLabel.AutoSize = True
        Me.InformationalLabel.Location = New System.Drawing.Point(179, 9)
        Me.InformationalLabel.Name = "InformationalLabel"
        Me.InformationalLabel.Size = New System.Drawing.Size(751, 26)
        Me.InformationalLabel.TabIndex = 4
        Me.InformationalLabel.Text = resources.GetString("InformationalLabel.Text")
        '
        'TurnLabel
        '
        Me.TurnLabel.AutoSize = True
        Me.TurnLabel.BackColor = System.Drawing.SystemColors.Control
        Me.TurnLabel.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TurnLabel.Location = New System.Drawing.Point(829, 936)
        Me.TurnLabel.Name = "TurnLabel"
        Me.TurnLabel.Size = New System.Drawing.Size(100, 22)
        Me.TurnLabel.TabIndex = 5
        Me.TurnLabel.Text = "Turn: 0/3"
        '
        'DartBoardPictureBox
        '
        Me.DartBoardPictureBox.BackgroundImage = Global.DartGame.My.Resources.Resources.Target21
        Me.DartBoardPictureBox.Location = New System.Drawing.Point(12, 41)
        Me.DartBoardPictureBox.Name = "DartBoardPictureBox"
        Me.DartBoardPictureBox.Size = New System.Drawing.Size(917, 917)
        Me.DartBoardPictureBox.TabIndex = 3
        Me.DartBoardPictureBox.TabStop = False
        '
        'DartGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 970)
        Me.Controls.Add(Me.TurnLabel)
        Me.Controls.Add(Me.InformationalLabel)
        Me.Controls.Add(Me.DartBoardPictureBox)
        Me.Controls.Add(Me.ReplayButton)
        Me.Controls.Add(Me.PlayButton)
        Me.Name = "DartGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dart Game"
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PlayButton As Button
    Friend WithEvents ReplayButton As Button
    Friend WithEvents DartBoardPictureBox As PictureBox
    Friend WithEvents InformationalLabel As Label
    Friend WithEvents TurnLabel As Label
End Class
