Imports System.Data.SqlClient
Imports System.IO
Imports BaseConnectionLibrary.ConnectionClasses

Namespace Classes

    Public Class DataOperations
        Inherits SqlServerConnection

        Private _excelCompanyFileName As String = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx")

        Public Function CopyToApplicationFolder(pFileName As String) As Boolean

            Try

                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\{Path.GetFileName(pFileName)}"),
                          Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), True)

                Return True

            Catch e1 As Exception
                Return False
            End Try

        End Function
        Public Sub WriteCustomerTableToXmlFile(pFileName As String, ByRef pRowsExported As Integer)

            CopyToApplicationFolder(_excelCompanyFileName)

            ' server name
            DatabaseServer = "KARENS-PC"
            ' database name
            DefaultCatalog = "ExcelExporting"

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {.Connection = cn}


                    cmd.CommandText = "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', " &
                                      $"'Excel 12.0;Database={pFileName}','SELECT * from [Customers$]') " &
                                      "SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle," &
                                      "[Address],City,Region,PostalCode,Country,Phone " &
                                      "FROM Customers"

                    Try
                        cn.Open()
                        pRowsExported = cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try
                End Using
            End Using
        End Sub
    End Class
End Namespace