<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmsetupstart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmsetupstart))
        Me.txtjob = New System.Windows.Forms.TextBox()
        Me.txtsuffix = New System.Windows.Forms.TextBox()
        Me.txtopernum = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnsetupend = New System.Windows.Forms.Button()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblempnum = New System.Windows.Forms.Label()
        Me.lblempname = New System.Windows.Forms.Label()
        Me.lblshift = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblsetupdesc = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblstarttime = New System.Windows.Forms.Label()
        Me.lblendtime = New System.Windows.Forms.Label()
        Me.lbltotalhrs = New System.Windows.Forms.Label()
        Me.lbltransdate = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtwc = New System.Windows.Forms.TextBox()
        Me.rtbmach = New System.Windows.Forms.RichTextBox()
        Me.cmbsetuptype = New System.Windows.Forms.ComboBox()
        Me.lblwhse = New System.Windows.Forms.Label()
        Me.txtwcdesc = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtjob
        '
        Me.txtjob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjob.Location = New System.Drawing.Point(174, 186)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.Size = New System.Drawing.Size(193, 22)
        Me.txtjob.TabIndex = 5
        '
        'txtsuffix
        '
        Me.txtsuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuffix.Location = New System.Drawing.Point(174, 214)
        Me.txtsuffix.Name = "txtsuffix"
        Me.txtsuffix.Size = New System.Drawing.Size(193, 22)
        Me.txtsuffix.TabIndex = 6
        '
        'txtopernum
        '
        Me.txtopernum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopernum.Location = New System.Drawing.Point(174, 242)
        Me.txtopernum.Name = "txtopernum"
        Me.txtopernum.Size = New System.Drawing.Size(193, 22)
        Me.txtopernum.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(291, 597)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(254, 37)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnsave.FlatAppearance.BorderSize = 2
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnsave.Location = New System.Drawing.Point(154, 554)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(254, 37)
        Me.btnsave.TabIndex = 12
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnsetupend
        '
        Me.btnsetupend.BackColor = System.Drawing.Color.Moccasin
        Me.btnsetupend.FlatAppearance.BorderColor = System.Drawing.Color.Moccasin
        Me.btnsetupend.FlatAppearance.BorderSize = 2
        Me.btnsetupend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsetupend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsetupend.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsetupend.Location = New System.Drawing.Point(21, 597)
        Me.btnsetupend.Name = "btnsetupend"
        Me.btnsetupend.Size = New System.Drawing.Size(254, 37)
        Me.btnsetupend.TabIndex = 13
        Me.btnsetupend.Text = "END SETUP RUN"
        Me.btnsetupend.UseVisualStyleBackColor = False
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbltime.Location = New System.Drawing.Point(178, 82)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(0, 23)
        Me.lbltime.TabIndex = 17
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbldate.Location = New System.Drawing.Point(178, 59)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(139, 23)
        Me.lbldate.TabIndex = 16
        Me.lbldate.Text = "CURRENT DATE :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label1.Location = New System.Drawing.Point(37, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "CURRENT TIME :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label2.Location = New System.Drawing.Point(37, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "CURRENT DATE :"
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
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(834, 19)
        Me.Panel1.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(2, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 29)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "SETUP START"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(89, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "EMPLOYEE :"
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(174, 115)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(71, 18)
        Me.lblempnum.TabIndex = 21
        Me.lblempnum.Text = "?empnum"
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(174, 138)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(78, 18)
        Me.lblempname.TabIndex = 22
        Me.lblempname.Text = "?empname"
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(174, 161)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(42, 18)
        Me.lblshift.TabIndex = 24
        Me.lblshift.Text = "?shift"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(130, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 18)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "JOB :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(111, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "SUFFIX :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(89, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "OPER. NO. :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(83, 272)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 18)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "SETUP TYPE :"
        '
        'lblsetupdesc
        '
        Me.lblsetupdesc.AutoSize = True
        Me.lblsetupdesc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsetupdesc.ForeColor = System.Drawing.Color.White
        Me.lblsetupdesc.Location = New System.Drawing.Point(174, 314)
        Me.lblsetupdesc.Name = "lblsetupdesc"
        Me.lblsetupdesc.Size = New System.Drawing.Size(0, 18)
        Me.lblsetupdesc.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(132, 353)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 18)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "WC :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(94, 388)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "MACHINE :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(119, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 18)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "SHIFT :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(30, 420)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(138, 18)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "TRANSACTION DATE :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(83, 452)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 18)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "START TIME :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(94, 484)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 18)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "END TIME :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(88, 516)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 18)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "TOTAL HRS :"
        '
        'lblstarttime
        '
        Me.lblstarttime.AutoSize = True
        Me.lblstarttime.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstarttime.ForeColor = System.Drawing.Color.White
        Me.lblstarttime.Location = New System.Drawing.Point(174, 452)
        Me.lblstarttime.Name = "lblstarttime"
        Me.lblstarttime.Size = New System.Drawing.Size(71, 18)
        Me.lblstarttime.TabIndex = 42
        Me.lblstarttime.Text = "?starttime"
        '
        'lblendtime
        '
        Me.lblendtime.AutoSize = True
        Me.lblendtime.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblendtime.ForeColor = System.Drawing.Color.White
        Me.lblendtime.Location = New System.Drawing.Point(174, 484)
        Me.lblendtime.Name = "lblendtime"
        Me.lblendtime.Size = New System.Drawing.Size(0, 18)
        Me.lblendtime.TabIndex = 43
        '
        'lbltotalhrs
        '
        Me.lbltotalhrs.AutoSize = True
        Me.lbltotalhrs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalhrs.ForeColor = System.Drawing.Color.White
        Me.lbltotalhrs.Location = New System.Drawing.Point(174, 516)
        Me.lbltotalhrs.Name = "lbltotalhrs"
        Me.lbltotalhrs.Size = New System.Drawing.Size(0, 18)
        Me.lbltotalhrs.TabIndex = 44
        '
        'lbltransdate
        '
        Me.lbltransdate.AutoSize = True
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.White
        Me.lbltransdate.Location = New System.Drawing.Point(174, 420)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(111, 18)
        Me.lbltransdate.TabIndex = 45
        Me.lbltransdate.Text = "?transactiondate"
        '
        'Timer1
        '
        '
        'txtwc
        '
        Me.txtwc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwc.Location = New System.Drawing.Point(174, 348)
        Me.txtwc.Name = "txtwc"
        Me.txtwc.ReadOnly = True
        Me.txtwc.Size = New System.Drawing.Size(60, 26)
        Me.txtwc.TabIndex = 10
        '
        'rtbmach
        '
        Me.rtbmach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbmach.Location = New System.Drawing.Point(174, 383)
        Me.rtbmach.Name = "rtbmach"
        Me.rtbmach.ReadOnly = True
        Me.rtbmach.Size = New System.Drawing.Size(291, 29)
        Me.rtbmach.TabIndex = 46
        Me.rtbmach.Text = ""
        '
        'cmbsetuptype
        '
        Me.cmbsetuptype.BackColor = System.Drawing.SystemColors.Info
        Me.cmbsetuptype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbsetuptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsetuptype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbsetuptype.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsetuptype.FormattingEnabled = True
        Me.cmbsetuptype.Location = New System.Drawing.Point(174, 270)
        Me.cmbsetuptype.Name = "cmbsetuptype"
        Me.cmbsetuptype.Size = New System.Drawing.Size(291, 32)
        Me.cmbsetuptype.TabIndex = 47
        '
        'lblwhse
        '
        Me.lblwhse.AutoSize = True
        Me.lblwhse.Location = New System.Drawing.Point(301, 37)
        Me.lblwhse.Name = "lblwhse"
        Me.lblwhse.Size = New System.Drawing.Size(0, 13)
        Me.lblwhse.TabIndex = 48
        Me.lblwhse.Visible = False
        '
        'txtwcdesc
        '
        Me.txtwcdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwcdesc.Location = New System.Drawing.Point(240, 348)
        Me.txtwcdesc.Name = "txtwcdesc"
        Me.txtwcdesc.ReadOnly = True
        Me.txtwcdesc.Size = New System.Drawing.Size(225, 26)
        Me.txtwcdesc.TabIndex = 49
        '
        'frmsetupstart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(829, 723)
        Me.Controls.Add(Me.txtwcdesc)
        Me.Controls.Add(Me.lblwhse)
        Me.Controls.Add(Me.cmbsetuptype)
        Me.Controls.Add(Me.rtbmach)
        Me.Controls.Add(Me.lbltransdate)
        Me.Controls.Add(Me.lbltotalhrs)
        Me.Controls.Add(Me.lblendtime)
        Me.Controls.Add(Me.lblstarttime)
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
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnsetupend)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtwc)
        Me.Controls.Add(Me.txtopernum)
        Me.Controls.Add(Me.txtsuffix)
        Me.Controls.Add(Me.txtjob)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1360, 0)
        Me.Name = "frmsetupstart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtjob As TextBox
    Friend WithEvents txtsuffix As TextBox
    Friend WithEvents txtopernum As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents btnsetupend As Button
    Friend WithEvents lbltime As Label
    Friend WithEvents lbldate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblempnum As Label
    Friend WithEvents lblempname As Label
    Friend WithEvents lblshift As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblsetupdesc As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblstarttime As Label
    Friend WithEvents lblendtime As Label
    Friend WithEvents lbltotalhrs As Label
    Friend WithEvents lbltransdate As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtwc As TextBox
    Friend WithEvents rtbmach As RichTextBox
    Friend WithEvents cmbsetuptype As ComboBox
    Friend WithEvents lblwhse As Label
    Friend WithEvents txtwcdesc As TextBox
End Class
