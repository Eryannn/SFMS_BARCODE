<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmachineend
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmachineend))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblstartint = New System.Windows.Forms.Label()
        Me.btnpost = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.lblnextop = New System.Windows.Forms.Label()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.lbltransdate = New System.Windows.Forms.Label()
        Me.lblstarttime = New System.Windows.Forms.Label()
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
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblwhse = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblendtime = New System.Windows.Forms.Label()
        Me.lbltotalhrs = New System.Windows.Forms.Label()
        Me.lblendint = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtqtycomplete = New System.Windows.Forms.TextBox()
        Me.txtqtyscrapped = New System.Windows.Forms.TextBox()
        Me.cmbreasoncode = New System.Windows.Forms.ComboBox()
        Me.lblreasondesc = New System.Windows.Forms.Label()
        Me.txtlot = New System.Windows.Forms.TextBox()
        Me.lblqtymoved = New System.Windows.Forms.Label()
        Me.dtptransdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_updatedby = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 19)
        Me.Panel1.TabIndex = 50
        '
        'lblstartint
        '
        Me.lblstartint.AutoSize = True
        Me.lblstartint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblstartint.Location = New System.Drawing.Point(384, 50)
        Me.lblstartint.Name = "lblstartint"
        Me.lblstartint.Size = New System.Drawing.Size(45, 13)
        Me.lblstartint.TabIndex = 127
        Me.lblstartint.Text = "Label22"
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
        Me.btnpost.Location = New System.Drawing.Point(161, 728)
        Me.btnpost.Name = "btnpost"
        Me.btnpost.Size = New System.Drawing.Size(254, 24)
        Me.btnpost.TabIndex = 126
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
        Me.btnsave.Location = New System.Drawing.Point(161, 668)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(254, 24)
        Me.btnsave.TabIndex = 125
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'lblnextop
        '
        Me.lblnextop.AutoSize = True
        Me.lblnextop.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnextop.ForeColor = System.Drawing.Color.White
        Me.lblnextop.Location = New System.Drawing.Point(210, 346)
        Me.lblnextop.Name = "lblnextop"
        Me.lblnextop.Size = New System.Drawing.Size(0, 18)
        Me.lblnextop.TabIndex = 124
        '
        'btnexit
        '
        Me.btnexit.BackColor = System.Drawing.Color.Red
        Me.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnexit.FlatAppearance.BorderSize = 2
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnexit.Location = New System.Drawing.Point(161, 698)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(254, 24)
        Me.btnexit.TabIndex = 123
        Me.btnexit.Text = "EXIT"
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'lbltransdate
        '
        Me.lbltransdate.AutoSize = True
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.White
        Me.lbltransdate.Location = New System.Drawing.Point(210, 550)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(0, 18)
        Me.lbltransdate.TabIndex = 122
        '
        'lblstarttime
        '
        Me.lblstarttime.AutoSize = True
        Me.lblstarttime.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstarttime.ForeColor = System.Drawing.Color.White
        Me.lblstarttime.Location = New System.Drawing.Point(210, 568)
        Me.lblstarttime.Name = "lblstarttime"
        Me.lblstarttime.Size = New System.Drawing.Size(0, 18)
        Me.lblstarttime.TabIndex = 121
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(127, 604)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 18)
        Me.Label21.TabIndex = 120
        Me.Label21.Text = "TOTAL HRS :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(133, 586)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 18)
        Me.Label20.TabIndex = 119
        Me.Label20.Text = "END TIME :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(122, 568)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 118
        Me.Label19.Text = "START TIME :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(69, 550)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 18)
        Me.Label18.TabIndex = 117
        Me.Label18.Text = "TRANSACTION DATE :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(169, 524)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 18)
        Me.Label17.TabIndex = 116
        Me.Label17.Text = "LOT :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(118, 497)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 18)
        Me.Label16.TabIndex = 115
        Me.Label16.Text = "QTY MOVED :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(98, 431)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 18)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "SCRAP REASON :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(101, 403)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 18)
        Me.Label14.TabIndex = 113
        Me.Label14.Text = "QTY SCRAPPED :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(91, 375)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 18)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "QTY COMPLETED :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(124, 346)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 18)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "NEXT OPER :"
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(279, 272)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 110
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(213, 307)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 109
        Me.rtbmach.Text = ""
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(213, 272)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 108
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(133, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 107
        Me.Label13.Text = "MACHINE :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(171, 277)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 18)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "WC :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(128, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "OPER. NO. :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(150, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "SUFFIX :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(169, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 18)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "JOB :"
        '
        'txtopernum
        '
        Me.txtopernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopernum.Location = New System.Drawing.Point(213, 243)
        Me.txtopernum.Name = "txtopernum"
        Me.txtopernum.Size = New System.Drawing.Size(193, 22)
        Me.txtopernum.TabIndex = 102
        '
        'txtsuffix
        '
        Me.txtsuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuffix.Location = New System.Drawing.Point(213, 215)
        Me.txtsuffix.Name = "txtsuffix"
        Me.txtsuffix.Size = New System.Drawing.Size(193, 22)
        Me.txtsuffix.TabIndex = 101
        '
        'txtjob
        '
        Me.txtjob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjob.Location = New System.Drawing.Point(213, 187)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.Size = New System.Drawing.Size(193, 22)
        Me.txtjob.TabIndex = 100
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(210, 163)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(42, 18)
        Me.lblshift.TabIndex = 99
        Me.lblshift.Text = "?shift"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(158, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "SHIFT :"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(210, 143)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(78, 18)
        Me.lblempname.TabIndex = 97
        Me.lblempname.Text = "?empname"
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(210, 120)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(71, 18)
        Me.lblempnum.TabIndex = 96
        Me.lblempnum.Text = "?empnum"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(128, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "EMPLOYEE :"
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbltime.Location = New System.Drawing.Point(214, 89)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(0, 23)
        Me.lbltime.TabIndex = 94
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbldate.Location = New System.Drawing.Point(214, 66)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(139, 23)
        Me.lbldate.TabIndex = 93
        Me.lbldate.Text = "CURRENT DATE :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label1.Location = New System.Drawing.Point(73, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "CURRENT TIME :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label2.Location = New System.Drawing.Point(73, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "CURRENT DATE :"
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(289, 39)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(32, 13)
        Me.lblwhse.TabIndex = 90
        Me.lblwhse.Text = "whse"
        Me.lblwhse.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(2, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(210, 29)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "MACHINE RUN END"
        '
        'lblendtime
        '
        Me.lblendtime.AutoSize = True
        Me.lblendtime.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblendtime.ForeColor = System.Drawing.Color.White
        Me.lblendtime.Location = New System.Drawing.Point(210, 586)
        Me.lblendtime.Name = "lblendtime"
        Me.lblendtime.Size = New System.Drawing.Size(0, 18)
        Me.lblendtime.TabIndex = 128
        '
        'lbltotalhrs
        '
        Me.lbltotalhrs.AutoSize = True
        Me.lbltotalhrs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalhrs.ForeColor = System.Drawing.Color.White
        Me.lbltotalhrs.Location = New System.Drawing.Point(210, 604)
        Me.lbltotalhrs.Name = "lbltotalhrs"
        Me.lbltotalhrs.Size = New System.Drawing.Size(15, 18)
        Me.lbltotalhrs.TabIndex = 129
        Me.lbltotalhrs.Text = "0"
        '
        'lblendint
        '
        Me.lblendint.AutoSize = True
        Me.lblendint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblendint.Location = New System.Drawing.Point(468, 50)
        Me.lblendint.Name = "lblendint"
        Me.lblendint.Size = New System.Drawing.Size(45, 13)
        Me.lblendint.TabIndex = 130
        Me.lblendint.Text = "Label22"
        Me.lblendint.Visible = False
        '
        'Timer1
        '
        '
        'txtqtycomplete
        '
        Me.txtqtycomplete.BackColor = System.Drawing.SystemColors.Info
        Me.txtqtycomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtycomplete.Location = New System.Drawing.Point(213, 373)
        Me.txtqtycomplete.Name = "txtqtycomplete"
        Me.txtqtycomplete.Size = New System.Drawing.Size(193, 22)
        Me.txtqtycomplete.TabIndex = 131
        Me.txtqtycomplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtqtyscrapped
        '
        Me.txtqtyscrapped.BackColor = System.Drawing.SystemColors.Info
        Me.txtqtyscrapped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtyscrapped.Location = New System.Drawing.Point(213, 401)
        Me.txtqtyscrapped.Name = "txtqtyscrapped"
        Me.txtqtyscrapped.Size = New System.Drawing.Size(193, 22)
        Me.txtqtyscrapped.TabIndex = 132
        Me.txtqtyscrapped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbreasoncode
        '
        Me.cmbreasoncode.BackColor = System.Drawing.Color.Yellow
        Me.cmbreasoncode.DropDownWidth = 193
        Me.cmbreasoncode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbreasoncode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbreasoncode.FormattingEnabled = True
        Me.cmbreasoncode.Location = New System.Drawing.Point(213, 431)
        Me.cmbreasoncode.Name = "cmbreasoncode"
        Me.cmbreasoncode.Size = New System.Drawing.Size(291, 32)
        Me.cmbreasoncode.TabIndex = 133
        '
        'lblreasondesc
        '
        Me.lblreasondesc.AutoSize = True
        Me.lblreasondesc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreasondesc.ForeColor = System.Drawing.Color.White
        Me.lblreasondesc.Location = New System.Drawing.Point(210, 472)
        Me.lblreasondesc.Name = "lblreasondesc"
        Me.lblreasondesc.Size = New System.Drawing.Size(0, 18)
        Me.lblreasondesc.TabIndex = 134
        '
        'txtlot
        '
        Me.txtlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlot.Location = New System.Drawing.Point(213, 522)
        Me.txtlot.Name = "txtlot"
        Me.txtlot.Size = New System.Drawing.Size(193, 22)
        Me.txtlot.TabIndex = 135
        '
        'lblqtymoved
        '
        Me.lblqtymoved.AutoSize = True
        Me.lblqtymoved.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblqtymoved.ForeColor = System.Drawing.Color.White
        Me.lblqtymoved.Location = New System.Drawing.Point(213, 497)
        Me.lblqtymoved.Name = "lblqtymoved"
        Me.lblqtymoved.Size = New System.Drawing.Size(15, 18)
        Me.lblqtymoved.TabIndex = 136
        Me.lblqtymoved.Text = "0"
        '
        'dtptransdate
        '
        Me.dtptransdate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtptransdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptransdate.Location = New System.Drawing.Point(339, 23)
        Me.dtptransdate.Name = "dtptransdate"
        Me.dtptransdate.Size = New System.Drawing.Size(200, 20)
        Me.dtptransdate.TabIndex = 137
        Me.dtptransdate.Visible = False
        '
        'lbl_updatedby
        '
        Me.lbl_updatedby.AutoSize = True
        Me.lbl_updatedby.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_updatedby.ForeColor = System.Drawing.Color.White
        Me.lbl_updatedby.Location = New System.Drawing.Point(405, 120)
        Me.lbl_updatedby.Name = "lbl_updatedby"
        Me.lbl_updatedby.Size = New System.Drawing.Size(0, 18)
        Me.lbl_updatedby.TabIndex = 138
        Me.lbl_updatedby.Visible = False
        '
        'frmmachineend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(552, 774)
        Me.Controls.Add(Me.lbl_updatedby)
        Me.Controls.Add(Me.dtptransdate)
        Me.Controls.Add(Me.lblqtymoved)
        Me.Controls.Add(Me.txtlot)
        Me.Controls.Add(Me.lblreasondesc)
        Me.Controls.Add(Me.cmbreasoncode)
        Me.Controls.Add(Me.txtqtyscrapped)
        Me.Controls.Add(Me.txtqtycomplete)
        Me.Controls.Add(Me.lblendint)
        Me.Controls.Add(Me.lbltotalhrs)
        Me.Controls.Add(Me.lblendtime)
        Me.Controls.Add(Me.lblstartint)
        Me.Controls.Add(Me.btnpost)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.lblnextop)
        Me.Controls.Add(Me.btnexit)
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
        Me.Name = "frmmachineend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmmachineend"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblstartint As Label
    Friend WithEvents btnpost As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents lblnextop As Label
    Friend WithEvents btnexit As Button
    Friend WithEvents lbltransdate As Label
    Friend WithEvents lblstarttime As Label
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
    Friend WithEvents lbltime As Label
    Friend WithEvents lbldate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblwhse As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblendtime As Label
    Friend WithEvents lbltotalhrs As Label
    Friend WithEvents lblendint As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtqtycomplete As TextBox
    Friend WithEvents txtqtyscrapped As TextBox
    Friend WithEvents cmbreasoncode As ComboBox
    Friend WithEvents lblreasondesc As Label
    Friend WithEvents txtlot As TextBox
    Friend WithEvents lblqtymoved As Label
    Friend WithEvents dtptransdate As DateTimePicker
    Friend WithEvents lbl_updatedby As Label
End Class
