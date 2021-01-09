Imports System.Data.SqlClient
Imports System.Configuration
Public Class VehicleForm

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Dim connection As New SqlConnection(constr)

        connection.Open()
        Dim da As New SqlDataAdapter("Select * from Vehicle_No where [Vehicle_No] = '" + TextBox1.Text.ToString() + "' ", connection)
        Dim ds As New DataSet
        da.Fill(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.SelectionFormula = "{Vehicle_No.Vehicle_No}='" + TextBox1.Text.ToString() + "'"
        CrystalReportViewer1.ReportSource = Application.StartupPath + "\CrystalReport\rptVehicleFrom.rpt"
        connection.Close()

        'Try

        'CrystalReportViewer1.SelectionFormula = "{Vehicle_No.Vehicle_No} = '" & TextBox1.Text & "'"
        'CrystalReportViewer1.Refresh()
        'CrystalReportViewer1.RefreshReport()
        'Catch ex As Exception
        ' MsgBox(ex.Message)
        'End Try




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()

    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub VehicleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class