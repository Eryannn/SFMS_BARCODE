<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nooperationsched
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblshift = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblempname = New System.Windows.Forms.Label()
        Me.lblempnum = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_machine = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpend = New System.Windows.Forms.DateTimePicker()
        Me.dtpstart = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_reason = New System.Windows.Forms.ComboBox()
        Me.lbl_reason_desc = New System.Windows.Forms.Label()
        Me.txtnotes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.lbl_seq = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.lbl_startint = New System.Windows.Forms.Label()
        Me.lbl_endint = New System.Windows.Forms.Label()
        Me.lbl_totalhrs = New System.Windows.Forms.Label()
        Me.lbl_site = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_section = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(14, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(277, 29)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "NO OPERATION SCHEDULE"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 25)
        Me.Panel1.TabIndex = 91
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(4, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(430, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SFMS BARCODE - NO OPERATION SCHEDULE"
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(109, 111)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(42, 18)
        Me.lblshift.TabIndex = 119
        Me.lblshift.Text = "?shift"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(57, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "SHIFT :"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(225, 81)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(96, 23)
        Me.lblempname.TabIndex = 117
        Me.lblempname.Text = "?empname"
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(109, 81)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(88, 23)
        Me.lblempnum.TabIndex = 116
        Me.lblempnum.Text = "?empnum"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 23)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "EMPLOYEE :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "MACHINE :"
        '
        'cmb_machine
        '
        Me.cmb_machine.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_machine.FormattingEnabled = True
        Me.cmb_machine.Location = New System.Drawing.Point(112, 195)
        Me.cmb_machine.Name = "cmb_machine"
        Me.cmb_machine.Size = New System.Drawing.Size(303, 33)
        Me.cmb_machine.TabIndex = 121
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(64, 238)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 18)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "SEQ : "
        '
        'dtpend
        '
        Me.dtpend.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpend.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpend.Location = New System.Drawing.Point(112, 318)
        Me.dtpend.Name = "dtpend"
        Me.dtpend.ShowUpDown = True
        Me.dtpend.Size = New System.Drawing.Size(303, 35)
        Me.dtpend.TabIndex = 131
        '
        'dtpstart
        '
        Me.dtpstart.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpstart.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpstart.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpstart.Location = New System.Drawing.Point(112, 272)
        Me.dtpstart.Name = "dtpstart"
        Me.dtpstart.ShowUpDown = True
        Me.dtpstart.Size = New System.Drawing.Size(303, 35)
        Me.dtpstart.TabIndex = 130
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(32, 326)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 18)
        Me.Label16.TabIndex = 129
        Me.Label16.Text = "END TIME :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(21, 281)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 18)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "START TIME :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(40, 413)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 18)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "REASON : "
        '
        'cmb_reason
        '
        Me.cmb_reason.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_reason.FormattingEnabled = True
        Me.cmb_reason.Location = New System.Drawing.Point(112, 413)
        Me.cmb_reason.Name = "cmb_reason"
        Me.cmb_reason.Size = New System.Drawing.Size(303, 32)
        Me.cmb_reason.TabIndex = 133
        '
        'lbl_reason_desc
        '
        Me.lbl_reason_desc.AutoSize = True
        Me.lbl_reason_desc.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_reason_desc.ForeColor = System.Drawing.Color.White
        Me.lbl_reason_desc.Location = New System.Drawing.Point(108, 452)
        Me.lbl_reason_desc.Name = "lbl_reason_desc"
        Me.lbl_reason_desc.Size = New System.Drawing.Size(0, 23)
        Me.lbl_reason_desc.TabIndex = 134
        '
        'txtnotes
        '
        Me.txtnotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnotes.Location = New System.Drawing.Point(112, 482)
        Me.txtnotes.Multiline = True
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.Size = New System.Drawing.Size(303, 85)
        Me.txtnotes.TabIndex = 185
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(50, 482)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 18)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "NOTES :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(22, 379)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 18)
        Me.Label6.TabIndex = 186
        Me.Label6.Text = "TOTAL HRS. : "
        '
        'btn_back
        '
        Me.btn_back.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_back.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_back.Location = New System.Drawing.Point(257, 594)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(124, 50)
        Me.btn_back.TabIndex = 187
        Me.btn_back.Text = "BACK"
        Me.btn_back.UseVisualStyleBackColor = False
        '
        'lbl_seq
        '
        Me.lbl_seq.AutoSize = True
        Me.lbl_seq.Font = New System.Drawing.Font("Calibri", 15.75!)
        Me.lbl_seq.ForeColor = System.Drawing.Color.White
        Me.lbl_seq.Location = New System.Drawing.Point(109, 235)
        Me.lbl_seq.Name = "lbl_seq"
        Me.lbl_seq.Size = New System.Drawing.Size(23, 26)
        Me.lbl_seq.TabIndex = 189
        Me.lbl_seq.Text = "0"
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.Lime
        Me.btn_save.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(127, 593)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(124, 51)
        Me.btn_save.TabIndex = 190
        Me.btn_save.Text = "SAVE"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'lbl_startint
        '
        Me.lbl_startint.AutoSize = True
        Me.lbl_startint.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_startint.ForeColor = System.Drawing.Color.White
        Me.lbl_startint.Location = New System.Drawing.Point(498, 99)
        Me.lbl_startint.Name = "lbl_startint"
        Me.lbl_startint.Size = New System.Drawing.Size(15, 18)
        Me.lbl_startint.TabIndex = 191
        Me.lbl_startint.Text = "0"
        Me.lbl_startint.Visible = False
        '
        'lbl_endint
        '
        Me.lbl_endint.AutoSize = True
        Me.lbl_endint.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_endint.ForeColor = System.Drawing.Color.White
        Me.lbl_endint.Location = New System.Drawing.Point(498, 134)
        Me.lbl_endint.Name = "lbl_endint"
        Me.lbl_endint.Size = New System.Drawing.Size(15, 18)
        Me.lbl_endint.TabIndex = 192
        Me.lbl_endint.Text = "0"
        Me.lbl_endint.Visible = False
        '
        'lbl_totalhrs
        '
        Me.lbl_totalhrs.AutoSize = True
        Me.lbl_totalhrs.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totalhrs.ForeColor = System.Drawing.Color.White
        Me.lbl_totalhrs.Location = New System.Drawing.Point(108, 373)
        Me.lbl_totalhrs.Name = "lbl_totalhrs"
        Me.lbl_totalhrs.Size = New System.Drawing.Size(23, 26)
        Me.lbl_totalhrs.TabIndex = 193
        Me.lbl_totalhrs.Text = "0"
        '
        'lbl_site
        '
        Me.lbl_site.AutoSize = True
        Me.lbl_site.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_site.ForeColor = System.Drawing.Color.White
        Me.lbl_site.Location = New System.Drawing.Point(337, 36)
        Me.lbl_site.Name = "lbl_site"
        Me.lbl_site.Size = New System.Drawing.Size(96, 23)
        Me.lbl_site.TabIndex = 194
        Me.lbl_site.Text = "?empname"
        Me.lbl_site.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(32, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 18)
        Me.Label5.TabIndex = 195
        Me.Label5.Text = "SECTION :"
        '
        'cmb_section
        '
        Me.cmb_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_section.FormattingEnabled = True
        Me.cmb_section.Items.AddRange(New Object() {"OFFSET", "WEB", "DIGITAL PRESS", "DIE CUTTING", "LAMINATION", "GLUING", "FOLDING", "STITCHING", "PERFECT BINDING", "ERECTING", "MANUAL FINISHING", "BINDERY FINISHING", "STRIPPING", "MANUAL STRIPPING", "MACHINE STRIPPING", "SHEETING/SLITTING", "CUTTING", "3 KNIVES", "INSPECTION MACHINE", "QA"})
        Me.cmb_section.Location = New System.Drawing.Point(113, 145)
        Me.cmb_section.Name = "cmb_section"
        Me.cmb_section.Size = New System.Drawing.Size(303, 33)
        Me.cmb_section.TabIndex = 196
        '
        'frm_nooperationsched
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(454, 726)
        Me.Controls.Add(Me.cmb_section)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_site)
        Me.Controls.Add(Me.lbl_totalhrs)
        Me.Controls.Add(Me.lbl_endint)
        Me.Controls.Add(Me.lbl_startint)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.lbl_seq)
        Me.Controls.Add(Me.btn_back)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtnotes)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbl_reason_desc)
        Me.Controls.Add(Me.cmb_reason)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpend)
        Me.Controls.Add(Me.dtpstart)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_machine)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblshift)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblempname)
        Me.Controls.Add(Me.lblempnum)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_nooperationsched"
        Me.Text = "frm_nooperationsched"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents lblshift As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblempname As Label
    Friend WithEvents lblempnum As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_machine As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpend As DateTimePicker
    Friend WithEvents dtpstart As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmb_reason As ComboBox
    Friend WithEvents lbl_reason_desc As Label
    Friend WithEvents txtnotes As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btn_back As Button
    Friend WithEvents lbl_seq As Label
    Friend WithEvents btn_save As Button
    Friend WithEvents lbl_startint As Label
    Friend WithEvents lbl_endint As Label
    Friend WithEvents lbl_totalhrs As Label
    Friend WithEvents lbl_site As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmb_section As ComboBox
End Class
