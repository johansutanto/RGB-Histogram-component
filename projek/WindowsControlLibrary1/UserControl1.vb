Imports System.ComponentModel

Public Class UserControl1
    Public Shared red(255) As Integer
    Public Shared green(255) As Integer
    Public Shared blue(255) As Integer
    Public max As Integer
    Public Average As Double

    Public ascending As Boolean
    Private color As Color
    Private histoHeight As Integer
    Private histoWidth As Integer
    Private img As Bitmap
    Private stroke As Integer
    Private clr As String
    Public Event changeHistoType()

    Property backgroundColor As Color
        Get
            Return color
        End Get
        Set(value As Color)
            color = value
            Invalidate()
        End Set
    End Property

    Property histogramHeight As Integer
        Get
            Return histoHeight
        End Get
        Set(value As Integer)
            histoHeight = value
            Invalidate()
        End Set
    End Property

    Property histogramWidth As Integer
        Get
            Return histoWidth
        End Get
        Set(value As Integer)
            histoWidth = value
            Invalidate()
        End Set
    End Property

    Property imagePath As Bitmap
        Get
            Return img
        End Get
        Set(value As Bitmap)
            value = New Bitmap(1024, 200)
            img = value
            Invalidate()
        End Set
    End Property

    Property histogramStroke As Integer
        Get
            Return stroke
        End Get
        Set(value As Integer)
            stroke = value
            Invalidate()
        End Set
    End Property

    Property selectionColor As String
        Get
            Return clr
        End Get
        Set(value As String)
            clr = value
            Invalidate()
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = Drawing.Color.LavenderBlush


    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        Dim image As Bitmap
        Dim imageGraphics As Graphics
        Dim x As Integer

        image = New Bitmap(1024, 200)
        imageGraphics = Graphics.FromImage(image)
        x = 0
        Dim redPen As New Pen(Color.FromArgb(255, 255, 0, 0), 1)
        Dim greenPen As New Pen(Color.FromArgb(255, 0, 255, 0), 1)
        Dim bluePen As New Pen(Color.FromArgb(255, 0, 0, 255), 1)
        If ComboBox1.SelectedItem = "Red" Then
            For Each i As Integer In red
                If Not i = 0 Then
                    imageGraphics.DrawLine(redPen, x, 200, x, 200 - CInt(i * NumericUpDown1.Value))
                End If
                x += 1
            Next
        ElseIf ComboBox1.SelectedItem = "Green" Then
            For Each i As Integer In green
                If Not i = 0 Then
                    imageGraphics.DrawLine(greenPen, x, 200, x, 200 - CInt(i * NumericUpDown1.Value))
                End If
                x += 1
            Next
        ElseIf ComboBox1.SelectedItem = "Blue" Then
            For Each i As Integer In blue
                If Not i = 0 Then
                    imageGraphics.DrawLine(bluePen, x, 200, x, 200 - CInt(i * NumericUpDown1.Value))
                End If
                x += 1
            Next
        End If
        PictureBox1.Image = image

        image = New Bitmap(1024, 200)
        imageGraphics = Graphics.FromImage(image)

        x = 0


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Browse.Click
        max = 0
        Average = 0
        Array.Clear(red, 0, 255)
        Array.Clear(green, 0, 255)
        Array.Clear(blue, 0, 255)
        'untuk ambil path file gambar
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Dim file As String = OpenFileDialog1.FileName
            TextBox1.Text = OpenFileDialog1.FileName
            check(file)
        Else
            Exit Sub
        End If

    End Sub

    Private Sub check(file As String)
        Dim a As Bitmap
        Try
            a = New Bitmap(file)
            'untuk inisialisasi array
            Array.Clear(red, 0, 255)
            Array.Clear(green, 0, 255)
            Array.Clear(blue, 0, 255)
            'untuk ambil pixel tiap koordinat
            For i = 0 To a.Width - 1
                For j = 0 To a.Height - 1
                    red(a.GetPixel(i, j).R) += 1
                    green(a.GetPixel(i, j).G) += 1
                    blue(a.GetPixel(i, j).B) += 1
                Next
            Next
            'untuk nentuin angka tertinggi dari histogram
            If red.Max() > green.Max Then
                If red.Max() > blue.Max Then
                    max = red.Max
                Else
                    max = blue.Max
                End If
            Else
                If green.Max() > blue.Max Then
                    max = green.Max
                Else
                    max = blue.Max
                End If
            End If

            'ketinggian stroke
            If max > 0 And max <= 200 Then
                lbl.Text = "200"
                Average = 1
            ElseIf max > 200 And max <= 10000 Then
                lbl.Text = "10.000"
                Average = 0.02
            ElseIf max > 10000 And max <= 20000 Then
                lbl.Text = "20.000"
                Average = 0.01
            ElseIf max > 20000 And max <= 30000 Then
                lbl.Text = "30.000"
                Average = 0.0066666666666666671
            ElseIf max > 30000 And max <= 40000 Then
                lbl.Text = "40.000"
                Average = 0.005
            ElseIf max > 40000 And max <= 50000 Then
                lbl.Text = "50.000"
                Average = 0.004
            ElseIf max > 50000 And max <= 60000 Then
                lbl.Text = "60.000"
                Average = 0.0033333333333333335
            ElseIf max > 60000 And max <= 70000 Then
                lbl.Text = "70.000"
                Average = 0.0028571428571428571
            ElseIf max > 70000 And max <= 80000 Then
                lbl.Text = "80.000"
                Average = 0.0025
            ElseIf max > 80000 And max <= 90000 Then
                lbl.Text = "90.000"
                Average = 0.0022222222222222222
            ElseIf max > 90000 And max <= 100000 Then
                lbl.Text = "100.000"
                Average = 0.002
            ElseIf max > 100000 And max <= 1000000 Then
                lbl.Text = "1.000.000"
                Average = 0.0002
            ElseIf max > 1000000 And max <= 2000000 Then
                lbl.Text = "2.000.000"
                Average = 0.0001
            ElseIf max > 2000000 Then
                lbl.Text = "+++"
                Average = 0.0001
            End If
            ComboBox1.SelectedItem = "Red"
            ref()

        Catch
            MsgBox("Please Select Image File!")
            Exit Sub
        End Try

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ref()
    End Sub
    'fungsi refresh
    Private Sub ref()
        Dim image As Bitmap
        Dim imageGraphics As Graphics
        Dim x As Integer
        PictureBox1.Image = Nothing
        PictureBox1.BackColor = Color.Empty
        PictureBox1.Invalidate()
        'buat bikin graph histogram
        If ComboBox1.SelectedItem = "Red" Then
            image = New Bitmap(1024, 200)
            imageGraphics = Graphics.FromImage(image)

            x = 0
            Dim redPen As New Pen(Color.FromArgb(255, 255, 0, 0), 3)
            For Each i As Integer In red
                If Not i = 0 Then
                    imageGraphics.DrawLine(redPen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next
            PictureBox1.Image = image

        ElseIf ComboBox1.SelectedItem = "Green" Then
            image = New Bitmap(1024, 200)
            imageGraphics = Graphics.FromImage(image)

            x = 0
            Dim greenPen As New Pen(color.FromArgb(255, 0, 255, 0), 3)
            For Each i As Integer In green
                If Not i = 0 Then
                    imageGraphics.DrawLine(greenPen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next
            PictureBox1.Image = image
        ElseIf ComboBox1.SelectedItem = "Blue" Then
            image = New Bitmap(1024, 200)
            imageGraphics = Graphics.FromImage(image)

            x = 0
            Dim bluePen As New Pen(color.FromArgb(255, 0, 0, 255), 3)
            For Each i As Integer In blue
                If Not i = 0 Then
                    imageGraphics.DrawLine(bluePen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next
            PictureBox1.Image = image
        End If
        NumericUpDown1.Value = 0.0099
        NumericUpDown1.Value += 0.0001
    End Sub



    
End Class
