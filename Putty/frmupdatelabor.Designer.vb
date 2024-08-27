<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmupdatelabor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmupdatelabor))
        Me.dtptransdate = New System.Windows.Forms.DateTimePicker()
        Me.lblum2 = New System.Windows.Forms.Label()
        Me.lblum1 = New System.Windows.Forms.Label()
        Me.lblum = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtqtymoved = New System.Windows.Forms.TextBox()
        Me.txtlot = New System.Windows.Forms.TextBox()
        Me.lblreasondesc = New System.Windows.Forms.Label()
        Me.cmbreasoncode = New System.Windows.Forms.ComboBox()
        Me.txtqtyscrapped = New System.Windows.Forms.TextBox()
        Me.txtqtycomplete = New System.Windows.Forms.TextBox()
        Me.lblendint = New System.Windows.Forms.Label()
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
        Me.dtpend = New System.Windows.Forms.DateTimePicker()
        Me.txttranstype = New System.Windows.Forms.TextBox()
        Me.lbl_updatedby = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtptransdate
        '
        Me.dtptransdate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtptransdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptransdate.Location = New System.Drawing.Point(341, 24)
        Me.dtptransdate.Name = "dtptransdate"
        Me.dtptransdate.Size = New System.Drawing.Size(200, 20)
        Me.dtptransdate.TabIndex = 243
        Me.dtptransdate.Visible = False
        '
        'lblum2
        '
        Me.lblum2.AutoSize = True
        Me.lblum2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblum2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblum2.Location = New System.Drawing.Point(412, 431)
        Me.lblum2.Name = "lblum2"
        Me.lblum2.Size = New System.Drawing.Size(0, 18)
        Me.lblum2.TabIndex = 241
        '
        'lblum1
        '
        Me.lblum1.AutoSize = True
        Me.lblum1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblum1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblum1.Location = New System.Drawing.Point(412, 351)
        Me.lblum1.Name = "lblum1"
        Me.lblum1.Size = New System.Drawing.Size(0, 18)
        Me.lblum1.TabIndex = 240
        '
        'lblum
        '
        Me.lblum.AutoSize = True
        Me.lblum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblum.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblum.Location = New System.Drawing.Point(412, 323)
        Me.lblum.Name = "lblum"
        Me.lblum.Size = New System.Drawing.Size(0, 18)
        Me.lblum.TabIndex = 239
        Me.lblum.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(2, -1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SFMS BARCODE"
        '
        'txtqtymoved
        '
        Me.txtqtymoved.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtqtymoved.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtymoved.Location = New System.Drawing.Point(213, 429)
        Me.txtqtymoved.Name = "txtqtymoved"
        Me.txtqtymoved.ReadOnly = True
        Me.txtqtymoved.Size = New System.Drawing.Size(193, 22)
        Me.txtqtymoved.TabIndex = 242
        Me.txtqtymoved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtlot
        '
        Me.txtlot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlot.Location = New System.Drawing.Point(213, 456)
        Me.txtlot.Name = "txtlot"
        Me.txtlot.ReadOnly = True
        Me.txtlot.Size = New System.Drawing.Size(193, 22)
        Me.txtlot.TabIndex = 238
        '
        'lblreasondesc
        '
        Me.lblreasondesc.AutoSize = True
        Me.lblreasondesc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreasondesc.ForeColor = System.Drawing.Color.White
        Me.lblreasondesc.Location = New System.Drawing.Point(210, 406)
        Me.lblreasondesc.Name = "lblreasondesc"
        Me.lblreasondesc.Size = New System.Drawing.Size(0, 18)
        Me.lblreasondesc.TabIndex = 237
        '
        'cmbreasoncode
        '
        Me.cmbreasoncode.FormattingEnabled = True
        Me.cmbreasoncode.Location = New System.Drawing.Point(213, 379)
        Me.cmbreasoncode.Name = "cmbreasoncode"
        Me.cmbreasoncode.Size = New System.Drawing.Size(193, 21)
        Me.cmbreasoncode.TabIndex = 236
        '
        'txtqtyscrapped
        '
        Me.txtqtyscrapped.BackColor = System.Drawing.SystemColors.Info
        Me.txtqtyscrapped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtyscrapped.Location = New System.Drawing.Point(213, 349)
        Me.txtqtyscrapped.Name = "txtqtyscrapped"
        Me.txtqtyscrapped.Size = New System.Drawing.Size(193, 22)
        Me.txtqtyscrapped.TabIndex = 235
        Me.txtqtyscrapped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtqtycomplete
        '
        Me.txtqtycomplete.BackColor = System.Drawing.SystemColors.Info
        Me.txtqtycomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtycomplete.Location = New System.Drawing.Point(213, 321)
        Me.txtqtycomplete.Name = "txtqtycomplete"
        Me.txtqtycomplete.Size = New System.Drawing.Size(193, 22)
        Me.txtqtycomplete.TabIndex = 234
        Me.txtqtycomplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblendint
        '
        Me.lblendint.AutoSize = True
        Me.lblendint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblendint.Location = New System.Drawing.Point(468, 49)
        Me.lblendint.Name = "lblendint"
        Me.lblendint.Size = New System.Drawing.Size(0, 13)
        Me.lblendint.TabIndex = 233
        Me.lblendint.Visible = False
        '
        'lbltotalhrs
        '
        Me.lbltotalhrs.AutoSize = True
        Me.lbltotalhrs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalhrs.ForeColor = System.Drawing.Color.White
        Me.lbltotalhrs.Location = New System.Drawing.Point(210, 560)
        Me.lbltotalhrs.Name = "lbltotalhrs"
        Me.lbltotalhrs.Size = New System.Drawing.Size(0, 18)
        Me.lbltotalhrs.TabIndex = 232
        '
        'lblstartint
        '
        Me.lblstartint.AutoSize = True
        Me.lblstartint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblstartint.Location = New System.Drawing.Point(384, 49)
        Me.lblstartint.Name = "lblstartint"
        Me.lblstartint.Size = New System.Drawing.Size(0, 13)
        Me.lblstartint.TabIndex = 230
        Me.lblstartint.Visible = False
        '
        'btnpost
        '
        Me.btnpost.BackColor = System.Drawing.Color.LimeGreen
        Me.btnpost.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnpost.FlatAppearance.BorderSize = 2
        Me.btnpost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpost.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnpost.Location = New System.Drawing.Point(305, 753)
        Me.btnpost.Name = "btnpost"
        Me.btnpost.Size = New System.Drawing.Size(254, 24)
        Me.btnpost.TabIndex = 229
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
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnsave.Location = New System.Drawing.Point(161, 606)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(254, 24)
        Me.btnsave.TabIndex = 228
        Me.btnsave.Text = "UPDATE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'lblnextop
        '
        Me.lblnextop.AutoSize = True
        Me.lblnextop.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnextop.ForeColor = System.Drawing.Color.White
        Me.lblnextop.Location = New System.Drawing.Point(210, 294)
        Me.lblnextop.Name = "lblnextop"
        Me.lblnextop.Size = New System.Drawing.Size(0, 18)
        Me.lblnextop.TabIndex = 227
        '
        'btnexit
        '
        Me.btnexit.BackColor = System.Drawing.Color.Red
        Me.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnexit.FlatAppearance.BorderSize = 2
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnexit.Location = New System.Drawing.Point(161, 636)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(254, 24)
        Me.btnexit.TabIndex = 226
        Me.btnexit.Text = "EXIT"
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'lbltransdate
        '
        Me.lbltransdate.AutoSize = True
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.White
        Me.lbltransdate.Location = New System.Drawing.Point(210, 484)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(0, 18)
        Me.lbltransdate.TabIndex = 225
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(127, 560)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 18)
        Me.Label21.TabIndex = 223
        Me.Label21.Text = "TOTAL HRS :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(133, 532)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 18)
        Me.Label20.TabIndex = 222
        Me.Label20.Text = "END TIME :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(122, 507)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 221
        Me.Label19.Text = "START TIME :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(69, 484)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 18)
        Me.Label18.TabIndex = 220
        Me.Label18.Text = "TRANSACTION DATE :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(169, 458)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 18)
        Me.Label17.TabIndex = 219
        Me.Label17.Text = "LOT :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(118, 431)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 18)
        Me.Label16.TabIndex = 218
        Me.Label16.Text = "QTY MOVED :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(98, 379)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 18)
        Me.Label15.TabIndex = 217
        Me.Label15.Text = "SCRAP REASON :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(101, 351)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 18)
        Me.Label14.TabIndex = 216
        Me.Label14.Text = "QTY SCRAPPED :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(91, 323)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 18)
        Me.Label11.TabIndex = 215
        Me.Label11.Text = "QTY COMPLETED :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(124, 294)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 18)
        Me.Label10.TabIndex = 214
        Me.Label10.Text = "NEXT OPER :"
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(279, 220)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 213
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(213, 255)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 212
        Me.rtbmach.Text = ""
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(213, 220)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 211
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(128, 260)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 210
        Me.Label13.Text = "RESOURCE :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(171, 225)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 18)
        Me.Label12.TabIndex = 209
        Me.Label12.Text = "WC :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(128, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 208
        Me.Label5.Text = "OPER. NO. :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(150, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "SUFFIX :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(169, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 18)
        Me.Label6.TabIndex = 206
        Me.Label6.Text = "JOB :"
        '
        'txtopernum
        '
        Me.txtopernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopernum.Location = New System.Drawing.Point(213, 191)
        Me.txtopernum.Name = "txtopernum"
        Me.txtopernum.ReadOnly = True
        Me.txtopernum.Size = New System.Drawing.Size(193, 22)
        Me.txtopernum.TabIndex = 205
        '
        'txtsuffix
        '
        Me.txtsuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuffix.Location = New System.Drawing.Point(213, 163)
        Me.txtsuffix.Name = "txtsuffix"
        Me.txtsuffix.ReadOnly = True
        Me.txtsuffix.Size = New System.Drawing.Size(193, 22)
        Me.txtsuffix.TabIndex = 204
        '
        'txtjob
        '
        Me.txtjob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjob.Location = New System.Drawing.Point(213, 135)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.ReadOnly = True
        Me.txtjob.Size = New System.Drawing.Size(193, 22)
        Me.txtjob.TabIndex = 203
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(210, 111)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(0, 18)
        Me.lblshift.TabIndex = 202
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(158, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "SHIFT :"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(210, 91)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(0, 18)
        Me.lblempname.TabIndex = 200
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(210, 68)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(0, 18)
        Me.lblempnum.TabIndex = 199
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(128, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 198
        Me.Label9.Text = "EMPLOYEE :"
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(289, 38)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(32, 13)
        Me.lblwhse.TabIndex = 193
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
        Me.Label8.Size = New System.Drawing.Size(217, 29)
        Me.Label8.TabIndex = 192
        Me.Label8.Text = "UPDATE LABOR RUN"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 19)
        Me.Panel1.TabIndex = 191
        '
        'dtpstart
        '
        Me.dtpstart.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpstart.Location = New System.Drawing.Point(213, 506)
        Me.dtpstart.Name = "dtpstart"
        Me.dtpstart.ShowUpDown = True
        Me.dtpstart.Size = New System.Drawing.Size(162, 20)
        Me.dtpstart.TabIndex = 244
        '
        'dtpend
        '
        Me.dtpend.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpend.Location = New System.Drawing.Point(213, 531)
        Me.dtpend.Name = "dtpend"
        Me.dtpend.ShowUpDown = True
        Me.dtpend.Size = New System.Drawing.Size(162, 20)
        Me.dtpend.TabIndex = 245
        '
        'txttranstype
        '
        Me.txttranstype.Location = New System.Drawing.Point(446, 68)
        Me.txttranstype.Name = "txttranstype"
        Me.txttranstype.ReadOnly = True
        Me.txttranstype.Size = New System.Drawing.Size(95, 20)
        Me.txttranstype.TabIndex = 246
        Me.txttranstype.Visible = False
        '
        'lbl_updatedby
        '
        Me.lbl_updatedby.AutoSize = True
        Me.lbl_updatedby.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_updatedby.ForeColor = System.Drawing.Color.White
        Me.lbl_updatedby.Location = New System.Drawing.Point(503, 135)
        Me.lbl_updatedby.Name = "lbl_updatedby"
        Me.lbl_updatedby.Size = New System.Drawing.Size(0, 18)
        Me.lbl_updatedby.TabIndex = 247
        Me.lbl_updatedby.Visible = False
        '
        'frmupdatelabor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(664, 669)
        Me.Controls.Add(Me.lbl_updatedby)
        Me.Controls.Add(Me.txttranstype)
        Me.Controls.Add(Me.dtpend)
        Me.Controls.Add(Me.dtpstart)
        Me.Controls.Add(Me.dtptransdate)
        Me.Controls.Add(Me.lblum2)
        Me.Controls.Add(Me.lblum1)
        Me.Controls.Add(Me.lblum)
        Me.Controls.Add(Me.txtqtymoved)
        Me.Controls.Add(Me.txtlot)
        Me.Controls.Add(Me.lblreasondesc)
        Me.Controls.Add(Me.cmbreasoncode)
        Me.Controls.Add(Me.txtqtyscrapped)
        Me.Controls.Add(Me.txtqtycomplete)
        Me.Controls.Add(Me.lblendint)
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
        Me.Location = New System.Drawing.Point(1395, 0)
        Me.Name = "frmupdatelabor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmupdatelabor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtptransdate As DateTimePicker
    Friend WithEvents lblum2 As Label
    Friend WithEvents lblum1 As Label
    Friend WithEvents lblum As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtqtymoved As TextBox
    Friend WithEvents txtlot As TextBox
    Friend WithEvents lblreasondesc As Label
    Friend WithEvents cmbreasoncode As ComboBox
    Friend WithEvents txtqtyscrapped As TextBox
    Friend WithEvents txtqtycomplete As TextBox
    Friend WithEvents lblendint As Label
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
    Friend WithEvents dtpend As DateTimePicker
    Friend WithEvents txttranstype As TextBox
    Friend WithEvents lbl_updatedby As Label
End Class
