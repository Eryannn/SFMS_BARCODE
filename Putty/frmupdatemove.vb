Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmupdatemove
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmviewunposted.txtempnum.Text

    Private Sub frmupdatemove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lbltransdate.Text = Now.ToString("MM/dd/yyyy")
        lblshift.Text = frmlogin.cmbshift.Text

        Dim getuserdetails As String = "select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        'MsgBox(userid)

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

    Private Sub load_data()
        Try
            con.Open()

            Dim cmdviewitems As SqlCommand = New SqlCommand("SELECT * 
               from sfms_jobtran 
               where job=@job AND
               suffix=@suffix AND
               oper_num=@opernum AND
               createdby=@empnum AND
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
                    'lblstartint.Text = CInt(readitems("start_time").ToString)


                    txtwc.Text = readitems("wc").ToString
                    txtwcdesc.Text = readitems("wcdesc").ToString
                    lblreasondesc.Text = readitems("Uf_Jobtran_TransactionType").ToString
                    cmbreasoncode.Text = readitems("reason_code").ToString
                    rtbmach.Text = readitems("UF_Jobtran_Machine").ToString
                    lblnextop.Text = readitems("next_oper").ToString
                    Dim dtpcurrent As DateTime = Today
                    Dim enddate As String = readitems("end_datetime").ToString

                    txtlot.Text = readitems("Lot").ToString
                    'lbltransdate.Text = readitems("trans_date").ToString
                    txtqtymoved.Text = readitems("qty_moved").ToString
                    txtqtycompleted.Text = readitems("qty_complete").ToString
                    txtqtyscrapped.Text = readitems("qty_scrapped").ToString
                    txt_docnum.Text = readitems("UF_Jobtran_DocNum").ToString
                    txtqtygood.Text = readitems("UF_Jobtran_Output").ToString
                    txtqtyrework.Text = readitems("UF_Jobtran_Rework").ToString
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
    Private Sub load_reasoncode()
        Try
            con1.Open()

            Dim cmd As SqlCommand = New SqlCommand("select reason_class, reason_code, description, reason_code + ' / ' + description as codeanddesc from reason where reason_code = @reasoncode", con1)

            cmd.Parameters.AddWithValue("@reasoncode", cmbreasoncode.Text)

            Dim read_cmd As SqlDataReader = cmd.ExecuteReader
            While read_cmd.Read
                lblreasondesc.Text = read_cmd("description").ToString

            End While
            read_cmd.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try
    End Sub


    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged

        load_data()
        load_reasoncode()

    End Sub

    Private Sub txtqtygood_TextChanged(sender As Object, e As EventArgs) Handles txtqtygood.TextChanged
        Dim totalqtycompleted As Integer
        If String.IsNullOrEmpty(txtqtygood.Text) Then
            txtqtygood.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txtqtygood.Text, qtyScrapped) Then
                txtqtygood.Text = qtyScrapped.ToString("n0")
                txtqtygood.Select(txtqtygood.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        If txtqtygood IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtqtygood.Text) AndAlso IsNumeric(txtqtygood.Text) Then
            If txtqtyrework IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtqtyrework.Text) AndAlso IsNumeric(txtqtyrework.Text) Then
                totalqtycompleted = (CInt(txtqtygood.Text) + CInt(txtqtyrework.Text)).ToString()
                txtqtycompleted.Text = (CInt(txtqtygood.Text) + CInt(txtqtyrework.Text)).ToString()
            End If
        End If

        'If lblnextop.Text Is Nothing OrElse lblnextop.Text = "0" Then
        '    txtqtymoved.Text = "0"
        'Else
        '    txtqtymoved.Text = totalqtycompleted
        'End If
        If txtwc.Text = "P610" Then
            txtqtymoved.Text = "0"
        ElseIf lblnextop.Text = "" OrElse lblnextop.Text = "0" Then
            txtqtymoved.Text = "0"
        Else
            txtqtymoved.Text = totalqtycompleted
        End If


    End Sub

    Private Sub txtqtyrework_TextChanged(sender As Object, e As EventArgs) Handles txtqtyrework.TextChanged
        If String.IsNullOrEmpty(txtqtyrework.Text) Then
            txtqtyrework.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txtqtyrework.Text, qtyScrapped) Then
                txtqtyrework.Text = qtyScrapped.ToString("n0")
                txtqtyrework.Select(txtqtyrework.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        Dim total As Double
        total = CInt(txtqtygood.Text) + CInt(txtqtyrework.Text)
        txtqtycompleted.Text = total

        If txtwc.Text = "P610" Then
            txtqtymoved.Text = "0"
        ElseIf lblnextop.Text = "" OrElse lblnextop.Text = "0" Then
            txtqtymoved.Text = "0"
        Else
            txtqtymoved.Text = total
        End If
    End Sub

    Private Sub txtqtycompleted_TextChanged(sender As Object, e As EventArgs) Handles txtqtycompleted.TextChanged
        If String.IsNullOrEmpty(txtqtycompleted.Text) Then
            txtqtycompleted.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txtqtycompleted.Text, qtyScrapped) Then
                txtqtycompleted.Text = qtyScrapped.ToString("n0")
                txtqtycompleted.Select(txtqtycompleted.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        If lblnextop.Text IsNot Nothing Then
            txtqtymoved.Text = CInt(txtqtycompleted.Text)
        Else
            txtqtymoved.Text = CInt("0")
        End If
    End Sub

    Private Sub txtqtyscrapped_TextChanged(sender As Object, e As EventArgs) Handles txtqtyscrapped.TextChanged
        If String.IsNullOrEmpty(txtqtyscrapped.Text) Then
            txtqtyscrapped.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txtqtyscrapped.Text, qtyScrapped) Then
                txtqtyscrapped.Text = qtyScrapped.ToString("n0")
                txtqtyscrapped.Select(txtqtyscrapped.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        If CInt(txtqtyscrapped.Text) <= 0 Then
            cmbreasoncode.Enabled = False
            cmbreasoncode.SelectedIndex = -1
            cmbreasoncode.Text = ""
            lblreasondesc.Text = If(cleartext() = 0, "", cleartext().ToString())
        Else
            cmbreasoncode.Enabled = True
        End If
    End Sub

    Private Sub cmbreasoncode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbreasoncode.SelectedIndexChanged
        Dim cmd As New SqlCommand("select reason_class, reason_code, description, reason_code + ' / ' + description as codeanddesc from reason where (reason_code + ' / ' + description) = @code", con1)

        cmd.Parameters.AddWithValue("@code", cmbreasoncode.Text)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                lblreasondesc.Text = readcmd("description").ToString
                Dim codeanddesc As String = readcmd("reason_code")
                cmbreasoncode.Items.Add(codeanddesc)
                cmbreasoncode.Text = readcmd("reason_code").ToString

            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub cmbreasoncode_DropDown(sender As Object, e As EventArgs) Handles cmbreasoncode.DropDown
        cmbreasoncode.Items.Clear()
        reasoncodewithdesc()
    End Sub

    Private Sub reasoncodewithdesc()
        Dim cmd As New SqlCommand("Select * from reason", con1)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                Dim codeanddesc As String = readcmd("reason_code") + " / " + readcmd("description")
                cmbreasoncode.Items.Add(codeanddesc)
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click


        Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            con.Open()

            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
            SET reason_code=@reasoncode,
            qty_complete=@qtycomplete,
            qty_scrapped=@qtyscrapped,
            qty_moved=@qtymoved,
            lot=@lot,
            UF_Jobtran_DocNum=@docnum,
            UF_Jobtran_Output=@qtygood,
            UF_Jobtran_Rework=@qtyrework,
            emp_num=@updatedby
            WHERE job=@job AND
            Suffix=@suffix AND
            Oper_num=@opernum AND
            trans_type='M' AND
            Status='U' AND
            createdby=@empnum AND
            CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)


            If cmbreasoncode.Text = "" Then
                cmdupdatesfms.Parameters.AddWithValue("@reasoncode", DBNull.Value)
            Else

                cmdupdatesfms.Parameters.AddWithValue("@reasoncode", cmbreasoncode.Text)
            End If

            'cmdupdatesfms.Parameters.AddWithValue("@reasondesc", lblreasondesc.Text)
            cmdupdatesfms.Parameters.AddWithValue("@qtycomplete", CInt(txtqtycompleted.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtyscrapped", CInt(txtqtyscrapped.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtymoved", CInt(txtqtymoved.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtyrework", CInt(txtqtyrework.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtygood", CInt(txtqtygood.Text))

            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdateString)
            cmdupdatesfms.Parameters.AddWithValue("@lot", txtlot.Text)
            cmdupdatesfms.Parameters.AddWithValue("@updatedby", lbl_updatedby.Text)

            If txt_docnum.Text = "" Then
                cmdupdatesfms.Parameters.AddWithValue("@docnum", DBNull.Value)
            Else
                cmdupdatesfms.Parameters.AddWithValue("@docnum", txt_docnum.Text)
            End If


            If CInt(txtqtyscrapped.Text) > 0 AndAlso lblreasondesc.Text = "" Then

                MsgBox("Reason Code is Required")
            Else

                If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
                    If txtlot.Text <> "" Then
                        cmdupdatesfms.ExecuteNonQuery()

                        MsgBox("Updated Successfully!")

                        btnpost.Enabled = True

                    Else
                        MsgBox("Lot is Required")
                    End If
                Else
                    cmdupdatesfms.ExecuteNonQuery()

                    MsgBox("Updated Successfully!")

                    btnpost.Enabled = True

                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnpost_Click(sender As Object, e As EventArgs) Handles btnpost.Click
        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job And suffix=@suffix And oper_num=@opernum And emp_num=@empnum And Trans_type = 'M' AND shift=@shift and CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
        cmdreadsfms.Parameters.AddWithValue("@job", txtjob.Text)
        cmdreadsfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdreadsfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
        cmdreadsfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
        'cmdreadsfms.Parameters.AddWithValue("@starttime", lblstartint.Text)
        'cmdreadsfms.Parameters.AddWithValue("@endtime", lblendint.Text)
        cmdreadsfms.Parameters.AddWithValue("@shift", lblshift.Text)
        Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        cmdreadsfms.Parameters.AddWithValue("@transdate", transdatestring)


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
                        InWorkflow)
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
                        0)", con1)


            Dim readsfms As SqlDataReader = cmdreadsfms.ExecuteReader
            'If readsfms.Read Then
            While readsfms.Read()
                cmdinsert.Parameters.AddWithValue("@job", readsfms("Job").ToString)
                cmdinsert.Parameters.AddWithValue("@suffix", readsfms("Suffix").ToString)
                cmdinsert.Parameters.AddWithValue("@transtype", readsfms("trans_type").ToString)


                ' cmdinsert.Parameters.AddWithValue("@transdate", readsfms("trans_date").ToString)

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
                    cmdinsert.Parameters.AddWithValue("@nextoper", Convert.ToInt32(readsfms("next_oper")))
                End If
                cmdinsert.Parameters.AddWithValue("@empnum", lblempnum.Text)

                If readsfms.IsDBNull(readsfms.GetOrdinal("start_time")) Then
                    cmdinsert.Parameters.AddWithValue("@starttime", DBNull.Value)
                Else
                    cmdinsert.Parameters.AddWithValue("@starttime", readsfms("start_time").ToString)
                End If


                'cmdinsert.Parameters.AddWithValue("@starttime", readsfms("start_time").ToString)

                If readsfms.IsDBNull(readsfms.GetOrdinal("end_time")) Then
                    cmdinsert.Parameters.AddWithValue("@endtime", DBNull.Value)
                Else
                    cmdinsert.Parameters.AddWithValue("@endtime", readsfms("end_time").ToString)
                End If

                'cmdinsert.Parameters.AddWithValue("@endtime", readsfms("end_time").ToString)

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

                'cmdinsert.Parameters.AddWithValue("@createddate", readsfms("CreateDate").ToString)

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


                cmdinsert.ExecuteNonQuery()
                MsgBox("Posted Successfully")
                btnsave.Enabled = False
                btnpost.Enabled = False
                btnexit.Enabled = True
            End While
            readsfms.Close()
            ' End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            con1.Close()
        End Try

        Try
            con.Open()
            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type='M'", con)
            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)

            Dim transdate As DateTime = dtptransdate.Value
            'Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
            'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdatestring)
            'MsgBox(transdatestring)

            cmdupdatesfms.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub load_table_for_operator()

        Try
            con.Open()
            Dim cmd_select_sfms_operator As New SqlCommand("Select_sfms_jobtran_operator", con)
            cmd_select_sfms_operator.CommandType = CommandType.StoredProcedure
            cmd_select_sfms_operator.Parameters.AddWithValue("@empnum", frmviewunposted.txtempnum.Text)
            cmd_select_sfms_operator.Parameters.Add("@startdate", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
            cmd_select_sfms_operator.Parameters.Add("@enddate", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)

            Dim sda_operator As New SqlDataAdapter(cmd_select_sfms_operator)
            Dim dt_operator As New DataTable
            sda_operator.Fill(dt_operator)
            frmviewunposted.DataGridView1.DataSource = dt_operator
            AutofitColumns(frmviewunposted.DataGridView1)
            enablecheckbox()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub load_table_for_supervisor()
        Try
            con.Open()
            Dim cmd_view_unposted_supervisor As New SqlCommand("Select_sfms_jobtran_supervisor", con)
            cmd_view_unposted_supervisor.CommandType = CommandType.StoredProcedure
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@sectionS", frmviewunposted.cmb_section.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@sectionE", frmviewunposted.cmb_section.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@machineS", frmviewunposted.cmb_machine.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@machineE", frmviewunposted.cmb_machine.Text)
            cmd_view_unposted_supervisor.Parameters.Add("@startdate", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
            cmd_view_unposted_supervisor.Parameters.Add("@enddate", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)

            Dim sda_supervisor As New SqlDataAdapter(cmd_view_unposted_supervisor)
            Dim dt_supervisor As New DataTable
            sda_supervisor.Fill(dt_supervisor)
            frmviewunposted.DataGridView1.DataSource = dt_supervisor




            AutofitColumns(frmviewunposted.DataGridView1)
            enablecheckbox()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub
    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        If app_prev_version = app_version Then
            If user_position = "Operator" Then
                load_table_for_operator()
            Else
                load_table_for_supervisor()
            End If
        End If

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
        'emp.Section

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
        '         Status='U'
        '     ORDER BY jobtran.trans_date DESC", con)
        '     'modify emp.dept into emp.section

        '     Dim viewunposted_operator As SqlCommand = New SqlCommand("SELECT 
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
        '         jobtran.createdby

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

        '     Try
        '         con.Open()

        '         If frmviewunposted.txt_position.Text = "Operator" Then
        '             frmviewunposted.cmb_section.Visible = False
        '             frmviewunposted.cmb_machine.Visible = False
        '             Label5.Text = ""
        '             Label6.Text = ""
        '             viewunposted_operator.Parameters.AddWithValue("@empnum", frmviewunposted.txtempnum.Text)
        '             viewunposted_operator.Parameters.Add("@date1", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
        '             viewunposted_operator.Parameters.Add("@date2", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)
        '             'viewunposted_operator.Parameters.AddWithValue("@machine", cmb_machine.Text)
        '             Dim a As New SqlDataAdapter(viewunposted_operator)
        '             Dim dt As New DataTable
        '             a.Fill(dt)

        '             frmviewunposted.DataGridView1.DataSource = dt
        '             AutofitColumns(frmviewunposted.DataGridView1)
        '             enablecheckbox()
        '             Me.Close()
        '         Else
        '             'viewunposted.Parameters.AddWithValue("@dept", txt_dept.Text) 'add this line for userdept
        '             viewunposted.Parameters.AddWithValue("@section", frmviewunposted.txt_section.Text) 'add this line for usersection
        '             viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
        '             viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)
        '             viewunposted.Parameters.AddWithValue("@machine", frmviewunposted.cmb_machine.Text)
        '             Dim a As New SqlDataAdapter(viewunposted)
        '             Dim dt As New DataTable
        '             a.Fill(dt)

        '             frmviewunposted.DataGridView1.DataSource = dt
        '             AutofitColumns(frmviewunposted.DataGridView1)
        '             enablecheckbox()
        '             Me.Close()
        '         End If

        '     Catch ex As Exception
        '         MsgBox(ex.Message)
        '     Finally
        '         con.Close()
        '     End Try


        'Try
        '    con.Open()
        '    Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
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

End Class