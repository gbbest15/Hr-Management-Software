Imports System.Configuration
Imports System.Data.SqlClient
Public Class TraningCertificateForm
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)

        connection.Open()
        Dim da As New SqlDataAdapter("Select * from cert_tran where [Employee_Name] = '" + TextBox1.Text.ToString() + "' ", connection)
        Dim ds As New DataSet
        da.Fill(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.SelectionFormula = "{cert_tran.Employee_Name}='" + TextBox1.Text.ToString() + "'"
        CrystalReportViewer1.ReportSource = Application.StartupPath + "\CrystalReport\TraningCertificate.rpt"
        connection.Close()
    End Sub

    Private Sub TraningCertificateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class