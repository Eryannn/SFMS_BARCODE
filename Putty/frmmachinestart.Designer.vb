<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmachinestart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmachinestart))
        Me.lblwhse = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblempname = New System.Windows.Forms.Label()
        Me.lblempnum = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblshift = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtopernum = New System.Windows.Forms.TextBox()
        Me.txtsuffix = New System.Windows.Forms.TextBox()
        Me.txtjob = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtwcdesc = New System.Windows.Forms.TextBox()
        Me.rtbmach = New System.Windows.Forms.RichTextBox()
        Me.txtwc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblstarttime = New System.Windows.Forms.Label()
        Me.lbltransdate = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblnextop = New System.Windows.Forms.Label()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblstartint = New System.Windows.Forms.Label()
        Me.lbllot = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(402, 38)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(38, 13)
        Me.lblwhse.TabIndex = 51
        Me.lblwhse.Text = "?whse"
        Me.lblwhse.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(0, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(229, 29)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "MACHINE RUN START"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 19)
        Me.Panel1.TabIndex = 49
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
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbltime.Location = New System.Drawing.Point(212, 88)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(0, 23)
        Me.lbltime.TabIndex = 55
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbldate.Location = New System.Drawing.Point(212, 65)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(114, 23)
        Me.lbldate.TabIndex = 54
        Me.lbldate.Text = "?currentdate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label1.Location = New System.Drawing.Point(71, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "CURRENT TIME :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label2.Location = New System.Drawing.Point(71, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "CURRENT DATE :"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(208, 142)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(78, 18)
        Me.lblempname.TabIndex = 58
        Me.lblempname.Text = "?empname"
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(208, 119)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(71, 18)
        Me.lblempnum.TabIndex = 57
        Me.lblempnum.Text = "?empnum"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(126, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "EMPLOYEE :"
        '
        'Timer1
        '
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(156, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "SHIFT :"
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(208, 162)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(42, 18)
        Me.lblshift.TabIndex = 60
        Me.lblshift.Text = "?shift"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(126, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "OPER. NO. :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(148, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "SUFFIX :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(167, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 18)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "JOB :"
        '
        'txtopernum
        '
        Me.txtopernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopernum.Location = New System.Drawing.Point(211, 242)
        Me.txtopernum.Name = "txtopernum"
        Me.txtopernum.Size = New System.Drawing.Size(193, 22)
        Me.txtopernum.TabIndex = 63
        '
        'txtsuffix
        '
        Me.txtsuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuffix.Location = New System.Drawing.Point(211, 214)
        Me.txtsuffix.Name = "txtsuffix"
        Me.txtsuffix.Size = New System.Drawing.Size(193, 22)
        Me.txtsuffix.TabIndex = 62
        '
        'txtjob
        '
        Me.txtjob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjob.Location = New System.Drawing.Point(211, 186)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.Size = New System.Drawing.Size(193, 22)
        Me.txtjob.TabIndex = 61
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(131, 311)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "MACHINE :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(169, 276)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 18)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "WC :"
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(277, 271)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 71
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(211, 306)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 70
        Me.rtbmach.Text = ""
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(211, 271)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 69
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(122, 345)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 18)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "NEXT OPER :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(89, 374)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 18)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "QTY COMPLETED :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(99, 402)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 18)
        Me.Label14.TabIndex = 74
        Me.Label14.Text = "QTY SCRAPPED :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(96, 430)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 18)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "SCRAP REASON :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(116, 463)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 18)
        Me.Label16.TabIndex = 76
        Me.Label16.Text = "QTY MOVED :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(167, 490)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 18)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "LOT :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(67, 508)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 18)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "TRANSACTION DATE :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(120, 526)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 79
        Me.Label19.Text = "START TIME :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(131, 544)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 18)
        Me.Label20.TabIndex = 80
        Me.Label20.Text = "END TIME :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(125, 562)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 18)
        Me.Label21.TabIndex = 81
        Me.Label21.Text = "TOTAL HRS :"
        '
        'lblstarttime
        '
        Me.lblstarttime.AutoSize = True
        Me.lblstarttime.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstarttime.ForeColor = System.Drawing.Color.White
        Me.lblstarttime.Location = New System.Drawing.Point(208, 526)
        Me.lblstarttime.Name = "lblstarttime"
        Me.lblstarttime.Size = New System.Drawing.Size(71, 18)
        Me.lblstarttime.TabIndex = 82
        Me.lblstarttime.Text = "?starttime"
        '
        'lbltransdate
        '
        Me.lbltransdate.AutoSize = True
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.White
        Me.lbltransdate.Location = New System.Drawing.Point(208, 508)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(111, 18)
        Me.lbltransdate.TabIndex = 83
        Me.lbltransdate.Text = "?transactiondate"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(277, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(254, 24)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblnextop
        '
        Me.lblnextop.AutoSize = True
        Me.lblnextop.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnextop.ForeColor = System.Drawing.Color.White
        Me.lblnextop.Location = New System.Drawing.Point(208, 345)
        Me.lblnextop.Name = "lblnextop"
        Me.lblnextop.Size = New System.Drawing.Size(0, 18)
        Me.lblnextop.TabIndex = 85
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnsave.FlatAppearance.BorderSize = 2
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnsave.Location = New System.Drawing.Point(159, 618)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(254, 24)
        Me.btnsave.TabIndex = 86
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LimeGreen
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.Location = New System.Drawing.Point(17, 648)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(254, 24)
        Me.Button2.TabIndex = 87
        Me.Button2.Text = "END MACHINE RUN"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'lblstartint
        '
        Me.lblstartint.AutoSize = True
        Me.lblstartint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblstartint.Location = New System.Drawing.Point(457, 34)
        Me.lblstartint.Name = "lblstartint"
        Me.lblstartint.Size = New System.Drawing.Size(44, 13)
        Me.lblstartint.TabIndex = 88
        Me.lblstartint.Text = "?startint"
        Me.lblstartint.Visible = False
        '
        'lbllot
        '
        Me.lbllot.AutoSize = True
        Me.lbllot.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllot.ForeColor = System.Drawing.Color.White
        Me.lbllot.Location = New System.Drawing.Point(208, 490)
        Me.lbllot.Name = "lbllot"
        Me.lbllot.Size = New System.Drawing.Size(0, 18)
        Me.lbllot.TabIndex = 89
        '
        'frmmachinestart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(555, 684)
        Me.Controls.Add(Me.lbllot)
        Me.Controls.Add(Me.lblstartint)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.lblnextop)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbltransdate)
        Me.Controls.Add(Me.lblstarttime)
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
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblwhse)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1360, 0)
        Me.Name = "frmmachinestart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmmachinestart"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblwhse As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents lbltime As Label
    Friend WithEvents lbldate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblempname As Label
    Friend WithEvents lblempnum As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents lblshift As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtopernum As TextBox
    Friend WithEvents txtsuffix As TextBox
    Friend WithEvents txtjob As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtwcdesc As TextBox
    Friend WithEvents rtbmach As RichTextBox
    Friend WithEvents txtwc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblstarttime As Label
    Friend WithEvents lbltransdate As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblnextop As Label
    Friend WithEvents btnsave As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents lblstartint As Label
    Friend WithEvents lbllot As Label
End Class
