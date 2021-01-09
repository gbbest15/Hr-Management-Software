Imports System.Data.SqlClient
Imports System.Configuration
Public Class LeaveForm
    Private Sub LeaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New hr_Management_softwareDataSet1
        Dim ad As New hr_Management_softwareDataSet1TableAdapters.Leave_SalaryTableAdapter
        ad.Fill(ds.Leave_Salary)
        Dim rpt As New LS
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)

        connection.Open()
        Dim da As New SqlDataAdapter("Select * from Leave_Salary where ID_No = '" + TextBox1.Text + "' ", connection)
        Dim ds As New DataSet
        da.Fill(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.SelectionFormula = "{Leave_Salary.ID_No}='" + TextBox1.Text + "'"
        CrystalReportViewer1.RefreshReport()
        connection.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class