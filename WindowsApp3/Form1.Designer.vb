<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.exportExcelButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'exportExcelButton
        '
        Me.exportExcelButton.Location = New System.Drawing.Point(35, 37)
        Me.exportExcelButton.Name = "exportExcelButton"
        Me.exportExcelButton.Size = New System.Drawing.Size(140, 23)
        Me.exportExcelButton.TabIndex = 0
        Me.exportExcelButton.Text = "Export To Excel"
        Me.exportExcelButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(211, 96)
        Me.Controls.Add(Me.exportExcelButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel from SQL-Server to Excel"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents exportExcelButton As Button
End Class
