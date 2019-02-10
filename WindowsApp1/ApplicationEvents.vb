Namespace My

    Partial Friend Class MyApplication
        ''' <summary>
        ''' Property to get command arguments minus argument 0 which is the
        ''' path and executable name
        ''' </summary>
        ''' <returns>Command arguments if present</returns>
        Public ReadOnly Property CommandLineArguments As String()
            Get
                Dim arguments = Environment.
                        GetCommandLineArgs.
                        ToList().
                        Select(Function(argument) argument.ToUpper()).
                        ToList()

                arguments.RemoveAt(0)

                Return arguments.ToArray()

            End Get
        End Property
        ''' <summary>
        ''' Determine if admin mode was requested
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property AdminMode() As Boolean
            Get
                If HasCommandLineArguments Then
                    Return CommandLineArguments.Contains("-ADMIN")
                Else
                    Return False
                End If
            End Get
        End Property
        ''' <summary>
        ''' Used to get command argument count
        ''' </summary>
        ''' <returns>Count of command arguments sent on startup of application</returns>
        Public ReadOnly Property HasCommandLineArguments As Boolean
            Get
                Return CommandLineArguments.Length = 1
            End Get
        End Property
    End Class
End Namespace
