Imports System.Data.SqlClient
Imports System.Configuration
Public Class Backup
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dread As SqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        blank("backup")
        bersih()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        blank("restore")
        bersih()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label3.Show()
        If ProgressBar1.Value = 25 Then
            Label3.Text = "25%"
        End If

        If ProgressBar1.Value = 50 Then
            Label3.Text = "50%"
        End If
        If ProgressBar1.Value = 75 Then
            Label3.Text = "75%"
        End If

        If ProgressBar1.Value = 100 Then
            Label3.Text = "100%"
        End If

        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Show()
            Timer1.Stop()
            MsgBox("Backup Succesful")
            Me.Close()
        End If

    End Sub

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Hide()
        ProgressBar1.Hide()
        server(".")
        server(".\sqlexpress")
    End Sub
    Sub blank(ByVal str As String)
        If cmbserver.Text = "" Or cmbdatabase.Text = "" Then
            MsgBox("Server Name & Database Blank Field")
            Exit Sub
        Else
            If str = "backup" Then
                SaveFileDialog1.FileName = cmbdatabase.Text

                SaveFileDialog1.ShowDialog()
                Timer1.Enabled = True
                ProgressBar1.Visible = True
                Dim s As String
                s = SaveFileDialog1.FileName
                query("backup database " & cmbdatabase.Text & " to disk='" & s & "'")
            Else
                If str = "restore" Then
                    OpenFileDialog1.ShowDialog()
                    Timer1.Enabled = True
                    ProgressBar1.Visible = True
                    query("RESTORE DATABASE " & cmbdatabase.Text & " FROM disk='" & OpenFileDialog1.FileName & "'")
                End If
            End If
        End If

    End Sub
    Sub query(ByVal que As String)
        On Error Resume Next
        cmd = New SqlCommand(que, con)
        cmd.ExecuteNonQuery()
    End Sub
    Sub connection()
        con = New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";Database=hr Management software;user id=sa;pwd=gbenga;")
        con.Open()
        cmbdatabase.Items.Clear()
        cmd = New SqlCommand("select * from sysdatabases", con)
        dread = cmd.ExecuteReader
        While dread.Read
            cmbdatabase.Items.Add(dread(0))
        End While
        dread.Close()
    End Sub
    Sub server(ByVal str As String)
        con = New SqlConnection("Data Source=.;Database=hr Management software;user id=sa;pwd=gbenga;")
        con.Open()
        cmd = New SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con)
        dread = cmd.ExecuteReader
        While dread.Read
            cmbserver.Items.Add(dread(2))
        End While
        dread.Close()
    End Sub
    Sub bersih()
        cmbserver.Text = ""
        cmbdatabase.Text = ""
        Label3.Text = ""
    End Sub

    Private Sub groupbox1_Enter(sender As Object, e As EventArgs) Handles groupbox1.Enter

    End Sub

    Private Sub cmbserver_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbserver.SelectedIndexChanged
        connection()
    End Sub
End Class