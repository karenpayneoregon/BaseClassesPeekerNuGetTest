Imports System.IO
Imports WindowsApp3.Classes

Public Class Form1
    Private Sub exportExcelButton_Click(sender As Object, e As EventArgs) Handles exportExcelButton.Click

        Dim fileName As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx")
        Dim rowsExported = 0

        Dim ops As New DataOperations
        ops.WriteCustomerTableToXmlFile(fileName, rowsExported)

        If ops.IsSuccessFul Then
            MessageBox.Show($"Done, exported {rowsExported} rows")
        Else
            MessageBox.Show($"Error{Environment.NewLine}{ops.LastExceptionMessage}")
        End If

    End Sub
End Class
