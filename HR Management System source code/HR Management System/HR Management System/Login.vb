Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Public Class Login
    Dim close As Boolean = False


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtpass.UseSystemPasswordChar = False
        Else
            txtpass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)
        Dim command As New SqlCommand("SELECT * FROM login WHERE Username = @username and Password= @password", connection)
        command.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = txtuser.Text
        command.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = txtpass.Text
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then
            MsgBox("Incorrect Username or Password")

        Else

            Me.Hide()
            Main.Show()

            MsgBox("Welcome to the HR MANAGEMENT SOFTWARE")

        End If




    End Sub

    Private Sub txtuser_TextChanged(sender As Object, e As EventArgs) Handles txtuser.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        close = "true"
        If close = "true" Then
            Application.Exit()

        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If close = "False" Then
            e.Cancel = True
            Me.Hide()

            NotifyIcon1.ShowBalloonTip(1000, "HR MANAGEMENT SOFTWARE", "Still Runing in the Notification", ToolTipIcon.Info)
        End If


    End Sub

    Private Sub Login_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        Me.Show()
    End Sub
End Class
