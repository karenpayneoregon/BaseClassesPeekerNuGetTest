Imports WindowsApp1.Classes

Public Class Form1
    Private bsCustomers As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim ops As New DataOperations()
        ops.RevealCommand = My.Application.AdminMode

        bsCustomers.DataSource = ops.GetCustomersByTitle("Owner")

        If ops.IsSuccessFul Then
            DataGridView1.DataSource = bsCustomers
        Else
            MessageBox.Show($"{ops.LastExceptionMessage}")
        End If

    End Sub
End Class
