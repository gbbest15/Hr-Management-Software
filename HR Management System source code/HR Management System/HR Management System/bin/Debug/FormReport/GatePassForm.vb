Imports System.Data.SqlClient
Imports System.Configuration
Public Class GatePassForm
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)

        connection.Open()
        Dim da As New SqlDataAdapter("Select * from Gate_Pass where [Employee_Name] = '" + TextBox1.Text.ToString() + "' ", connection)
        Dim ds As New DataSet
        da.Fill(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.SelectionFormula = "{Gate_Pass.Employee_Name}='" + TextBox1.Text.ToString() + "'"
        CrystalReportViewer1.ReportSource = Application.StartupPath + "\CrystalReport\GatePassReport.rpt"
        connection.Close()
    End Sub

    Private Sub GatePassForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class