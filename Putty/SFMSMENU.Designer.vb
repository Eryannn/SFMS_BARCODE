<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SFMSMENU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SFMSMENU))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_setup = New System.Windows.Forms.Button()
        Me.btn_labor = New System.Windows.Forms.Button()
        Me.btn_machine = New System.Windows.Forms.Button()
        Me.btn_downtime = New System.Windows.Forms.Button()
        Me.btn_tsqa_move = New System.Windows.Forms.Button()
        Me.lblempname = New System.Windows.Forms.Label()
        Me.lblempnum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.lblshift = New System.Windows.Forms.Label()
        Me.btn_unposted = New System.Windows.Forms.Button()
        Me.btn_posted = New System.Windows.Forms.Button()
        Me.btn_fgts = New System.Windows.Forms.Button()
        Me.btn_viewdt = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_move_mcnum = New System.Windows.Forms.Button()
        Me.lbl_user = New System.Windows.Forms.Label()
        Me.btn_nooperation = New System.Windows.Forms.Button()
        Me.lbl_site = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 85)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Stencil", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 34)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SFMS BARCODE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label2.Location = New System.Drawing.Point(109, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CURRENT DATE :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label3.Location = New System.Drawing.Point(109, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "CURRENT TIME :"
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbldate.Location = New System.Drawing.Point(250, 102)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(135, 23)
        Me.lbldate.TabIndex = 3
        Me.lbldate.Text = "CURRENT DATE :"
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.LawnGreen
        Me.lbltime.Location = New System.Drawing.Point(250, 125)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(0, 23)
        Me.lbltime.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btn_setup
        '
        Me.btn_setup.BackColor = System.Drawing.Color.Moccasin
        Me.btn_setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_setup.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_setup.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btn_setup.Location = New System.Drawing.Point(18, 26)
        Me.btn_setup.Name = "btn_setup"
        Me.btn_setup.Size = New System.Drawing.Size(203, 47)
        Me.btn_setup.TabIndex = 5
        Me.btn_setup.Text = "SETUP"
        Me.btn_setup.UseVisualStyleBackColor = False
        '
        'btn_labor
        '
        Me.btn_labor.BackColor = System.Drawing.Color.LemonChiffon
        Me.btn_labor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_labor.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold)
        Me.btn_labor.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btn_labor.Location = New System.Drawing.Point(237, 26)
        Me.btn_labor.Name = "btn_labor"
        Me.btn_labor.Size = New System.Drawing.Size(203, 47)
        Me.btn_labor.TabIndex = 7
        Me.btn_labor.Text = "LABOR RUN"
        Me.btn_labor.UseVisualStyleBackColor = False
        '
        'btn_machine
        '
        Me.btn_machine.BackColor = System.Drawing.Color.PaleGreen
        Me.btn_machine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_machine.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold)
        Me.btn_machine.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btn_machine.Location = New System.Drawing.Point(18, 88)
        Me.btn_machine.Name = "btn_machine"
        Me.btn_machine.Size = New System.Drawing.Size(203, 47)
        Me.btn_machine.TabIndex = 9
        Me.btn_machine.Text = "MACHINE RUN "
        Me.btn_machine.UseVisualStyleBackColor = False
        '
        'btn_downtime
        '
        Me.btn_downtime.BackColor = System.Drawing.Color.Red
        Me.btn_downtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_downtime.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn_downtime.ForeColor = System.Drawing.Color.Transparent
        Me.btn_downtime.Location = New System.Drawing.Point(35, 482)
        Me.btn_downtime.Name = "btn_downtime"
        Me.btn_downtime.Size = New System.Drawing.Size(203, 39)
        Me.btn_downtime.TabIndex = 11
        Me.btn_downtime.Text = "DOWNTIME"
        Me.btn_downtime.UseVisualStyleBackColor = False
        '
        'btn_tsqa_move
        '
        Me.btn_tsqa_move.BackColor = System.Drawing.Color.LightCyan
        Me.btn_tsqa_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_tsqa_move.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold)
        Me.btn_tsqa_move.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btn_tsqa_move.Location = New System.Drawing.Point(19, 28)
        Me.btn_tsqa_move.Name = "btn_tsqa_move"
        Me.btn_tsqa_move.Size = New System.Drawing.Size(203, 47)
        Me.btn_tsqa_move.TabIndex = 12
        Me.btn_tsqa_move.Text = "MOVE"
        Me.btn_tsqa_move.UseVisualStyleBackColor = False
        '
        'lblempname
        '
        Me.lblempname.AutoSize = True
        Me.lblempname.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempname.ForeColor = System.Drawing.Color.White
        Me.lblempname.Location = New System.Drawing.Point(763, 511)
        Me.lblempname.Name = "lblempname"
        Me.lblempname.Size = New System.Drawing.Size(80, 19)
        Me.lblempname.TabIndex = 13
        Me.lblempname.Text = "?empname"
        Me.lblempname.Visible = False
        '
        'lblempnum
        '
        Me.lblempnum.AutoSize = True
        Me.lblempnum.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempnum.ForeColor = System.Drawing.Color.White
        Me.lblempnum.Location = New System.Drawing.Point(763, 492)
        Me.lblempnum.Name = "lblempnum"
        Me.lblempnum.Size = New System.Drawing.Size(72, 19)
        Me.lblempnum.TabIndex = 14
        Me.lblempnum.Text = "?empnum"
        Me.lblempnum.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 601)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "USERNAME:"
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Red
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button9.ForeColor = System.Drawing.Color.Transparent
        Me.Button9.Location = New System.Drawing.Point(353, 585)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(113, 27)
        Me.Button9.TabIndex = 16
        Me.Button9.Text = "LOGOUT"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'lblshift
        '
        Me.lblshift.AutoSize = True
        Me.lblshift.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshift.ForeColor = System.Drawing.Color.White
        Me.lblshift.Location = New System.Drawing.Point(898, 511)
        Me.lblshift.Name = "lblshift"
        Me.lblshift.Size = New System.Drawing.Size(45, 19)
        Me.lblshift.TabIndex = 17
        Me.lblshift.Text = "?shift"
        Me.lblshift.Visible = False
        '
        'btn_unposted
        '
        Me.btn_unposted.BackColor = System.Drawing.Color.SkyBlue
        Me.btn_unposted.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.btn_unposted.FlatAppearance.BorderSize = 2
        Me.btn_unposted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_unposted.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_unposted.ForeColor = System.Drawing.Color.Transparent
        Me.btn_unposted.Location = New System.Drawing.Point(18, 150)
        Me.btn_unposted.Name = "btn_unposted"
        Me.btn_unposted.Size = New System.Drawing.Size(203, 47)
        Me.btn_unposted.TabIndex = 18
        Me.btn_unposted.Text = "VIEW UNPOSTED TRX"
        Me.btn_unposted.UseVisualStyleBackColor = False
        '
        'btn_posted
        '
        Me.btn_posted.BackColor = System.Drawing.Color.SkyBlue
        Me.btn_posted.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.btn_posted.FlatAppearance.BorderSize = 2
        Me.btn_posted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_posted.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_posted.ForeColor = System.Drawing.Color.Transparent
        Me.btn_posted.Location = New System.Drawing.Point(237, 150)
        Me.btn_posted.Name = "btn_posted"
        Me.btn_posted.Size = New System.Drawing.Size(203, 47)
        Me.btn_posted.TabIndex = 19
        Me.btn_posted.Text = "VIEW POSTED TRX"
        Me.btn_posted.UseVisualStyleBackColor = False
        '
        'btn_fgts
        '
        Me.btn_fgts.BackColor = System.Drawing.Color.AliceBlue
        Me.btn_fgts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_fgts.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn_fgts.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btn_fgts.Location = New System.Drawing.Point(35, 535)
        Me.btn_fgts.Name = "btn_fgts"
        Me.btn_fgts.Size = New System.Drawing.Size(203, 39)
        Me.btn_fgts.TabIndex = 20
        Me.btn_fgts.Text = "FGTS PRINTING"
        Me.btn_fgts.UseVisualStyleBackColor = False
        Me.btn_fgts.Visible = False
        '
        'btn_viewdt
        '
        Me.btn_viewdt.BackColor = System.Drawing.Color.Red
        Me.btn_viewdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_viewdt.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_viewdt.ForeColor = System.Drawing.Color.Transparent
        Me.btn_viewdt.Location = New System.Drawing.Point(254, 482)
        Me.btn_viewdt.Name = "btn_viewdt"
        Me.btn_viewdt.Size = New System.Drawing.Size(203, 39)
        Me.btn_viewdt.TabIndex = 21
        Me.btn_viewdt.Text = "VIEW DOWNTIME TRX"
        Me.btn_viewdt.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_move_mcnum)
        Me.GroupBox1.Controls.Add(Me.btn_posted)
        Me.GroupBox1.Controls.Add(Me.btn_unposted)
        Me.GroupBox1.Controls.Add(Me.btn_machine)
        Me.GroupBox1.Controls.Add(Me.btn_labor)
        Me.GroupBox1.Controls.Add(Me.btn_setup)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(17, 159)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 214)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "JOB TRANSTACTIONS"
        '
        'btn_move_mcnum
        '
        Me.btn_move_mcnum.BackColor = System.Drawing.Color.AliceBlue
        Me.btn_move_mcnum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_move_mcnum.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold)
        Me.btn_move_mcnum.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btn_move_mcnum.Location = New System.Drawing.Point(237, 88)
        Me.btn_move_mcnum.Name = "btn_move_mcnum"
        Me.btn_move_mcnum.Size = New System.Drawing.Size(203, 47)
        Me.btn_move_mcnum.TabIndex = 12
        Me.btn_move_mcnum.Text = "MOVE"
        Me.btn_move_mcnum.UseVisualStyleBackColor = False
        '
        'lbl_user
        '
        Me.lbl_user.AutoSize = True
        Me.lbl_user.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lbl_user.ForeColor = System.Drawing.Color.White
        Me.lbl_user.Location = New System.Drawing.Point(109, 604)
        Me.lbl_user.Name = "lbl_user"
        Me.lbl_user.Size = New System.Drawing.Size(52, 19)
        Me.lbl_user.TabIndex = 23
        Me.lbl_user.Text = "Label4"
        '
        'btn_nooperation
        '
        Me.btn_nooperation.BackColor = System.Drawing.Color.Red
        Me.btn_nooperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nooperation.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nooperation.ForeColor = System.Drawing.Color.Transparent
        Me.btn_nooperation.Location = New System.Drawing.Point(254, 535)
        Me.btn_nooperation.Name = "btn_nooperation"
        Me.btn_nooperation.Size = New System.Drawing.Size(203, 39)
        Me.btn_nooperation.TabIndex = 24
        Me.btn_nooperation.Text = "No Operation Schedule"
        Me.btn_nooperation.UseVisualStyleBackColor = False
        '
        'lbl_site
        '
        Me.lbl_site.AutoSize = True
        Me.lbl_site.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lbl_site.ForeColor = System.Drawing.Color.White
        Me.lbl_site.Location = New System.Drawing.Point(503, 558)
        Me.lbl_site.Name = "lbl_site"
        Me.lbl_site.Size = New System.Drawing.Size(52, 19)
        Me.lbl_site.TabIndex = 25
        Me.lbl_site.Text = "Label4"
        Me.lbl_site.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_tsqa_move)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(16, 383)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 93)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TSQA"
        '
        'SFMSMENU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(488, 682)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_site)
        Me.Controls.Add(Me.btn_nooperation)
        Me.Controls.Add(Me.lbl_user)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_viewdt)
        Me.Controls.Add(Me.btn_fgts)
        Me.Controls.Add(Me.lblshift)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblempnum)
        Me.Controls.Add(Me.lblempname)
        Me.Controls.Add(Me.btn_downtime)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1430, 250)
        Me.Name = "SFMSMENU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SFMSMENU"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbldate As Label
    Friend WithEvents lbltime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn_setup As Button
    Friend WithEvents btn_labor As Button
    Friend WithEvents btn_machine As Button
    Friend WithEvents btn_downtime As Button
    Friend WithEvents btn_tsqa_move As Button
    Friend WithEvents lblempname As Label
    Friend WithEvents lblempnum As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents lblshift As Label
    Friend WithEvents btn_unposted As Button
    Friend WithEvents btn_posted As Button
    Friend WithEvents btn_fgts As Button
    Friend WithEvents btn_viewdt As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbl_user As Label
    Friend WithEvents btn_nooperation As Button
    Friend WithEvents lbl_site As Label
    Friend WithEvents btn_move_mcnum As Button
    Friend WithEvents GroupBox2 As GroupBox
End Class
