<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmupdatemachine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmupdatemachine))
        Me.dtptransdate = New System.Windows.Forms.DateTimePicker()
        Me.txtlot = New System.Windows.Forms.TextBox()
        Me.lblendint = New System.Windows.Forms.Label()
        Me.lblqtymoved = New System.Windows.Forms.Label()
        Me.lblreasondesc = New System.Windows.Forms.Label()
        Me.cmbreasoncode = New System.Windows.Forms.ComboBox()
        Me.txtqtyscrapped = New System.Windows.Forms.TextBox()
        Me.txtqtycomplete = New System.Windows.Forms.TextBox()
        Me.lbltotalhrs = New System.Windows.Forms.Label()
        Me.lblstartint = New System.Windows.Forms.Label()
        Me.btnpost = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.lblnextop = New System.Windows.Forms.Label()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.lbltransdate = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtwcdesc = New System.Windows.Forms.TextBox()
        Me.rtbmach = New System.Windows.Forms.RichTextBox()
        Me.txtwc = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtopernum = New System.Windows.Forms.TextBox()
        Me.txtsuffix = New System.Windows.Forms.TextBox()
        Me.txtjob = New System.Windows.Forms.TextBox()
        Me.lblshift = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblempname = New System.Windows.Forms.Label()
        Me.lblempnum = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblwhse = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpstart = New System.Windows.Forms.DateTimePicker()
        Me.txttranstype = New System.Windows.Forms.TextBox()
        Me.dtpend = New System.Windows.Forms.DateTimePicker()
        Me.lbl_updatedby = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtptransdate
        '
        Me.dtptransdate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtptransdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptransdate.Location = New System.Drawing.Point(339, 22)
        Me.dtptransdate.Name = "dtptransdate"
        Me.dtptransdate.Size = New System.Drawing.Size(200, 20)
        Me.dtptransdate.TabIndex = 187
        Me.dtptransdate.Visible = False
        '
        'txtlot
        '
        Me.txtlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlot.Location = New System.Drawing.Point(213, 471)
        Me.txtlot.Name = "txtlot"
        Me.txtlot.Size = New System.Drawing.Size(193, 22)
        Me.txtlot.TabIndex = 185
        '
        'lblendint
        '
        Me.lblendint.AutoSize = True
        Me.lblendint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblendint.Location = New System.Drawing.Point(468, 49)
        Me.lblendint.Name = "lblendint"
        Me.lblendint.Size = New System.Drawing.Size(0, 13)
        Me.lblendint.TabIndex = 180
        Me.lblendint.Visible = False
        '
        'lblqtymoved
        '
        Me.lblqtymoved.AutoSize = True
        Me.lblqtymoved.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblqtymoved.ForeColor = System.Drawing.Color.White
        Me.lblqtymoved.Location = New System.Drawing.Point(213, 446)
        Me.lblqtymoved.Name = "lblqtymoved"
        Me.lblqtymoved.Size = New System.Drawing.Size(0, 18)
        Me.lblqtymoved.TabIndex = 186
        '
        'lblreasondesc
        '
        Me.lblreasondesc.AutoSize = True
        Me.lblreasondesc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreasondesc.ForeColor = System.Drawing.Color.White
        Me.lblreasondesc.Location = New System.Drawing.Point(210, 421)
        Me.lblreasondesc.Name = "lblreasondesc"
        Me.lblreasondesc.Size = New System.Drawing.Size(0, 18)
        Me.lblreasondesc.TabIndex = 184
        '
        'cmbreasoncode
        '
        Me.cmbreasoncode.FormattingEnabled = True
        Me.cmbreasoncode.Location = New System.Drawing.Point(213, 394)
        Me.cmbreasoncode.Name = "cmbreasoncode"
        Me.cmbreasoncode.Size = New System.Drawing.Size(193, 21)
        Me.cmbreasoncode.TabIndex = 183
        '
        'txtqtyscrapped
        '
        Me.txtqtyscrapped.BackColor = System.Drawing.SystemColors.Info
        Me.txtqtyscrapped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtyscrapped.Location = New System.Drawing.Point(213, 364)
        Me.txtqtyscrapped.Name = "txtqtyscrapped"
        Me.txtqtyscrapped.Size = New System.Drawing.Size(193, 22)
        Me.txtqtyscrapped.TabIndex = 182
        Me.txtqtyscrapped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtqtycomplete
        '
        Me.txtqtycomplete.BackColor = System.Drawing.SystemColors.Info
        Me.txtqtycomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtycomplete.Location = New System.Drawing.Point(213, 336)
        Me.txtqtycomplete.Name = "txtqtycomplete"
        Me.txtqtycomplete.Size = New System.Drawing.Size(193, 22)
        Me.txtqtycomplete.TabIndex = 181
        Me.txtqtycomplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalhrs
        '
        Me.lbltotalhrs.AutoSize = True
        Me.lbltotalhrs.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalhrs.ForeColor = System.Drawing.Color.White
        Me.lbltotalhrs.Location = New System.Drawing.Point(213, 647)
        Me.lbltotalhrs.Name = "lbltotalhrs"
        Me.lbltotalhrs.Size = New System.Drawing.Size(0, 29)
        Me.lbltotalhrs.TabIndex = 179
        '
        'lblstartint
        '
        Me.lblstartint.AutoSize = True
        Me.lblstartint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblstartint.Location = New System.Drawing.Point(384, 49)
        Me.lblstartint.Name = "lblstartint"
        Me.lblstartint.Size = New System.Drawing.Size(0, 13)
        Me.lblstartint.TabIndex = 177
        Me.lblstartint.Visible = False
        '
        'btnpost
        '
        Me.btnpost.BackColor = System.Drawing.Color.LimeGreen
        Me.btnpost.Enabled = False
        Me.btnpost.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnpost.FlatAppearance.BorderSize = 2
        Me.btnpost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpost.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnpost.Location = New System.Drawing.Point(504, 748)
        Me.btnpost.Name = "btnpost"
        Me.btnpost.Size = New System.Drawing.Size(254, 24)
        Me.btnpost.TabIndex = 176
        Me.btnpost.Text = "POST"
        Me.btnpost.UseVisualStyleBackColor = False
        Me.btnpost.Visible = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnsave.FlatAppearance.BorderSize = 2
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnsave.Location = New System.Drawing.Point(161, 688)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(254, 44)
        Me.btnsave.TabIndex = 175
        Me.btnsave.Text = "UPDATE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'lblnextop
        '
        Me.lblnextop.AutoSize = True
        Me.lblnextop.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnextop.ForeColor = System.Drawing.Color.White
        Me.lblnextop.Location = New System.Drawing.Point(210, 309)
        Me.lblnextop.Name = "lblnextop"
        Me.lblnextop.Size = New System.Drawing.Size(0, 18)
        Me.lblnextop.TabIndex = 174
        '
        'btnexit
        '
        Me.btnexit.BackColor = System.Drawing.Color.Red
        Me.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnexit.FlatAppearance.BorderSize = 2
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnexit.Location = New System.Drawing.Point(161, 738)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(254, 45)
        Me.btnexit.TabIndex = 173
        Me.btnexit.Text = "EXIT"
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'lbltransdate
        '
        Me.lbltransdate.AutoSize = True
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.White
        Me.lbltransdate.Location = New System.Drawing.Point(210, 499)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(0, 18)
        Me.lbltransdate.TabIndex = 172
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(124, 647)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 18)
        Me.Label21.TabIndex = 170
        Me.Label21.Text = "TOTAL HRS :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(99, 587)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 26)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "END TIME :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(85, 529)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(122, 26)
        Me.Label19.TabIndex = 168
        Me.Label19.Text = "START TIME :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(69, 499)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 18)
        Me.Label18.TabIndex = 167
        Me.Label18.Text = "TRANSACTION DATE :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(169, 473)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 18)
        Me.Label17.TabIndex = 166
        Me.Label17.Text = "LOT :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(118, 446)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 18)
        Me.Label16.TabIndex = 165
        Me.Label16.Text = "QTY MOVED :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(98, 394)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 18)
        Me.Label15.TabIndex = 164
        Me.Label15.Text = "SCRAP REASON :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(101, 366)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 18)
        Me.Label14.TabIndex = 163
        Me.Label14.Text = "QTY SCRAPPED :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(91, 338)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 18)
        Me.Label11.TabIndex = 162
        Me.Label11.Text = "QTY COMPLETED :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(124, 309)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 18)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "NEXT OPER :"
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(279, 235)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 160
        Me.txtwcdesc.Visible = False
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(213, 270)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 159
        Me.rtbmach.Text = ""
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(213, 235)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 158
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(133, 275)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 157
        Me.Label13.Text = "MACHINE :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(171, 240)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 18)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "WC :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(128, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "OPER. NO. :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(150, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "SUFFIX :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SFMS BARCODE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(169, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 18)
        Me.Label6.TabIndex = 153
        Me.Label6.Text = "JOB :"
        '
        'txtopernum
        '
        Me.txtopernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopernum.Location = New System.Drawing.Point(213, 206)
        Me.txtopernum.Name = "txtopernum"
        Me.txtopernum.ReadOnly = True
        Me.txtopernum.Size = New System.Drawing.Size(193, 22)
        Me.txtopernum.TabIndex = 152
        '
        'txtsuffix
        '
        Me.txtsuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuffix.Location = New System.Drawing.Point(213, 178)
        Me.txtsuffix.Name = "txtsuffix"
        Me.txtsuffix.ReadOnly = True
        Me.txtsuffix.Size = New System.Drawing.Size(193, 22)
        Me.txtsuffix.TabIndex = 151
        '
        'txtjob
        '
        Me.txtjob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjob.Location = New System.Drawing.Point(213, 150)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.ReadOnly = True
        Me.txtjob.Size = New System.Drawing.Size(193, 22)
        Me.txtjob.TabIndex = 150
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(210, 126)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(42, 18)
        Me.lblshift.TabIndex = 149
        Me.lblshift.Text = "?shift"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(158, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "SHIFT :"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(210, 106)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(78, 18)
        Me.lblempname.TabIndex = 147
        Me.lblempname.Text = "?empname"
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(210, 83)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(71, 18)
        Me.lblempnum.TabIndex = 146
        Me.lblempnum.Text = "?empnum"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(128, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "EMPLOYEE :"
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(289, 38)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(32, 13)
        Me.lblwhse.TabIndex = 140
        Me.lblwhse.Text = "whse"
        Me.lblwhse.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(2, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(247, 29)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "UPDATE MACHINE RUN"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 19)
        Me.Panel1.TabIndex = 138
        '
        'dtpstart
        '
        Me.dtpstart.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpstart.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpstart.Location = New System.Drawing.Point(213, 524)
        Me.dtpstart.Name = "dtpstart"
        Me.dtpstart.ShowUpDown = True
        Me.dtpstart.Size = New System.Drawing.Size(346, 38)
        Me.dtpstart.TabIndex = 188
        '
        'txttranstype
        '
        Me.txttranstype.Location = New System.Drawing.Point(444, 65)
        Me.txttranstype.Name = "txttranstype"
        Me.txttranstype.ReadOnly = True
        Me.txttranstype.Size = New System.Drawing.Size(95, 20)
        Me.txttranstype.TabIndex = 189
        Me.txttranstype.Visible = False
        '
        'dtpend
        '
        Me.dtpend.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpend.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpend.Location = New System.Drawing.Point(213, 581)
        Me.dtpend.Name = "dtpend"
        Me.dtpend.ShowUpDown = True
        Me.dtpend.Size = New System.Drawing.Size(346, 38)
        Me.dtpend.TabIndex = 190
        '
        'lbl_updatedby
        '
        Me.lbl_updatedby.AutoSize = True
        Me.lbl_updatedby.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_updatedby.ForeColor = System.Drawing.Color.White
        Me.lbl_updatedby.Location = New System.Drawing.Point(384, 106)
        Me.lbl_updatedby.Name = "lbl_updatedby"
        Me.lbl_updatedby.Size = New System.Drawing.Size(0, 18)
        Me.lbl_updatedby.TabIndex = 191
        Me.lbl_updatedby.Visible = False
        '
        'frmupdatemachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(779, 784)
        Me.Controls.Add(Me.lbl_updatedby)
        Me.Controls.Add(Me.dtpend)
        Me.Controls.Add(Me.txttranstype)
        Me.Controls.Add(Me.dtpstart)
        Me.Controls.Add(Me.dtptransdate)
        Me.Controls.Add(Me.txtlot)
        Me.Controls.Add(Me.lblendint)
        Me.Controls.Add(Me.lblqtymoved)
        Me.Controls.Add(Me.lblreasondesc)
        Me.Controls.Add(Me.cmbreasoncode)
        Me.Controls.Add(Me.txtqtyscrapped)
        Me.Controls.Add(Me.txtqtycomplete)
        Me.Controls.Add(Me.lbltotalhrs)
        Me.Controls.Add(Me.lblstartint)
        Me.Controls.Add(Me.btnpost)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.lblnextop)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.lbltransdate)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtwcdesc)
        Me.Controls.Add(Me.rtbmach)
        Me.Controls.Add(Me.txtwc)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtopernum)
        Me.Controls.Add(Me.txtsuffix)
        Me.Controls.Add(Me.txtjob)
        Me.Controls.Add(Me.lblshift)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblempname)
        Me.Controls.Add(Me.lblempnum)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblwhse)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1360, 0)
        Me.Name = "frmupdatemachine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmupdatemachine"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtptransdate As DateTimePicker
    Friend WithEvents txtlot As TextBox
    Friend WithEvents lblendint As Label
    Friend WithEvents lblqtymoved As Label
    Friend WithEvents lblreasondesc As Label
    Friend WithEvents cmbreasoncode As ComboBox
    Friend WithEvents txtqtyscrapped As TextBox
    Friend WithEvents txtqtycomplete As TextBox
    Friend WithEvents lbltotalhrs As Label
    Friend WithEvents lblstartint As Label
    Friend WithEvents btnpost As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents lblnextop As Label
    Friend WithEvents btnexit As Button
    Friend WithEvents lbltransdate As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtwcdesc As TextBox
    Friend WithEvents rtbmach As RichTextBox
    Friend WithEvents txtwc As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtopernum As TextBox
    Friend WithEvents txtsuffix As TextBox
    Friend WithEvents txtjob As TextBox
    Friend WithEvents lblshift As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblempname As Label
    Friend WithEvents lblempnum As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblwhse As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpstart As DateTimePicker
    Friend WithEvents txttranstype As TextBox
    Friend WithEvents dtpend As DateTimePicker
    Friend WithEvents lbl_updatedby As Label
End Class
