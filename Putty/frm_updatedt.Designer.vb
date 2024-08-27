<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_updatedt
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
        Me.components = New System.ComponentModel.Container()
        Me.txtempnum = New System.Windows.Forms.TextBox()
        Me.txtrowpointer = New System.Windows.Forms.TextBox()
        Me.lblsection = New System.Windows.Forms.Label()
        Me.cmbcause = New System.Windows.Forms.ComboBox()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.lblrootcause = New System.Windows.Forms.Label()
        Me.txtnotes = New System.Windows.Forms.TextBox()
        Me.lbltotalhrs = New System.Windows.Forms.Label()
        Me.dtpend = New System.Windows.Forms.DateTimePicker()
        Me.dtpstart = New System.Windows.Forms.DateTimePicker()
        Me.lblseq = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblendint = New System.Windows.Forms.Label()
        Me.lblstartint = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtempnum
        '
        Me.txtempnum.Location = New System.Drawing.Point(224, 40)
        Me.txtempnum.Multiline = True
        Me.txtempnum.Name = "txtempnum"
        Me.txtempnum.Size = New System.Drawing.Size(146, 21)
        Me.txtempnum.TabIndex = 190
        Me.txtempnum.Visible = False
        '
        'txtrowpointer
        '
        Me.txtrowpointer.Location = New System.Drawing.Point(30, 483)
        Me.txtrowpointer.Multiline = True
        Me.txtrowpointer.Name = "txtrowpointer"
        Me.txtrowpointer.Size = New System.Drawing.Size(269, 21)
        Me.txtrowpointer.TabIndex = 188
        Me.txtrowpointer.Visible = False
        '
        'lblsection
        '
        Me.lblsection.AutoSize = True
        Me.lblsection.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsection.ForeColor = System.Drawing.Color.White
        Me.lblsection.Location = New System.Drawing.Point(389, 40)
        Me.lblsection.Name = "lblsection"
        Me.lblsection.Size = New System.Drawing.Size(59, 18)
        Me.lblsection.TabIndex = 187
        Me.lblsection.Text = "?section"
        Me.lblsection.Visible = False
        '
        'cmbcause
        '
        Me.cmbcause.FormattingEnabled = True
        Me.cmbcause.Location = New System.Drawing.Point(138, 250)
        Me.cmbcause.Name = "cmbcause"
        Me.cmbcause.Size = New System.Drawing.Size(240, 21)
        Me.cmbcause.TabIndex = 186
        '
        'cmbcategory
        '
        Me.cmbcategory.DropDownWidth = 240
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(138, 212)
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(240, 21)
        Me.cmbcategory.TabIndex = 185
        '
        'lblrootcause
        '
        Me.lblrootcause.AutoSize = True
        Me.lblrootcause.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrootcause.ForeColor = System.Drawing.Color.White
        Me.lblrootcause.Location = New System.Drawing.Point(128, 273)
        Me.lblrootcause.Name = "lblrootcause"
        Me.lblrootcause.Size = New System.Drawing.Size(0, 18)
        Me.lblrootcause.TabIndex = 184
        '
        'txtnotes
        '
        Me.txtnotes.Location = New System.Drawing.Point(131, 301)
        Me.txtnotes.Multiline = True
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.Size = New System.Drawing.Size(269, 57)
        Me.txtnotes.TabIndex = 183
        '
        'lbltotalhrs
        '
        Me.lbltotalhrs.AutoSize = True
        Me.lbltotalhrs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalhrs.ForeColor = System.Drawing.Color.White
        Me.lbltotalhrs.Location = New System.Drawing.Point(131, 172)
        Me.lbltotalhrs.Name = "lbltotalhrs"
        Me.lbltotalhrs.Size = New System.Drawing.Size(0, 18)
        Me.lbltotalhrs.TabIndex = 182
        '
        'dtpend
        '
        Me.dtpend.CustomFormat = "M/dd/yyyy hh:mm tt"
        Me.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpend.Location = New System.Drawing.Point(131, 140)
        Me.dtpend.Name = "dtpend"
        Me.dtpend.Size = New System.Drawing.Size(233, 20)
        Me.dtpend.TabIndex = 181
        '
        'dtpstart
        '
        Me.dtpstart.CustomFormat = "M/dd/yyyy hh:mm tt"
        Me.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpstart.Location = New System.Drawing.Point(131, 104)
        Me.dtpstart.Name = "dtpstart"
        Me.dtpstart.Size = New System.Drawing.Size(233, 20)
        Me.dtpstart.TabIndex = 180
        '
        'lblseq
        '
        Me.lblseq.AutoSize = True
        Me.lblseq.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblseq.ForeColor = System.Drawing.Color.White
        Me.lblseq.Location = New System.Drawing.Point(135, 74)
        Me.lblseq.Name = "lblseq"
        Me.lblseq.Size = New System.Drawing.Size(0, 18)
        Me.lblseq.TabIndex = 179
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(41, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "TOTAL HRS. :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(4, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(283, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SFMS BARCODE - DOWNTIME"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(54, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 18)
        Me.Label12.TabIndex = 177
        Me.Label12.Text = "END TIME:"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(151, 424)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 43)
        Me.Button2.TabIndex = 176
        Me.Button2.Text = "BACK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(151, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 43)
        Me.Button1.TabIndex = 175
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(61, 301)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 18)
        Me.Label10.TabIndex = 174
        Me.Label10.Text = "NOTES :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(32, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 18)
        Me.Label5.TabIndex = 173
        Me.Label5.Text = "ROOT CAUSE :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(33, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 18)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "CAUSE CODE :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(27, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 18)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "DT CATEGORY :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(43, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 18)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = "START TIME:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(90, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 18)
        Me.Label9.TabIndex = 169
        Me.Label9.Text = "SEQ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(18, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 29)
        Me.Label8.TabIndex = 168
        Me.Label8.Text = "DOWNTIME"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 25)
        Me.Panel1.TabIndex = 167
        '
        'lblendint
        '
        Me.lblendint.AutoSize = True
        Me.lblendint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblendint.Location = New System.Drawing.Point(479, 74)
        Me.lblendint.Name = "lblendint"
        Me.lblendint.Size = New System.Drawing.Size(0, 13)
        Me.lblendint.TabIndex = 192
        Me.lblendint.Visible = False
        '
        'lblstartint
        '
        Me.lblstartint.AutoSize = True
        Me.lblstartint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblstartint.Location = New System.Drawing.Point(395, 74)
        Me.lblstartint.Name = "lblstartint"
        Me.lblstartint.Size = New System.Drawing.Size(0, 13)
        Me.lblstartint.TabIndex = 191
        Me.lblstartint.Visible = False
        '
        'frm_updatedt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(409, 473)
        Me.Controls.Add(Me.lblendint)
        Me.Controls.Add(Me.lblstartint)
        Me.Controls.Add(Me.txtempnum)
        Me.Controls.Add(Me.txtrowpointer)
        Me.Controls.Add(Me.lblsection)
        Me.Controls.Add(Me.cmbcause)
        Me.Controls.Add(Me.cmbcategory)
        Me.Controls.Add(Me.lblrootcause)
        Me.Controls.Add(Me.txtnotes)
        Me.Controls.Add(Me.lbltotalhrs)
        Me.Controls.Add(Me.dtpend)
        Me.Controls.Add(Me.dtpstart)
        Me.Controls.Add(Me.lblseq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(1500, 0)
        Me.Name = "frm_updatedt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frm_updatedt"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtempnum As TextBox
    Friend WithEvents txtrowpointer As TextBox
    Friend WithEvents lblsection As Label
    Friend WithEvents cmbcause As ComboBox
    Friend WithEvents cmbcategory As ComboBox
    Friend WithEvents lblrootcause As Label
    Friend WithEvents txtnotes As TextBox
    Friend WithEvents lbltotalhrs As Label
    Friend WithEvents dtpend As DateTimePicker
    Friend WithEvents dtpstart As DateTimePicker
    Friend WithEvents lblseq As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblendint As Label
    Friend WithEvents lblstartint As Label
End Class
