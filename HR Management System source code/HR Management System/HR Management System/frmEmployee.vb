Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel



Public Class frmEmployee
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Try
            Dim query1 As String = "select * from employee_form  WHERE Employee_Name = @employeeName OR Employee_No= @employeeNo OR Qid_No= @qidno"
            Dim Constrr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection1 As New SqlConnection(Constrr)
            Dim cmd1 As SqlCommand = New SqlCommand(query1, connection1)
            connection1.Open()
            cmd1.Parameters.AddWithValue("@qidno", txtQidNo.Text)
            cmd1.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
            cmd1.Parameters.AddWithValue("@employeeName", txtemployeeName.Text)
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If reader.HasRows Then
                    MsgBox(" QID NO , EMPLOYEE NUMBER OR EMPLOYEE NAME - User Already Exist !!!", MsgBoxStyle.Exclamation, "Add New User !!")
                Else
                    Dim query As String = "INSERT INTO employee_form ( Employee_No, Employee_Name, Nationality, Destination, Division, Qid_No, Qid_Expiry_Date, Passport_Number, PP_Expiry_Date, Driving_Licence, D_Licence_Expiry_Date, Health_Card_No, Health_Card_Expiry_Date, Dath_of_Birth, Blood_Group, Join_Date, Re_entry_date, Total_year_service, Re_service, Basic_salary, Allawance, Mobile_Number, Address_in_qater, Next_of_kin, Image, Destination_Image, Qid_image, PP_image, DL_Image, Health_Image, Allowance_Image) values (@employeeNo,@employeeName,@Nationality,@Destination, @Division,@Qidno,@QidExpirydate,@Passportno,@PPExpdate,@Drivinglicence, @DrivinglicenceExp,@HealthcardNo,@HealthcardExp,@Dob,@Bloodgroup,@JoinDate,@ReEntryDate, @Totalyearservice ,@Reservice,@Basicsalary,@Allawance,@mobilenumber,@Addressinqater,@Nextofkin,@image,@deImage,@Qimage,@PPmage,@Dlimage,@HeImage,@AlImage)"
                    Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
                    Dim connection As New SqlConnection(constr)
                    Dim a As New MemoryStream
                    Dim b As New MemoryStream
                    Dim c As New MemoryStream
                    Dim d As New MemoryStream
                    Dim j As New MemoryStream
                    Dim f As New MemoryStream
                    Dim h As New MemoryStream
                    PictureBox1.Image.Save(a, PictureBox1.Image.RawFormat)
                    PictureBox2.Image.Save(b, PictureBox2.Image.RawFormat)
                    PictureBox3.Image.Save(c, PictureBox3.Image.RawFormat)
                    PictureBox4.Image.Save(d, PictureBox4.Image.RawFormat)
                    PictureBox5.Image.Save(j, PictureBox5.Image.RawFormat)
                    PictureBox6.Image.Save(f, PictureBox6.Image.RawFormat)
                    PictureBox7.Image.Save(h, PictureBox7.Image.RawFormat)
                    connection.Open()
                    Using cmd As SqlCommand = New SqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@employeeNo", TextBox1.Text.Trim)
                        cmd.Parameters.AddWithValue("@employeeName", txtemployeeName.Text.Trim)
                        cmd.Parameters.AddWithValue("@Nationality", cbNationality.Text.Trim)
                        cmd.Parameters.AddWithValue("@Destination", txtdestination.Text)
                        cmd.Parameters.AddWithValue("@Division", cboDivision.Text)
                        cmd.Parameters.AddWithValue("@Qidno", txtQidNo.Text)
                        cmd.Parameters.AddWithValue("@QidExpirydate", txtqidexpiry.Text)
                        cmd.Parameters.AddWithValue("@Passportno", txtpassNumber.Text)
                        cmd.Parameters.AddWithValue("@PPExpdate", txtppexpiry.Text)
                        cmd.Parameters.AddWithValue("@Drivinglicence", txtDrivingLi.Text)
                        cmd.Parameters.AddWithValue("@DrivinglicenceExp", dtLiciencedate.Text)
                        cmd.Parameters.AddWithValue("@HealthcardNo", txtHealthNo.Text)
                        cmd.Parameters.AddWithValue("@HealthcardExp", dthealthexpiry.Text)
                        cmd.Parameters.AddWithValue("@Dob", dtpDateBirth.Text)
                        cmd.Parameters.AddWithValue("@Bloodgroup", cbbloodgroup.Text)
                        cmd.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Text)
                        cmd.Parameters.AddWithValue("@ReEntryDate", dtentrydate.Text)
                        cmd.Parameters.AddWithValue("@Totalyearservice", txtTotalYear.Text)
                        cmd.Parameters.AddWithValue("@Reservice", txtreService.Text)
                        cmd.Parameters.AddWithValue("@Basicsalary", txtBasicSalary.Text)
                        cmd.Parameters.AddWithValue("@Allawance", txtallawance.Text)
                        cmd.Parameters.AddWithValue("@mobilenumber", txtMobileNumber.Text)
                        cmd.Parameters.AddWithValue("@Addressinqater", txtaddress.Text)
                        cmd.Parameters.AddWithValue("@Nextofkin", txtNextKin.Text)
                        cmd.Parameters.AddWithValue("@image", a.ToArray())
                        cmd.Parameters.AddWithValue("@deImage", b.ToArray())
                        cmd.Parameters.AddWithValue("@Qimage", c.ToArray())
                        cmd.Parameters.AddWithValue("@PPmage", d.ToArray())
                        cmd.Parameters.AddWithValue("@Dlimage", j.ToArray())
                        cmd.Parameters.AddWithValue("@HeImage", f.ToArray())
                        cmd.Parameters.AddWithValue("@AlImage", h.ToArray())
                        cmd.ExecuteNonQuery()
                        connection.Close()
                        MsgBox("Data Save Sucessful")

                        frmEmployee_Load(Nothing, Nothing)
                    End Using
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 2
        Timer1.Enabled = True
        dtentrydate.MaxDate = Now.Date
        dtpJoinDate.MaxDate = Now.Date
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet2.employee_form' table. You can move, or remove it, as needed.
        Me.Employee_formTableAdapter1.Fill(Me.Hr_Management_softwareDataSet2.employee_form)
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.employee_form' table. You can move, or remove it, as needed.
        Me.Employee_formTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.employee_form)
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridView1.EnableHeadersVisualStyles = False




    End Sub
    Private Sub clear()
        txtallawance.Clear()
        TextBox1.Clear()

        txtBasicSalary.Clear()
        txtDrivingLi.Clear()
        txtemployeeName.Clear()
        txtHealthNo.Clear()
        txtMobileNumber.Clear()
        txtNextKin.Clear()
        txtpassNumber.Clear()
        txtQidNo.Clear()
        txtTotalYear.Clear()
        txtdestination.Clear()
        txtaddress.Clear()
        txtreService.Clear()
        cbbloodgroup.Text = ""
        cbNationality.Text = ""
        cboDivision.Text = ""
        PictureBox1.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox2.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox3.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox4.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox5.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox6.Image = HR_Management_System.My.Resources.Resources.images
        PictureBox7.Image = HR_Management_System.My.Resources.Resources.images
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        clear()



    End Sub


    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim query As String = "DELETE FROM employee_form  WHERE Employee_No = @employeeNo"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim a As New MemoryStream
        Dim b As New MemoryStream
        Dim c As New MemoryStream
        Dim d As New MemoryStream
        Dim j As New MemoryStream
        Dim f As New MemoryStream
        Dim h As New MemoryStream
        PictureBox1.Image.Save(a, PictureBox1.Image.RawFormat)
        PictureBox2.Image.Save(b, PictureBox2.Image.RawFormat)
        PictureBox3.Image.Save(c, PictureBox3.Image.RawFormat)
        PictureBox4.Image.Save(d, PictureBox4.Image.RawFormat)
        PictureBox5.Image.Save(j, PictureBox5.Image.RawFormat)
        PictureBox6.Image.Save(f, PictureBox6.Image.RawFormat)
        PictureBox7.Image.Save(h, PictureBox7.Image.RawFormat)
        connection.Open()
        DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
        If DialogResult = vbYes Then
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
                cmd.Parameters.AddWithValue("@employeeName", txtemployeeName.Text)
                cmd.Parameters.AddWithValue("@Nationality", cbNationality.Text)
                cmd.Parameters.AddWithValue("@Destination", txtdestination.Text)
                cmd.Parameters.AddWithValue("@Division", cboDivision.Text)
                cmd.Parameters.AddWithValue("@Qidno", txtQidNo.Text)
                cmd.Parameters.AddWithValue("@QidExpirydate", txtqidexpiry.Text)
                cmd.Parameters.AddWithValue("@Passportno", txtpassNumber.Text)
                cmd.Parameters.AddWithValue("@PPExpdate", txtppexpiry.Text)
                cmd.Parameters.AddWithValue("@Drivinglicence", txtDrivingLi.Text)
                cmd.Parameters.AddWithValue("@DrivinglicenceExp", dtLiciencedate.Text)
                cmd.Parameters.AddWithValue("@HealthcardNo", txtHealthNo.Text)
                cmd.Parameters.AddWithValue("@HealthcardExp", dthealthexpiry.Text)
                cmd.Parameters.AddWithValue("@Dob", dtpDateBirth.Text)
                cmd.Parameters.AddWithValue("@Bloodgroup", cbbloodgroup.Text)
                cmd.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Text)
                cmd.Parameters.AddWithValue("@ReEntryDate", dtentrydate.Text)
                cmd.Parameters.AddWithValue("@Totalyearservice", txtTotalYear.Text)
                cmd.Parameters.AddWithValue("@Reservice", txtreService.Text)
                cmd.Parameters.AddWithValue("@Basicsalary", txtBasicSalary.Text)
                cmd.Parameters.AddWithValue("@Allawance", txtallawance.Text)
                cmd.Parameters.AddWithValue("@mobilenumber", txtMobileNumber.Text)
                cmd.Parameters.AddWithValue("@Addressinqater", txtaddress.Text)
                cmd.Parameters.AddWithValue("@Nextofkin", txtNextKin.Text)
                cmd.Parameters.AddWithValue("@image", a.ToArray())
                cmd.Parameters.AddWithValue("@deImage", b.ToArray())
                cmd.Parameters.AddWithValue("@Qimage", c.ToArray())
                cmd.Parameters.AddWithValue("@PPmage", d.ToArray())
                cmd.Parameters.AddWithValue("@Dlimage", j.ToArray())
                cmd.Parameters.AddWithValue("@HeImage", f.ToArray())
                cmd.Parameters.AddWithValue("@AlImage", h.ToArray())
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data DELETE Sucessful")

                frmEmployee_Load(Nothing, Nothing)
            End Using
        End If

    End Sub


    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            Dim query As String = "UPDATE employee_form  Set Employee_Name = @employeeName, Nationality= @Nationality, Destination=@Destination, Division=@Division,Qid_No=@Qidno,Qid_Expiry_Date=@QidExpirydate,Passport_Number=@Passportno,PP_Expiry_Date=@PPExpdate,Driving_Licence =@Drivinglicence,D_Licence_Expiry_Date =@DrivinglicenceExp,Health_Card_No= @HealthcardNo,Health_Card_Expiry_Date = @HealthcardExp,Dath_of_Birth =@Dob ,Blood_Group=@Bloodgroup,Join_Date=@JoinDate,Re_entry_date=@ReEntryDate,Total_year_service =@Totalyearservice,Re_service= @Reservice,Basic_salary=@Basicsalary ,Allawance = @Allawance,Mobile_Number=@mobilenumber,Address_in_qater=@Addressinqater,Next_of_kin=@Nextofkin,Image=@image,Destination_Image=@deImage, Qid_image =@Qimage,PP_image=@PPmage,DL_Image=@Dlimage,Health_Image=@HeImage,Allowance_Image=@AlImage WHERE Employee_No = @employeeNo"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Dim a As New MemoryStream
            Dim b As New MemoryStream
            Dim c As New MemoryStream
            Dim d As New MemoryStream
            Dim j As New MemoryStream
            Dim f As New MemoryStream
            Dim h As New MemoryStream
            PictureBox1.Image.Save(a, PictureBox1.Image.RawFormat)
            PictureBox2.Image.Save(b, PictureBox2.Image.RawFormat)
            PictureBox3.Image.Save(c, PictureBox3.Image.RawFormat)
            PictureBox4.Image.Save(d, PictureBox4.Image.RawFormat)
            PictureBox5.Image.Save(j, PictureBox5.Image.RawFormat)
            PictureBox6.Image.Save(f, PictureBox6.Image.RawFormat)
            PictureBox7.Image.Save(h, PictureBox7.Image.RawFormat)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@employeeNo", TextBox1.Text)
                cmd.Parameters.AddWithValue("@employeeName", txtemployeeName.Text)
                cmd.Parameters.AddWithValue("@Nationality", cbNationality.Text)
                cmd.Parameters.AddWithValue("@Destination", txtdestination.Text)
                cmd.Parameters.AddWithValue("@Division", cboDivision.Text)
                cmd.Parameters.AddWithValue("@Qidno", txtQidNo.Text)
                cmd.Parameters.AddWithValue("@QidExpirydate", txtqidexpiry.Text)
                cmd.Parameters.AddWithValue("@Passportno", txtpassNumber.Text)
                cmd.Parameters.AddWithValue("@PPExpdate", txtppexpiry.Text)
                cmd.Parameters.AddWithValue("@Drivinglicence", txtDrivingLi.Text)
                cmd.Parameters.AddWithValue("@DrivinglicenceExp", dtLiciencedate.Text)
                cmd.Parameters.AddWithValue("@HealthcardNo", txtHealthNo.Text)
                cmd.Parameters.AddWithValue("@HealthcardExp", dthealthexpiry.Text)
                cmd.Parameters.AddWithValue("@Dob", dtpDateBirth.Text)
                cmd.Parameters.AddWithValue("@Bloodgroup", cbbloodgroup.Text)
                cmd.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Text)
                cmd.Parameters.AddWithValue("@ReEntryDate", dtentrydate.Text)
                cmd.Parameters.AddWithValue("@Totalyearservice", txtTotalYear.Text)
                cmd.Parameters.AddWithValue("@Reservice", txtreService.Text)
                cmd.Parameters.AddWithValue("@Basicsalary", txtBasicSalary.Text)
                cmd.Parameters.AddWithValue("@Allawance", txtallawance.Text)
                cmd.Parameters.AddWithValue("@mobilenumber", txtMobileNumber.Text)
                cmd.Parameters.AddWithValue("@Addressinqater", txtaddress.Text)
                cmd.Parameters.AddWithValue("@Nextofkin", txtNextKin.Text)
                cmd.Parameters.AddWithValue("@image", a.ToArray())
                cmd.Parameters.AddWithValue("@deImage", b.ToArray())
                cmd.Parameters.AddWithValue("@Qimage", c.ToArray())
                cmd.Parameters.AddWithValue("@PPmage", d.ToArray())
                cmd.Parameters.AddWithValue("@Dlimage", j.ToArray())
                cmd.Parameters.AddWithValue("@HeImage", f.ToArray())
                cmd.Parameters.AddWithValue("@AlImage", h.ToArray())
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Update Sucessful")
                frmEmployee_Load(Nothing, Nothing)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox2.Visible = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox3.Visible = False
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox4.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox4.Visible = False
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox5.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox5.Visible = False
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox6.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox6.Visible = False
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox7.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox7.Visible = False
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        EmployeeForm.ShowDialog()

    End Sub

    Private Sub dtpJoinDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpJoinDate.ValueChanged
        dtpJoinDate.MaxDate = Now.Date
        Dim arrivaldate As DateTime = DateTime.Now
        Dim departuredate As DateTime = Me.dtpJoinDate.Value

        Dim DaysStayed As Int32 = arrivaldate.Subtract(departuredate).TotalDays
        'departuredate.Subtract(arrivaldate).Days

        Dim sure As Int32 = DaysStayed
        txtTotalYear.Text = sure.ToString()


    End Sub

    Private Sub dtentrydate_ValueChanged(sender As Object, e As EventArgs) Handles dtentrydate.ValueChanged

        Dim arrivaldate As DateTime = DateTime.Now
        Dim departuredate As DateTime = Me.dtentrydate.Value
        Dim DaysStayed As Int32 = arrivaldate.Subtract(departuredate).TotalDays
        Dim sure As Double = DaysStayed
        txtreService.Text = sure.ToString()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        picture.PictureBox1.Image = PictureBox6.Image
        picture.ShowDialog()
        ' PictureBox6.Visible = True
        PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            PictureBox5.Visible = False
            PictureBox7.Visible = False



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False

        picture.PictureBox1.Image = PictureBox2.Image
        picture.ShowDialog()


    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dropdown.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        picture.PictureBox1.Image = PictureBox3.Image
        picture.ShowDialog()
        ' PictureBox3.Visible = True
        PictureBox2.Visible = False
            PictureBox4.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False
            PictureBox7.Visible = False


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        picture.PictureBox1.Image = PictureBox4.Image
        picture.ShowDialog()
        'PictureBox4.Visible = True
        PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False
            PictureBox7.Visible = False



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        picture.PictureBox1.Image = PictureBox5.Image
        picture.ShowDialog()
        'PictureBox5.Visible = True
        PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            PictureBox6.Visible = False
            PictureBox7.Visible = False



    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        picture.PictureBox1.Image = PictureBox7.Image
        picture.ShowDialog()
        'PictureBox7.Visible = True
        PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If TextBox11.Text = "" Then
            MsgBox("Please provide what you want To search For", vbInformation)
        ElseIf ComboBox3.Text = "" Then
            MessageBox.Show("please Select from which you want To search")
        ElseIf ComboBox3.Text = "Name" Then
            Dim query As String = " Select * from employee_form where Employee_Name  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "QID Number" Then
            Dim query As String = " select * from employee_form where Qid_No  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Conact Number" Then
            Dim query As String = " select * from employee_form where Mobile_Number  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Passport Number" Then
            Dim query As String = " select * from employee_form where Passport_Number  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "Health card Number" Then
            Dim query As String = " select * from employee_form where Health_Card_No  ='" & TextBox11.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using

        ElseIf ComboBox3.Text = "Driving License Number" Then
            Dim query As String = " select * from employee_form where Driving_Licence  ='" & TextBox11.Text & "'"
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


    Private Sub cboDivision_Click(sender As Object, e As EventArgs) Handles cboDivision.Click

        Try
            Dim Str As String = "select * from DropdownMenu where dropdown = 'Division'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Dim da As New SqlDataAdapter(Str, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then

                cboDivision.DataSource = dt
                cboDivision.DisplayMember = "Added_Text"
                cboDivision.ValueMember = "id"
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub cbNationality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNationality.SelectedIndexChanged

    End Sub

    Private Sub cbNationality_Click(sender As Object, e As EventArgs) Handles cbNationality.Click


        Try
            Dim Str As String = "select * from DropdownMenu where dropdown = 'Nationality'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Dim da As New SqlDataAdapter(Str, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then

                cbNationality.DataSource = dt
                cbNationality.DisplayMember = "Added_Text"
                cbNationality.ValueMember = "id"
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub cbbloodgroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbloodgroup.SelectedIndexChanged

    End Sub

    Private Sub cbbloodgroup_Click(sender As Object, e As EventArgs) Handles cbbloodgroup.Click

        '

        Try
            Dim Str As String = "select * from DropdownMenu where dropdown = 'Blood Group'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Dim da As New SqlDataAdapter(Str, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then

                cbbloodgroup.DataSource = dt
                cbbloodgroup.DisplayMember = "Added_Text"
                cbbloodgroup.ValueMember = "id"
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Try
            xlApp.DisplayAlerts = False
            xlWorkBook = xlApp.Workbooks.Add
            xlWorkSheet = DirectCast(xlWorkBook.Sheets("Sheet1"), Excel.Worksheet)

            xlApp.Visible = True

            xlWorkSheet.Cells(1, 1) = TextBox1.Text
            xlWorkSheet.Cells(1, 2) = txtemployeeName.Text
            xlWorkSheet.Cells(1, 3) = cboDivision.Text
            xlWorkSheet.Cells(1, 4) = txtQidNo.Text
            xlWorkSheet.Cells(1, 5) = txtpassNumber.Text
            xlWorkSheet.Cells(1, 6) = txtDrivingLi.Text
            xlWorkSheet.Cells(1, 7) = txtHealthNo.Text
            xlWorkSheet.Cells(1, 8) = dtpDateBirth.Text
            xlWorkSheet.Cells(1, 9) = dtpJoinDate.Text
            xlWorkSheet.Cells(1, 10) = txtTotalYear.Text
            xlWorkSheet.Cells(1, 11) = txtBasicSalary.Text
            xlWorkSheet.Cells(1, 12) = txtMobileNumber.Text
            xlWorkSheet.Cells(1, 13) = txtNextKin.Text
            xlWorkSheet.Cells(1, 14) = cbNationality.Text
            xlWorkSheet.Cells(1, 15) = txtdestination.Text
            xlWorkSheet.Cells(1, 16) = txtqidexpiry.Text
            xlWorkSheet.Cells(1, 17) = txtppexpiry.Text
            xlWorkSheet.Cells(1, 18) = dtLiciencedate.Text
            xlWorkSheet.Cells(1, 19) = dthealthexpiry.Text
            xlWorkSheet.Cells(2, 20) = cbbloodgroup.Text
            xlWorkSheet.Cells(1, 21) = dtentrydate.Text
            xlWorkSheet.Cells(1, 22) = txtreService.Text
            xlWorkSheet.Cells(1, 23) = txtallawance.Text
            xlWorkSheet.Cells(1, 24) = txtaddress.Text
            xlWorkSheet.Cells(1, 24) = PictureBox1.Image

            xlWorkBook.SaveAs("E:\Book1.xls", FileFormat:=56)
            xlWorkBook.Close() 'Close workbook
            xlApp.Quit() 'Quit the application


            ReleaseObject(xlWorkSheet)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlApp)
            MsgBox("Excel Saved..")
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub



    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

        Me.Close()


    End Sub

    Private Sub cboDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivision.SelectedIndexChanged

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Timer1.Interval = 2 Then
            LoadPopup.Show()

            Timer1.Enabled = False
        End If
        Timer1.Enabled = False

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        For Each rows As DataGridViewRow In DataGridView1.Rows
            If rows.Cells(7).Value = Date.Today Then
                rows.DefaultCellStyle.BackColor = Color.Red
            ElseIf rows.Cells(9).Value = Date.Today Then
                rows.DefaultCellStyle.BackColor = Color.Red
            ElseIf rows.Cells(11).Value = Date.Today Then
                rows.DefaultCellStyle.BackColor = Color.Red
            ElseIf rows.Cells(13).Value = Date.Today Then
                rows.DefaultCellStyle.BackColor = Color.Red
            End If
        Next

    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

    End Sub

    Private Sub txtpassNumber_TextChanged(sender As Object, e As EventArgs) Handles txtpassNumber.TextChanged
        If txtpassNumber.Text = "" Then
            txtppexpiry.CustomFormat = ""
            txtppexpiry.Enabled = False
        Else
            txtppexpiry.Enabled = True
        End If

    End Sub

    Private Sub txtDrivingLi_TextChanged(sender As Object, e As EventArgs) Handles txtDrivingLi.TextChanged
        If txtDrivingLi.Text = "" Then
            dtLiciencedate.CustomFormat = ""
            dtLiciencedate.Enabled = False
        Else
            dtLiciencedate.Enabled = True
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try


            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            txtemployeeName.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            cbNationality.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            txtdestination.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            cboDivision.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            txtQidNo.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            txtqidexpiry.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
            txtpassNumber.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
            txtppexpiry.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
            txtDrivingLi.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
            dtLiciencedate.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value
            txtHealthNo.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value
            dthealthexpiry.Text = DataGridView1.Rows(e.RowIndex).Cells(13).Value
            dtpDateBirth.Text = DataGridView1.Rows(e.RowIndex).Cells(14).Value
            cbbloodgroup.Text = DataGridView1.Rows(e.RowIndex).Cells(15).Value
            dtpJoinDate.Text = DataGridView1.Rows(e.RowIndex).Cells(16).Value
            dtentrydate.Text = DataGridView1.Rows(e.RowIndex).Cells(17).Value
            txtTotalYear.Text = DataGridView1.Rows(e.RowIndex).Cells(18).Value
            txtreService.Text = DataGridView1.Rows(e.RowIndex).Cells(19).Value
            txtBasicSalary.Text = DataGridView1.Rows(e.RowIndex).Cells(20).Value
            txtallawance.Text = DataGridView1.Rows(e.RowIndex).Cells(21).Value
            txtMobileNumber.Text = DataGridView1.Rows(e.RowIndex).Cells(22).Value
            txtaddress.Text = DataGridView1.Rows(e.RowIndex).Cells(23).Value
            txtNextKin.Text = DataGridView1.Rows(e.RowIndex).Cells(24).Value

            Dim img() As Byte
            Dim img1() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte
            img = DataGridView1.Rows(e.RowIndex).Cells(25).Value
            img1 = DataGridView1.Rows(e.RowIndex).Cells(26).Value
            img2 = DataGridView1.Rows(e.RowIndex).Cells(27).Value
            img3 = DataGridView1.Rows(e.RowIndex).Cells(28).Value
            img4 = DataGridView1.Rows(e.RowIndex).Cells(29).Value
            img5 = DataGridView1.Rows(e.RowIndex).Cells(30).Value
            img6 = DataGridView1.Rows(e.RowIndex).Cells(31).Value
            Dim m As New MemoryStream(img)
            Dim m1 As New MemoryStream(img1)
            Dim m2 As New MemoryStream(img2)
            Dim m3 As New MemoryStream(img3)
            Dim m4 As New MemoryStream(img4)
            Dim m5 As New MemoryStream(img5)
            Dim m6 As New MemoryStream(img6)

            PictureBox1.Image = Image.FromStream(m)
            PictureBox2.Image = Image.FromStream(m1)
            PictureBox3.Image = Image.FromStream(m2)
            PictureBox4.Image = Image.FromStream(m3)
            PictureBox5.Image = Image.FromStream(m4)
            PictureBox6.Image = Image.FromStream(m5)
            PictureBox7.Image = Image.FromStream(m6)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class