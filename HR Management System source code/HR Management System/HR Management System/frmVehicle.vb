Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Public Class frmVehicle
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query1 As String = "select * from Vehicle_No  WHERE Vehicle_No = @vehicle "
        Dim Constrr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection1 As New SqlConnection(Constrr)
        Dim cmd1 As SqlCommand = New SqlCommand(query1, connection1)
        connection1.Open()
        cmd1.Parameters.AddWithValue("@vehicle", TextBox1.Text)
        Using reader As SqlDataReader = cmd1.ExecuteReader()
            If reader.HasRows Then
                MsgBox("  EMPLOYEE NAME - User Already Exist !!!", MsgBoxStyle.Exclamation, "Add New User !!")
            Else
                Dim query As String = "INSERT INTO Vehicle_No ( Vehicle_No, Istimary_Expiry_Date, Insurance_Validity_Date, Vehicle_Pass, Image,Image1,Image2) values (@vehicle, @istimary,@insurance, @vehiclePass, @Image,@Image1,@Image2)"
                Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
                Dim connection As New SqlConnection(constr)
                Dim m As New MemoryStream
                Dim ms As New MemoryStream
                Dim ma As New MemoryStream
                PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
                PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                PictureBox3.Image.Save(ma, PictureBox3.Image.RawFormat)
                connection.Open()
                Using cmd As SqlCommand = New SqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@vehicle", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@istimary", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@insurance", TextBox3.Text)
                    cmd.Parameters.AddWithValue("@vehiclePass", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@Image", m.ToArray())
                    cmd.Parameters.AddWithValue("@Image1", ms.ToArray())
                    cmd.Parameters.AddWithValue("@Image2", ma.ToArray())
                    cmd.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Data Save Sucessful")
                    frmVehicle_Load(Nothing, Nothing)
                End Using
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox4.Clear()
        PictureBox1.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox2.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox3.Image = HR_Management_System.My.Resources.Resources.images
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "DELETE Vehicle_NO WHERE Vehicle_No = @vehicle"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        Dim ms As New MemoryStream
        Dim ma As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
        PictureBox3.Image.Save(ma, PictureBox3.Image.RawFormat)
        connection.Open()
        DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
        If DialogResult = vbYes Then
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@vehicle", TextBox1.Text)
                cmd.Parameters.AddWithValue("@istimary", TextBox2.Text)
                cmd.Parameters.AddWithValue("@insurance", TextBox3.Text)
                cmd.Parameters.AddWithValue("@vehiclePass", TextBox4.Text)
                cmd.Parameters.AddWithValue("@Image", m.ToArray())
                cmd.Parameters.AddWithValue("@Image1", ms.ToArray())
                cmd.Parameters.AddWithValue("@Image2", ma.ToArray())
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Save Sucessful")
                frmVehicle_Load(Nothing, Nothing)
            End Using
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "UPDATE Vehicle_No SET Istimary_Expiry_Date = @istimary, Insurance_Validity_Date= @insurance, Vehicle_Pass = @vehiclePass, Image = @Image,Image1 = @Image1,Image2=@Image2 WHERE Vehicle_No = @vehicle"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        Dim ms As New MemoryStream
        Dim ma As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
        PictureBox3.Image.Save(ma, PictureBox3.Image.RawFormat)
        connection.Open()
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@vehicle", TextBox1.Text)
            cmd.Parameters.AddWithValue("@istimary", TextBox2.Text)
            cmd.Parameters.AddWithValue("@insurance", TextBox3.Text)
            cmd.Parameters.AddWithValue("@vehiclePass", TextBox4.Text)
            cmd.Parameters.AddWithValue("@Image", m.ToArray())
            cmd.Parameters.AddWithValue("@Image1", ms.ToArray())
            cmd.Parameters.AddWithValue("@Image2", ma.ToArray())
            cmd.ExecuteNonQuery()
            connection.Close()
            MsgBox("Data Save Sucessful")
            frmVehicle_Load(Nothing, Nothing)
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox2.Visible = False
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox3.Visible = False
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        picture.PictureBox1.Image = PictureBox1.Image
        picture.ShowDialog()
        'PictureBox1.Visible = True
        PictureBox2.Visible = False
        PictureBox3.Visible = False


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        picture.PictureBox1.Image = PictureBox2.Image
        picture.ShowDialog()
        'PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox1.Visible = False


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        picture.PictureBox1.Image = PictureBox3.Image
        picture.ShowDialog()
        'PictureBox3.Visible = True
        PictureBox1.Visible = False
        PictureBox2.Visible = False


    End Sub

    Private Sub frmVehicle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.Vehicle_No' table. You can move, or remove it, as needed.
        Me.Vehicle_NoTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.Vehicle_No)
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridView1.EnableHeadersVisualStyles = False
        Me.Size = New Size(990, 328)

    End Sub


    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If TextBox11.Text = "" Then
            MsgBox("Please provide what you want to search for", vbInformation)
        ElseIf ComboBox3.Text = "" Then
            MessageBox.Show("please select from which you want to search")
        ElseIf ComboBox3.Text = "Vehicle No" Then
            Dim query As String = " select * from Vehicle_No where Vehicle_No  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Vehicle Pass" Then
            Dim query As String = " select * from Vehicle_No where Vehicle Pass  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim report1 As New rptVehicleFrom
            report1.SetParameterValue("VehicleNo", TextBox1.Text)
            report1.SetParameterValue("Istamira", TextBox2.Text)
            report1.SetParameterValue("Insurance", TextBox3.Text)
            report1.SetParameterValue("VehiclePass", TextBox4.Text)
            VehicleForm.CrystalReportViewer1.ReportSource = report1
            VehicleForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Hide()

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            Dim img() As Byte
            Dim img1() As Byte
            Dim img2() As Byte
            img = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            img1 = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            img2 = DataGridView1.Rows(e.RowIndex).Cells(7).Value
            Dim m As New MemoryStream(img)
            Dim ma As New MemoryStream(img1)
            Dim mr As New MemoryStream(img2)
            PictureBox1.Image = Image.FromStream(m)
            PictureBox2.Image = Image.FromStream(ma)
            PictureBox3.Image = Image.FromStream(mr)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class