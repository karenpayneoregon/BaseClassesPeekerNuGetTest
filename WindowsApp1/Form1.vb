Imports System.Text
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

        Dim PeopleList As New List(Of Person) From
        {
            New Person With {.Id = 1, .FirstName = "Jim", .LastName = "Jones"},
            New Person With {.Id = 2, .FirstName = "Mary", .LastName = "Adams"}
        }

        Dim manager As New Manager With {.Id = 1, .FirstName = "Karen", .LastName = "Payne", .Employees = PeopleList}

        Dim TextBox1 As New TextBox With {.Text = "/"}


        Dim result As String = "Apples/Oranges/Grapes"


        Dim parts As String() = result.
                Split(New String() {TextBox1.Text}, StringSplitOptions.None).
                ToList().Where(Function(line) Not String.IsNullOrWhiteSpace(line)).
                ToArray()

        For Each something In parts
            Console.WriteLine(something)
        Next
    End Sub
End Class
Public Class Person
    Public Property Id() As Integer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public ReadOnly Property FullName() As String
        Get
            Return $"{FirstName} {LastName}"
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Id.ToString()
    End Function
End Class
Public Class Manager
    Inherits Person
    Public Property Division() As String
    Public Property Employees() As List(Of Person)
End Class
Public Class Employee
    Inherits Person

    Public Property StartTime() As TimeSpan
    Public Property EndTime() As TimeSpan
    Public Property Manager() As Manager
End Class
