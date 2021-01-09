Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class gatepass


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim query1 As String = "select * from Gate_Pass  WHERE Employee_Name = @employeeName "
        Dim Constrr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection1 As New SqlConnection(Constrr)
        Dim cmd1 As SqlCommand = New SqlCommand(query1, connection1)
        connection1.Open()
        cmd1.Parameters.AddWithValue("@employeeName", txtname.Text)
        Using reader As SqlDataReader = cmd1.ExecuteReader()
            If reader.HasRows Then
                MsgBox("  EMPLOYEE NAME - User Already Exist !!!", MsgBoxStyle.Exclamation, "Add New User !!")
            Else
                Dim query As String = "INSERT INTO Gate_Pass ( Employee_Name, Pass_Type, GatePass_Validity, Retun_Date, Image) values (@employeeName, @passType,@GatePass_Validity,@Return_Date, @view)"
                Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
                Dim connection As New SqlConnection(constr)
                Dim m As New MemoryStream
                PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
                connection.Open()
                Using cmd As SqlCommand = New SqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@employeeName", txtname.Text)
                    cmd.Parameters.AddWithValue("@passType", txtpasstype.Text)
                    cmd.Parameters.AddWithValue("@GatePass_Validity", txtValidity.Text)
                    cmd.Parameters.AddWithValue("@Return_Date", txtReDate.Text)
                    cmd.Parameters.AddWithValue("@view", m.ToArray())
                    cmd.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Data Save Sucessful")
                    gatepass_Load(Nothing, Nothing)
                End Using
            End If

        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Image = HR_Management_System.My.Resources.Resources.images
        txtname.Clear()
        txtpasstype.Clear()
        txtValidity.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "DELETE FROM  Gate_Pass  WHERE id= @id"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        connection.Open()
        DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
        If DialogResult = vbYes Then
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", Label6.Text)
                cmd.Parameters.AddWithValue("@employeeName", txtname.Text)
                cmd.Parameters.AddWithValue("@passType", txtpasstype.Text)
                cmd.Parameters.AddWithValue("@GatePass_Validity", txtValidity.Text)
                cmd.Parameters.AddWithValue("@Return_Date", txtReDate.Text)
                cmd.Parameters.AddWithValue("@view", m.ToArray())
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Delect Sucessful")
                gatepass_Load(Nothing, Nothing)
            End Using
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "UPDATE Gate_Pass SET  Pass_Tpe=@passType, GatePass_Validity= @GatePass_Validity, Return_Date= @Return_Date, Image= @view WHERE  Employee_Name=@employeeName"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim m As New MemoryStream
        PictureBox1.Image.Save(m, PictureBox1.Image.RawFormat)
        connection.Open()
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@employeeName", txtname.Text)
            cmd.Parameters.AddWithValue("@passType", txtpasstype.Text)
            cmd.Parameters.AddWithValue("@GatePass_Validity", txtValidity.Text)
            cmd.Parameters.AddWithValue("@Return_Date", txtReDate.Text)
            cmd.Parameters.AddWithValue("@view", m.ToArray())
            cmd.ExecuteNonQuery()
            connection.Close()
            MsgBox("Data Update Sucessful")
            gatepass_Load(Nothing, Nothing)
        End Using
    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If TextBox11.Text = "" Then
            ErrorProvider1.SetError(TextBox11, "Please provide what you want to search for")
        ElseIf ComboBox3.Text = "" Then
            ErrorProvider1.SetError(ComboBox3, "please select from which you want to search")
        ElseIf ComboBox3.Text = "Name" Then
            Dim query As String = " select * from Gate_Pass where Employee_Name  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Pass Type" Then
            Dim query As String = " select * from Gate_Pass where Employee_Name  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Gatepass Valilidty " Then
            Dim query As String = " select * from Gate_Pass where GatePass_Validity  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Date" Then
            Dim query As String = " select * from Gate_Pass where GatePass_Validity  ='" & TextBox11.Text & "'"
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Size = New Size(927, 486)
        picture.PictureBox1.Image = PictureBox1.Image
        picture.ShowDialog()
        'PictureBox1.Visible = True

    End Sub

    Private Sub gatepass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.Gate_Pass' table. You can move, or remove it, as needed.
        Me.Gate_PassTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.Gate_Pass)
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridView1.EnableHeadersVisualStyles = False
        Me.Size = New Size(927, 313)

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim report1 As New GatePassReport
            report1.SetParameterValue("EmployeeName", txtname.Name)
            report1.SetParameterValue("PassType", txtpasstype.Text)
            report1.SetParameterValue("GatePassValidity", txtValidity.Text)
            report1.SetParameterValue("ReturnDate", txtReDate.Text)
            GatePassForm.CrystalReportViewer1.ReportSource = report1
            GatePassForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Hide()

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Label6.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            txtname.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            txtpasstype.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            txtValidity.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            txtReDate.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            Dim img() As Byte
            img = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            Dim m As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(m)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class