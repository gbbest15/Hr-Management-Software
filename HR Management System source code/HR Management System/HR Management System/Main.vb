Public Class Main
    Private Sub EndToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EndToolStripMenuItem.Click
        Me.Close()
        Dim f As New Login
        f.Show()
        Login.txtpass.Clear()
        Login.txtuser.Clear()


    End Sub

    Private Sub ExiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExiteToolStripMenuItem.Click
        Me.Hide()
        Login.Show()
        Login.txtpass.Clear()
        Login.txtuser.Clear()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmVehicle.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Letters.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LeaveSavary.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmEmployee.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gatepass.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TrainingCert.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        VehicleExpenses.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        VacationSchedule.Show()
    End Sub

    Private Sub BackUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackUpToolStripMenuItem.Click
        Backup.Show()
    End Sub

    Private Sub DataBaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataBaseToolStripMenuItem.Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub AddVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddVehicleToolStripMenuItem.Click
        frmVehicle.Show()
    End Sub

    Private Sub EmployeeFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeFormToolStripMenuItem.Click
        frmEmployee.Show()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class