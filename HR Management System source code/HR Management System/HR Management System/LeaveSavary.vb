Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class LeaveSavary
    Private Sub LeaveSavary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.gratidute_paid' table. You can move, or remove it, as needed.
        Me.Gratidute_paidTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.gratidute_paid)
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.Leave_Salary' table. You can move, or remove it, as needed.
        Me.Leave_SalaryTableAdapter.Fill(Me.Hr_Management_softwareDataSet1.Leave_Salary)
        DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridView2.EnableHeadersVisualStyles = False

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim query As String = "INSERT INTO  gratidute_paid (Description,Paid) values(@description, @paid) "
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@description", TextBox6.Text)
                cmd.Parameters.AddWithValue("@paid", TextBox3.Text)
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Save Sucessful")
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        LeaveSavary_Load(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim query As String = "DELECT gratidute_paid WHERE Description= @description"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@description", TextBox6.Text)
                cmd.Parameters.AddWithValue("@paid", TextBox3.Text)
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Delete Sucessful")

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        LeaveSavary_Load(Nothing, Nothing)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick



    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Try
            Dim query As String = "INSERT INTO  Leave_Salary (Date, Employee_Name, ID_No, Nationality, Agreement_Date, Departure_Date, Agreement_Salary, Date_From, Date_To, Total_Days, T_Absent, No_Day_Vacation, T_Works_Days, Total_Leave_Days, T_Leave_Salary, T_End_Service, Net_Payable, Net_Balance) VALUES (@date, @employeeName, @idno, @nationality, @agreementdate, @departureDate, @agreementSalary,@datefrom, @Dateto, @totaldays, @tamount, @nodayVacation, @tworkdays, @totalleavedays, @tleavesalary, @tendservice, @netpayable, @netbalance)"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@date", TextBox1.Text)
                cmd.Parameters.AddWithValue("@employeeName", txtemployeeName.Text)
                cmd.Parameters.AddWithValue("@idno", txtQidNo.Text)
                cmd.Parameters.AddWithValue("@nationality", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@agreementdate", TextBox5.Text)
                cmd.Parameters.AddWithValue("@departureDate", TextBox7.Text)
                cmd.Parameters.AddWithValue("@agreementSalary", TextBox4.Text)
                cmd.Parameters.AddWithValue("@datefrom", dtpDateFrom.Text)
                cmd.Parameters.AddWithValue("@Dateto", dtpDateTo.Text)
                cmd.Parameters.AddWithValue("@totaldays", TextBox13.Text)
                cmd.Parameters.AddWithValue("@tamount", TextBox8.Text)
                cmd.Parameters.AddWithValue("@nodayVacation", TextBox10.Text)
                cmd.Parameters.AddWithValue("@tworkdays", TextBox12.Text)
                cmd.Parameters.AddWithValue("@totalleavedays", TextBox14.Text)
                cmd.Parameters.AddWithValue("@tleavesalary", TextBox18.Text)
                cmd.Parameters.AddWithValue("@tendservice", TextBox16.Text)
                cmd.Parameters.AddWithValue("@netpayable", TextBox20.Text)
                cmd.Parameters.AddWithValue("@netbalance", txtnetbal.Text)
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Save Sucessful")
                LeaveSavary_Load(Nothing, Nothing)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dtpDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateFrom.ValueChanged

    End Sub

    Private Sub dtpDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateTo.ValueChanged
        Dim arrivaldate As DateTime = Me.dtpDateFrom.Value
        Dim departuredate As DateTime = Me.dtpDateTo.Value

        Dim DaysStayed As Int32 = departuredate.Subtract(arrivaldate).Days

        Dim sure As String = DaysStayed
        TextBox13.Text = sure.ToString()
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged



    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text <> "" Then
            TextBox14.Text = Val((TextBox19.Text / 365) * 21)
        End If

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Dim sum As Integer
        Dim sum1 As Integer
        If TextBox10.Text <> "" Then
            sum = ((TextBox8.Text) + CDbl(TextBox10.Text))
            TextBox12.Text = (TextBox13.Text) - CDbl(sum)

        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        If TextBox12.Text <> "" Then
            TextBox19.Text = Val(TextBox12.Text).ToString
        End If

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If TextBox2.Text = "" Then
            MsgBox("Please provide what you want to search for", vbInformation)
        ElseIf ComboBox3.Text = "" Then
            MessageBox.Show("please select from which you want to search")
        ElseIf ComboBox3.Text = "Employee Name" Then
            Dim query As String = " select * from Leave_Salary where Employee_Name  ='" & TextBox2.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView2.DataSource = dt
            End Using
        ElseIf ComboBox3.Text = "ID Number" Then
            Dim query As String = " select * from Vehicle_Expenses where ID_No  ='" & TextBox2.Text & "'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView2.DataSource = dt
            End Using
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text <> "" Then
            TextBox18.Text = Val((600 / 30) * TextBox14.Text).ToString("C")
            TextBox16.Text = Val((600 / 30) * TextBox14.Text).ToString("C")
        End If
    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged
        TextBox16.Text = Val(TextBox18.Text).ToString("C")

    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            Dim query As String = "UPDATE Leave_Salary SET Date = @date, Employee_Name = @employeeName, Nationality = @nationality, Agreement_Date = @agreementdate, Departure_Date = @departureDate, Agreement_Salary = @agreementSalary, Date_From= @datefrom, Date_To=@Dateto, Total_Days =@totaldays, T_Absent =@tamount, No_Day_Vacation=@nodayVacation, T_Works_Days=@tworkdays, Total_Leave_Days=@totalleavedays , T_Leave_Salary=@tleavesalary, T_End_Service =@tendservice, Net_Payable =@netpayable, Net_Balance = @netbalance WHERE  ID_No= @idno"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@date", TextBox1.Text)
                cmd.Parameters.AddWithValue("@employeeName", txtemployeeName.Text)
                cmd.Parameters.AddWithValue("@idno", txtQidNo.Text)
                cmd.Parameters.AddWithValue("@nationality", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@agreementdate", TextBox5.Text)
                cmd.Parameters.AddWithValue("@departureDate", TextBox7.Text)
                cmd.Parameters.AddWithValue("@agreementSalary", TextBox4.Text)
                cmd.Parameters.AddWithValue("@datefrom", dtpDateFrom.Text)
                cmd.Parameters.AddWithValue("@Dateto", dtpDateTo.Text)
                cmd.Parameters.AddWithValue("@totaldays", TextBox13.Text)
                cmd.Parameters.AddWithValue("@tamount", TextBox8.Text)
                cmd.Parameters.AddWithValue("@nodayVacation", TextBox10.Text)
                cmd.Parameters.AddWithValue("@tworkdays", TextBox12.Text)
                cmd.Parameters.AddWithValue("@totalleavedays", TextBox14.Text)
                cmd.Parameters.AddWithValue("@tleavesalary", TextBox18.Text)
                cmd.Parameters.AddWithValue("@tendservice", TextBox16.Text)
                cmd.Parameters.AddWithValue("@netpayable", TextBox20.Text)
                cmd.Parameters.AddWithValue("@netbalance", txtnetbal.Text)
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Update Sucessful")
                LeaveSavary_Load(Nothing, Nothing)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Try
            Dim query As String = "DELETE from Leave_Salary  WHERE  ID_No= @idno"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
            If DialogResult = vbYes Then
                Using cmd As SqlCommand = New SqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@date", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@employeeName", txtemployeeName.Text)
                    cmd.Parameters.AddWithValue("@idno", txtQidNo.Text)
                    cmd.Parameters.AddWithValue("@nationality", ComboBox1.Text)
                    cmd.Parameters.AddWithValue("@agreementdate", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@departureDate", TextBox7.Text)
                    cmd.Parameters.AddWithValue("@agreementSalary", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@datefrom", dtpDateFrom.Text)
                    cmd.Parameters.AddWithValue("@Dateto", dtpDateTo.Text)
                    cmd.Parameters.AddWithValue("@totaldays", TextBox13.Text)
                    cmd.Parameters.AddWithValue("@tamount", TextBox8.Text)
                    cmd.Parameters.AddWithValue("@nodayVacation", TextBox10.Text)
                    cmd.Parameters.AddWithValue("@tworkdays", TextBox12.Text)
                    cmd.Parameters.AddWithValue("@totalleavedays", TextBox14.Text)
                    cmd.Parameters.AddWithValue("@tleavesalary", TextBox18.Text)
                    cmd.Parameters.AddWithValue("@tendservice", TextBox16.Text)
                    cmd.Parameters.AddWithValue("@netpayable", TextBox20.Text)
                    cmd.Parameters.AddWithValue("@netbalance", txtnetbal.Text)
                    cmd.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Data Delete Sucessful")
                    LeaveSavary_Load(Nothing, Nothing)
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TextBox6.Clear()
        TextBox3.Clear()
        TextBox1.Clear()
        txtemployeeName.Clear()
        txtQidNo.Clear()
        TextBox5.Clear()
        TextBox7.Clear()
        TextBox4.Clear()
        TextBox13.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        TextBox12.Clear()
        TextBox14.Clear()
        TextBox18.Clear()
        TextBox16.Clear()
        TextBox20.Clear()
        txtnetbal.Clear()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        LeaveForm.ShowDialog()


    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Hide()

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        Try
            Dim Str As String = "select * from DropdownMenu where dropdown = 'Nationality'"
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
            Dim connection As New SqlConnection(constr)
            connection.Open()
            Dim da As New SqlDataAdapter(Str, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then

                ComboBox1.DataSource = dt
                ComboBox1.DisplayMember = "Added_Text"
                ComboBox1.ValueMember = "id"
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        Try

            TextBox1.Text = DataGridView2.Rows(e.RowIndex).Cells(0).Value
            txtemployeeName.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value
            txtQidNo.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            ComboBox1.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value
            TextBox5.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value
            TextBox7.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            TextBox4.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value
            dtpDateFrom.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value
            dtpDateTo.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value
            TextBox13.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value
            TextBox8.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value
            TextBox10.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value
            TextBox12.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value
            TextBox14.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value
            TextBox18.Text = DataGridView2.Rows(e.RowIndex).Cells(14).Value
            TextBox16.Text = DataGridView2.Rows(e.RowIndex).Cells(15).Value
            TextBox20.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value
            txtnetbal.Text = DataGridView2.Rows(e.RowIndex).Cells(17).Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        If TextBox20.Text <> "" Then
            txtnetbal.Text = Val(TextBox20.Text)
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text <> "" Then
            TextBox20.Text = Val(TextBox20.Text) - Val(TextBox3.Text)
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox3.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class