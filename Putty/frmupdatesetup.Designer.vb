<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmupdatesetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmupdatesetup))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtwcdesc = New System.Windows.Forms.TextBox()
        Me.txtwc = New System.Windows.Forms.TextBox()
        Me.rtbmach = New System.Windows.Forms.RichTextBox()
        Me.lbltransdate = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblsetupdesc = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblshift = New System.Windows.Forms.Label()
        Me.lblempname = New System.Windows.Forms.Label()
        Me.lblempnum = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtopernum = New System.Windows.Forms.TextBox()
        Me.txtsuffix = New System.Windows.Forms.TextBox()
        Me.txtjob = New System.Windows.Forms.TextBox()
        Me.lblintend = New System.Windows.Forms.Label()
        Me.lblintstart = New System.Windows.Forms.Label()
        Me.lblwhse = New System.Windows.Forms.Label()
        Me.dtptransdate = New System.Windows.Forms.DateTimePicker()
        Me.btnpost = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.dtpstart = New System.Windows.Forms.DateTimePicker()
        Me.dtpend = New System.Windows.Forms.DateTimePicker()
        Me.txttotalhrs = New System.Windows.Forms.TextBox()
        Me.cmbsetuptype = New System.Windows.Forms.ComboBox()
        Me.txttranstype = New System.Windows.Forms.TextBox()
        Me.lbl_updatedby = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(2, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 29)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "UPDATE SETUP"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 20)
        Me.Panel1.TabIndex = 61
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SFMS BARCODE"
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(242, 281)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 117
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(176, 281)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 116
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(176, 316)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 114
        Me.rtbmach.Text = ""
        '
        'lbltransdate
        '
        Me.lbltransdate.AutoSize = True
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.White
        Me.lbltransdate.Location = New System.Drawing.Point(176, 353)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(74, 18)
        Me.lbltransdate.TabIndex = 113
        Me.lbltransdate.Text = "?transdate"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(90, 449)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 18)
        Me.Label17.TabIndex = 109
        Me.Label17.Text = "TOTAL HRS :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(96, 417)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 18)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "END TIME :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(85, 385)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 18)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "START TIME :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(32, 353)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(138, 18)
        Me.Label14.TabIndex = 106
        Me.Label14.Text = "TRANSACTION DATE :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(121, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 18)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "SHIFT :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(96, 321)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "MACHINE :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(134, 286)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 18)
        Me.Label12.TabIndex = 103
        Me.Label12.Text = "WC :"
        '
        'lblsetupdesc
        '
        Me.lblsetupdesc.AutoSize = True
        Me.lblsetupdesc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsetupdesc.ForeColor = System.Drawing.Color.White
        Me.lblsetupdesc.Location = New System.Drawing.Point(177, 257)
        Me.lblsetupdesc.Name = "lblsetupdesc"
        Me.lblsetupdesc.Size = New System.Drawing.Size(0, 18)
        Me.lblsetupdesc.TabIndex = 102
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(85, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 18)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "SETUP TYPE :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(91, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "OPER. NO. :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(113, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "SUFFIX :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(132, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 18)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "JOB :"
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(176, 121)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(42, 18)
        Me.lblshift.TabIndex = 97
        Me.lblshift.Text = "?shift"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(176, 98)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(78, 18)
        Me.lblempname.TabIndex = 96
        Me.lblempname.Text = "?empname"
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(176, 75)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(71, 18)
        Me.lblempnum.TabIndex = 95
        Me.lblempnum.Text = "?empnum"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(91, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "EMPLOYEE :"
        '
        'txtopernum
        '
        Me.txtopernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopernum.Location = New System.Drawing.Point(176, 202)
        Me.txtopernum.Name = "txtopernum"
        Me.txtopernum.ReadOnly = True
        Me.txtopernum.Size = New System.Drawing.Size(193, 22)
        Me.txtopernum.TabIndex = 89
        '
        'txtsuffix
        '
        Me.txtsuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuffix.Location = New System.Drawing.Point(176, 174)
        Me.txtsuffix.Name = "txtsuffix"
        Me.txtsuffix.ReadOnly = True
        Me.txtsuffix.Size = New System.Drawing.Size(193, 22)
        Me.txtsuffix.TabIndex = 88
        '
        'txtjob
        '
        Me.txtjob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjob.Location = New System.Drawing.Point(176, 146)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.ReadOnly = True
        Me.txtjob.Size = New System.Drawing.Size(193, 22)
        Me.txtjob.TabIndex = 87
        '
        'lblintend
        '
        Me.lblintend.AutoSize = True
        Me.lblintend.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblintend.ForeColor = System.Drawing.Color.White
        Me.lblintend.Location = New System.Drawing.Point(505, 63)
        Me.lblintend.Name = "lblintend"
        Me.lblintend.Size = New System.Drawing.Size(0, 18)
        Me.lblintend.TabIndex = 120
        Me.lblintend.Visible = False
        '
        'lblintstart
        '
        Me.lblintstart.AutoSize = True
        Me.lblintstart.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblintstart.ForeColor = System.Drawing.Color.White
        Me.lblintstart.Location = New System.Drawing.Point(505, 45)
        Me.lblintstart.Name = "lblintstart"
        Me.lblintstart.Size = New System.Drawing.Size(0, 18)
        Me.lblintstart.TabIndex = 119
        Me.lblintstart.Visible = False
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(505, 32)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(38, 13)
        Me.lblwhse.TabIndex = 118
        Me.lblwhse.Text = "?whse"
        Me.lblwhse.Visible = False
        '
        'dtptransdate
        '
        Me.dtptransdate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtptransdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptransdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptransdate.Location = New System.Drawing.Point(299, 25)
        Me.dtptransdate.Name = "dtptransdate"
        Me.dtptransdate.Size = New System.Drawing.Size(200, 26)
        Me.dtptransdate.TabIndex = 125
        Me.dtptransdate.Visible = False
        '
        'btnpost
        '
        Me.btnpost.BackColor = System.Drawing.Color.LimeGreen
        Me.btnpost.Enabled = False
        Me.btnpost.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnpost.FlatAppearance.BorderSize = 2
        Me.btnpost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpost.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnpost.Location = New System.Drawing.Point(156, 591)
        Me.btnpost.Name = "btnpost"
        Me.btnpost.Size = New System.Drawing.Size(254, 37)
        Me.btnpost.TabIndex = 124
        Me.btnpost.Text = "POST"
        Me.btnpost.UseVisualStyleBackColor = False
        Me.btnpost.Visible = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.LimeGreen
        Me.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnupdate.FlatAppearance.BorderSize = 2
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnupdate.Location = New System.Drawing.Point(156, 484)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(254, 37)
        Me.btnupdate.TabIndex = 122
        Me.btnupdate.Text = "UPDATE"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'btnexit
        '
        Me.btnexit.BackColor = System.Drawing.Color.Red
        Me.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnexit.FlatAppearance.BorderSize = 2
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnexit.Location = New System.Drawing.Point(156, 527)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(254, 37)
        Me.btnexit.TabIndex = 121
        Me.btnexit.Text = "EXIT"
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'dtpstart
        '
        Me.dtpstart.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpstart.Location = New System.Drawing.Point(176, 383)
        Me.dtpstart.Name = "dtpstart"
        Me.dtpstart.ShowUpDown = True
        Me.dtpstart.Size = New System.Drawing.Size(162, 20)
        Me.dtpstart.TabIndex = 126
        '
        'dtpend
        '
        Me.dtpend.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpend.Location = New System.Drawing.Point(176, 415)
        Me.dtpend.Name = "dtpend"
        Me.dtpend.ShowUpDown = True
        Me.dtpend.Size = New System.Drawing.Size(162, 20)
        Me.dtpend.TabIndex = 127
        '
        'txttotalhrs
        '
        Me.txttotalhrs.Location = New System.Drawing.Point(176, 447)
        Me.txttotalhrs.Name = "txttotalhrs"
        Me.txttotalhrs.ReadOnly = True
        Me.txttotalhrs.Size = New System.Drawing.Size(162, 20)
        Me.txttotalhrs.TabIndex = 128
        '
        'cmbsetuptype
        '
        Me.cmbsetuptype.BackColor = System.Drawing.SystemColors.Info
        Me.cmbsetuptype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbsetuptype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsetuptype.FormattingEnabled = True
        Me.cmbsetuptype.Location = New System.Drawing.Point(176, 230)
        Me.cmbsetuptype.Name = "cmbsetuptype"
        Me.cmbsetuptype.Size = New System.Drawing.Size(291, 23)
        Me.cmbsetuptype.TabIndex = 129
        '
        'txttranstype
        '
        Me.txttranstype.Location = New System.Drawing.Point(404, 57)
        Me.txttranstype.Name = "txttranstype"
        Me.txttranstype.Size = New System.Drawing.Size(95, 20)
        Me.txttranstype.TabIndex = 130
        Me.txttranstype.Visible = False
        '
        'lbl_updatedby
        '
        Me.lbl_updatedby.AutoSize = True
        Me.lbl_updatedby.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_updatedby.ForeColor = System.Drawing.Color.White
        Me.lbl_updatedby.Location = New System.Drawing.Point(401, 98)
        Me.lbl_updatedby.Name = "lbl_updatedby"
        Me.lbl_updatedby.Size = New System.Drawing.Size(0, 18)
        Me.lbl_updatedby.TabIndex = 131
        Me.lbl_updatedby.Visible = False
        '
        'frmupdatesetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(682, 572)
        Me.Controls.Add(Me.lbl_updatedby)
        Me.Controls.Add(Me.txttranstype)
        Me.Controls.Add(Me.cmbsetuptype)
        Me.Controls.Add(Me.txttotalhrs)
        Me.Controls.Add(Me.dtpend)
        Me.Controls.Add(Me.dtpstart)
        Me.Controls.Add(Me.dtptransdate)
        Me.Controls.Add(Me.btnpost)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.lblintend)
        Me.Controls.Add(Me.lblintstart)
        Me.Controls.Add(Me.lblwhse)
        Me.Controls.Add(Me.txtwcdesc)
        Me.Controls.Add(Me.txtwc)
        Me.Controls.Add(Me.rtbmach)
        Me.Controls.Add(Me.lbltransdate)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblsetupdesc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblshift)
        Me.Controls.Add(Me.lblempname)
        Me.Controls.Add(Me.lblempnum)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtopernum)
        Me.Controls.Add(Me.txtsuffix)
        Me.Controls.Add(Me.txtjob)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1360, 0)
        Me.Name = "frmupdatesetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmupdatesetup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtwcdesc As TextBox
    Friend WithEvents txtwc As TextBox
    Friend WithEvents rtbmach As RichTextBox
    Friend WithEvents lbltransdate As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblsetupdesc As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblshift As Label
    Friend WithEvents lblempname As Label
    Friend WithEvents lblempnum As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtopernum As TextBox
    Friend WithEvents txtsuffix As TextBox
    Friend WithEvents txtjob As TextBox
    Friend WithEvents lblintend As Label
    Friend WithEvents lblintstart As Label
    Friend WithEvents lblwhse As Label
    Friend WithEvents dtptransdate As DateTimePicker
    Friend WithEvents btnpost As Button
    Friend WithEvents btnupdate As Button
    Friend WithEvents btnexit As Button
    Friend WithEvents dtpstart As DateTimePicker
    Friend WithEvents dtpend As DateTimePicker
    Friend WithEvents txttotalhrs As TextBox
    Friend WithEvents cmbsetuptype As ComboBox
    Friend WithEvents txttranstype As TextBox
    Friend WithEvents lbl_updatedby As Label
End Class
