Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization
Public Class frmviewunposted
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text
    Dim validateinsert As Boolean = False
    'ERIAN 28AUG2024 CHANGED from txt_section to cmb_section due to supervisor have multiple sections
    'ERIAN 2SEPT2024 change the viewing of table
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnback.Click

        Try
            con.Open()
            'ERIAN 03SEPT2024 UPDATE THE QUERY BASED ON USER'S SECTION AND MACHINE
            Dim cmd As SqlCommand = New SqlCommand("
            UPDATE 

			            jobtran
            SET 
			            jobtran.[Select] = 0
            FROM 
	            Pallet_Tagging.dbo.sfms_jobtran jobtran
            INNER JOIN 
	            [PI-SP_App].dbo.job job ON 
		            jobtran.job = job.job AND 
		            jobtran.Suffix = job.suffix
            LEFT JOIN 
	            Employee emp ON 
	            jobtran.createdby = emp.Emp_num
            WHERE 
		            emp.section = @section AND
                    jobtran.trans_date BETWEEN @startdate AND @enddate AND
                    jobtran.UF_Jobtran_Machine = @machine AND
                    Status='U'", con)
            cmd.Parameters.AddWithValue("@section", cmb_section.Text)
            cmd.Parameters.Add("@startdate", SqlDbType.DateTime).Value = dtp_start.Value.Date
            cmd.Parameters.Add("@enddate", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
            cmd.Parameters.AddWithValue("@machine", cmb_machine.Text)

            cmd.ExecuteNonQuery()
            SFMSMENU.Show()
            frmupdatesetup.Close()
            frmupdatemachine.Close()
            frmupdatelabor.Close()
            frmupdatemove.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Function enablecheckbox()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If user_position = "Operator" Then
                row.ReadOnly = False
                row.Cells("Select").ReadOnly = True
            Else
                row.ReadOnly = True
                row.Cells("Select").ReadOnly = False
            End If

        Next
        Return 0
    End Function

    Private Sub load_table_for_operator()

        Try
            con.Open()
            Dim cmd_select_sfms_operator As New SqlCommand("Select_sfms_jobtran_operator", con)
            cmd_select_sfms_operator.CommandType = CommandType.StoredProcedure
            cmd_select_sfms_operator.Parameters.AddWithValue("@empnum", txtempnum.Text)
            cmd_select_sfms_operator.Parameters.Add("@startdate", SqlDbType.DateTime).Value = dtp_start.Value.Date
            cmd_select_sfms_operator.Parameters.Add("@enddate", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)

            Dim sda_operator As New SqlDataAdapter(cmd_select_sfms_operator)
            Dim dt_operator As New DataTable
            sda_operator.Fill(dt_operator)
            DataGridView1.DataSource = dt_operator
            AutofitColumns(DataGridView1)
            enablecheckbox()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        'Dim viewunposted_operator As SqlCommand = New SqlCommand("SELECT 
        '         jobtran.[SELECT],
        '         jobtran.job, 
        '         jobtran.Suffix, 
        '         jobtran.oper_num,
        '         jobtran.trans_date,
        '         CASE 
        '             WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
        '             WHEN jobtran.trans_type = 'S' THEN 'Setup'
        '             WHEN jobtran.trans_type = 'M' THEN 'Move'
        '             ELSE 'Lbr Run'
        '         END AS [TRX TYPE],
        '         jobtran.wcdesc,
        '         jobtran.UF_Jobtran_Machine,
        '         job.description,
        '      CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
        '      CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
        '      CAST(jobtran.a_hrs AS DECIMAL(18, 2)) AS TotalHrs,
        '      CAST(jobtran.qty_complete AS INT) AS QTYCOMPLETED,
        '      CAST(jobtran.qty_scrapped AS INT) AS QTYSCRAPPED,
        '         jobtran.createdby,
        '         UF_Jobtran_DocNum
        '     FROM 
        '        Pallet_Tagging.dbo.sfms_jobtran jobtran
        '     INNER JOIN 
        '      [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        '  LEFT JOIN
        'Employee emp on jobtran.emp_num = emp.Emp_num
        '     WHERE 
        '         jobtran.createdby = @empnum AND
        '         jobtran.trans_date BETWEEN @date1 AND @date2 AND
        '         Status='U'
        '     ORDER BY jobtran.trans_date DESC", con)


        'viewunposted_operator.Parameters.AddWithValue("@machine", cmb_machine.Text)
    End Sub

    Private Sub load_table_for_supervisor()
        Try
            con.Open()
            Dim cmd_view_unposted_supervisor As New SqlCommand("Select_sfms_jobtran_supervisor", con)
            cmd_view_unposted_supervisor.CommandType = CommandType.StoredProcedure
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@sectionS", cmb_section.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@sectionE", cmb_section.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@machineS", cmb_machine.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@machineE", cmb_machine.Text)
            cmd_view_unposted_supervisor.Parameters.Add("@startdate", SqlDbType.DateTime).Value = dtp_start.Value.Date
            cmd_view_unposted_supervisor.Parameters.Add("@enddate", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)

            Dim sda_supervisor As New SqlDataAdapter(cmd_view_unposted_supervisor)
            Dim dt_supervisor As New DataTable
            sda_supervisor.Fill(dt_supervisor)
            DataGridView1.DataSource = dt_supervisor

            'Dim btn As New DataGridViewButtonColumn
            'DataGridView1.Columns.Add(btn)
            'btn.HeaderText = ""
            'btn.Text = "Delete"
            'btn.Name = "btn_delete"
            'btn.UseColumnTextForButtonValue = True
            'DataGridView1.Columns.Insert(1, btn)



            AutofitColumns(DataGridView1)
            enablecheckbox()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try



        '     Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
        '         jobtran.[SELECT],
        '         jobtran.job, 
        '         jobtran.Suffix, 
        '         jobtran.oper_num,
        '         jobtran.trans_date,
        '         CASE 
        '             WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
        '             WHEN jobtran.trans_type = 'S' THEN 'Setup'
        '             WHEN jobtran.trans_type = 'M' THEN 'Move'
        '             ELSE 'Lbr Run'
        '         END AS [TRX TYPE],
        '         jobtran.wcdesc,
        '         jobtran.UF_Jobtran_Machine,
        '         job.description,
        '      CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
        '      CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
        '      CAST(jobtran.a_hrs AS DECIMAL(18, 2)) AS TotalHrs,
        '      CAST(jobtran.qty_complete AS INT) AS QTYCOMPLETED,
        '      CAST(jobtran.qty_scrapped AS INT) AS QTYSCRAPPED,
        'jobtran.Createdby,
        '         emp.Name,
        'emp.Section,
        '         UF_Jobtran_DocNum

        '     FROM 
        '        Pallet_Tagging.dbo.sfms_jobtran jobtran
        '     INNER JOIN 
        '      [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        '  LEFT JOIN
        'Employee emp on jobtran.createdby = emp.Emp_num
        '     WHERE 
        '         emp.section = @section AND
        '         jobtran.trans_date BETWEEN @date1 AND @date2 AND
        '         jobtran.UF_Jobtran_Machine = @machine AND
        '         jobtran.Status='U'
        '     ORDER BY jobtran.trans_date DESC", con)
        'modify emp.dept into emp.section

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If user_position = "Operator" Then
            load_table_for_operator()
        Else
            load_table_for_supervisor()
        End If



    End Sub
    Private Sub AutofitColumns(dataGridView As DataGridView)
        ' Auto-resize columns to fit their content
        For Each column As DataGridViewColumn In dataGridView.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        ' Perform the actual auto-resizing based on content
        dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub frmviewunposted_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtempnum.Text = user_id

        If user_position = "Operator" Then
            cmb_section.Visible = False
            cmb_machine.Visible = False
            Label6.Visible = False
            Label5.Visible = False
            btnpost.Visible = false
        Else
            cmb_section.Visible = True
            cmb_machine.Visible = True
            Label6.Visible = True
            Label5.Visible = True
            btnpost.Visible = True
        End If

        'Dim getuserdetails As String = "Select Site, Emp_num, Name, position, dept, section from Employee where Emp_num = @empnum"
        'Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        'cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        'Try
        '    con.Open()
        '    Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
        '    If readuserdetails.HasRows Then
        '        While readuserdetails.Read
        '            txtempname.Text = readuserdetails("Name").ToString
        '            txt_section.Text = readuserdetails("section").ToString
        '            txt_position.Text = readuserdetails("position").ToString
        '            cmb_section.Text = readuserdetails("section").ToString
        '            If readuserdetails("Position").ToString = "Operator" Then
        '                btnpost.Enabled = False
        '            Else
        '                btnpost.Enabled = True
        '            End If
        '        End While
        '        readuserdetails.Close()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        Dim job As String = DataGridView1.SelectedCells(1).Value?.ToString()
        Dim suffix As String = DataGridView1.SelectedCells(2).Value?.ToString()
        Dim opernum As String = DataGridView1.SelectedCells(3).Value.ToString()

        Dim type As String = DataGridView1.SelectedCells(5).Value?.ToString()
        Dim wc As String = DataGridView1.SelectedCells(7).Value?.ToString()
        Dim transdate As String = DataGridView1.SelectedCells(4).Value?.ToString()
        Dim ahrs As String = DataGridView1.SelectedCells(12).Value?.ToString
        Dim empnum As String = DataGridView1.SelectedCells(14).Value?.ToString()



        'Dim job As String = DataGridView1.SelectedCells(0).Value?.ToString()
        'Dim suffix As String = DataGridView1.SelectedCells(1).Value?.ToString()
        'Dim opernum As String = DataGridView1.SelectedCells(2).Value.ToString()

        'Dim type As String = DataGridView1.SelectedCells(4).Value?.ToString()
        'Dim wc As String = DataGridView1.SelectedCells(5).Value?.ToString()
        'Dim transdate As String = DataGridView1.SelectedCells(3).Value?.ToString()
        'Dim ahrs As String = DataGridView1.SelectedCells(10).Value?.ToString
        ' Handle date conversion, assuming the date is in a valid format
        'Dim startDateTime As DateTime
        'Dim endDateTime As DateTime

        If DataGridView1.SelectedCells(5).Value.ToString = "Setup" Then
            If DataGridView1.SelectedCells(10).Value.ToString = "" Then
                If txt_position.Text = "Operator" Then
                    frmsetupend.txtjob.Text = job
                    frmsetupend.txtsuffix.Text = suffix

                    frmsetupend.lbl_updatedby.Text = txtempnum.Text ' add this line

                    frmsetupend.Show()
                    frmsetupend.lblempnum.Text = empnum
                    frmsetupend.lblempname.Text = txtempname.Text
                    frmsetupend.txtopernum.Text = opernum
                    Me.Close()
                Else
                    Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                    frmsetupend.txtjob.Text = job
                    frmsetupend.txtsuffix.Text = suffix

                    frmsetupend.lbl_updatedby.Text = txtempnum.Text ' add this line

                    frmsetupend.Show()
                    frmsetupend.lblempnum.Text = empnum
                    frmsetupend.lblempname.Text = empname
                    frmsetupend.txtopernum.Text = opernum
                    Me.Close()
                End If
            Else
                If txt_position.Text = "Operator" Then
                    frmupdatesetup.txtjob.Text = job
                    frmupdatesetup.txtsuffix.Text = suffix
                    frmupdatesetup.Show()
                    frmupdatesetup.lblempnum.Text = txtempnum.Text
                    frmupdatesetup.lbl_updatedby.Text = txtempnum.Text 'add this line
                    frmupdatesetup.lblempname.Text = txtempname.Text
                    frmupdatesetup.dtptransdate.Value = transdate
                    frmupdatesetup.txttranstype.Text = "S"
                    frmupdatesetup.txtopernum.Text = opernum
                    '   Me.Hide()
                Else
                    Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                    frmupdatesetup.txtjob.Text = job
                    frmupdatesetup.txtsuffix.Text = suffix
                    frmupdatesetup.Show()
                    frmupdatesetup.lblempnum.Text = empnum
                    frmupdatesetup.lbl_updatedby.Text = txtempnum.Text 'add this line
                    frmupdatesetup.lblempname.Text = empname
                    frmupdatesetup.dtptransdate.Value = transdate
                    frmupdatesetup.txttranstype.Text = "S"
                    frmupdatesetup.txtopernum.Text = opernum
                    '   Me.Hide()
                End If

            End If
        ElseIf DataGridView1.SelectedCells(5).Value.ToString = "Mch Run" Then
            If DataGridView1.SelectedCells(10).Value.ToString = "" Then
                If txt_position.Text = "Operator" Then
                    frmmachineend.txtjob.Text = job
                    frmmachineend.txtsuffix.Text = suffix
                    frmmachineend.Show()
                    frmmachineend.lblempnum.Text = txtempnum.Text
                    frmmachineend.lbl_updatedby.Text = txtempnum.Text 'add this line
                    frmmachineend.lblempname.Text = txtempname.Text
                    frmmachineend.txtopernum.Text = opernum
                    Me.Close()
                Else
                    Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                    frmmachineend.txtjob.Text = job
                    frmmachineend.txtsuffix.Text = suffix
                    frmmachineend.Show()
                    frmmachineend.lblempnum.Text = empnum
                    frmmachineend.lbl_updatedby.Text = txtempnum.Text 'add this line
                    frmmachineend.lblempname.Text = empname
                    frmmachineend.txtopernum.Text = opernum
                    Me.Close()
                End If
            Else
                If txt_position.Text = "Operator" Then
                    frmupdatemachine.txtjob.Text = job
                    frmupdatemachine.txtsuffix.Text = suffix
                    frmupdatemachine.Show()
                    frmupdatemachine.lblempnum.Text = txtempnum.Text
                    frmupdatemachine.lbl_updatedby.Text = txtempnum.Text 'add this line
                    frmupdatemachine.lblempname.Text = txtempname.Text
                    frmupdatemachine.dtptransdate.Value = transdate
                    frmupdatemachine.txttranstype.Text = "C"
                    frmupdatemachine.txtopernum.Text = opernum
                Else
                    Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                    frmupdatemachine.txtjob.Text = job
                    frmupdatemachine.txtsuffix.Text = suffix
                    frmupdatemachine.Show()
                    frmupdatemachine.lblempnum.Text = empnum
                    frmupdatemachine.lbl_updatedby.Text = txtempnum.Text 'add this line
                    frmupdatemachine.lblempname.Text = empname
                    frmupdatemachine.dtptransdate.Value = transdate
                    frmupdatemachine.txttranstype.Text = "C"
                    frmupdatemachine.txtopernum.Text = opernum
                    '  Me.Hide()
                End If
            End If


        ElseIf DataGridView1.SelectedCells(5).Value.ToString = "Lbr Run" Then

            If DataGridView1.SelectedCells(10).Value.ToString = "" Then
                If txt_position.Text = "Operator" Then
                    frmlaborend.txtjob.Text = job
                    frmlaborend.txtsuffix.Text = suffix


                    frmlaborend.Show()
                    frmlaborend.lblempnum.Text = txtempnum.Text ' add this line
                    frmlaborend.txtopernum.Text = opernum
                    frmlaborend.lbl_updatedby.Text = txtempnum.Text
                    frmlaborend.lblempname.Text = txtempname.Text
                    Me.Close()
                Else
                    Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                    frmlaborend.txtjob.Text = job
                    frmlaborend.txtsuffix.Text = suffix


                    frmlaborend.Show()
                    frmlaborend.lblempnum.Text = empnum ' add this line
                    frmlaborend.txtopernum.Text = opernum
                    frmlaborend.lbl_updatedby.Text = txtempnum.Text
                    frmlaborend.lblempname.Text = empname
                    Me.Close()
                End If

            Else
                If txt_position.Text = "Operator" Then
                    frmupdatelabor.txtjob.Text = job
                    frmupdatelabor.txtsuffix.Text = suffix
                    frmupdatelabor.Show()
                    frmupdatelabor.lblempnum.Text = txtempnum.Text ' add this line
                    frmupdatelabor.lbl_updatedby.Text = txtempnum.Text
                    frmupdatelabor.lblempname.Text = txtempname.Text
                    frmupdatelabor.dtptransdate.Value = transdate
                    frmupdatelabor.txttranstype.Text = "R"
                    frmupdatelabor.txtopernum.Text = opernum
                    ' Me.Hide()
                Else
                    Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                    frmupdatelabor.txtjob.Text = job
                    frmupdatelabor.txtsuffix.Text = suffix
                    frmupdatelabor.Show()
                    frmupdatelabor.lblempnum.Text = empnum ' add this line
                    frmupdatelabor.lbl_updatedby.Text = txtempnum.Text
                    frmupdatelabor.lblempname.Text = empname
                    frmupdatelabor.dtptransdate.Value = transdate
                    frmupdatelabor.txttranstype.Text = "R"
                    frmupdatelabor.txtopernum.Text = opernum
                    ' Me.Hide()
                End If
            End If
        Else
            If txt_position.Text = "Operator" Then
                frmupdatemove.txtjob.Text = job
                frmupdatemove.txtsuffix.Text = suffix
                frmupdatemove.Show()
                frmupdatemove.lblempnum.Text = txtempnum.Text
                frmupdatemove.lbl_updatedby.Text = txtempnum.Text
                frmupdatemove.lblempname.Text = txtempname.Text
                frmupdatemove.dtptransdate.Value = transdate
                frmupdatemove.txttranstype.Text = "M"
                frmupdatemove.txtopernum.Text = opernum
                'Me.Hide()
            Else
                Dim empname As String = DataGridView1.SelectedCells(15).Value?.ToString()
                frmupdatemove.txtjob.Text = job
                frmupdatemove.txtsuffix.Text = suffix
                frmupdatemove.Show()
                frmupdatemove.lblempnum.Text = empnum
                frmupdatemove.lbl_updatedby.Text = txtempnum.Text
                frmupdatemove.lblempname.Text = empname
                frmupdatemove.dtptransdate.Value = transdate
                frmupdatemove.txttranstype.Text = "M"
                frmupdatemove.txtopernum.Text = opernum
                'Me.Hide()
            End If

        End If




    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click

        Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
            jobtran.[SELECT],
            jobtran.job, 
            jobtran.Suffix, 
            jobtran.oper_num,
            jobtran.trans_date,
            CASE 
                WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                WHEN jobtran.trans_type = 'S' THEN 'Setup'
                WHEN jobtran.trans_type = 'M' THEN 'Move'
                ELSE 'Lbr Run'
            END AS [TRX TYPE],
            jobtran.wcdesc,
            jobtran.UF_Jobtran_Machine,
            job.description,
	        CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
	        CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
	        CAST(jobtran.a_hrs AS DECIMAL(18, 2)) AS TotalHrs,
	        CAST(jobtran.qty_complete AS INT) AS QTYCOMPLETED,
	        CAST(jobtran.qty_scrapped AS INT) AS QTYSCRAPPED,
			jobtran.Createdby,
            emp.Name,
			emp.Section
        
        FROM 
           Pallet_Tagging.dbo.sfms_jobtran jobtran
        INNER JOIN 
	        [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
	    LEFT JOIN
			Employee emp on jobtran.createdby = emp.Emp_num
        WHERE 
            emp.section = @section AND
            jobtran.trans_date BETWEEN @date1 AND @date2 AND
            jobtran.UF_Jobtran_Machine = @machine AND
            jobtran.Status='U'
        ORDER BY jobtran.trans_date DESC", con)
        'modify emp.dept into emp.section

        Dim viewunposted_operator As SqlCommand = New SqlCommand("SELECT 
            jobtran.[SELECT],
            jobtran.job, 
            jobtran.Suffix, 
            jobtran.oper_num,
            jobtran.trans_date,
            CASE 
                WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                WHEN jobtran.trans_type = 'S' THEN 'Setup'
                WHEN jobtran.trans_type = 'M' THEN 'Move'
                ELSE 'Lbr Run'
            END AS [TRX TYPE],
            jobtran.wcdesc,
            jobtran.UF_Jobtran_Machine,
            job.description,
	        CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
	        CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
	        CAST(jobtran.a_hrs AS DECIMAL(18, 2)) AS TotalHrs,
	        CAST(jobtran.qty_complete AS INT) AS QTYCOMPLETED,
	        CAST(jobtran.qty_scrapped AS INT) AS QTYSCRAPPED,
            jobtran.createdby
        
        FROM 
           Pallet_Tagging.dbo.sfms_jobtran jobtran
        INNER JOIN 
	        [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
	    LEFT JOIN
			Employee emp on jobtran.emp_num = emp.Emp_num
        WHERE 
            jobtran.createdby = @empnum AND
            jobtran.trans_date BETWEEN @date1 AND @date2 AND
            Status='U'
        ORDER BY jobtran.trans_date DESC", con)

        Try
            con.Open()

            If txt_position.Text = "Operator" Then
                cmb_section.Visible = False
                cmb_machine.Visible = False
                Label5.Text = ""
                Label6.Text = ""
                viewunposted_operator.Parameters.AddWithValue("@empnum", txtempnum.Text)
                viewunposted_operator.Parameters.Add("@date1", SqlDbType.DateTime).Value = dtp_start.Value.Date
                viewunposted_operator.Parameters.Add("@date2", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
                'viewunposted_operator.Parameters.AddWithValue("@machine", cmb_machine.Text)
                Dim a As New SqlDataAdapter(viewunposted_operator)
                Dim dt As New DataTable
                a.Fill(dt)

                DataGridView1.DataSource = dt
                AutofitColumns(DataGridView1)
                enablecheckbox()
            Else
                'viewunposted.Parameters.AddWithValue("@dept", txt_dept.Text) 'add this line for userdept
                viewunposted.Parameters.AddWithValue("@section", cmb_section.Text) 'ERIAN 28AUG2024 CHANGED from txt_section to cmb_section due to supervisor have multiple sections
                viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = dtp_start.Value.Date
                viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
                viewunposted.Parameters.AddWithValue("@machine", cmb_machine.Text)
                Dim a As New SqlDataAdapter(viewunposted)
                Dim dt As New DataTable
                a.Fill(dt)

                DataGridView1.DataSource = dt
                AutofitColumns(DataGridView1)
                enablecheckbox()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        'Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
        '    jobtran.job, 
        '    jobtran.Suffix, 
        '    jobtran.oper_num,
        '    jobtran.trans_date,
        '    CASE 
        '        WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
        '        WHEN jobtran.trans_type = 'S' THEN 'Setup'
        '        WHEN jobtran.trans_type = 'M' THEN 'Move'
        '        ELSE 'Lbr Run'
        '    END AS [TRX TYPE],
        '    jobtran.wcdesc,
        '    jobtran.UF_Jobtran_Machine,
        '    job.description,
        ' CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
        ' CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
        ' jobtran.a_hrs,
        ' jobtran.qty_complete,
        ' jobtran.qty_scrapped
        'FROM 
        '   Pallet_Tagging.dbo.sfms_jobtran jobtran
        'INNER JOIN 
        ' [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        'WHERE 
        '    jobtran.emp_num = @empnum AND 
        '    jobtran.trans_date BETWEEN @date1 AND @date2 AND
        '    Status='U'", con)

        'viewunposted.Parameters.AddWithValue("@empnum", txtempnum.Text)
        'viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
        'viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)

        'Dim a As New SqlDataAdapter(viewunposted)
        'Dim dt As New DataTable
        'a.Fill(dt)
        'DataGridView1.DataSource = dt


        'AutofitColumns(DataGridView1)jobtran.[select],

        'Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
        '    jobtran.[Select],
        '    jobtran.job, 
        '    jobtran.Suffix, 
        '    jobtran.oper_num,
        '    jobtran.trans_date,
        '    CASE 
        '        WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
        '        WHEN jobtran.trans_type = 'S' THEN 'Setup'
        '        WHEN jobtran.trans_type = 'M' THEN 'Move'
        '        ELSE 'Lbr Run'
        '    END AS [TRX TYPE],
        '    jobtran.wcdesc,
        '    jobtran.UF_Jobtran_Machine,
        '    job.description,
        ' CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
        ' CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
        ' jobtran.a_hrs,
        ' jobtran.qty_complete,
        ' jobtran.qty_scrapped
        'FROM 
        '   Pallet_Tagging.dbo.sfms_jobtran jobtran
        'INNER JOIN 
        ' [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        'WHERE 
        '    jobtran.emp_num = @empnum AND 
        '    jobtran.trans_date BETWEEN @date1 AND @date2 AND
        '    Status='U'", con)

        'viewunposted.Parameters.AddWithValue("@empnum", txtempnum.Text)
        'viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
        'viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
        'Dim a As New SqlDataAdapter(viewunposted)
        'Dim dt As New DataTable
        'a.Fill(dt)

        'DataGridView1.DataSource = dt
        'AutofitColumns(DataGridView1)
        'enablecheckbox()


        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    row.ReadOnly = True
        '    row.Cells("Select").ReadOnly = False
        'Next

    End Sub

    Private Sub btnpost_Click(sender As Object, e As EventArgs) Handles btnpost.Click
        ' check_update()
        'Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where [Select] = 1", con)
        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran a
        INNER JOIN Employee b on a.CreatedBy = b.Emp_num
        where [Select] = 1 and b.Section = @section AND UF_Jobtran_Machine = @machine AND 
        trans_date BETWEEN @startdate AND @enddate AND status='U'", con)

        cmdreadsfms.Parameters.AddWithValue("@section", cmb_section.Text)
        cmdreadsfms.Parameters.AddWithValue("@machine", cmb_machine.Text)
        cmdreadsfms.Parameters.Add("@startdate", SqlDbType.DateTime).Value = dtp_start.Value.Date
        cmdreadsfms.Parameters.Add("@enddate", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
        Dim transdate As DateTime = DataGridView1.SelectedCells(4).Value.ToString
        Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
        'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        cmdreadsfms.Parameters.AddWithValue("@transdate", transdatestring)

        Dim totalhrs As String = DataGridView1.SelectedCells(11).Value.ToString

        Dim transtype As String = DataGridView1.SelectedCells(5).Value.ToString

        If transtype = "Mch Run" Then
            transtype = "C"
            cmdreadsfms.Parameters.AddWithValue("@transtype", transtype)
        ElseIf transtype = "Lbr Run" Then
            transtype = "R"
            cmdreadsfms.Parameters.AddWithValue("@transtype", transtype)
        ElseIf transtype = "Setup" Then
            transtype = "S"
            cmdreadsfms.Parameters.AddWithValue("@transtype", transtype)
        Else
            transtype = "M"
            cmdreadsfms.Parameters.AddWithValue("@transtype", transtype)
        End If

        Dim isposted As Boolean = False

        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else

            Try
                con1.Open()
                con.Open()
                If app_prev_version <> app_version Then
                    MsgBox("Please Update the SFMS Application")
                Else


                    'REFRESH TABLE
                    Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
                 jobtran.[SELECT],
                 jobtran.job, 
                 jobtran.Suffix, 
                 jobtran.oper_num,
                 jobtran.trans_date,
                 CASE 
                     WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                     WHEN jobtran.trans_type = 'S' THEN 'Setup'
                     WHEN jobtran.trans_type = 'M' THEN 'Move'
                     ELSE 'Lbr Run'
                 END AS [TRX TYPE],
                 jobtran.wcdesc,
                 jobtran.UF_Jobtran_Machine,
                 job.description,
              CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
              CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
              CAST(jobtran.a_hrs AS DECIMAL(18, 2)) AS TotalHrs,
              CAST(jobtran.qty_complete AS INT) AS QTYCOMPLETED,
              CAST(jobtran.qty_scrapped AS INT) AS QTYSCRAPPED,
        jobtran.Createdby,
                 emp.Name,
        emp.Section

             FROM 
                Pallet_Tagging.dbo.sfms_jobtran jobtran
             INNER JOIN 
              [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
          LEFT JOIN
        Employee emp on jobtran.createdby = emp.Emp_num
             WHERE 
                 emp.section = @section AND
                 jobtran.trans_date BETWEEN @date1 AND @date2 AND
                 jobtran.UF_Jobtran_Machine = @machine AND
                 Status='U'
             ORDER BY jobtran.trans_date DESC", con)

                    viewunposted.Parameters.AddWithValue("@section", cmb_section.Text) 'ERIAN 2SEPT2024 change the viewing of table
                    viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = dtp_start.Value.Date
                    viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
                    viewunposted.Parameters.AddWithValue("@machine", cmb_machine.Text)


                    'Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE [Select] = 1 AND emp_num = @empnum AND Status = 'U'", con)
                    'cmdupdatesfms.Parameters.AddWithValue("@job", DataGridView1.SelectedCells(1).Value.ToString)AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type = @transtype
                    'cmdupdatesfms.Parameters.AddWithValue("@empnum", txtempnum.Text)

                    Dim cmdinsert As SqlCommand = New SqlCommand("INSERT INTO Jobtran 
                                         (job,
                                         suffix,
                                         trans_type,
                                         trans_date,
                                         qty_complete,
                                         qty_scrapped, 
                                         oper_num,
                                         a_hrs, 
                                         next_oper, 
                                         emp_num, 
                                         start_time,
                                         end_time,
                                         qty_moved,
                                         whse,
                                         loc,
                                         lot,
                                         shift,
                                         reason_code,
                                         wc,
                                         Uf_JobTran_TransactionType,
                                         Uf_JobTran_Machine,
                                         Uf_JobTran_Output,
                                         Uf_JobTran_Rework,
                                         CreatedBy,
                                         CreateDate,
                                         a_$,
                                         pay_rate,
                                         user_code,
                                         close_job,
                                         issue_parent,
                                         complete_op,
                                         pr_rate,
                                         job_rate,
                                         posted,
                                         low_level,
                                         backflush,
                                         trans_class,
                                         awaiting_eop,
                                         fixovhd,
                                         varovhd,
                                         co_product_mix,
                                         NoteExistsFlag,
                                         UpdatedBy,
                                         InWorkflow,
                                         Uf_Jobtran_DocNum)
                             VALUES 
                                        (@job,
                                         @suffix,
                                         @transtype,
                                         @transdate,
                                         @qtycomplete,
                                         @qtyscrapped,
                                         @opernum,
                                         @ahrs,
                                         @nextoper,
                                         @empnum,
                                         @starttime,
                                         @endtime,
                                         @qtymoved,
                                         @whse,
                                         @loc,
                                         @lot,
                                         @shift,
                                         @reasoncode,
                                         @wc,
                                         @uftranstype,
                                         @ufmachine,
                                         @ufoutput,
                                         @ufrework,
                                         @createdby,
                                         @createddate,
                                         '0',
                                         'R',
                                         @user_code,
                                         0,
                                         0,
                                         0,
                                         0,
                                         0,
                                         0,
                                         1,
                                         0,
                                         'J',
                                         0,
                                         0,
                                         0,
                                         0,
                                         0,
                                         @updatedby,
                                         0,
                                         @ufdocnum)", con1)
                    '=============================================================
                    Dim readsfms As SqlDataReader = cmdreadsfms.ExecuteReader
                    ''Dim validateinsert As Boolean = False


                    While readsfms.Read
                        If CDbl(readsfms("a_hrs").ToString) <> 0 AndAlso readsfms("trans_type").ToString <> "M" Then

                            cmdinsert.Parameters.Clear()
                            cmdinsert.Parameters.AddWithValue("@job", readsfms("Job").ToString)
                            cmdinsert.Parameters.AddWithValue("@suffix", readsfms("Suffix").ToString)
                            cmdinsert.Parameters.AddWithValue("@transtype", readsfms("trans_type").ToString)

                            'cmdinsert.Parameters.AddWithValue("@transdate", readsfms("trans_date").ToString)

                            If readsfms.IsDBNull(readsfms.GetOrdinal("trans_date")) Then
                                cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
                            Else
                                Dim transDate1 As DateTime
                                If DateTime.TryParse(readsfms("trans_date").ToString(), transDate1) Then
                                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = transDate1
                                Else
                                    ' Handle invalid date format
                                    ' For example, log an error or set a default date
                                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
                                End If
                            End If


                            cmdinsert.Parameters.AddWithValue("@qtycomplete", readsfms("qty_complete").ToString)
                            cmdinsert.Parameters.AddWithValue("@qtyscrapped", readsfms("qty_scrapped").ToString)
                            cmdinsert.Parameters.AddWithValue("@opernum", readsfms("oper_num").ToString)
                            cmdinsert.Parameters.AddWithValue("@ahrs", readsfms("a_hrs").ToString)
                            'cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("next_oper")) Then
                                cmdinsert.Parameters.AddWithValue("@nextoper", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper"))
                            End If
                            cmdinsert.Parameters.AddWithValue("@empnum", readsfms("emp_num").ToString)
                            cmdinsert.Parameters.AddWithValue("@starttime", readsfms("start_time").ToString)
                            cmdinsert.Parameters.AddWithValue("@endtime", readsfms("end_time").ToString)
                            cmdinsert.Parameters.AddWithValue("@qtymoved", readsfms("qty_moved").ToString)
                            cmdinsert.Parameters.AddWithValue("@whse", readsfms("whse").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("loc")) Then
                                cmdinsert.Parameters.AddWithValue("@loc", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc"))
                            End If
                            ' cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("lot")) Then
                                cmdinsert.Parameters.AddWithValue("@lot", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot"))
                            End If
                            'cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot").ToString)
                            cmdinsert.Parameters.AddWithValue("@shift", readsfms("shift").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("reason_code")) Then
                                cmdinsert.Parameters.AddWithValue("@reasoncode", DBNull.Value)
                            ElseIf readsfms("reason_code").ToString = "" Then
                                cmdinsert.Parameters.AddWithValue("@reasoncode", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code"))
                            End If
                            'cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code").ToString)
                            cmdinsert.Parameters.AddWithValue("@wc", readsfms("wc").ToString)
                            If readsfms("wc").ToString = "P610" Then
                                cmdinsert.Parameters.AddWithValue("@user_code", "QAI")
                            Else
                                cmdinsert.Parameters.AddWithValue("@user_code", DBNull.Value)
                            End If
                            If readsfms.IsDBNull(readsfms.GetOrdinal("UF_Jobtran_TransactionType")) Then
                                cmdinsert.Parameters.AddWithValue("@uftranstype", DBNull.Value)
                            ElseIf readsfms("UF_Jobtran_TransactionType").ToString = "" Then
                                cmdinsert.Parameters.AddWithValue("uftranstype", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@uftranstype", readsfms("Uf_Jobtran_TransactionType").ToString)
                            End If

                            'cmdinsert.Parameters.AddWithValue("@uftranstype", readsfms("Uf_Jobtran_TransactionType").ToString)
                            cmdinsert.Parameters.AddWithValue("@ufmachine", readsfms("Uf_Jobtran_Machine").ToString)
                            cmdinsert.Parameters.AddWithValue("@ufoutput", readsfms("Uf_Jobtran_Output").ToString)
                            cmdinsert.Parameters.AddWithValue("@ufrework", readsfms("Uf_Jobtran_Rework").ToString)
                            'cmdinsert.Parameters.AddWithValue("@createdby", readsfms("CreatedBy").ToString)
                            cmdinsert.Parameters.AddWithValue("@createdby", txtempnum.Text)
                            ' cmdinsert.Parameters.AddWithValue("@createddate", readsfms("CreateDate").ToString)
                            'cmdinsert.Parameters.addw
                            If readsfms.IsDBNull(readsfms.GetOrdinal("CreateDate")) Then
                                cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
                            Else
                                Dim createddate As DateTime
                                If DateTime.TryParse(readsfms("CreateDate").ToString(), createddate) Then
                                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate
                                Else
                                    ' Handle invalid date format
                                    ' For example, log an error or set a default date
                                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
                                End If
                            End If

                            cmdinsert.Parameters.AddWithValue("@updatedby", txtempnum.Text)

                            If readsfms.IsDBNull(readsfms.GetOrdinal("UF_Jobtran_DocNum")) Then
                                cmdinsert.Parameters.AddWithValue("@ufdocnum", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@ufdocnum", readsfms("UF_Jobtran_DocNum").ToString)
                            End If

                            ' cmdinsert.Parameters.AddWithValue("@ufdocnum", readsfms("UF_Jobtran_DocNum").ToString)
                            'cmdinsert.ExecuteNonQuery()

                            'MsgBox("posting")
                            '  MsgBox(txtempnum.Text)
                            If cmdinsert.ExecuteNonQuery > 0 Then
                                job_posted = True
                            End If
                        ElseIf readsfms("trans_type").ToString = "M"
                            cmdinsert.Parameters.Clear()
                            cmdinsert.Parameters.AddWithValue("@job", readsfms("Job").ToString)
                            cmdinsert.Parameters.AddWithValue("@suffix", readsfms("Suffix").ToString)
                            cmdinsert.Parameters.AddWithValue("@transtype", readsfms("trans_type").ToString)

                            'cmdinsert.Parameters.AddWithValue("@transdate", readsfms("trans_date").ToString)

                            If readsfms.IsDBNull(readsfms.GetOrdinal("trans_date")) Then
                                cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
                            Else
                                Dim transDate1 As DateTime
                                If DateTime.TryParse(readsfms("trans_date").ToString(), transDate1) Then
                                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = transDate1
                                Else
                                    ' Handle invalid date format
                                    ' For example, log an error or set a default date
                                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
                                End If
                            End If


                            cmdinsert.Parameters.AddWithValue("@qtycomplete", readsfms("qty_complete").ToString)
                            cmdinsert.Parameters.AddWithValue("@qtyscrapped", readsfms("qty_scrapped").ToString)
                            cmdinsert.Parameters.AddWithValue("@opernum", readsfms("oper_num").ToString)
                            cmdinsert.Parameters.AddWithValue("@ahrs", readsfms("a_hrs").ToString)
                            'cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("next_oper")) Then
                                cmdinsert.Parameters.AddWithValue("@nextoper", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper"))
                            End If
                            cmdinsert.Parameters.AddWithValue("@empnum", readsfms("emp_num").ToString)
                            cmdinsert.Parameters.AddWithValue("@starttime", readsfms("start_time").ToString)
                            cmdinsert.Parameters.AddWithValue("@endtime", readsfms("end_time").ToString)
                            cmdinsert.Parameters.AddWithValue("@qtymoved", readsfms("qty_moved").ToString)
                            cmdinsert.Parameters.AddWithValue("@whse", readsfms("whse").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("loc")) Then
                                cmdinsert.Parameters.AddWithValue("@loc", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc"))
                            End If

                            If readsfms.IsDBNull(readsfms.GetOrdinal("lot")) Then
                                cmdinsert.Parameters.AddWithValue("@lot", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot"))
                            End If

                            cmdinsert.Parameters.AddWithValue("@shift", readsfms("shift").ToString)
                            If readsfms.IsDBNull(readsfms.GetOrdinal("reason_code")) Then
                                cmdinsert.Parameters.AddWithValue("@reasoncode", DBNull.Value)
                            Else
                                cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code"))
                            End If

                            cmdinsert.Parameters.AddWithValue("@wc", readsfms("wc").ToString)
                            cmdinsert.Parameters.AddWithValue("@uftranstype", readsfms("Uf_Jobtran_TransactionType").ToString)
                            cmdinsert.Parameters.AddWithValue("@ufmachine", readsfms("Uf_Jobtran_Machine").ToString)
                            cmdinsert.Parameters.AddWithValue("@ufoutput", readsfms("Uf_Jobtran_Output").ToString)
                            cmdinsert.Parameters.AddWithValue("@ufrework", readsfms("Uf_Jobtran_Rework").ToString)
                            ' cmdinsert.Parameters.AddWithValue("@createdby", readsfms("CreatedBy").ToString)

                            cmdinsert.Parameters.AddWithValue("@createdby", txtempnum.Text)
                            If readsfms("wc").ToString = "P610" Then
                                cmdinsert.Parameters.AddWithValue("@user_code", "QAI")
                            Else
                                cmdinsert.Parameters.AddWithValue("@user_code", DBNull.Value)
                            End If

                            If readsfms.IsDBNull(readsfms.GetOrdinal("CreateDate")) Then
                                cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
                            Else
                                Dim createddate As DateTime
                                If DateTime.TryParse(readsfms("CreateDate").ToString(), createddate) Then
                                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate
                                Else
                                    ' Handle invalid date format
                                    ' For example, log an error or set a default date
                                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
                                End If
                            End If

                            cmdinsert.Parameters.AddWithValue("@updatedby", txtempnum.Text)
                            cmdinsert.Parameters.AddWithValue("@ufdocnum", readsfms("UF_Jobtran_DocNum").ToString)
                            'cmdinsert.ExecuteNonQuery()

                            'MsgBox("Posted Successfully MOVE SETUP")
                            If cmdinsert.ExecuteNonQuery > 0 Then
                                job_posted = True
                            End If
                            'cmdupdatesfms.ExecuteNonQuery()
                            'MsgBox("MOVE POSTING")
                        Else

                            'MsgBox("Invalid")
                        End If

                    End While
                    readsfms.Close()




                    Dim a As New SqlDataAdapter(viewunposted)
                    Dim dt As New DataTable
                    a.Fill(dt)
                    DataGridView1.DataSource = dt
                    AutofitColumns(DataGridView1)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con1.Close()
            End Try

            Try
                con.Open()

                Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
                 jobtran.[SELECT],
                 jobtran.job, 
                 jobtran.Suffix, 
                 jobtran.oper_num,
                 jobtran.trans_date,
                 CASE 
                     WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                     WHEN jobtran.trans_type = 'S' THEN 'Setup'
                     WHEN jobtran.trans_type = 'M' THEN 'Move'
                     ELSE 'Lbr Run'
                 END AS [TRX TYPE],
                 jobtran.wcdesc,
                 jobtran.UF_Jobtran_Machine,
                 job.description,
              CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
              CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
              CAST(jobtran.a_hrs AS DECIMAL(18, 2)) AS TotalHrs,
              CAST(jobtran.qty_complete AS INT) AS QTYCOMPLETED,
              CAST(jobtran.qty_scrapped AS INT) AS QTYSCRAPPED,
        jobtran.Createdby,
                 emp.Name,
        emp.Section

             FROM 
                Pallet_Tagging.dbo.sfms_jobtran jobtran
             INNER JOIN 
              [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
          LEFT JOIN
        Employee emp on jobtran.createdby = emp.Emp_num
             WHERE 
                 emp.section = @section AND
                 jobtran.trans_date BETWEEN @date1 AND @date2 AND
                 jobtran.UF_Jobtran_Machine = @machine AND
                 Status='U'
             ORDER BY jobtran.trans_date DESC", con)

                viewunposted.Parameters.AddWithValue("@section", cmb_section.Text) 'ERIAN 2SEPT2024 change the viewing of table
                viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = dtp_start.Value.Date
                viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
                viewunposted.Parameters.AddWithValue("@machine", cmb_machine.Text)

                Dim cmdupdatesfms As SqlCommand = New SqlCommand("
            UPDATE sfms_jobtran
                     SET Status = 'P',
                        [Select] = 0,
                        PostedBy=@postedby
            from sfms_jobtran a
                INNER JOIN Employee b on a.CreatedBy = b.Emp_num
            WHERE 
				    a.[Select] = 1 AND 
				    b.Section = @section AND 
				    a.UF_Jobtran_Machine = @machine AND 
				    trans_date between @startdate AND @enddate AND
				    a.Status = 'U' AND 
				(
                    (a.trans_type <> 'M' AND a.a_hrs <> 0) OR
                    (a.trans_type = 'M'))", con)
                cmdupdatesfms.Parameters.AddWithValue("@section", cmb_section.Text)
                cmdupdatesfms.Parameters.AddWithValue("@machine", cmb_machine.Text)
                cmdupdatesfms.Parameters.AddWithValue("@postedby", txtempnum.Text)
                cmdupdatesfms.Parameters.Add("@startdate", SqlDbType.DateTime).Value = dtp_start.Value.Date
                cmdupdatesfms.Parameters.Add("@enddate", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)
                If job_posted Then
                    cmdupdatesfms.ExecuteNonQuery()
                    MsgBox("Job Posted")
                    job_posted = False

                Else
                    MsgBox("Invalid")
                End If

                'If cmdupdatesfms.ExecuteNonQuery > 0 Then
                '    MsgBox("Job Posted working")
                'End If
                Dim a As New SqlDataAdapter(viewunposted)
                Dim dt As New DataTable
                a.Fill(dt)
                DataGridView1.DataSource = dt
                AutofitColumns(DataGridView1)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try

        End If

    End Sub

    Private Sub sfms_post()

    End Sub

    Private Sub DataGridView1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        ' Check if the clicked cell is in the "Select" column


        'If e.ColumnIndex = DataGridView1.Columns("Select").Index AndAlso e.RowIndex >= 0 Then
        '    ' This code will make sure the checkbox value is toggled immediately
        '    DataGridView1.EndEdit()
        'End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            con.Open()

            For Each row As DataGridViewRow In DataGridView1.Rows



                Dim ischecked As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                If ischecked Then

                    Dim originalDateTimeString As DateTime = row.Cells("trans_date").Value.ToString()

                    Dim formattedDateTimeString As String = originalDateTimeString.ToString("yyyy-MM-dd HH:mm:ss")

                    Dim cmdchecked As New SqlCommand("UPDATE sfms_jobtran Set [Select] = 1 WHERE Job = @job And Suffix = @suffix And Oper_num = @opernum And CONVERT(VARCHAR, trans_date, 120) LIKE @transdate", con)

                    cmdchecked.Parameters.AddWithValue("@job", row.Cells("Job").Value)
                    cmdchecked.Parameters.AddWithValue("@suffix", row.Cells("Suffix").Value)
                    cmdchecked.Parameters.AddWithValue("@opernum", row.Cells("oper_num").Value)

                    cmdchecked.Parameters.AddWithValue("@transdate", formattedDateTimeString)

                    cmdchecked.ExecuteNonQuery()
                    'MsgBox(row.Cells("trans_date").Value)
                    'MsgBox(formattedDateTimeString)
                Else
                    Dim originalDateTimeString As DateTime = row.Cells("trans_date").Value.ToString()

                    Dim formattedDateTimeString As String = originalDateTimeString.ToString("yyyy-MM-dd HH:mm:ss")
                    Dim cmdunchecked As New SqlCommand("UPDATE sfms_jobtran Set [Select] = 0 WHERE Job = @job And Suffix = @suffix And Oper_num = @opernum And CONVERT(VARCHAR, trans_date, 120) LIKE @transdate", con)
                    'MsgBox(formattedDateTimeString)
                    cmdunchecked.Parameters.AddWithValue("@job", row.Cells("Job").Value)
                    cmdunchecked.Parameters.AddWithValue("@suffix", row.Cells("Suffix").Value)
                    cmdunchecked.Parameters.AddWithValue("@opernum", row.Cells("oper_num").Value)
                    cmdunchecked.Parameters.AddWithValue("@transdate", formattedDateTimeString)

                    cmdunchecked.ExecuteNonQuery()
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub cmb_machine_DropDown(sender As Object, e As EventArgs) Handles cmb_machine.DropDown
        cmb_machine.Items.Clear()
        populaterscmach()
    End Sub

    Private Sub populaterscmach()
        Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        'Dim cmd1 As SqlCommand = New SqlCommand("SELECT RS.RESID,RS.DESCR FROM wc INNER JOIN wcresourcegroup WCR ON WC.wc=WCR.wc INNER JOIN RGRPMBR000 RG ON RG.RGID=WCR.rgid INNER JOIN RESRC000 RS ON RS.RESID=RG.RESID where wc.wc=@wc", con1)
        Dim cmd1 As SqlCommand = New SqlCommand("SELECT DISTINCT RS.RESID,RS.DESCR, RS.Uf_Resrc_Section FROM wc INNER JOIN wcresourcegroup WCR ON WC.wc=WCR.wc INNER JOIN RGRPMBR000 RG ON RG.RGID=WCR.rgid RIGHT JOIN RESRC000 RS ON RS.RESID=RG.RESID WHERE RS.Uf_Resrc_Section = @section", con1)
        cmd1.Parameters.AddWithValue("@section", cmb_section.Text)
        Try
            con1.Open()
            Dim reader As SqlDataReader = cmd1.ExecuteReader
            If reader.HasRows Then
                While reader.Read()
                    cmb_machine.Items.Add(reader("RESID").ToString())
                End While
                reader.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmb_section_DropDown(sender As Object, e As EventArgs) Handles cmb_section.DropDown
        cmb_machine.SelectedIndex = -1
    End Sub

    'Private Sub btn_selectall_Click(sender As Object, e As EventArgs) Handles btn_selectall.Click
    '    Try
    '        con.Open()
    '        Dim cmd_select_all As SqlCommand = New SqlCommand("
    '        UPDATE
    '            Pallet_Tagging.dbo.sfms_jobtran jobtran
    '        SET 
    '            jobtran.[Select] = 1
    '        INNER JOIN 
    '         [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
    '     LEFT JOIN
    '   Employee emp on jobtran.emp_num = emp.Emp_num
    '        WHERE 
    '            emp.section = @section AND
    '            jobtran.trans_date BETWEEN @date1 AND @date2 AND
    '            jobtran.UF_Jobtran_Machine = @machine AND
    '            jobtran.Status='U'
    '        ORDER BY jobtran.trans_date DESC
    '            ", con)

    '        cmd_select_all.Parameters.AddWithValue("@section", cmb_section.Text)
    '        cmd_select_all.Parameters.AddWithValue("@machine", cmb_machine.Text)
    '        cmd_select_all.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
    '        cmd_select_all.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub btn_selectall_Click(sender As Object, e As EventArgs) Handles btn_selectall.Click
        'Try
        '    con.Open()
        '    Dim cmd_select_all As SqlCommand = New SqlCommand("
        'UPDATE Pallet_Tagging.dbo.sfms_jobtran
        'SET [Select] = 1
        'WHERE EXISTS (
        '    SELECT 1 
        '    FROM [PI-SP_App].dbo.job job
        '    LEFT JOIN Employee emp ON jobtran.emp_num = emp.Emp_num
        '    WHERE jobtran.job = job.job
        '    AND jobtran.Suffix = job.suffix
        '    AND emp.section = @section
        '    AND jobtran.trans_date BETWEEN @date1 AND @date2
        '    AND jobtran.UF_Jobtran_Machine = @machine
        '    AND jobtran.Status = 'U'
        ')", con)

        '    cmd_select_all.Parameters.AddWithValue("@section", cmb_section.Text)
        '    cmd_select_all.Parameters.AddWithValue("@machine", cmb_machine.Text)
        '    cmd_select_all.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
        '    cmd_select_all.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)

        '    cmd_select_all.ExecuteNonQuery()
        '    con.Close()

        '    ' Refresh the DataGridView
        '    RefreshDataGridView()
        'Catch ex As Exception
        '    MessageBox.Show("Error: " & ex.Message)
        'End Try
        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    If Not row.IsNewRow Then
        '        Dim operator_section As String = row.Cells("Section").Value.ToString
        '        If cmb_section.Text = operator_section Then
        '            Dim checkBoxCell As DataGridViewCheckBoxCell = TryCast(row.Cells("Select"), DataGridViewCheckBoxCell)
        '            If checkBoxCell IsNot Nothing Then
        '                checkBoxCell.Value = Not CBool(checkBoxCell.Value)
        '            End If
        '        End If
        '    End If
        'Next
        If user_position <> "Operator" Then
            select_all()
            load_table_for_supervisor()
        End If

    End Sub

    Private Sub select_all()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("Select").Value = False Then
                row.Cells("Select").Value = True
            Else
                row.Cells("Select").Value = False
            End If
        Next
    End Sub

    Private Function loggedinusername()

        Dim createdbyuser As String = String.Empty

        Using con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
            con.Open()

            Using cmd As New SqlCommand("Select Name, Emp_num from Ptag_line WHERE Emp_num=@empnum", con)
                cmd.Parameters.AddWithValue("@empnum", txtempnum.Text)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    createdbyuser = reader("Emp_num").ToString()
                End If
            End Using
        End Using
        Return createdbyuser

    End Function

    Private Sub RefreshDataGridView()
        Dim query As String = "SELECT * FROM Pallet_Tagging.dbo.sfms_jobtran " &
                              "WHERE EXISTS ( " &
                              "SELECT 1 " &
                              "FROM [PI-SP_App].dbo.job job " &
                              "LEFT JOIN Employee emp ON sfms_jobtran.emp_num = emp.Emp_num " &
                              "WHERE sfms_jobtran.job = job.job " &
                              "AND sfms_jobtran.Suffix = job.suffix " &
                              "AND emp.section = @section " &
                              "AND sfms_jobtran.trans_date BETWEEN @date1 AND @date2 " &
                              "AND sfms_jobtran.UF_Jobtran_Machine = @machine " &
                              "AND sfms_jobtran.Status = 'U')"

        Dim cmd As SqlCommand = New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@section", cmb_section.Text)
        cmd.Parameters.AddWithValue("@machine", cmb_machine.Text)
        cmd.Parameters.Add("@date1", SqlDbType.DateTime).Value = dtp_start.Value.Date
        cmd.Parameters.Add("@date2", SqlDbType.DateTime).Value = dtp_end.Value.AddDays(1)

        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim table As DataTable = New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub

    Private Sub cmb_machine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_machine.SelectedIndexChanged

    End Sub






    'Private Sub btnpost_Click(sender As Object, e As EventArgs) Handles btnpost.Click
    '    Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job AND suffix=@suffix AND oper_num=@opernum AND emp_num=@empnum AND Trans_type = 'S' AND start_time = @starttime and end_time=@endtime AND shift=@shift and CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
    '    cmdreadsfms.Parameters.AddWithValue("@job", txtjob.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@starttime", lblintstart.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@endtime", lblintend.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@shift", lblshift.Text)
    '    Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
    '    cmdreadsfms.Parameters.AddWithValue("@transdate", transdateString)

    '    Try
    '        con1.Open()
    '        con.Open()

    '        Dim cmdinsert As SqlCommand = New SqlCommand("INSERT INTO Jobtran 
    '                        (job,
    '                        suffix,
    '                        trans_type,
    '                        trans_date,
    '                        qty_complete,
    '                        qty_scrapped, 
    '                        oper_num,
    '                        a_hrs, 
    '                        next_oper, 
    '                        emp_num, 
    '                        start_time,
    '                        end_time,
    '                        qty_moved,
    '                        whse,
    '                        loc,
    '                        lot,
    '                        shift,
    '                        reason_code,
    '                        wc,
    '                        Uf_JobTran_TransactionType,
    '                        Uf_JobTran_Machine,
    '                        Uf_JobTran_Output,
    '                        Uf_JobTran_Rework,
    '                        CreatedBy,
    '                        CreateDate,
    '                        a_$,
    '                        pay_rate,
    '                        close_job,
    '                        issue_parent,
    '                        complete_op,
    '                        pr_rate,
    '                        job_rate,
    '                        posted,
    '                        low_level,
    '                        backflush,
    '                        trans_class,
    '                        awaiting_eop,
    '                        fixovhd,
    '                        varovhd,
    '                        co_product_mix,
    '                        NoteExistsFlag,
    '                        UpdatedBy,
    '                        InWorkflow,
    '                        Uf_Jobtran_DocNum)
    '            VALUES 
    '                       (@job,
    '                        @suffix,
    '                        @transtype,
    '                        @transdate,
    '                        @qtycomplete,
    '                        @qtyscrapped,
    '                        @opernum,
    '                        @ahrs,
    '                        @nextoper,
    '                        @empnum,
    '                        @starttime,
    '                        @endtime,
    '                        @qtymoved,
    '                        @whse,
    '                        @loc,
    '                        @lot,
    '                        @shift,
    '                        @reasoncode,
    '                        @wc,
    '                        @uftranstype,
    '                        @ufmachine,
    '                        @ufoutput,
    '                        @ufrework,
    '                        @createdby,
    '                        @createddate,
    '                        '0',
    '                        'R',
    '                        0,
    '                        0,
    '                        0,
    '                        0,
    '                        0,
    '                        0,
    '                        1,
    '                        0,
    '                        'J',
    '                        0,
    '                        0,
    '                        0,
    '                        0,
    '                        0,
    '                        @updatedby,
    '                        0,
    '                        @ufdocnum)", con1)



    '        Dim readsfms As SqlDataReader = cmdreadsfms.ExecuteReader

    '        While readsfms.Read()
    '            cmdinsert.Parameters.AddWithValue("@job", readsfms("Job").ToString)
    '            cmdinsert.Parameters.AddWithValue("@suffix", readsfms("Suffix").ToString)
    '            cmdinsert.Parameters.AddWithValue("@transtype", readsfms("trans_type").ToString)

    '            'mdinsert.Parameters.AddWithValue("@transdate", readsfms("trans_date").ToString)

    '            If readsfms.IsDBNull(readsfms.GetOrdinal("trans_date")) Then
    '                cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
    '            Else
    '                Dim transDate As DateTime
    '                If DateTime.TryParse(readsfms("trans_date").ToString(), transDate) Then
    '                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = transDate
    '                Else
    '                    ' Handle invalid date format
    '                    ' For example, log an error or set a default date
    '                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
    '                End If
    '            End If


    '            cmdinsert.Parameters.AddWithValue("@qtycomplete", readsfms("qty_complete").ToString)
    '            cmdinsert.Parameters.AddWithValue("@qtyscrapped", readsfms("qty_scrapped").ToString)
    '            cmdinsert.Parameters.AddWithValue("@opernum", readsfms("oper_num").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ahrs", readsfms("a_hrs").ToString)
    '            'cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("next_oper")) Then
    '                cmdinsert.Parameters.AddWithValue("@nextoper", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper"))
    '            End If
    '            cmdinsert.Parameters.AddWithValue("@empnum", lblempnum.Text)
    '            cmdinsert.Parameters.AddWithValue("@starttime", readsfms("start_time").ToString)
    '            cmdinsert.Parameters.AddWithValue("@endtime", readsfms("end_time").ToString)
    '            cmdinsert.Parameters.AddWithValue("@qtymoved", readsfms("qty_moved").ToString)
    '            cmdinsert.Parameters.AddWithValue("@whse", readsfms("whse").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("loc")) Then
    '                cmdinsert.Parameters.AddWithValue("@loc", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc"))
    '            End If
    '            ' cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("lot")) Then
    '                cmdinsert.Parameters.AddWithValue("@lot", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot"))
    '            End If
    '            'cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot").ToString)
    '            cmdinsert.Parameters.AddWithValue("@shift", readsfms("shift").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("reason_code")) Then
    '                cmdinsert.Parameters.AddWithValue("@reasoncode", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code"))
    '            End If
    '            'cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code").ToString)
    '            cmdinsert.Parameters.AddWithValue("@wc", readsfms("wc").ToString)
    '            cmdinsert.Parameters.AddWithValue("@uftranstype", readsfms("Uf_Jobtran_TransactionType").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ufmachine", readsfms("Uf_Jobtran_Machine").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ufoutput", readsfms("Uf_Jobtran_Output").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ufrework", readsfms("Uf_Jobtran_Rework").ToString)
    '            cmdinsert.Parameters.AddWithValue("@createdby", readsfms("CreatedBy").ToString)

    '            ' cmdinsert.Parameters.AddWithValue("@createddate", readsfms("CreateDate").ToString)

    '            If readsfms.IsDBNull(readsfms.GetOrdinal("CreateDate")) Then
    '                cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
    '            Else
    '                Dim createddate As DateTime
    '                If DateTime.TryParse(readsfms("CreateDate").ToString(), createddate) Then
    '                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate
    '                Else
    '                    ' Handle invalid date format
    '                    ' For example, log an error or set a default date
    '                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
    '                End If
    '            End If

    '            cmdinsert.Parameters.AddWithValue("@updatedby", lblempnum.Text)
    '            cmdinsert.Parameters.AddWithValue("@ufdocnum", readsfms("UF_Jobtran_DocNum").ToString)
    '            cmdinsert.ExecuteNonQuery()
    '            MsgBox("Posted Successfully")
    '        End While
    '        readsfms.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '        con1.Close()
    '    End Try
    '    Try
    '        con.Open()
    '        Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type = 'S'", con)
    '        cmdupdatesfms.Parameters.AddWithValue("@job", DataGridView1.SelectedCells(0).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@suffix", DataGridView1.SelectedCells(1).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@opernum", DataGridView1.SelectedCells(2).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@empnum", txtempnum.Text)

    '        Dim transdate As DateTime = DataGridView1.SelectedCells(3).Value.ToString
    '        'Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
    '        'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
    '        cmdupdatesfms.Parameters.AddWithValue("@transdate", transdateString)

    '        cmdupdatesfms.ExecuteNonQuery()
    '        btnpost.Enabled = False
    '        btnupdate.Enabled = False
    '        'MsgBox("Saved in Posted Job!")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    'Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

    '    Try
    '        con.Open()
    '        Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type = 'S'", con)
    '        cmdupdatesfms.Parameters.AddWithValue("@job", DataGridView1.SelectedCells(0).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@suffix", DataGridView1.SelectedCells(1).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@opernum", DataGridView1.SelectedCells(2).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@empnum", txtempnum.Text)

    '        Dim transdate As DateTime = DataGridView1.SelectedCells(3).Value.ToString
    '        Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
    '        'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
    '        cmdupdatesfms.Parameters.AddWithValue("@transdate", transdatestring)

    '        cmdupdatesfms.ExecuteNonQuery()
    '        btnpost.Enabled = False
    '        btnupdate.Enabled = False
    '        'MsgBox("Saved in Posted Job!")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try

    '    Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job AND suffix=@suffix AND oper_num=@opernum AND emp_num=@empnum AND Trans_type = 'S' AND start_time = @starttime and end_time=@endtime AND shift=@shift and CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
    '    cmdreadsfms.Parameters.AddWithValue("@job", DataGridView1.SelectedCells(0).Value.ToString)
    '    cmdreadsfms.Parameters.AddWithValue("@suffix", DataGridView1.SelectedCells(1).Value.ToStringt)
    '    cmdreadsfms.Parameters.AddWithValue("@opernum", DataGridView1.SelectedCells(2).Value.ToString)
    '    cmdreadsfms.Parameters.AddWithValue("@empnum", txtempnum.Text)
    '    cmdreadsfms.Parameters.AddWithValue("@shift", lblshift.Text)

    '    'Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
    '    cmdreadsfms.Parameters.AddWithValue("@transdate", transdateString)

    '    Try
    '        con1.Open()
    '        con.Open()

    '        Dim cmdinsert As SqlCommand = New SqlCommand("INSERT INTO Jobtran 
    '                            (job,
    '                            suffix,
    '                            trans_type,
    '                            trans_date,
    '                            qty_complete,
    '                            qty_scrapped, 
    '                            oper_num,
    '                            a_hrs, 
    '                            next_oper, 
    '                            emp_num, 
    '                            start_time,
    '                            end_time,
    '                            qty_moved,
    '                            whse,
    '                            loc,
    '                            lot,
    '                            shift,
    '                            reason_code,
    '                            wc,
    '                            Uf_JobTran_TransactionType,
    '                            Uf_JobTran_Machine,
    '                            Uf_JobTran_Output,
    '                            Uf_JobTran_Rework,
    '                            CreatedBy,
    '                            CreateDate,
    '                            a_$,
    '                            pay_rate,
    '                            close_job,
    '                            issue_parent,
    '                            complete_op,
    '                            pr_rate,
    '                            job_rate,
    '                            posted,
    '                            low_level,
    '                            backflush,
    '                            trans_class,
    '                            awaiting_eop,
    '                            fixovhd,
    '                            varovhd,
    '                            co_product_mix,
    '                            NoteExistsFlag,
    '                            UpdatedBy,
    '                            InWorkflow,
    '                            Uf_Jobtran_DocNum)
    '                VALUES 
    '                           (@job,
    '                            @suffix,
    '                            @transtype,
    '                            @transdate,
    '                            @qtycomplete,
    '                            @qtyscrapped,
    '                            @opernum,
    '                            @ahrs,
    '                            @nextoper,
    '                            @empnum,
    '                            @starttime,
    '                            @endtime,
    '                            @qtymoved,
    '                            @whse,
    '                            @loc,
    '                            @lot,
    '                            @shift,
    '                            @reasoncode,
    '                            @wc,
    '                            @uftranstype,
    '                            @ufmachine,
    '                            @ufoutput,
    '                            @ufrework,
    '                            @createdby,
    '                            @createddate,
    '                            '0',
    '                            'R',
    '                            0,
    '                            0,
    '                            0,
    '                            0,
    '                            0,
    '                            0,
    '                            1,
    '                            0,
    '                            'J',
    '                            0,
    '                            0,
    '                            0,
    '                            0,
    '                            0,
    '                            @updatedby,
    '                            0,
    '                            @ufdocnum)", con1)



    '        Dim readsfms As SqlDataReader = cmdreadsfms.ExecuteReader

    '        While readsfms.Read()
    '            cmdinsert.Parameters.AddWithValue("@job", readsfms("Job").ToString)
    '            cmdinsert.Parameters.AddWithValue("@suffix", readsfms("Suffix").ToString)
    '            cmdinsert.Parameters.AddWithValue("@transtype", readsfms("trans_type").ToString)

    '            'mdinsert.Parameters.AddWithValue("@transdate", readsfms("trans_date").ToString)

    '            If readsfms.IsDBNull(readsfms.GetOrdinal("trans_date")) Then
    '                cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
    '            Else
    '                Dim transDate As DateTime
    '                If DateTime.TryParse(readsfms("trans_date").ToString(), transDate) Then
    '                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = transDate
    '                Else
    '                    ' Handle invalid date format
    '                    ' For example, log an error or set a default date
    '                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
    '                End If
    '            End If


    '            cmdinsert.Parameters.AddWithValue("@qtycomplete", readsfms("qty_complete").ToString)
    '            cmdinsert.Parameters.AddWithValue("@qtyscrapped", readsfms("qty_scrapped").ToString)
    '            cmdinsert.Parameters.AddWithValue("@opernum", readsfms("oper_num").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ahrs", readsfms("a_hrs").ToString)
    '            'cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("next_oper")) Then
    '                cmdinsert.Parameters.AddWithValue("@nextoper", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@nextoper", readsfms("next_oper"))
    '            End If
    '            cmdinsert.Parameters.AddWithValue("@empnum", lblempnum.Text)
    '            cmdinsert.Parameters.AddWithValue("@starttime", readsfms("start_time").ToString)
    '            cmdinsert.Parameters.AddWithValue("@endtime", readsfms("end_time").ToString)
    '            cmdinsert.Parameters.AddWithValue("@qtymoved", readsfms("qty_moved").ToString)
    '            cmdinsert.Parameters.AddWithValue("@whse", readsfms("whse").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("loc")) Then
    '                cmdinsert.Parameters.AddWithValue("@loc", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc"))
    '            End If
    '            ' cmdinsert.Parameters.AddWithValue("@loc", readsfms("loc").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("lot")) Then
    '                cmdinsert.Parameters.AddWithValue("@lot", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot"))
    '            End If
    '            'cmdinsert.Parameters.AddWithValue("@lot", readsfms("lot").ToString)
    '            cmdinsert.Parameters.AddWithValue("@shift", readsfms("shift").ToString)
    '            If readsfms.IsDBNull(readsfms.GetOrdinal("reason_code")) Then
    '                cmdinsert.Parameters.AddWithValue("@reasoncode", DBNull.Value)
    '            Else
    '                cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code"))
    '            End If
    '            'cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code").ToString)
    '            cmdinsert.Parameters.AddWithValue("@wc", readsfms("wc").ToString)
    '            cmdinsert.Parameters.AddWithValue("@uftranstype", readsfms("Uf_Jobtran_TransactionType").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ufmachine", readsfms("Uf_Jobtran_Machine").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ufoutput", readsfms("Uf_Jobtran_Output").ToString)
    '            cmdinsert.Parameters.AddWithValue("@ufrework", readsfms("Uf_Jobtran_Rework").ToString)
    '            cmdinsert.Parameters.AddWithValue("@createdby", readsfms("CreatedBy").ToString)

    '            ' cmdinsert.Parameters.AddWithValue("@createddate", readsfms("CreateDate").ToString)

    '            If readsfms.IsDBNull(readsfms.GetOrdinal("CreateDate")) Then
    '                cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
    '            Else
    '                Dim createddate As DateTime
    '                If DateTime.TryParse(readsfms("CreateDate").ToString(), createddate) Then
    '                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate
    '                Else
    '                    ' Handle invalid date format
    '                    ' For example, log an error or set a default date
    '                    cmdinsert.Parameters.Add("@createddate", SqlDbType.DateTime).Value = DBNull.Value
    '                End If
    '            End If

    '            cmdinsert.Parameters.AddWithValue("@updatedby", lblempnum.Text)
    '            cmdinsert.Parameters.AddWithValue("@ufdocnum", readsfms("UF_Jobtran_DocNum").ToString)
    '            cmdinsert.ExecuteNonQuery()
    '            MsgBox("Posted Successfully")
    '        End While
    '        readsfms.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '        con1.Close()
    '    End Try
    '    Try
    '        con.Open()
    '        Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type = 'S'", con)
    '        cmdupdatesfms.Parameters.AddWithValue("@job", DataGridView1.SelectedCells(0).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@suffix", DataGridView1.SelectedCells(1).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@opernum", DataGridView1.SelectedCells(2).Value.ToString)
    '        cmdupdatesfms.Parameters.AddWithValue("@empnum", txtempnum.Text)

    '        'Dim transdate As DateTime = DataGridView1.SelectedCells(3).Value.ToString
    '        'Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
    '        'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
    '        cmdupdatesfms.Parameters.AddWithValue("@transdate", transdateString)

    '        cmdupdatesfms.ExecuteNonQuery()
    '        btnpost.Enabled = False
    '        btnupdate.Enabled = False
    '        'MsgBox("Saved in Posted Job!")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try


    'End Sub
End Class