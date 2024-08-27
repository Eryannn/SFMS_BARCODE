Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization
Public Class frmviewunposted
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnback.Click

        Try
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("UPDATE sfms_jobtran Set [Select] = 0 WHERE Createdby=@empnum", con)
            cmd.Parameters.AddWithValue("@empnum", txtempnum.Text)

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
            row.ReadOnly = True
            row.Cells("Select").ReadOnly = False
        Next
        Return 0
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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
                viewunposted_operator.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
                viewunposted_operator.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
                'viewunposted_operator.Parameters.AddWithValue("@machine", cmb_machine.Text)
                Dim a As New SqlDataAdapter(viewunposted_operator)
                Dim dt As New DataTable
                a.Fill(dt)

                DataGridView1.DataSource = dt
                AutofitColumns(DataGridView1)
                enablecheckbox()
            Else
                'viewunposted.Parameters.AddWithValue("@dept", txt_dept.Text) 'add this line for userdept
                viewunposted.Parameters.AddWithValue("@section", txt_section.Text) 'add this line for usersection
                viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
                viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
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

        txtempnum.Text = userid

        Dim getuserdetails As String = "Select Site, Emp_num, Name, position, dept, section from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        Try
            con.Open()
            Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
            If readuserdetails.HasRows Then
                While readuserdetails.Read
                    txtempname.Text = readuserdetails("Name").ToString
                    txt_section.Text = readuserdetails("section").ToString
                    txt_position.Text = readuserdetails("position").ToString
                    cmb_section.Text = readuserdetails("section").ToString
                    If readuserdetails("Position").ToString = "Operator" Then
                        btnpost.Enabled = False
                    Else
                        btnpost.Enabled = True
                    End If
                End While
                readuserdetails.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

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
            Status='U'
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
                viewunposted_operator.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
                viewunposted_operator.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
                'viewunposted_operator.Parameters.AddWithValue("@machine", cmb_machine.Text)
                Dim a As New SqlDataAdapter(viewunposted_operator)
                Dim dt As New DataTable
                a.Fill(dt)

                DataGridView1.DataSource = dt
                AutofitColumns(DataGridView1)
                enablecheckbox()
            Else
                'viewunposted.Parameters.AddWithValue("@dept", txt_dept.Text) 'add this line for userdept
                viewunposted.Parameters.AddWithValue("@section", txt_section.Text) 'add this line for usersection
                viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
                viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
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
        'Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where [Select] = 1", con)
        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran a
        INNER JOIN Employee b on a.CreatedBy = b.Emp_num
        where [Select] = 1 and b.Section = @section AND UF_Jobtran_Machine = @machine", con)
        'Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job AND suffix=@suffix AND oper_num=@opernum AND emp_num=@empnum AND Trans_type = @transtype and CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
        'cmdreadsfms.Parameters.AddWithValue("@job", DataGridView1.SelectedCells(1).Value.ToString)
        'cmdreadsfms.Parameters.AddWithValue("@suffix", DataGridView1.SelectedCells(2).Value.ToString)
        'cmdreadsfms.Parameters.AddWithValue("@opernum", DataGridView1.SelectedCells(3).Value.ToString)
        ''cmdreadsfms.Parameters.AddWithValue("@empnum", txtempnum.Text)AND emp_num=@empnum
        'cmdreadsfms.Parameters.AddWithValue("@starttime", lblintstart.Text)
        ' cmdreadsfms.Parameters.AddWithValue("@endtime", lblintend.Text)
        'cmdreadsfms.Parameters.AddWithValue("@shift", .Text)
        cmdreadsfms.Parameters.AddWithValue("@section", txt_section.Text)
        cmdreadsfms.Parameters.AddWithValue("@machine", cmb_machine.Text)


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



        Try
            con1.Open()
            con.Open()

            'REFRESH TABLE
            Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
            jobtran.[Select],
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
	        jobtran.a_hrs,
	        jobtran.qty_complete,
	        jobtran.qty_scrapped
        FROM 
           Pallet_Tagging.dbo.sfms_jobtran jobtran
        INNER JOIN 
	        [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        WHERE 
            jobtran.emp_num = @empnum AND 
            jobtran.trans_date BETWEEN @date1 AND @date2 AND
            Status='U'", con)

            viewunposted.Parameters.AddWithValue("@empnum", txtempnum.Text)
            viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)


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
            Dim validateinsert As Boolean = False

            'If totalhrs > 0 Then
            While readsfms.Read()
                If CInt(readsfms("a_hrs").ToString) > 0 AndAlso readsfms("trans_type").ToString <> "M" Then
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
                    cmdinsert.Parameters.AddWithValue("@empnum", txtempnum.Text)
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
                        cmdinsert.Parameters.AddWithValue("@createdby", readsfms("CreatedBy").ToString)

                        ' cmdinsert.Parameters.AddWithValue("@createddate", readsfms("CreateDate").ToString)

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

                        If cmdinsert.ExecuteNonQuery > 0 Then
                            validateinsert = True
                        End If
                        'cmdupdatesfms.ExecuteNonQuery()
                        'MsgBox("Posted Successfully not moved setup")
                    ElseIf readsfms("trans_type").ToString = "M" Then
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
                    cmdinsert.Parameters.AddWithValue("@empnum", txtempnum.Text)
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
                    cmdinsert.Parameters.AddWithValue("@createdby", readsfms("CreatedBy").ToString)



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
                        validateinsert = True
                    End If

                    'cmdupdatesfms.ExecuteNonQuery()
                End If
            End While

            readsfms.Close()

            If validateinsert Then
                MsgBox("POSTED")
                isposted = True
            Else
                MsgBox("INVALID")
                isposted = False
            End If

            Dim a As New SqlDataAdapter(viewunposted)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt
            AutofitColumns(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            con1.Close()
        End Try

        Try
            'Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
            '        SET Status = 'P'
            '        WHERE [Select] = 1
            '          AND emp_num = @empnum
            '          AND Status = 'U'
            '          AND (
            '              (trans_type <> 'M' AND a_hrs <> 0) OR
            '              (trans_type = 'M'))", con)
            'cmdupdatesfms.Parameters.AddWithValue("@empnum", txtempnum.Text)

            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
                SET Status = 'P'
		        from sfms_jobtran a
		        INNER JOIN Employee b on a.CreatedBy = b.Emp_num
                WHERE a.[Select] = 1
			        AND b.Section = @section
			        AND a.UF_Jobtran_Machine = @machine
                    AND a.Status = 'U'
                    AND (
                        (a.trans_type <> 'M' AND a.a_hrs <> 0) OR
                        (a.trans_type = 'M'))", con)
            cmdupdatesfms.Parameters.AddWithValue("@section", txt_section.Text)
            cmdupdatesfms.Parameters.AddWithValue("@machine", cmb_machine.Text)

            'Dim cmd_sfmsjobtranview As SqlCommand = New SqlCommand("Select * from sfms_jobtran where [Select] = 1 AND emp_num=@empnum", con)
            'cmd_sfmsjobtranview.Parameters.AddWithValue("@empnum", txtempnum.Text)

            Dim cmd_sfmsjobtranview As SqlCommand = New SqlCommand("select * from sfms_jobtran a
		        INNER JOIN Employee b on a.CreatedBy = b.Emp_num
                WHERE a.[SELECT] = 1
			        AND b.Section = @section
			        AND a.UF_Jobtran_Machine = @machine
                    AND a.Status = 'U'
                    AND (
                        (a.trans_type <> 'M' AND a.a_hrs <> 0) OR
                        (a.trans_type = 'M'))", con)
            cmd_sfmsjobtranview.Parameters.AddWithValue("@section", txt_section.Text)
            cmd_sfmsjobtranview.Parameters.AddWithValue("@machine", cmb_machine.Text)

            con.Open()
            Dim readsfmsjobtran As SqlDataReader = cmd_sfmsjobtranview.ExecuteReader()
            Dim validateinsert As Boolean = False

            While readsfmsjobtran.Read()
                Dim type As String = readsfmsjobtran("trans_type").ToString()
                Dim aHrs As Integer = If(IsDBNull(readsfmsjobtran("a_hrs")), 0, CInt(readsfmsjobtran("a_hrs").ToString()))

                If isposted Then
                    If type <> "M" AndAlso aHrs > 0 Then
                        validateinsert = True
                    ElseIf type = "M" Then
                        validateinsert = True
                    End If
                End If
            End While

            readsfmsjobtran.Close()

            If validateinsert Then
                cmdupdatesfms.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox("TESTDEBUG")
        Finally
            con.Close()
            isposted = False
        End Try


        'Try
        '    Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
        '        SET Status = 'P'
        '        WHERE [Select] = 1
        '          AND emp_num = @empnum
        '          AND Status = 'U'
        '          AND (
        '              (trans_type <> 'M' AND a_hrs <> 0) OR
        '              (trans_type = 'M'))", con)
        '    cmdupdatesfms.Parameters.AddWithValue("@empnum", txtempnum.Text)
        '    Dim cmd_sfmsjobtranview As SqlCommand = New SqlCommand("Select * from sfms_jobtran where [Select] = 1 AND emp_num=@empnum", con)
        '    cmd_sfmsjobtranview.Parameters.AddWithValue("@empnum", txtempnum.Text)
        '    con.Open()
        '    Dim readsfmsjobtran As SqlDataReader = cmd_sfmsjobtranview.ExecuteReader
        '    Dim validateinsert As Boolean = False

        '    While readsfmsjobtran.Read()
        '        If isposted Then
        '            If CInt(readsfmsjobtran("a_hrs").ToString) > 0 AndAlso readsfmsjobtran("trans_type").ToString <> "M" Then
        '                'cmdupdatesfms.Parameters.Clear()

        '                readsfmsjobtran.Close()
        '                cmdupdatesfms.ExecuteNonQuery()
        '                MsgBox("UPDATED SUCCESSFULLY NOT MOVED")
        '            ElseIf readsfmsjobtran("trans_type").ToString = "M" Then
        '                readsfmsjobtran.Read()
        '                'cmdupdatesfms.Parameters.Clear()
        '                'cmdupdatesfms.ExecuteNonQuery()
        '                readsfmsjobtran.Close()
        '                cmdupdatesfms.ExecuteNonQuery()
        '                MsgBox("UPDATED SUCCESSFULLY MOVE SETUP")

        '            End If
        '        End If
        '    End While
        'Catch ex As Exception
        '    MsgBox("DEBUGGING")
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        '    isposted = False
        'End Try


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