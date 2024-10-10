<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_move_wmcnum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_move_wmcnum))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblwhse = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_empnum = New System.Windows.Forms.Label()
        Me.lbl_empname = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl_shift = New System.Windows.Forms.Label()
        Me.txt_job = New System.Windows.Forms.TextBox()
        Me.txt_suffix = New System.Windows.Forms.TextBox()
        Me.txt_opernum = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtwc = New System.Windows.Forms.TextBox()
        Me.rtbmach = New System.Windows.Forms.RichTextBox()
        Me.txtwcdesc = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_nextop = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_qtygood = New System.Windows.Forms.TextBox()
        Me.txt_qtyscrap = New System.Windows.Forms.TextBox()
        Me.cmb_reasoncode = New System.Windows.Forms.ComboBox()
        Me.lbl_reason_desc = New System.Windows.Forms.Label()
        Me.txt_lot = New System.Windows.Forms.TextBox()
        Me.txt_qtymove = New System.Windows.Forms.TextBox()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txt_qtyrework = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lbl_um_qtygood = New System.Windows.Forms.Label()
        Me.lbl_um_qtyrework = New System.Windows.Forms.Label()
        Me.lbl_um_qtycomplete = New System.Windows.Forms.Label()
        Me.lbl_um_qtyscrap = New System.Windows.Forms.Label()
        Me.lbl_um_qtymove = New System.Windows.Forms.Label()
        Me.txt_qtycomplete = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txt_mcnum = New System.Windows.Forms.TextBox()
        Me.txt_cntrl_pt = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txt_qtyredtags = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lbl_um_qtyredtags = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SFMS BARCODE"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(581, 19)
        Me.Panel1.TabIndex = 139
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(288, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 229
        Me.DateTimePicker1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(16, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 29)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "MOVE"
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(273, 56)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(32, 13)
        Me.lblwhse.TabIndex = 180
        Me.lblwhse.Text = "whse"
        Me.lblwhse.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label4.Location = New System.Drawing.Point(57, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 23)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "CURRENT DATE :"
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_date.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbl_date.Location = New System.Drawing.Point(198, 83)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(139, 23)
        Me.lbl_date.TabIndex = 183
        Me.lbl_date.Text = "CURRENT DATE :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(112, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 18)
        Me.Label8.TabIndex = 185
        Me.Label8.Text = "EMPLOYEE :"
        '
        'lbl_empnum
        '
        Me.lbl_empnum.AutoSize = True
        Me.lbl_empnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_empnum.ForeColor = System.Drawing.Color.White
        Me.lbl_empnum.Location = New System.Drawing.Point(194, 137)
        Me.lbl_empnum.Name = "lbl_empnum"
        Me.lbl_empnum.Size = New System.Drawing.Size(71, 18)
        Me.lbl_empnum.TabIndex = 186
        Me.lbl_empnum.Text = "?empnum"
        '
        'lbl_empname
        '
        Me.lbl_empname.AutoSize = True
        Me.lbl_empname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_empname.ForeColor = System.Drawing.Color.White
        Me.lbl_empname.Location = New System.Drawing.Point(194, 160)
        Me.lbl_empname.Name = "lbl_empname"
        Me.lbl_empname.Size = New System.Drawing.Size(78, 18)
        Me.lbl_empname.TabIndex = 187
        Me.lbl_empname.Text = "?empname"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(142, 180)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 18)
        Me.Label11.TabIndex = 188
        Me.Label11.Text = "SHIFT :"
        '
        'lbl_shift
        '
        Me.lbl_shift.AutoSize = True
        Me.lbl_shift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift.ForeColor = System.Drawing.Color.White
        Me.lbl_shift.Location = New System.Drawing.Point(194, 180)
        Me.lbl_shift.Name = "lbl_shift"
        Me.lbl_shift.Size = New System.Drawing.Size(42, 18)
        Me.lbl_shift.TabIndex = 189
        Me.lbl_shift.Text = "?shift"
        '
        'txt_job
        '
        Me.txt_job.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_job.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_job.Location = New System.Drawing.Point(197, 204)
        Me.txt_job.MaxLength = 10
        Me.txt_job.Name = "txt_job"
        Me.txt_job.Size = New System.Drawing.Size(193, 22)
        Me.txt_job.TabIndex = 1
        '
        'txt_suffix
        '
        Me.txt_suffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_suffix.Location = New System.Drawing.Point(197, 232)
        Me.txt_suffix.Name = "txt_suffix"
        Me.txt_suffix.Size = New System.Drawing.Size(193, 22)
        Me.txt_suffix.TabIndex = 2
        '
        'txt_opernum
        '
        Me.txt_opernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_opernum.Location = New System.Drawing.Point(197, 260)
        Me.txt_opernum.Name = "txt_opernum"
        Me.txt_opernum.Size = New System.Drawing.Size(193, 22)
        Me.txt_opernum.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(153, 206)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 18)
        Me.Label13.TabIndex = 193
        Me.Label13.Text = "JOB :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(134, 234)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 18)
        Me.Label14.TabIndex = 194
        Me.Label14.Text = "SUFFIX :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(112, 262)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 18)
        Me.Label15.TabIndex = 195
        Me.Label15.Text = "OPER. NO. :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(155, 294)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 18)
        Me.Label16.TabIndex = 196
        Me.Label16.Text = "WC :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(112, 329)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 18)
        Me.Label17.TabIndex = 197
        Me.Label17.Text = "RESOURCE :"
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(197, 289)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 198
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(197, 324)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 199
        Me.rtbmach.Text = ""
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(263, 289)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 200
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(108, 363)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 18)
        Me.Label18.TabIndex = 201
        Me.Label18.Text = "NEXT OPER :"
        '
        'lbl_nextop
        '
        Me.lbl_nextop.AutoSize = True
        Me.lbl_nextop.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nextop.ForeColor = System.Drawing.Color.White
        Me.lbl_nextop.Location = New System.Drawing.Point(194, 363)
        Me.lbl_nextop.Name = "lbl_nextop"
        Me.lbl_nextop.Size = New System.Drawing.Size(0, 18)
        Me.lbl_nextop.TabIndex = 202
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(24, 395)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(167, 18)
        Me.Label20.TabIndex = 205
        Me.Label20.Text = "QTY COMPLETED (GOOD) :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(85, 509)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 18)
        Me.Label21.TabIndex = 206
        Me.Label21.Text = "QTY SCRAPPED :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(82, 537)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 18)
        Me.Label22.TabIndex = 207
        Me.Label22.Text = "SCRAP REASON :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(102, 589)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(89, 18)
        Me.Label23.TabIndex = 208
        Me.Label23.Text = "QTY MOVED :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(153, 616)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 18)
        Me.Label24.TabIndex = 209
        Me.Label24.Text = "LOT :"
        '
        'txt_qtygood
        '
        Me.txt_qtygood.BackColor = System.Drawing.SystemColors.Info
        Me.txt_qtygood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtygood.Location = New System.Drawing.Point(197, 393)
        Me.txt_qtygood.Name = "txt_qtygood"
        Me.txt_qtygood.Size = New System.Drawing.Size(193, 22)
        Me.txt_qtygood.TabIndex = 4
        Me.txt_qtygood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_qtyscrap
        '
        Me.txt_qtyscrap.BackColor = System.Drawing.SystemColors.Info
        Me.txt_qtyscrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtyscrap.Location = New System.Drawing.Point(197, 507)
        Me.txt_qtyscrap.Name = "txt_qtyscrap"
        Me.txt_qtyscrap.Size = New System.Drawing.Size(193, 22)
        Me.txt_qtyscrap.TabIndex = 211
        Me.txt_qtyscrap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmb_reasoncode
        '
        Me.cmb_reasoncode.BackColor = System.Drawing.Color.Yellow
        Me.cmb_reasoncode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_reasoncode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_reasoncode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmb_reasoncode.FormattingEnabled = True
        Me.cmb_reasoncode.Location = New System.Drawing.Point(197, 537)
        Me.cmb_reasoncode.Name = "cmb_reasoncode"
        Me.cmb_reasoncode.Size = New System.Drawing.Size(193, 21)
        Me.cmb_reasoncode.TabIndex = 212
        '
        'lbl_reason_desc
        '
        Me.lbl_reason_desc.AutoSize = True
        Me.lbl_reason_desc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_reason_desc.ForeColor = System.Drawing.Color.White
        Me.lbl_reason_desc.Location = New System.Drawing.Point(194, 564)
        Me.lbl_reason_desc.Name = "lbl_reason_desc"
        Me.lbl_reason_desc.Size = New System.Drawing.Size(0, 18)
        Me.lbl_reason_desc.TabIndex = 213
        '
        'txt_lot
        '
        Me.txt_lot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_lot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lot.Location = New System.Drawing.Point(197, 614)
        Me.txt_lot.Name = "txt_lot"
        Me.txt_lot.ReadOnly = True
        Me.txt_lot.Size = New System.Drawing.Size(193, 22)
        Me.txt_lot.TabIndex = 214
        Me.txt_lot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_qtymove
        '
        Me.txt_qtymove.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_qtymove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtymove.Location = New System.Drawing.Point(197, 587)
        Me.txt_qtymove.Name = "txt_qtymove"
        Me.txt_qtymove.ReadOnly = True
        Me.txt_qtymove.Size = New System.Drawing.Size(193, 22)
        Me.txt_qtymove.TabIndex = 215
        Me.txt_qtymove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Red
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderSize = 2
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(156, 707)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(254, 24)
        Me.btn_exit.TabIndex = 216
        Me.btn_exit.Text = "EXIT"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btn_save.FlatAppearance.BorderSize = 2
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_save.Location = New System.Drawing.Point(156, 677)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(254, 24)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "SAVE"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LimeGreen
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(158, 739)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(254, 24)
        Me.Button3.TabIndex = 218
        Me.Button3.Text = "POST"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(9, 423)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(183, 18)
        Me.Label26.TabIndex = 219
        Me.Label26.Text = "QTY COMPLETED (REWORK) :"
        '
        'txt_qtyrework
        '
        Me.txt_qtyrework.BackColor = System.Drawing.SystemColors.Info
        Me.txt_qtyrework.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtyrework.Location = New System.Drawing.Point(197, 421)
        Me.txt_qtyrework.Name = "txt_qtyrework"
        Me.txt_qtyrework.Size = New System.Drawing.Size(193, 22)
        Me.txt_qtyrework.TabIndex = 220
        Me.txt_qtyrework.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(76, 451)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(116, 18)
        Me.Label27.TabIndex = 221
        Me.Label27.Text = "QTY COMPLETED :"
        '
        'lbl_um_qtygood
        '
        Me.lbl_um_qtygood.AutoSize = True
        Me.lbl_um_qtygood.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_um_qtygood.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_um_qtygood.Location = New System.Drawing.Point(396, 395)
        Me.lbl_um_qtygood.Name = "lbl_um_qtygood"
        Me.lbl_um_qtygood.Size = New System.Drawing.Size(0, 18)
        Me.lbl_um_qtygood.TabIndex = 223
        '
        'lbl_um_qtyrework
        '
        Me.lbl_um_qtyrework.AutoSize = True
        Me.lbl_um_qtyrework.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_um_qtyrework.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_um_qtyrework.Location = New System.Drawing.Point(396, 423)
        Me.lbl_um_qtyrework.Name = "lbl_um_qtyrework"
        Me.lbl_um_qtyrework.Size = New System.Drawing.Size(0, 18)
        Me.lbl_um_qtyrework.TabIndex = 224
        '
        'lbl_um_qtycomplete
        '
        Me.lbl_um_qtycomplete.AutoSize = True
        Me.lbl_um_qtycomplete.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_um_qtycomplete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_um_qtycomplete.Location = New System.Drawing.Point(396, 451)
        Me.lbl_um_qtycomplete.Name = "lbl_um_qtycomplete"
        Me.lbl_um_qtycomplete.Size = New System.Drawing.Size(0, 18)
        Me.lbl_um_qtycomplete.TabIndex = 225
        '
        'lbl_um_qtyscrap
        '
        Me.lbl_um_qtyscrap.AutoSize = True
        Me.lbl_um_qtyscrap.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_um_qtyscrap.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_um_qtyscrap.Location = New System.Drawing.Point(396, 509)
        Me.lbl_um_qtyscrap.Name = "lbl_um_qtyscrap"
        Me.lbl_um_qtyscrap.Size = New System.Drawing.Size(0, 18)
        Me.lbl_um_qtyscrap.TabIndex = 226
        '
        'lbl_um_qtymove
        '
        Me.lbl_um_qtymove.AutoSize = True
        Me.lbl_um_qtymove.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_um_qtymove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_um_qtymove.Location = New System.Drawing.Point(396, 589)
        Me.lbl_um_qtymove.Name = "lbl_um_qtymove"
        Me.lbl_um_qtymove.Size = New System.Drawing.Size(0, 18)
        Me.lbl_um_qtymove.TabIndex = 227
        '
        'txt_qtycomplete
        '
        Me.txt_qtycomplete.BackColor = System.Drawing.SystemColors.Info
        Me.txt_qtycomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtycomplete.Location = New System.Drawing.Point(197, 449)
        Me.txt_qtycomplete.Name = "txt_qtycomplete"
        Me.txt_qtycomplete.ReadOnly = True
        Me.txt_qtycomplete.Size = New System.Drawing.Size(193, 22)
        Me.txt_qtycomplete.TabIndex = 228
        Me.txt_qtycomplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(146, 644)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 18)
        Me.Label33.TabIndex = 230
        Me.Label33.Text = "MC # :"
        '
        'txt_mcnum
        '
        Me.txt_mcnum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_mcnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mcnum.Location = New System.Drawing.Point(197, 642)
        Me.txt_mcnum.Name = "txt_mcnum"
        Me.txt_mcnum.Size = New System.Drawing.Size(193, 22)
        Me.txt_mcnum.TabIndex = 5
        Me.txt_mcnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cntrl_pt
        '
        Me.txt_cntrl_pt.Location = New System.Drawing.Point(361, 363)
        Me.txt_cntrl_pt.Name = "txt_cntrl_pt"
        Me.txt_cntrl_pt.Size = New System.Drawing.Size(51, 20)
        Me.txt_cntrl_pt.TabIndex = 232
        '
        'txt_qtyredtags
        '
        Me.txt_qtyredtags.BackColor = System.Drawing.SystemColors.Info
        Me.txt_qtyredtags.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtyredtags.Location = New System.Drawing.Point(197, 479)
        Me.txt_qtyredtags.Name = "txt_qtyredtags"
        Me.txt_qtyredtags.Size = New System.Drawing.Size(193, 22)
        Me.txt_qtyredtags.TabIndex = 234
        Me.txt_qtyredtags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(91, 481)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 18)
        Me.Label34.TabIndex = 233
        Me.Label34.Text = "RED TAGS QTY :"
        '
        'lbl_um_qtyredtags
        '
        Me.lbl_um_qtyredtags.AutoSize = True
        Me.lbl_um_qtyredtags.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_um_qtyredtags.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_um_qtyredtags.Location = New System.Drawing.Point(396, 481)
        Me.lbl_um_qtyredtags.Name = "lbl_um_qtyredtags"
        Me.lbl_um_qtyredtags.Size = New System.Drawing.Size(0, 18)
        Me.lbl_um_qtyredtags.TabIndex = 235
        '
        'frm_move_wmcnum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(579, 845)
        Me.Controls.Add(Me.lbl_um_qtyredtags)
        Me.Controls.Add(Me.txt_qtyredtags)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txt_cntrl_pt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_mcnum)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblwhse)
        Me.Controls.Add(Me.txt_qtycomplete)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_um_qtymove)
        Me.Controls.Add(Me.lbl_um_qtyscrap)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.lbl_um_qtycomplete)
        Me.Controls.Add(Me.lbl_um_qtyrework)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbl_um_qtygood)
        Me.Controls.Add(Me.lbl_empnum)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lbl_empname)
        Me.Controls.Add(Me.txt_qtyrework)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lbl_shift)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txt_job)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.txt_suffix)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.txt_opernum)
        Me.Controls.Add(Me.txt_qtymove)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_lot)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lbl_reason_desc)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmb_reasoncode)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_qtyscrap)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txt_qtygood)
        Me.Controls.Add(Me.txtwc)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.rtbmach)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtwcdesc)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lbl_nextop)
        Me.Controls.Add(Me.Label20)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_move_wmcnum"
        Me.Text = "frm_move_wmcnum"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents lblwhse As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_date As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbl_empnum As Label
    Friend WithEvents lbl_empname As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbl_shift As Label
    Friend WithEvents txt_job As TextBox
    Friend WithEvents txt_suffix As TextBox
    Friend WithEvents txt_opernum As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtwc As TextBox
    Friend WithEvents rtbmach As RichTextBox
    Friend WithEvents txtwcdesc As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents lbl_nextop As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txt_qtygood As TextBox
    Friend WithEvents txt_qtyscrap As TextBox
    Friend WithEvents cmb_reasoncode As ComboBox
    Friend WithEvents lbl_reason_desc As Label
    Friend WithEvents txt_lot As TextBox
    Friend WithEvents txt_qtymove As TextBox
    Friend WithEvents btn_exit As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents txt_qtyrework As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents lbl_um_qtygood As Label
    Friend WithEvents lbl_um_qtyrework As Label
    Friend WithEvents lbl_um_qtycomplete As Label
    Friend WithEvents lbl_um_qtyscrap As Label
    Friend WithEvents lbl_um_qtymove As Label
    Friend WithEvents txt_qtycomplete As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txt_mcnum As TextBox
    Friend WithEvents txt_cntrl_pt As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txt_qtyredtags As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents lbl_um_qtyredtags As Label
End Class
