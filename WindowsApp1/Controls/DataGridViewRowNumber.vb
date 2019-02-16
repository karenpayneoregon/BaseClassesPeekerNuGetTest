Namespace Controls
    ''' <summary>
    ''' This DataGridView will display row number of each row in the row header.
    ''' </summary>
    Public Class DataGridViewRowNumber
        Inherits DataGridView

        Protected Overrides Sub OnRowPostPaint(e As DataGridViewRowPostPaintEventArgs)

            Dim rowNumber As String = (e.RowIndex + 1).ToString()

            Dim sizeVar As SizeF = e.Graphics.MeasureString(rowNumber, Font)

            If RowHeadersWidth < CInt(sizeVar.Width + 20) Then
                RowHeadersWidth = CInt(sizeVar.Width + 20)
            End If

            Dim b As Brush = SystemBrushes.ControlText

            e.Graphics.DrawString(
                rowNumber,
                Font,
                b,
                e.RowBounds.Location.X + 15,
                e.RowBounds.Location.Y + ((e.RowBounds.Height - sizeVar.Height) / 2)
            )

            MyBase.OnRowPostPaint(e)

        End Sub
    End Class
End Namespace