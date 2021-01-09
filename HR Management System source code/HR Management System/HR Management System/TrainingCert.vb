Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class TrainingCert
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim query As String = "INSERT INTO cert_tran ( Employee_Name, Certificate_Name, Image) values (@employeeName, @CertificateName, @view)"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        connection.Open()
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@employeeName", txtemplyeeName.Text)
            cmd.Parameters.AddWithValue("@CertificateName", txtcertificateName.Text)
            cmd.Parameters.AddWithValue("@view", m.ToArray())
            cmd.ExecuteNonQuery()
            connection.Close()
            MsgBox("Data Save Sucessful")
            TrainingCert_Load(Nothing, Nothing)
        End Using
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        PictureBox1.Image = HR_Management_System.My.Resources.Resources.images
        txtemplyeeName.Clear()
        txtcertificateName.Clear()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        picture.PictureBox1.Image = PictureBox1.Image
        picture.ShowDialog()
        'PictureBox1.Visible = True

    End Sub

    Private Sub TrainingCert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(865, 329)
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.cert_tran' table. You can move, or remove it, as needed.
        Me.Cert_tranTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.cert_tran)

        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridView1.EnableHeadersVisualStyles = False

    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim query As String = "DELETE FROM cert_tran WHERE Employee_Name = @employeeName"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        connection.Open()
        DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
        If DialogResult = vbYes Then
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@employeeName", txtemplyeeName.Text)
                cmd.Parameters.AddWithValue("@CertificateName", txtcertificateName.Text)
                cmd.Parameters.AddWithValue("@view", m.ToArray())
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Delete Sucessful")
                TrainingCert_Load(Nothing, Nothing)
            End Using
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "UPDATE  cert_tran SET Employee_Name =@employeeName, Image=@view WHERE Employee_Name = @employeeName "
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        connection.Open()
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@employeeName", txtemplyeeName.Text)
            cmd.Parameters.AddWithValue("@CertificateName", txtcertificateName.Text)
            cmd.Parameters.AddWithValue("@view", m.ToArray())
            cmd.ExecuteNonQuery()
            connection.Close()
            MsgBox("Data Delete Sucessful")
            TrainingCert_Load(Nothing, Nothing)
        End Using
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TrainingCert_Load(Nothing, Nothing)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If TextBox11.Text = "" Then
            ErrorProvider1.SetError(TextBox11, "Please provide what you want to search for")
        ElseIf ComboBox3.Text = "" Then
            ErrorProvider1.SetError(ComboBox3, "please select from which you want to search")
        ElseIf ComboBox3.Text = "Employee Name" Then
            Dim query As String = " select * from cert_tran where Employee_Name  ='" & TextBox11.Text & "'"
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
            Dim report1 As New GatePassReport
            report1.SetParameterValue("Name", txtemplyeeName.Name)
            report1.SetParameterValue("Certificate", txtcertificateName.Text)

            TraningCertificateForm.CrystalReportViewer1.ReportSource = report1
            TraningCertificateForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            txtemplyeeName.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            txtcertificateName.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            Dim img() As Byte
            img = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            Dim m As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(m)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class