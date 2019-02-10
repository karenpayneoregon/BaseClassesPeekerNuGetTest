Imports System.Data.SqlClient
Imports System.Reflection
Imports BaseConnectionLibrary.ConnectionClasses
Imports DataProviderCommandHelpers

Namespace Classes
    Public Class DataOperations
        Inherits SqlServerConnection

        ''' <summary>
        ''' Used to display or not to display SQL statements
        ''' </summary>
        ''' <returns></returns>
        Public Property RevealCommand() As Boolean

        ''' <summary>
        ''' Setup connection and if command text should be shown
        ''' </summary>
        ''' <param name="pRevealCommand"></param>
        Public Sub New(Optional pRevealCommand As Boolean = False)
            DatabaseServer = "KARENS-PC"
            DefaultCatalog = "WorkingWithDataTips_1"
            RevealCommand = pRevealCommand
        End Sub
        ''' <summary>
        ''' Return active or inactive customers
        ''' </summary>
        ''' <param name="pStatus">Status of customers</param>
        ''' <returns>DataTable</returns>
        Public Function GetCustomersByStatus(Optional pStatus As Boolean = True) As DataTable

            Dim dt As New DataTable

            mHasException = False

            Dim selectStatement As String =
                    "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " &
                    "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, " &
                    " Country, JoinDate AS Joined " &
                    "FROM dbo.Customers " &
                    "WHERE ActiveStatus = @ActiveStatus"


            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {.Connection = cn}

                    cmd.CommandText = selectStatement
                    cmd.Parameters.AddWithValue("@ActiveStatus", pStatus)

                    Try

                        cn.Open()

                        If RevealCommand Then
                            Console.WriteLine($"SQL From {MethodBase.GetCurrentMethod()}")
                            Console.WriteLine(cmd.RevealCommandQuery())
                        End If

                        dt.Load(cmd.ExecuteReader())
                        dt.Columns("CustomerIdentifier").ColumnMapping = MappingType.Hidden

                    Catch ex As Exception

                        mHasException = True
                        mLastException = ex

                    End Try

                End Using
            End Using

            Return dt
        End Function
        ''' <summary>
        ''' Return Customers by contact title
        ''' </summary>
        ''' <param name="pContactTitle">Contact title type</param>
        ''' <returns>DataTable</returns>
        Public Function GetCustomersByTitle(Optional pContactTitle As String = "Owner") As DataTable

            Dim dt As New DataTable

            mHasException = False

            Dim selectStatement As String =
                    "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " &
                    "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, " &
                    "Country, JoinDate AS Joined " &
                    "FROM dbo.Customers " &
                    "WHERE ContactTitle = @ContactTitle"

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {.Connection = cn}

                    cmd.CommandText = selectStatement
                    cmd.Parameters.AddWithValue("@ContactTitle", pContactTitle)

                    Try

                        If RevealCommand Then
                            Console.WriteLine($"SQL From {MethodBase.GetCurrentMethod()}")
                            Console.WriteLine(cmd.RevealCommandQuery())
                        End If


                        cn.Open()

                        dt.Load(cmd.ExecuteReader())
                        dt.Columns("CustomerIdentifier").ColumnMapping = MappingType.Hidden

                    Catch ex As Exception

                        mHasException = True
                        mLastException = ex

                    End Try

                End Using
            End Using

            Return dt

        End Function

    End Class
End Namespace