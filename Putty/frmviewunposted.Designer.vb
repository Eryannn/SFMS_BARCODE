<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmviewunposted
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmviewunposted))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_section = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_machine = New System.Windows.Forms.ComboBox()
        Me.txt_position = New System.Windows.Forms.TextBox()
        Me.txt_section = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtempname = New System.Windows.Forms.TextBox()
        Me.txtempnum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnback = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnpost = New System.Windows.Forms.Button()
        Me.btn_selectall = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(14, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 22)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "SFMS BARCODE"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1318, 64)
        Me.Panel1.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(14, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "UNPOSTED JOB TRANSACTIONS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmb_section)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmb_machine)
        Me.Panel2.Controls.Add(Me.txt_position)
        Me.Panel2.Controls.Add(Me.txt_section)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.DateTimePicker2)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Controls.Add(Me.txtempname)
        Me.Panel2.Controls.Add(Me.txtempnum)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(-2, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1318, 189)
        Me.Panel2.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 25)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Section              :"
        '
        'cmb_section
        '
        Me.cmb_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_section.FormattingEnabled = True
        Me.cmb_section.Items.AddRange(New Object() {"OFFSET", "WEB", "DIGITAL PRESS", "DIE CUTTING", "LAMINATION", "GLUING", "FOLDING", "STITCHING", "PERFECT BINDING", "ERECTING", "MANUAL FINISHING", "BINDERY FINISHING", "STRIPPING", "MANUAL STRIPPING", "MACHINE STRIPPING", "SHEETING/SLITTING", "CUTTING", "3 KNIVES", "INSPECTION MACHINE", "QA"})
        Me.cmb_section.Location = New System.Drawing.Point(240, 98)
        Me.cmb_section.Name = "cmb_section"
        Me.cmb_section.Size = New System.Drawing.Size(364, 33)
        Me.cmb_section.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(627, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(171, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Machine         :"
        '
        'cmb_machine
        '
        Me.cmb_machine.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_machine.FormattingEnabled = True
        Me.cmb_machine.Location = New System.Drawing.Point(804, 99)
        Me.cmb_machine.Name = "cmb_machine"
        Me.cmb_machine.Size = New System.Drawing.Size(364, 33)
        Me.cmb_machine.TabIndex = 10
        '
        'txt_position
        '
        Me.txt_position.Location = New System.Drawing.Point(1027, 26)
        Me.txt_position.Name = "txt_position"
        Me.txt_position.ReadOnly = True
        Me.txt_position.Size = New System.Drawing.Size(154, 20)
        Me.txt_position.TabIndex = 9
        Me.txt_position.Visible = False
        '
        'txt_section
        '
        Me.txt_section.Location = New System.Drawing.Point(843, 25)
        Me.txt_section.Name = "txt_section"
        Me.txt_section.ReadOnly = True
        Me.txt_section.Size = New System.Drawing.Size(154, 20)
        Me.txt_section.TabIndex = 8
        Me.txt_section.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Yellow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(240, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 39)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "FILTER"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(413, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "-"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(442, 64)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(162, 31)
        Me.DateTimePicker2.TabIndex = 5
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(239, 64)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(162, 31)
        Me.DateTimePicker1.TabIndex = 4
        '
        'txtempname
        '
        Me.txtempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempname.Location = New System.Drawing.Point(388, 22)
        Me.txtempname.Name = "txtempname"
        Me.txtempname.ReadOnly = True
        Me.txtempname.Size = New System.Drawing.Size(302, 31)
        Me.txtempname.TabIndex = 3
        '
        'txtempnum
        '
        Me.txtempnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempnum.Location = New System.Drawing.Point(240, 22)
        Me.txtempnum.Name = "txtempnum"
        Me.txtempnum.ReadOnly = True
        Me.txtempnum.Size = New System.Drawing.Size(142, 31)
        Me.txtempnum.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Date                  :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Employee           :"
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.PaleGreen
        Me.btnrefresh.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(1135, 268)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(167, 52)
        Me.btnrefresh.TabIndex = 8
        Me.btnrefresh.Text = "REFRESH"
        Me.btnrefresh.UseVisualStyleBackColor = False
        Me.btnrefresh.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 326)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1286, 295)
        Me.DataGridView1.TabIndex = 21
        '
        'btnback
        '
        Me.btnback.BackColor = System.Drawing.Color.Tomato
        Me.btnback.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnback.FlatAppearance.BorderSize = 2
        Me.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnback.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnback.ForeColor = System.Drawing.Color.White
        Me.btnback.Location = New System.Drawing.Point(1177, 634)
        Me.btnback.Name = "btnback"
        Me.btnback.Size = New System.Drawing.Size(125, 42)
        Me.btnback.TabIndex = 22
        Me.btnback.Text = "BACK"
        Me.btnback.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.Yellow
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.Location = New System.Drawing.Point(16, 634)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(125, 42)
        Me.btnupdate.TabIndex = 23
        Me.btnupdate.Text = "EDIT"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'btnpost
        '
        Me.btnpost.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnpost.Enabled = False
        Me.btnpost.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btnpost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpost.Location = New System.Drawing.Point(589, 634)
        Me.btnpost.Name = "btnpost"
        Me.btnpost.Size = New System.Drawing.Size(125, 42)
        Me.btnpost.TabIndex = 24
        Me.btnpost.Text = "POST"
        Me.btnpost.UseVisualStyleBackColor = False
        '
        'btn_selectall
        '
        Me.btn_selectall.BackColor = System.Drawing.Color.PaleGreen
        Me.btn_selectall.FlatAppearance.BorderColor = System.Drawing.Color.Lime
        Me.btn_selectall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_selectall.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectall.Location = New System.Drawing.Point(16, 268)
        Me.btn_selectall.Name = "btn_selectall"
        Me.btn_selectall.Size = New System.Drawing.Size(167, 52)
        Me.btn_selectall.TabIndex = 25
        Me.btn_selectall.Text = "Select All"
        Me.btn_selectall.UseVisualStyleBackColor = False
        '
        'frmviewunposted
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1314, 683)
        Me.Controls.Add(Me.btn_selectall)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btnpost)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.btnback)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmviewunposted"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmviewunposted"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtempname As TextBox
    Friend WithEvents txtempnum As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnback As Button
    Friend WithEvents btnupdate As Button
    Friend WithEvents btnpost As Button
    Friend WithEvents btnrefresh As Button
    Friend WithEvents txt_section As TextBox
    Friend WithEvents txt_position As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmb_machine As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmb_section As ComboBox
    Friend WithEvents btn_selectall As Button
End Class
