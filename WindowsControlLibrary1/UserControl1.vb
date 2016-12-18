Imports System.ComponentModel

Public Class UserControl1
    Public Shared red(255) As Integer
    Public Shared green(255) As Integer
    Public Shared blue(255) As Integer
    Public Shared red1(255) As Integer
    Public Shared green1(255) As Integer
    Public Shared blue1(255) As Integer
    Public max As Integer
    Public Average As Double
    Dim file As String
    Public Enum flip
        Ascending
        Descending
    End Enum
    Public Enum histoType
        Red
        Green
        Blue
        RGB
    End Enum
    Private color As Color
    Private img As Bitmap
    Private clr As histoType
    Public Event changeHistoType()
    Public mflip As flip
    Property histogramColor As Color
        Get
            Return color
        End Get
        Set(value As Color)
            color = value
            PictureBox1.BackColor = value
        End Set
    End Property

    Property histoFlip As flip
        Get
            Return mflip
        End Get
        Set(value As flip)
            mflip = value
            reverseHisto()
        End Set
    End Property

    Property histogramStroke As Double
        Get
            Return valueChange
        End Get
        Set(value As Double)
            valueChange = value
            change()
        End Set
    End Property

    Property selectionColor As histoType
        Get
            Return clr
        End Get
        Set(value As histoType)
            clr = value
            changeColor()



        End Set
    End Property



    Public Property PathFile As String
        Get
            Return TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = Drawing.Color.LavenderBlush


    End Sub
    Dim valueChange = 0.01
    Private Sub change()
        'NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        Dim image As Bitmap
        Dim imageGraphics As Graphics
        Dim x As Integer

        image = New Bitmap(1024, 200)
        imageGraphics = Graphics.FromImage(image)
        x = 0


        If clr = histoType.Red Then
            Dim redPen As New Pen(color.FromArgb(255, 255, 0, 0), 1)
            For Each i As Integer In red
                If Not i = 0 Then
                    'koordinat (x, y) width height
                    imageGraphics.DrawLine(redPen, x, 200, x, 200 - CInt(i * valueChange))
                End If
                x += 1
            Next
        ElseIf clr = histoType.Green Then
            Dim greenPen As New Pen(color.FromArgb(255, 0, 255, 0), 1)
            For Each i As Integer In green
                If Not i = 0 Then

                    imageGraphics.DrawLine(greenPen, x, 200, x, 200 - CInt(i * valueChange))
                End If
                x += 1
            Next
        ElseIf clr = histoType.Blue Then

            Dim bluePen As New Pen(color.FromArgb(255, 0, 0, 255), 1)
            For Each i As Integer In blue
                If Not i = 0 Then
                    imageGraphics.DrawLine(bluePen, x, 200, x, 200 - CInt(i * valueChange))
                End If
                x += 1
            Next
        ElseIf clr = histoType.RGB Then
            Dim redPen As New Pen(color.FromArgb(128, 255, 0, 0), 1)
            Dim bluePen As New Pen(color.FromArgb(128, 0, 0, 255), 1)
            Dim greenPen As New Pen(color.FromArgb(128, 0, 255, 0), 1)
            image = New Bitmap(1024, 200)
            imageGraphics = Graphics.FromImage(image)
            x = 0
            'Dim redPen As New Pen(color.FromArgb(255, 255, 0, 0), 3)
            For Each i As Integer In red
                If Not i = 0 Then
                    imageGraphics.DrawLine(redPen, x, 200, x, 200 - CInt(i * valueChange))
                End If
                x += 1
            Next
            x = 0
            'Dim bluePen As New Pen(color.FromArgb(255, 0, 0, 255), 3)
            For Each i As Integer In blue
                If Not i = 0 Then
                    imageGraphics.DrawLine(bluePen, x, 200, x, 200 - CInt(i * valueChange))
                End If
                x += 1
            Next
            x = 0
            'Dim greenPen As New Pen(color.FromArgb(255, 0, 255, 0), 3)
            For Each i As Integer In green
                If Not i = 0 Then
                    imageGraphics.DrawLine(greenPen, x, 200, x, 200 - CInt(i * valueChange))
                End If
                x += 1
            Next
        End If
        PictureBox1.Image = image

        image = New Bitmap(1024, 200)
        imageGraphics = Graphics.FromImage(image)

        x = 0
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

        'ketinggian max
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

    End Sub

    Public Sub addStroke()
        valueChange += 0.001
        change()


    End Sub

    Public Sub subStroke()
        If valueChange > 0.0000001 Then
            valueChange -= 0.001
            change()
        End If
    End Sub

    Public Sub addImage()
        max = 0
        Average = 0
        Array.Clear(red, 0, 255)
        Array.Clear(green, 0, 255)
        Array.Clear(blue, 0, 255)

        'untuk ambil path file gambar
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            file = OpenFileDialog1.FileName
            TextBox1.Text = OpenFileDialog1.FileName
            convertImage(file)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub convertImage(file As String)
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
            'ketinggian max
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
            clr = histoType.Red
            changeColor()
        Catch
            MsgBox("Please Select Image File!")
            Exit Sub
        End Try
    End Sub

    Public Sub reverseHisto()
        If mflip = flip.Ascending Then
            A.Text = "255"
            Z.Text = "0"
        Else
            A.Text = "0"
            Z.Text = "255"
        End If
        If mflip = flip.Ascending Then
            mflip = flip.Descending
            Array.Reverse(blue)
            Array.Reverse(green)
            Array.Reverse(red)
            changeColor()
        Else
            mflip = flip.Ascending
            Array.Reverse(blue)
            Array.Reverse(green)
            Array.Reverse(red)
            changeColor()
        End If
    End Sub

    'fungsi ubah warna
    Private Sub changeColor()
        Dim image As Bitmap
        Dim imageGraphics As Graphics
        Dim x As Integer
        PictureBox1.Image = Nothing
        PictureBox1.BackColor = color.Empty
        PictureBox1.Invalidate()
        'buat bikin graph histogram
        If clr = histoType.Red Then
            image = New Bitmap(1024, 200)
            imageGraphics = Graphics.FromImage(image)
            x = 0
            Dim redPen As New Pen(color.FromArgb(255, 255, 0, 0), 3)
            For Each i As Integer In red
                If Not i = 0 Then
                    imageGraphics.DrawLine(redPen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next

            PictureBox1.Image = image

        ElseIf clr = histoType.Green Then
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
        ElseIf clr = histoType.Blue Then
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
        ElseIf clr = histoType.RGB Then
            image = New Bitmap(1024, 200)
            imageGraphics = Graphics.FromImage(image)
            x = 0
            Dim redPen As New Pen(color.FromArgb(128, 255, 0, 0), 3)
            For Each i As Integer In red
                If Not i = 0 Then
                    imageGraphics.DrawLine(redPen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next
            x = 0
            Dim bluePen As New Pen(color.FromArgb(128, 0, 0, 255), 3)
            For Each i As Integer In blue
                If Not i = 0 Then
                    imageGraphics.DrawLine(bluePen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next
            x = 0
            Dim greenPen As New Pen(color.FromArgb(128, 0, 255, 0), 3)
            For Each i As Integer In green
                If Not i = 0 Then
                    imageGraphics.DrawLine(greenPen, x, 200, x, 200 - CInt(i * Average))
                End If
                x += 1
            Next
        End If
        valueChange += 0.0001
        change()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        convertImage(TextBox1.Text)
    End Sub
End Class
