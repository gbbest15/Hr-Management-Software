Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Public Class VacationSchedule
    Private Sub VacationSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet11.V_schedule' table. You can move, or remove it, as needed.
        Me.V_scheduleTableAdapter.Fill(Me.Hr_Management_softwareDataSet11.V_schedule)
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.V_schedule' table. You can move, or remove it, as needed.
        Me.V_scheduleTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.V_schedule)

        DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        'DataGridView2.Item(columnIndex, RowIndex).Style
        DataGridView2.EnableHeadersVisualStyles = False

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query1 As String = "select * from V_schedule  WHERE Employee_Name = @employeeNo "
        Dim Constrr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection1 As New SqlConnection(Constrr)
        Dim cmd1 As SqlCommand = New SqlCommand(query1, connection1)
        connection1.Open()
        cmd1.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
        Using reader As SqlDataReader = cmd1.ExecuteReader()
            If reader.HasRows Then
                MsgBox("Employee Name - User Already Exist !!!", MsgBoxStyle.Exclamation, "Add New User !!")
            Else
                Dim query As String = "INSERT INTO V_schedule (Employee_Name, First_Entry, Leave_Application_Copy, Leave_Salary_Net,Paid_Leave_Salary,Balance_Leave_Salary,Re_Entry_Ticket_Copy,Total_Year_of_Service,Re_Service,Image,image1) values (@employeeNo,@FirstName,@LeaveApplicationCopy,@LeaveSalaryNet,@PaidLeaveSalary,@BalanceLeaveSalary,@ReEntryTicketCopy,@TotalYearofService,@ReService,@Image,@image1)"
                Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
                Dim connection As New SqlConnection(constr)
                Try
                    Dim a As New MemoryStream
                    Dim b As New MemoryStream
                    PictureBox1.Image.Save(a, PictureBox1.Image.RawFormat)
                    PictureBox2.Image.Save(b, PictureBox2.Image.RawFormat)
                    connection.Open()
                    Using cmd As SqlCommand = New SqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@FirstName", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@LeaveApplicationCopy", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@LeaveSalaryNet", TextBox4.Text)
                        cmd.Parameters.AddWithValue("@PaidLeaveSalary", TextBox8.Text)
                        cmd.Parameters.AddWithValue("@BalanceLeaveSalary", TextBox7.Text)
                        cmd.Parameters.AddWithValue("@ReEntryTicketCopy", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@TotalYearofService", TextBox6.Text)
                        cmd.Parameters.AddWithValue("@ReService", TextBox9.Text)
                        cmd.Parameters.AddWithValue("@Image", a.ToArray())
                        cmd.Parameters.AddWithValue("@image1", b.ToArray())
                        cmd.ExecuteNonQuery()
                        connection.Close()
                        MsgBox("Data Save Sucessful")
                        VacationSchedule_Load(Nothing, Nothing)
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Using

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "UPDATE V_schedule SET Employee_Name =@employeeNo, First_Entry= @FirstName, Leave_Application_Copy= @LeaveApplicationCopy, Leave_Salary_Net= @LeaveSalaryNet ,Paid_Leave_Salary =@PaidLeaveSalary,Balance_Leave_Salary= @BalanceLeaveSalary,Re_Entry_Ticket_Copy=@ReEntryTicketCopy,Total_Year_of_Service = @TotalYearofService,Re_Service =@ReService,Image=@Image,image1=@image1 where id=@id"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim a As New MemoryStream
        Dim b As New MemoryStream
        PictureBox1.Image.Save(a, PictureBox1.Image.RawFormat)
        PictureBox2.Image.Save(b, PictureBox2.Image.RawFormat)
        connection.Open()
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", Label15.Text)
            cmd.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
            cmd.Parameters.AddWithValue("@FirstName", TextBox2.Text)
            cmd.Parameters.AddWithValue("@LeaveApplicationCopy", TextBox3.Text)
            cmd.Parameters.AddWithValue("@LeaveSalaryNet", TextBox4.Text)
            cmd.Parameters.AddWithValue("@PaidLeaveSalary", TextBox8.Text)
            cmd.Parameters.AddWithValue("@BalanceLeaveSalary", TextBox7.Text)
            cmd.Parameters.AddWithValue("@ReEntryTicketCopy", TextBox5.Text)
            cmd.Parameters.AddWithValue("@TotalYearofService", TextBox6.Text)
            cmd.Parameters.AddWithValue("@ReService", TextBox9.Text)
            cmd.Parameters.AddWithValue("@Image", a.ToArray())
            cmd.Parameters.AddWithValue("@image1", b.ToArray())
            cmd.ExecuteNonQuery()
            connection.Close()
            MsgBox("Data Update Sucessful")
            VacationSchedule_Load(Nothing, Nothing)
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "DELETE V_schedule FROM where id= @id"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim a As New MemoryStream
        Dim b As New MemoryStream
        PictureBox1.Image.Save(a, PictureBox1.Image.RawFormat)
        PictureBox2.Image.Save(b, PictureBox2.Image.RawFormat)
        connection.Open()
        DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
        If DialogResult = vbYes Then
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", Label15.Text)
                cmd.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
                cmd.Parameters.AddWithValue("@FirstName", TextBox2.Text)
                cmd.Parameters.AddWithValue("@LeaveApplicationCopy", TextBox3.Text)
                cmd.Parameters.AddWithValue("@LeaveSalaryNet", TextBox4.Text)
                cmd.Parameters.AddWithValue("@PaidLeaveSalary", TextBox8.Text)
                cmd.Parameters.AddWithValue("@BalanceLeaveSalary", TextBox7.Text)
                cmd.Parameters.AddWithValue("@ReEntryTicketCopy", TextBox5.Text)
                cmd.Parameters.AddWithValue("@TotalYearofService", TextBox6.Text)
                cmd.Parameters.AddWithValue("@ReService", TextBox9.Text)
                cmd.Parameters.AddWithValue("@Image", a.ToArray())
                cmd.Parameters.AddWithValue("@image1", b.ToArray())
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Delete Sucessful")
                VacationSchedule_Load(Nothing, Nothing)
            End Using
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()
    End Sub
    Private Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        PictureBox1.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox2.Image = HR_Management_System.My.Resources.Resources.images
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        picture.PictureBox1.Image = PictureBox2.Image
        picture.ShowDialog()
        ' PictureBox2.Visible = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        picture.PictureBox1.Image = PictureBox2.Image
        picture.ShowDialog()
        ' PictureBox2.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox2.Visible = False
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim report1 As New vehicleScheduleReport
        report1.SetParameterValue("EmployeeName", TextBox1.Text)
        report1.SetParameterValue("First Entry", TextBox2.Text)
        report1.SetParameterValue("Leave Application Copy", TextBox3.Text)
        report1.SetParameterValue("Leave Salary Net", TextBox4.Text)
        report1.SetParameterValue("Paid Leave Salary", TextBox8.Text)
        report1.SetParameterValue("Balance Leave Salary", TextBox7.Text)
        report1.SetParameterValue("Re Entry", TextBox5.Text)
        report1.SetParameterValue("Total year of service", TextBox6.Text)
        report1.SetParameterValue("Re Service", TextBox9.Text)
        Form1.CrystalReportViewer1.ReportSource = report1
        Form1.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim report1 As New vehicleScheduleReport
        report1.SetParameterValue("EmployeeName", TextBox1.Text)
        report1.SetParameterValue("First Entry", TextBox2.Text)
        report1.SetParameterValue("Leave Application Copy", TextBox3.Text)
        report1.SetParameterValue("Leave Salary Net", TextBox4.Text)
        report1.SetParameterValue("Paid Leave Salary", TextBox8.Text)
        report1.SetParameterValue("Balance Leave Salary", TextBox7.Text)
        report1.SetParameterValue("Re Entry", TextBox5.Text)
        report1.SetParameterValue("Total year of service", TextBox6.Text)
        report1.SetParameterValue("Re Service", TextBox9.Text)
        Form1.CrystalReportViewer1.ReportSource = report1
        Form1.ShowDialog()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim query As String = " select * from V_schedule where Date BETWEEN @d1 AND @d2"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            Dim da As New SqlDataAdapter(cmd)
            cmd.Parameters.Add("@d1", SqlDbType.Date).Value = dtLiciencedate.Value
            cmd.Parameters.Add("@d2", SqlDbType.Date).Value = DateTimePicker1.Value
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView2.DataSource = dt
        End Using
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If TextBox11.Text = "" Then
            MsgBox("Please provide value you want to search for")
        ElseIf ComboBox3.Text = "" Then
            MsgBox(ComboBox3, "please select from which you want to search By")
        ElseIf ComboBox3.Text = "Employee Name" Then
            Dim query As String = " select * from V_schedule where Employee_Name  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView2.DataSource = dt
            End Using
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim i As Integer

        With DataGridView2
            If e.RowIndex > 0 Then
                i = .CurrentRow.Index
                TextBox1.Text = .Rows(i).Cells("Employee_Name").Value.ToString()
                TextBox2.Text = .Rows(i).Cells("First_Entry").Value.ToString
                TextBox3.Text = .Rows(i).Cells("Leave_Application_Copy").Value.ToString
                TextBox4.Text = .Rows(i).Cells("Leave_Salary_Net").Value.ToString
                TextBox8.Text = .Rows(i).Cells("Paid_Leave_Salary").Value.ToString
                TextBox7.Text = .Rows(i).Cells("Balance_Leave_Salary").Value.ToString
                TextBox5.Text = .Rows(i).Cells("Re_Entry_Ticket_Copy").Value.ToString
                TextBox6.Text = .Rows(i).Cells("Total_Year_of_Service").Value.ToString
                TextBox9.Text = .Rows(i).Cells("Re_Service").Value.ToString
                Dim img() As Byte
                Dim img1() As Byte
                img = .Rows(i).Cells("Image").Value
                img1 = .Rows(i).Cells("image1").Value
                Dim m As New MemoryStream(img)
                Dim m1 As New MemoryStream(img1)
                PictureBox1.Image = Image.FromStream(m)
                PictureBox2.Image = Image.FromStream(m1)
            End If
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Hide()

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Label15.Text = DataGridView2.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value
        TextBox8.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
        TextBox7.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value
        TextBox5.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value
        TextBox6.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value
        TextBox9.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value
        Dim img() As Byte
        Dim img1() As Byte
        img = DataGridView2.Rows(e.RowIndex).Cells(10).Value
        img1 = DataGridView2.Rows(e.RowIndex).Cells(11).Value
        Dim m As New MemoryStream(img)
        Dim m1 As New MemoryStream(img1)
        PictureBox1.Image = Image.FromStream(m)
        PictureBox2.Image = Image.FromStream(m1)
    End Sub
End Class