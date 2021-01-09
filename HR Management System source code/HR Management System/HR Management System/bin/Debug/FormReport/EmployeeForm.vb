Imports System.Data.SqlClient
Imports System.Configuration
Public Class EmployeeForm
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)

        connection.Open()
        Dim da As New SqlDataAdapter("Select * from employee_form where [Employee_No] = '" + TextBox1.Text.ToString() + "' ", connection)
        Dim ds As New DataSet
        da.Fill(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.SelectionFormula = "{employee_form.Employee_No}='" + TextBox1.Text.ToString() + "'"
        CrystalReportViewer1.ReportSource = Application.StartupPath + "\CrystalReport\EmployeeReport.rpt"
        connection.Close()
    End Sub

    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class