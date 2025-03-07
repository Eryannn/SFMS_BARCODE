﻿Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmupdatesetup

    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmviewunposted.txtempnum.Text

    Private Sub dtpstart_TextChanged(sender As Object, e As EventArgs) Handles dtpstart.TextChanged
        'Dim dtpstartint As Integer = dtpstart.Value.Hour * 3600 + dtpstart.Value.Minute * 60 + dtpstart.Value.Second

        'Dim totaltimeinseconds As Integer = CInt(lblendtime.Text) - CInt(lblstarttime.Text)

        'Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        'If totalhours < 0 Then
        '    totalhours = totalhours + 24
        'End If

        'lblstarttime.Text = dtpstartint
        'txttotalhrs.Text = totalhours.ToString

        'backup
        Dim dtpstartint As Integer = dtpstart.Value.Hour * 3600 + dtpstart.Value.Minute * 60 + dtpstart.Value.Second

        Dim totaltimeinseconds As Integer = CInt(lblintend.Text) - CInt(lblintstart.Text)

        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        If totalhours < 0 Then
            totalhours = totalhours + 24
        End If

        lblintstart.Text = dtpstartint
        'txttotalhrs.Text = totalhours.ToString
        'backup


        'Dim startDateTime As DateTime = dtpstart.Value
        'Dim endDateTime As DateTime = dtpend.Value

        '' If end time is earlier than start time, it crosses midnight, so add 24 hours to end time
        'If endDateTime < startDateTime Then
        '    endDateTime = endDateTime.AddDays(1)
        'End If

        'Dim totalSeconds As Integer = (endDateTime - startDateTime).TotalSeconds

        'Dim totalHours As Double = Math.Round(totalSeconds / 3600, 3)
        'If totalhours < 0 Then
        '    totalhours += 24
        'End If

        'txttotalhrs.Text = totalhours.ToString()


    End Sub

    Private Sub dtpend_TextChanged(sender As Object, e As EventArgs) Handles dtpend.TextChanged
        Dim dtpendint As Integer = dtpend.Value.Hour * 3600 + dtpend.Value.Minute * 60 + dtpstart.Value.Second

        Dim totaltimeinseconds As Integer = CInt(lblintend.Text) - CInt(lblintstart.Text)

        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        If totalhours < 0 Then
            totalhours = totalhours + 24
        End If



        lblintend.Text = dtpendint
        'txttotalhrs.Text = totalhours


    End Sub

    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        Try
            con.Open()

            Dim cmdviewitems As SqlCommand = New SqlCommand("SELECT * 
               from sfms_jobtran 
               where job=@job AND
               suffix=@suffix AND
               oper_num=@opernum AND
               Createdby=@empnum AND
	           trans_type=@type AND
               CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
            'CONVERT(VARCHAR, trans_date, 120) LIKE @transdate
            cmdviewitems.Parameters.AddWithValue("@job", txtjob.Text)
            cmdviewitems.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdviewitems.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdviewitems.Parameters.AddWithValue("@empnum", lblempnum.Text)
            'cmdviewitems.Parameters.AddWithValue("@empname", lblempname.Text)
            cmdviewitems.Parameters.AddWithValue("@type", txttranstype.Text)
            Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            cmdviewitems.Parameters.AddWithValue("@transdate", transdateString)

            Dim readitems As SqlDataReader = cmdviewitems.ExecuteReader
            If readitems.HasRows Then
                While readitems.Read()
                    lblintstart.Text = CInt(readitems("start_time").ToString)

                    Dim endint As String = readitems("end_time").ToString
                    If endint = "" Then
                        lblintend.Text = "0"
                    Else
                        'lblintend.Text = "5"
                        lblintend.Text = CDbl(readitems("end_time").ToString)
                    End If
                    txtwc.Text = readitems("wc").ToString
                    txtwcdesc.Text = readitems("wcdesc").ToString
                    txttotalhrs.Text = readitems("a_hrs").ToString
                    'cmbsetuptype.Text = readitems("Uf_Jobtran_TransactionType").ToString
                    txttotalhrs.Text = readitems("Uf_Jobtran_TransactionType").ToString
                    rtbmach.Text = readitems("UF_Jobtran_Machine").ToString
                    dtpstart.Value = readitems("start_datetime").ToString

                    Dim dtpcurrent As DateTime = Today
                    Dim enddate As String = readitems("end_datetime").ToString
                    If enddate = "" Then
                        dtpend.Value = dtpcurrent
                    Else
                        dtpend.Value = enddate
                    End If

                    lbltransdate.Text = readitems("trans_date").ToString


                End While
            Else
                readitems.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub frmupdatesetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblempnum.Text = frmlogin.txtuserid.Text
        lblshift.Text = frmlogin.cmbshift.Text

        Dim getuserdetails As String = "Select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", lblempnum.Text)

        Dim cmdgetdesc As SqlCommand = New SqlCommand("Select code, description, code + ' / ' + description as codeanddesc from Ptag_Setuptype where Code = @code", con)
        cmdgetdesc.Parameters.AddWithValue("@code", cmbsetuptype.Text)

        Try
            con.Open()
            Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
            If readuserdetails.HasRows Then
                While readuserdetails.Read
                    lblempname.Text = readuserdetails("Name").ToString
                End While
                readuserdetails.Close()
            End If

        Catch ex As Exception
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnexit.Click

        'Try
        '    con.Open()
        '    Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
        '    Jobtran.[Select],
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

        '    viewunposted.Parameters.AddWithValue("@empnum", frmviewunposted.txtempnum.Text)
        '    viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = frmviewunposted.DateTimePicker1.Value.Date
        '    viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = frmviewunposted.DateTimePicker2.Value.AddDays(1)

        '    Dim a As New SqlDataAdapter(viewunposted)
        '    Dim dt As New DataTable
        '    a.Fill(dt)
        '    frmviewunposted.DataGridView1.DataSource = dt


        '    AutofitColumns(frmviewunposted.DataGridView1)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try

        'frmviewunposted.Show()
        'SFMSMENU.lblempnum.Text = lblempnum.Text
        'SFMSMENU.lblempname.Text = lblempname.Text
        'Me.Close()

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

            If frmviewunposted.txt_position.Text = "Operator" Then
                frmviewunposted.cmb_section.Visible = False
                frmviewunposted.cmb_machine.Visible = False
                Label5.Text = ""
                Label6.Text = ""
                viewunposted_operator.Parameters.AddWithValue("@empnum", frmviewunposted.txtempnum.Text)
                viewunposted_operator.Parameters.Add("@date1", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
                viewunposted_operator.Parameters.Add("@date2", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)
                'viewunposted_operator.Parameters.AddWithValue("@machine", cmb_machine.Text)
                Dim a As New SqlDataAdapter(viewunposted_operator)
                Dim dt As New DataTable
                a.Fill(dt)

                frmviewunposted.DataGridView1.DataSource = dt
                AutofitColumns(frmviewunposted.DataGridView1)
                enablecheckbox()
                Me.Close()
            Else
                'viewunposted.Parameters.AddWithValue("@dept", txt_dept.Text) 'add this line for userdept
                viewunposted.Parameters.AddWithValue("@section", frmviewunposted.txt_section.Text) 'add this line for usersection
                viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
                viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)
                viewunposted.Parameters.AddWithValue("@machine", frmviewunposted.cmb_machine.Text)
                Dim a As New SqlDataAdapter(viewunposted)
                Dim dt As New DataTable
                a.Fill(dt)

                frmviewunposted.DataGridView1.DataSource = dt
                AutofitColumns(frmviewunposted.DataGridView1)
                enablecheckbox()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function enablecheckbox()
        For Each row As DataGridViewRow In frmviewunposted.DataGridView1.Rows
            row.ReadOnly = True
            row.Cells("Select").ReadOnly = False
        Next
        Return 0
    End Function

    Private Sub AutofitColumns(dataGridView As DataGridView)
        ' Auto-resize columns to fit their content
        For Each column As DataGridViewColumn In dataGridView.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        ' Perform the actual auto-resizing based on content
        dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        Dim dtpstartstring As String = dtpstart.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
        Dim dtpendstring As String = dtpend.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
        'MsgBox(dtpstartstring)
        Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            con.Open()
            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
            SET start_datetime=@startdatetime,
            end_datetime=@enddatetime,
            start_time=@startint,
            end_time=@endint,
            a_hrs=@ahrs,
            Uf_jobtran_TransactionType=@reasondesc,
            emp_num=@updatedby
            WHERE job=@job AND
            Suffix=@suffix AND
            Oper_num=@opernum AND
            trans_type='S' AND
            Status='U' AND
            Createdby=@empnum AND
            CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)

            cmdupdatesfms.Parameters.AddWithValue("@startdatetime", dtpstartstring)
            cmdupdatesfms.Parameters.AddWithValue("@enddatetime", dtpendstring)
            cmdupdatesfms.Parameters.AddWithValue("@startint", lblintstart.Text)
            cmdupdatesfms.Parameters.AddWithValue("@endint", lblintend.Text)
            cmdupdatesfms.Parameters.AddWithValue("@ahrs", txttotalhrs.Text)
            'cmdupdatesfms.Parameters.AddWithValue("@reasoncode", cmbsetuptype.Text)
            cmdupdatesfms.Parameters.AddWithValue("@reasondesc", cmbsetuptype.Text)

            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text) 'changes from lblempnum to lbl_updatedby
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdateString)
            cmdupdatesfms.Parameters.AddWithValue("@updatedby", lbl_updatedby.Text)
            If cmbsetuptype.Text = "" Then
                MsgBox("Setup Type Required!")
            Else
                cmdupdatesfms.ExecuteNonQuery()

                MsgBox("Updated Successfully!")

                btnpost.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnpost.Click
        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job AND suffix=@suffix AND oper_num=@opernum AND emp_num=@empnum AND Trans_type = 'S' AND start_time = @starttime and end_time=@endtime AND shift=@shift and CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
        cmdreadsfms.Parameters.AddWithValue("@job", txtjob.Text)
        cmdreadsfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdreadsfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
        cmdreadsfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
        cmdreadsfms.Parameters.AddWithValue("@starttime", lblintstart.Text)
        cmdreadsfms.Parameters.AddWithValue("@endtime", lblintend.Text)
        cmdreadsfms.Parameters.AddWithValue("@shift", lblshift.Text)
        Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        cmdreadsfms.Parameters.AddWithValue("@transdate", transdateString)

        Try
            con1.Open()
            con.Open()

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



            Dim readsfms As SqlDataReader = cmdreadsfms.ExecuteReader

            While readsfms.Read()
                cmdinsert.Parameters.AddWithValue("@job", readsfms("Job").ToString)
                cmdinsert.Parameters.AddWithValue("@suffix", readsfms("Suffix").ToString)
                cmdinsert.Parameters.AddWithValue("@transtype", readsfms("trans_type").ToString)

                'mdinsert.Parameters.AddWithValue("@transdate", readsfms("trans_date").ToString)

                If readsfms.IsDBNull(readsfms.GetOrdinal("trans_date")) Then
                    cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = DBNull.Value
                Else
                    Dim transDate As DateTime
                    If DateTime.TryParse(readsfms("trans_date").ToString(), transDate) Then
                        cmdinsert.Parameters.Add("@transdate", SqlDbType.DateTime).Value = transDate
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
                cmdinsert.Parameters.AddWithValue("@empnum", lblempnum.Text)
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
                Else
                    cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code"))
                End If
                'cmdinsert.Parameters.AddWithValue("@reasoncode", readsfms("reason_code").ToString)
                cmdinsert.Parameters.AddWithValue("@wc", readsfms("wc").ToString)
                cmdinsert.Parameters.AddWithValue("@uftranstype", readsfms("Uf_Jobtran_TransactionType").ToString)
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

                cmdinsert.Parameters.AddWithValue("@updatedby", lblempnum.Text)
                cmdinsert.Parameters.AddWithValue("@ufdocnum", readsfms("UF_Jobtran_DocNum").ToString)
                cmdinsert.ExecuteNonQuery()
                MsgBox("Posted Successfully")
            End While
            readsfms.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            con1.Close()
        End Try
        Try
            con.Open()
            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type = 'S'", con)
            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)

            Dim transdate As DateTime = dtptransdate.Value
            'Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
            'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdatestring)

            cmdupdatesfms.ExecuteNonQuery()
            btnpost.Enabled = False
            btnupdate.Enabled = False
            'MsgBox("Saved in Posted Job!")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub lblintend_TextChanged(sender As Object, e As EventArgs) Handles lblintend.TextChanged

        Dim totaltime As Integer = CInt(lblintend.Text) - CInt(lblintstart.Text)
        Dim totalhours As Double = totaltime / 3600

        ' Adjust total hours if it's negative or exceeds 24
        If totalhours < 0 Then
            totalhours += 24
        ElseIf totalhours >= 24 Then
            totalhours -= 24
        End If

        txttotalhrs.Text = Math.Round(totalhours, 3).ToString()




    End Sub

    Private Sub lblintstart_TextChanged(sender As Object, e As EventArgs) Handles lblintstart.TextChanged

        If lblintend.Text = "" Then
            lblintend.Text = 0
        End If

        Dim totaltime As Integer = CInt(lblintend.Text) - CInt(lblintstart.Text)
        Dim totalhours As Double = totaltime / 3600

        ' Adjust total hours if it's negative or exceeds 24
        If totalhours < 0 Then
            totalhours += 24
        ElseIf totalhours >= 24 Then
            totalhours -= 24
        End If

        txttotalhrs.Text = Math.Round(totalhours, 3).ToString()
    End Sub

    Private Sub cmbsetuptype_DropDown(sender As Object, e As EventArgs) Handles cmbsetuptype.DropDown
        cmbsetuptype.Items.Clear()
        setupcodewithdescription()
    End Sub

    Private Sub setupcodewithdescription()
        Dim cmd_offset As New SqlCommand("Select * from Ptag_Setuptype WHERE Code IN ('SMF','SMP','WUP')", con)
        Dim cmd_nonoffset As New SqlCommand("Select * from Ptag_Setuptype WHERE Code IN ('SMF','SMP')", con)

        Dim cmd As SqlCommand

        If user_section = "OFFSET" Then
            cmd = cmd_offset
        Else
            cmd = cmd_nonoffset
        End If


        Try
            con.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                Dim codeanddesc As String = readcmd("Code") + " / " + readcmd("Description")
                cmbsetuptype.Items.Add(codeanddesc)
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmbsetuptype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsetuptype.SelectedIndexChanged

        Dim cmd As New SqlCommand("Select code, description, code + ' / ' + description as codeanddesc from Ptag_Setuptype where (Code + ' / ' + Description) = @code", con)
        cmd.Parameters.AddWithValue("@code", cmbsetuptype.Text)

        Try
            con.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                lblsetupdesc.Text = readcmd("Description").ToString
                Dim codeanddesc As String = readcmd("Code")
                cmbsetuptype.Items.Add(codeanddesc)
                cmbsetuptype.Text = readcmd("Code").ToString

            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmbsetuptype_TextChanged(sender As Object, e As EventArgs) Handles cmbsetuptype.TextChanged

        'Dim con_desc As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")

        'Dim cmdgetdesc As SqlCommand = New SqlCommand("Select code, description, code + ' / ' + description as codeanddesc from Ptag_Setuptype where Code = @code", con_desc)
        'cmdgetdesc.Parameters.AddWithValue("@code", cmbsetuptype.Text)

        'Try
        '    con_desc.Open()
        '    Dim read_cmdgetdesc As SqlDataReader = cmdgetdesc.ExecuteReader
        '    While read_cmdgetdesc.Read
        '        lblsetupdesc.Text = read_cmdgetdesc("description").ToString
        '    End While

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con_desc.Close()
        'End Try

    End Sub


End Class