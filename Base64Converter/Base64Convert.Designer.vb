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
        Me.txtASCII = New System.Windows.Forms.TextBox()
        Me.txtBase64 = New System.Windows.Forms.TextBox()
        Me.btnDecode = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEncode = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtASCII
        '
        Me.txtASCII.Location = New System.Drawing.Point(562, 40)
        Me.txtASCII.Multiline = True
        Me.txtASCII.Name = "txtASCII"
        Me.txtASCII.ReadOnly = True
        Me.txtASCII.Size = New System.Drawing.Size(517, 431)
        Me.txtASCII.TabIndex = 1
        '
        'txtBase64
        '
        Me.txtBase64.Location = New System.Drawing.Point(2, 40)
        Me.txtBase64.Multiline = True
        Me.txtBase64.Name = "txtBase64"
        Me.txtBase64.Size = New System.Drawing.Size(517, 431)
        Me.txtBase64.TabIndex = 0
        '
        'btnDecode
        '
        Me.btnDecode.Location = New System.Drawing.Point(283, 11)
        Me.btnDecode.Name = "btnDecode"
        Me.btnDecode.Size = New System.Drawing.Size(75, 23)
        Me.btnDecode.TabIndex = 2
        Me.btnDecode.Text = "Decode"
        Me.btnDecode.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Paste Text Here:"
        '
        'btnEncode
        '
        Me.btnEncode.Location = New System.Drawing.Point(444, 11)
        Me.btnEncode.Name = "btnEncode"
        Me.btnEncode.Size = New System.Drawing.Size(75, 23)
        Me.btnEncode.TabIndex = 5
        Me.btnEncode.Text = "Encode"
        Me.btnEncode.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 485)
        Me.Controls.Add(Me.btnEncode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDecode)
        Me.Controls.Add(Me.txtBase64)
        Me.Controls.Add(Me.txtASCII)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txtASCII As System.Windows.Forms.TextBox
    Friend WithEvents txtBase64 As System.Windows.Forms.TextBox
    Friend WithEvents btnDecode As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEncode As System.Windows.Forms.Button

End Class
