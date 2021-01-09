Imports System.Data.SqlClient
Imports System.Configuration
Public Class Dropdown
    Private Sub Dropdown_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bind_datagrid()
    End Sub
    Private Sub bind_datagrid()
        Dim query As String = "SELECT * from DropdownMenu  "
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Using cmd As SqlCommand = New SqlCommand(query, connection)
            Dim da As New SqlDataAdapter()
            da.SelectCommand = cmd
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt

        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "INSERT INTO DropdownMenu (dropdown,Added_Text) values (@dropdown,@addedtext)"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Try
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dropdown", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@addedtext", TextBox1.Text)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Save Sucessful")
                bind_datagrid()
                TextBox1.Clear()

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query As String = "Update  DropdownMenu SET dropdown=@dropdown,Added_Text=@addedtext WHERE id=@id"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Try
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", Label2.Text)
                cmd.Parameters.AddWithValue("@dropdown", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@addedtext", TextBox1.Text)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Update Sucessful")
                bind_datagrid()
                TextBox1.Clear()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "Delete from  DropdownMenu WHERE id=@id"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Try
            Using cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", Label2.Text)
                cmd.Parameters.AddWithValue("@dropdown", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@addedtext", TextBox1.Text)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Data Delete Sucessful")
                bind_datagrid()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer

        With DataGridView1
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                Label2.Text = .Rows(i).Cells("id").Value.ToString
                ComboBox1.Text = .Rows(i).Cells("dropdown").Value.ToString
                TextBox1.Text = .Rows(i).Cells("Added_Text").Value.ToString

            End If
        End With
    End Sub
End Class