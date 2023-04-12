Public Class NotificationBar

    Private _NumberOfTimesBlink As Integer

    Public Enum NotificationIconType
        Exclamation
        Information
        Question
    End Enum

    <System.ComponentModel.DefaultValue(5)>
    Public Property BlinkTimes() As Integer
        Get
            Return Me._NumberOfTimesBlink
        End Get
        Set(ByVal value As Integer)
            Me._NumberOfTimesBlink = value
            If value Then
                Me.TableLayoutPanel1.ColumnStyles(0).Width = 35
            Else
                Me.TableLayoutPanel1.ColumnStyles(0).Width = 0
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Me.Visible = False
        Me.Dock = DockStyle.Top
        Me._NumberOfTimesBlink = 5
    End Sub

    Public Sub ShowNotificiation(ByVal NotificationText As String, ByVal NotificationType As NotificationIconType, ByVal Blink As Boolean)
        Me.lblNotification.Text = NotificationText
        Select Case NotificationType
            Case NotificationIconType.Exclamation
                Me.picIcon.Image = My.Resources.Resources.WarningHS
            Case NotificationIconType.Information
                Me.picIcon.Image = My.Resources.Resources.info16
            Case NotificationIconType.Question
                Me.picIcon.Image = My.Resources.Resources.question16
        End Select
        Me.Visible = True
        If Blink Then
            Me.tmrBlink.Enabled = True
        End If
        Me.BackColor = Color.FromKnownColor(KnownColor.Info)
        Me.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
    End Sub

    Private Sub tmrBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlink.Tick
        Static NumberOfTimesBlinked As Integer

        If NumberOfTimesBlinked > Me._NumberOfTimesBlink Then
            NumberOfTimesBlinked = 0
            Me.tmrBlink.Enabled = False
        Else
            If NumberOfTimesBlinked Mod 2 = 0 Then
                Me.BackColor = Color.FromKnownColor(KnownColor.Highlight)
                Me.ForeColor = Color.FromKnownColor(KnownColor.HighlightText)
            Else
                Me.BackColor = Color.FromKnownColor(KnownColor.Info)
                Me.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            End If

            NumberOfTimesBlinked += 1
        End If
    End Sub
End Class
