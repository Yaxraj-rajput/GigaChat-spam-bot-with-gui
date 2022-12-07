Imports System.IO
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window

Public Class Form1

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer

    Dim WithEvents Tmr As New Timer



    Private Sub Tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tmr.Tick

        If CBool(GetAsyncKeyState(Keys.ShiftKey)) And CBool(GetAsyncKeyState(Keys.Q)) Then


            If String.IsNullOrEmpty(BunifuTextBox1.Text) Then
                MsgBox("Enter Text")

            Else
                Timer1.Start()
            End If

        End If

        If CBool(GetAsyncKeyState(Keys.ShiftKey)) And CBool(GetAsyncKeyState(Keys.E)) Then


            If String.IsNullOrEmpty(BunifuTextBox1.Text) Then
                MsgBox("Enter Text")

            Else
                Timer1.Stop()
            End If

        End If



    End Sub

    Dim interv As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tmr.Interval = 100

        Tmr.Start()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick



        SendKeys.Send(BunifuTextBox1.Text)
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If String.IsNullOrEmpty(BunifuTextBox1.Text) Then
            MsgBox("Enter Text")

        Else
            Timer1.Start()
        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Timer1.Stop()

    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        BunifuTextBox1.Text = ""
    End Sub

    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        For disapper As Single = 1.0! To 0 Step -0.2!
            Me.Opacity = disapper
            'Me.Refresh()
            System.Threading.Thread.Sleep(50)
        Next
        Me.Close()

    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click

        Dim OpenFileDialog1 As OpenFileDialog = New OpenFileDialog()


        OpenFileDialog1.Title = "Select Text File"
        OpenFileDialog1.Filter = "Text File|*.txt"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            BunifuTextBox1.Text = File.ReadAllText(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub BunifuHSlider1_Scroll(sender As Object, e As Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs) Handles BunifuHSlider1.Scroll


        interv = BunifuHSlider1.Value

        BunifuLabel2.Text = "Interval: " & interv

        Timer1.Interval = interv

        If BunifuHSlider1.Value < 500 Then
            BunifuLabel2.ForeColor = Color.FromArgb(207, 68, 70)
        Else
            BunifuLabel2.ForeColor = Color.FromArgb(119, 124, 125)

        End If

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub






End Class
