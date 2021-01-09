Imports System.Data.SqlClient
Imports System.Configuration
Public Class VehicleForm

    Private Sub Button5_Click(sender As Object, e As EventArgs)





    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class