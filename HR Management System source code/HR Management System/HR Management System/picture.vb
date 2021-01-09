Imports System.Drawing.Printing

Public Class picture


    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        PrintDocument1.Print()
        ' PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub picture_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(PictureBox1.Image, 0, 0)
    End Sub
End Class