Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class LoadPopup
    Private Sub LoadPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New hr_Management_softwareDataSet2
        Dim ad As New hr_Management_softwareDataSet2TableAdapters.employee_formTableAdapter
        ad.Fill(ds.employee_form)
        Dim rpt As New PopupRequest
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class