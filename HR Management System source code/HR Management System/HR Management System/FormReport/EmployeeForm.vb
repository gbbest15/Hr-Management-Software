Imports System.Data.SqlClient
Imports System.Configuration
Public Class EmployeeForm
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)

        connection.Open()
        Dim da As New SqlDataAdapter("Select * from employee_form where Employee_No = '" + TextBox1.Text + "' ", connection)
        Dim ds As New DataSet
        da.Fill(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.SelectionFormula = "{employee_form.Employee_No}='" + TextBox1.Text + "'"
        CrystalReportViewer1.RefreshReport()
        connection.Close()


    End Sub

    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New hr_Management_softwareDataSet2
        Dim ad As New hr_Management_softwareDataSet2TableAdapters.employee_formTableAdapter
        ad.Fill(ds.employee_form)
        Dim rpt As New EmployeeReport
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class