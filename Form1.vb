Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label1.Text = "If this process is NOT running: " Then
            Label1.Text = "If this process is running: "
        Else
            Label1.Text = "If this process is NOT running: "
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = TextBox3.Text

        Dim p() As Process
        p = Process.GetProcessesByName(TextBox1.Text)

        If Label1.Text = "If this process is NOT running: " Then
            If p.Count > 0 Then
                ' Process is running
            Else
                For Each proc As Process In Process.GetProcessesByName(TextBox2.Text)
                    proc.Kill()
                    Timer2.Start()
                Next
                ' Process is not running
            End If

        Else
            If p.Count > 0 Then
                ' Process is running
            Else
                For Each proc As Process In Process.GetProcessesByName(TextBox2.Text)
                    proc.Kill()
                    Timer2.Start()
                Next
                ' Process is not running
            End If
        End If

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        If e.CloseReason <> CloseReason.WindowsShutDown Then
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
            My.Settings.Save()

            e.Cancel = True
        End If
    End Sub

    Private Sub CloseKillSwitchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseKillSwitchToolStripMenuItem.Click
        NotifyIcon1.Visible = False
        My.Settings.Save()
        End
    End Sub
End Class
