Imports System.IO
Imports BaseConnectionLibrary

Public Class FileOperations
    Inherits BaseExceptionProperties
    Public Function ReadFileWithBaseExceptionProperties(ByVal fileName As String) As List(Of String)
        mHasException = False
        Dim lines = New List(Of String)()

        Try
            lines = File.ReadAllLines(fileName).ToList()
        Catch e As Exception
            mHasException = True
            mLastException = e
        End Try
        Return lines
    End Function

End Class

