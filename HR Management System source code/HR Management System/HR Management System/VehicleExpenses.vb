Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Windows.Forms.DataVisualization.Charting
Public Class VehicleExpenses
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub VehicleExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet1.Vehicle_Expenses' table. You can move, or remove it, as needed.
        Me.Vehicle_ExpensesTableAdapter1.Fill(Me.Hr_Management_softwareDataSet1.Vehicle_Expenses)
        'TODO: This line of code loads data into the 'Hr_Management_softwareDataSet.Vehicle_Expenses' table. You can move, or remove it, as needed.
        Me.Vehicle_ExpensesTableAdapter.Fill(Me.Hr_Management_softwareDataSet.Vehicle_Expenses)
        'TODO: This line of code loads data into the 'School_managementDataSet.Login' table. You can move, or remove it, as needed.
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridView1.EnableHeadersVisualStyles = False
        chart()

    End Sub

    Private Sub chart()
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim sqlProducts As String = "select * from Vehicle_Expenses"
        Dim da As New SqlDataAdapter(sqlProducts, connection)
        Dim ds As New DataSet()
        da.Fill(ds)

        Dim ChartArea1 As ChartArea = New ChartArea()
        Dim Legend1 As Legend = New Legend()
        Dim Series1 As Series = New Series()
        Dim Chart1 = New Chart()
        Me.Controls.Add(Chart1)

        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)

        Chart1.Name = "Month"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New System.Drawing.Size(20, 20)
        Chart1.TabIndex = 0
        Chart1.Text = "Chart1"

        Chart1.Series("Series1").XValueMember = "Date"
        Chart1.Series("Series1").YValueMembers = "Amount"

        Chart1.DataSource = ds
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query1 As String = "select * from Vehicle_Expenses  WHERE Vehicle_No = @vehicle "
        Dim Constrr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection1 As New SqlConnection(Constrr)
        Dim cmd1 As SqlCommand = New SqlCommand(query1, connection1)
        connection1.Open()
        cmd1.Parameters.AddWithValue("@vehicle", txtvehicleNo.Text)
        Using reader As SqlDataReader = cmd1.ExecuteReader()
            If reader.HasRows Then
                MsgBox("  Vehicle No - User Already Exist !!!", MsgBoxStyle.Exclamation, "Add New User !!")
            Else
                Dim query As String = "INSERT INTO Vehicle_Expenses (Date,Vehicle_No, Description, Expenses, Fine, Amount) values (@date,@vehicle,@Des,@Exp,@fin,@Amount)"
                Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
                Dim connection As New SqlConnection(constr)
                Try
                    Using cmd As SqlCommand = New SqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@Date", txtdate.Text)
                        cmd.Parameters.AddWithValue("@vehicle", txtvehicleNo.Text)
                        cmd.Parameters.AddWithValue("@Des", txtDescription.Text)
                        cmd.Parameters.AddWithValue("@Exp", txtexpenses.Text)
                        cmd.Parameters.AddWithValue("@fin", txtfine.Text)
                        cmd.Parameters.AddWithValue("@Amount", txtamount.Text)
                        connection.Open()
                        cmd.ExecuteNonQuery()
                        connection.Close()
                        MsgBox("Data Save Sucessful")
                        Chart1.DataBind()
                        VehicleExpenses_Load(Nothing, Nothing)
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()


    End Sub
    Private Sub clear()
        txtamount.Clear()
        txtDescription.Clear()
        txtexpenses.Clear()
        txtfine.Clear()
        txtvehicleNo.Clear()
    End Sub

    Private Sub txtexpenses_TextChanged(sender As Object, e As EventArgs) Handles txtexpenses.TextChanged

    End Sub

    Private Sub txtexpenses_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexpenses.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""

    End Sub

    Private Sub txtfine_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfine.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""

    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "UPDATE Vehicle_Expenses SET Date = @date, Description=@Des, Expenses=@Exp, Fine=@fin, Amount=@Amount WHERE Vehicle_No = @vehicle"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Try
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Date", txtdate.Text)
                cmd.Parameters.AddWithValue("@vehicle", txtvehicleNo.Text)
                cmd.Parameters.AddWithValue("@Des", txtDescription.Text)
                cmd.Parameters.AddWithValue("@Exp", txtexpenses.Text)
                cmd.Parameters.AddWithValue("@fin", txtfine.Text)
                cmd.Parameters.AddWithValue("@Amount", txtamount.Text)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()

                MsgBox("Data UPDATE Sucessful")
                VehicleExpenses_Load(Nothing, Nothing)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtfine_TextChanged(sender As Object, e As EventArgs) Handles txtfine.TextChanged
        If txtexpenses.Text <> "" And txtfine.Text <> "" Then
            Dim num1 As Integer = txtexpenses.Text
            Dim num2 As Integer = txtfine.Text
            Dim ans As Integer = num1 + num2
            txtamount.Text = FormatCurrency(ans)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "DELETE FROM Vehicle_Expenses WHERE Vehicle_No = @vehicle"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Try
            DialogResult = MsgBox("DID YOU WANT TO DELECT", vbYesNo)
            If DialogResult = vbYes Then
                Using cmd As SqlCommand = New SqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Date", txtdate.Text)
                    cmd.Parameters.AddWithValue("@vehicle", txtvehicleNo.Text)
                    cmd.Parameters.AddWithValue("@Des", txtDescription.Text)
                    cmd.Parameters.AddWithValue("@Exp", txtexpenses.Text)
                    cmd.Parameters.AddWithValue("@fin", txtfine.Text)
                    cmd.Parameters.AddWithValue("@Amount", txtamount.Text)
                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                    clear()
                    MsgBox("Data DELECTED Sucessful")
                    VehicleExpenses_Load(Nothing, Nothing)
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Try


            If TextBox11.Text = "" Then
                ErrorProvider1.SetError(TextBox11, "Please provide what you want to search for")
            ElseIf ComboBox3.Text = "" Then
                ErrorProvider1.SetError(ComboBox3, "please select from which you want to search")
            ElseIf ComboBox3.Text = "Vehicle No" Then
                Dim query As String = " select * from Vehicle_Expenses where Vehicle_No  ='" & TextBox11.Text & "'"
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
                Dim query As String = " select * from Vehicle_Expenses where Date  ='" & TextBox11.Text & "'"
                Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
                Dim connection As New SqlConnection(constr)
                Using cmd As SqlCommand = New SqlCommand(query, connection)
                    Dim da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    DataGridView1.DataSource = dt
                End Using
            ElseIf ComboBox3.Text = "Fine" Then
                Dim query As String = " select * from Vehicle_Expenses where Fine  ='" & TextBox11.Text & "'"
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Close()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            txtdate.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            txtvehicleNo.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            txtDescription.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            txtexpenses.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            txtfine.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            txtamount.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class