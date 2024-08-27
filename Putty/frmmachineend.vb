Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmmachineend

    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmmachinestart.lblempnum.Text

    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        Dim cmdcheckpending As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job = @job AND Suffix = @suffix AND oper_num = @opernum AND end_time IS NULL AND trans_type = 'C' AND emp_num = @empnum AND shift = @shift", con)
        cmdcheckpending.Parameters.AddWithValue("@job", txtjob.Text)
        cmdcheckpending.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdcheckpending.Parameters.AddWithValue("@opernum", txtopernum.Text)
        ' cmdcheckpending.Parameters.AddWithValue("@transdate", lbltransdate.Text)
        cmdcheckpending.Parameters.AddWithValue("@empnum", lblempnum.Text)
        cmdcheckpending.Parameters.AddWithValue("@shift", lblshift.Text)

        Dim cmdnextop As SqlCommand = New SqlCommand("select top 1 jrt.job,	jrt.suffix	,jrt.oper_num,	jrt.wc ,wc.description
                         from jobroute jrt
                         inner join wc on wc.wc=jrt.wc 
                         where jrt.job =@job
                         and jrt.suffix=@suffix
                         and jrt.oper_num>@opernum
                         order by  jrt.oper_num ASC", con1)
        cmdnextop.Parameters.AddWithValue("@job", txtjob.Text)
        cmdnextop.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdnextop.Parameters.AddWithValue("@opernum", txtopernum.Text)

        Dim cmdnextop1 As SqlCommand = New SqlCommand("select ref_job as job ,ref_suf as suffix,ref_oper as oper_num ,wc.wc,wc.description
                         from job jb
                         left join jobroute jr on jb.ref_job=jr.job
                         and jb.ref_suf=jr.suffix 
                         and jb.ref_oper=jr.oper_num
                         inner join wc on wc.wc=jr.wc
                         where jb.job=@job and jb.suffix=@suffix", con1)
        cmdnextop1.Parameters.AddWithValue("@job", txtjob.Text)
        cmdnextop1.Parameters.AddWithValue("@suffix", txtsuffix.Text)


        Try
            con.Open()
            con1.Open()
            Dim readsfms As SqlDataReader = cmdcheckpending.ExecuteReader

            If txtopernum.Text.Length <= 0 Then
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                txtlot.Clear()
                txtqtycomplete.Clear()
                txtqtyscrapped.Text = "0"
                lblstartint.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblendint.Text = If(cleartext() = 0, "", cleartext().ToString())
                lbltotalhrs.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblstarttime.Text = If(cleartext() = 0, "", cleartext().ToString())

            End If

            If readsfms.HasRows Then
                While readsfms.Read
                    txtwc.Text = readsfms("wc").ToString
                    txtwcdesc.Text = readsfms("wcdesc").ToString
                    rtbmach.Text = readsfms("UF_Jobtran_Machine").ToString
                    Dim transdate As DateTime = DirectCast(readsfms("trans_date"), DateTime)
                    lbltransdate.Text = transdate.ToString("MM/dd/yyyy")
                    dtptransdate.Value = transdate.ToString("yyyy-MM-dd HH:mm:ss")
                    Dim starttime As DateTime = DirectCast(readsfms("start_datetime"), DateTime)
                    lblstarttime.Text = starttime.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper
                    If readsfms("wc").ToString = "P230" Then
                        txtlot.Text = ""
                    Else
                        txtlot.Text = readsfms("lot").ToString
                    End If

                    lblstartint.Text = readsfms("start_time").ToString
                    lblnextop.Text = readsfms("next_oper").ToString

                    btnsave.Enabled = True
                    btnpost.Enabled = False

                    Dim endTime As DateTime
                    If DateTime.TryParseExact(lblendtime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, endTime) Then
                        Dim endTimeInt As Integer = endTime.Hour * 3600 + endTime.Minute * 60 + endTime.Second
                        Dim totaltimeinseconds As Integer = endTimeInt - CInt(readsfms("start_time"))

                        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
                        If totalhours < 0 Then
                            totalhours = totalhours + 24
                        End If
                        lblendint.Text = endTimeInt
                        lbltotalhrs.Text = totalhours.ToString
                        txtqtycomplete.Text = 0
                        txtqtyscrapped.Text = 0
                    End If
                End While
                readsfms.Close()

            Else
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                txtlot.Clear()
                txtqtycomplete.Clear()
                txtqtyscrapped.Clear()
                lblstartint.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblendint.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblreasondesc.Text = If(cleartext() = 0, "", cleartext().ToString())
                cmbreasoncode.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            con1.Close()
        End Try

    End Sub

    Private Sub frmmachineend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblendtime.Text = Now.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper()
        lbltransdate.Text = Now.ToString("MM/dd/yyyy")
        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")
        lblshift.Text = frmlogin.cmbshift.Text
        Timer1.Enabled = True

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = Date.Now.ToString("hh:mm:ss tt").ToUpper()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        SFMSMENU.Show()
        SFMSMENU.lblempnum.Text = lblempnum.Text
        SFMSMENU.lblempname.Text = lblempname.Text
        frmmachinestart.close
        Me.Close()
    End Sub

    Private Sub cmbreasoncode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbreasoncode.SelectedIndexChanged

        Dim cmd As New SqlCommand("select reason_class, reason_code, description, reason_code + ' / ' + description as codeanddesc from reason where (reason_code + ' / ' + description) = @code", con1)

        'Dim cmd As New SqlCommand("Select code, description, code + ' / ' + description as codeanddesc from Ptag_Setuptype where (Code + ' / ' + Description) = @code", con)
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

        Try
            con.Open()

            Dim cmdupdate As SqlCommand = New SqlCommand("
                    UPDATE sfms_jobtran set 
                    end_time = @endtime, 
                    a_hrs = @totalhrs, 
                    end_datetime = @enddatetime, 
                    reason_code = @reason_code, 
                    qty_complete=@qtycomplete,
                    qty_scrapped=@qtyscrapped,
                    qty_moved=@qtymoved,
                    lot=@lot,
                    emp_num=@updatedby
                    WHERE 
                    job = @job AND 
                    Suffix = @suffix AND 
                    oper_num = @opernum AND 
                    end_time IS NULL and 
                    createdby=@empnum AND
                    trans_type = 'C'", con)
            cmdupdate.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdate.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdate.Parameters.AddWithValue("@opernum", txtopernum.Text)

            cmdupdate.Parameters.AddWithValue("@endtime", lblendint.Text)
            cmdupdate.Parameters.AddWithValue("@totalhrs", lbltotalhrs.Text)
            cmdupdate.Parameters.AddWithValue("@enddatetime", lblendtime.Text)


            If cmbreasoncode.Text = "" Then
                cmdupdate.Parameters.AddWithValue("@reason_code", DBNull.Value)
            Else
                cmdupdate.Parameters.AddWithValue("@reason_code", cmbreasoncode.Text)
            End If
            'cmdupdate.Parameters.AddWithValue("@reason_code", cmbreasoncode.Text)
            'cmdupdate.Parameters.AddWithValue("@transtype", lblreasondesc.Text)
            cmdupdate.Parameters.AddWithValue("@qtycomplete", CInt(txtqtycomplete.Text))
            cmdupdate.Parameters.AddWithValue("@qtyscrapped", CInt(txtqtyscrapped.Text))
            cmdupdate.Parameters.AddWithValue("@lot", txtlot.Text)

            If lblnextop IsNot Nothing Then
                cmdupdate.Parameters.AddWithValue("@qtymoved", CInt(txtqtycomplete.Text))
            ElseIf lblnextop.Text = "0"
                cmdupdate.Parameters.AddWithValue("@qtymoved", 0)
            End If

            If lbl_updatedby.Text = "" Then
                cmdupdate.Parameters.AddWithValue("@updatedby", lblempnum.Text)
            Else
                cmdupdate.Parameters.AddWithValue("@updatedby", lbl_updatedby.Text)
            End If

            cmdupdate.Parameters.AddWithValue("@empnum", lblempnum.Text)

            If CInt(txtqtyscrapped.Text) <= 0 Then

                If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
                    If txtlot.Text <> "" Then
                        cmdupdate.ExecuteNonQuery()
                        MsgBox("Saved Successfully! Ready for posting.")
                        btnsave.Enabled = False
                        btnpost.Enabled = True
                        btnexit.Enabled = True
                    Else
                        MsgBox("Lot is Required")
                    End If
                Else
                    cmdupdate.ExecuteNonQuery()
                    MsgBox("Saved Successfully! Ready for posting.")
                    btnsave.Enabled = False
                    btnpost.Enabled = True
                    btnexit.Enabled = True
                End If

            Else
                If cmbreasoncode.SelectedIndex = -1 Then
                    MsgBox("Scrap Reason Required!")
                    cmbreasoncode.Focus()
                Else

                    If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
                        If txtlot.Text <> "" Then
                            cmdupdate.ExecuteNonQuery()
                            MsgBox("Saved Successfully! Ready for posting.")
                            btnsave.Enabled = False
                            btnpost.Enabled = True
                            btnexit.Enabled = True
                        Else
                            MsgBox("Lot is Required")
                        End If
                    Else
                        cmdupdate.ExecuteNonQuery()
                        MsgBox("Saved Successfully! Ready for posting.")
                        btnsave.Enabled = False
                        btnpost.Enabled = True
                        btnexit.Enabled = True
                    End If
                End If
            End If


            'If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
            '    If txtlot.Text <> "" Then
            '        cmdupdate.ExecuteNonQuery()
            '        MsgBox("Saved Successfully! Ready for posting.")
            '        btnsave.Enabled = False
            '        btnpost.Enabled = True
            '        btnexit.Enabled = True
            '    Else
            '        MsgBox("Lot is Required")
            '    End If
            'Else
            '    cmdupdate.ExecuteNonQuery()
            '    MsgBox("Saved Successfully! Ready for posting.")
            '    btnsave.Enabled = False
            '    btnpost.Enabled = True
            '    btnexit.Enabled = True
            'End If

            'cmdupdate.ExecuteNonQuery()
            'MsgBox("Saved Successfully! Ready for posting.")
            'btnsave.Enabled = False
            'btnpost.Enabled = True
            'btnexit.Enabled = True











            'If CInt(txtqtyscrapped.Text) <= 0 Then
            '    If cmbreasoncode.SelectedIndex = -1 Then
            '        MsgBox("Scrap Reason Required!")
            '        cmbreasoncode.Focus()
            '    Else
            '        Dim cmdupdate As SqlCommand = New SqlCommand("
            '        UPDATE sfms_jobtran set 
            '        end_time = @endtime, 
            '        a_hrs = @totalhrs, 
            '        end_datetime = @enddatetime, 
            '        reason_code = @reason_code, 
            '        Uf_Jobtran_TransactionType = @transtype,
            '        qty_complete=@qtycomplete,
            '        qty_scrapped=@qtyscrapped,
            '        qty_moved=@qtymoved
            '        WHERE 
            '        job = @job AND 
            '        Suffix = @suffix AND 
            '        oper_num = @opernum AND 
            '        end_time IS NULL and 
            '        trans_type = 'C'", con)
            '        cmdupdate.Parameters.AddWithValue("@job", txtjob.Text)
            '        cmdupdate.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            '        cmdupdate.Parameters.AddWithValue("@opernum", txtopernum.Text)

            '        cmdupdate.Parameters.AddWithValue("@endtime", lblendint.Text)
            '        cmdupdate.Parameters.AddWithValue("@totalhrs", lbltotalhrs.Text)
            '        cmdupdate.Parameters.AddWithValue("@enddatetime", lbldate.Text)


            '        cmdupdate.Parameters.AddWithValue("@reason_code", cmbreasoncode.Text)
            '        cmdupdate.Parameters.AddWithValue("@transtype", lblreasondesc.Text)
            '        cmdupdate.Parameters.AddWithValue("@qtycomplete", CInt(txtqtycomplete.Text))
            '        cmdupdate.Parameters.AddWithValue("@qtyscrapped", CInt(txtqtyscrapped.Text))

            '        If lblnextop IsNot Nothing Then
            '            cmdupdate.Parameters.AddWithValue("@qtymoved", CInt(txtqtycomplete.Text))
            '        ElseIf lblnextop.Text = "0"
            '            cmdupdate.Parameters.AddWithValue("@qtymoved", 0)
            '        End If

            '        cmdupdate.ExecuteNonQuery()
            '        MsgBox("Saved Successfully! Ready for posting.")
            '        btnsave.Enabled = False
            '        btnpost.Enabled = True
            '        btnexit.Enabled = False
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtqtycomplete.TextChanged
        'txtqtycomplete.Text = CDbl(txtqtycomplete.Text).ToString("n0")
        'txtqtycomplete.Select(txtqtycomplete.Text.Length, 0)


        If String.IsNullOrEmpty(txtqtycomplete.Text) Then
            txtqtycomplete.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txtqtycomplete.Text, qtyScrapped) Then
                txtqtycomplete.Text = qtyScrapped.ToString("n0")
                txtqtycomplete.Select(txtqtycomplete.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        If lblnextop.Text Is Nothing OrElse lblnextop.Text = "0" Then
            lblqtymoved.Text = "0"
        Else
            lblqtymoved.Text = txtqtycomplete.Text
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtqtyscrapped.TextChanged


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
            lblreasondesc.Text = If(cleartext() = 0, "", cleartext().ToString())
        Else
            cmbreasoncode.Enabled = True
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnpost.Click
        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job And suffix=@suffix And oper_num=@opernum And emp_num=@empnum And Trans_type = 'C' AND start_time = @starttime and end_time=@endtime AND shift=@shift", con)
        cmdreadsfms.Parameters.AddWithValue("@job", txtjob.Text)
        cmdreadsfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdreadsfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
        cmdreadsfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
        cmdreadsfms.Parameters.AddWithValue("@starttime", lblstartint.Text)
        cmdreadsfms.Parameters.AddWithValue("@endtime", lblendint.Text)
        cmdreadsfms.Parameters.AddWithValue("@shift", lblshift.Text)


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
            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U' AND Trans_type='C'", con)
            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)

            Dim transdate As DateTime = dtptransdate.Value
            Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
            'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdatestring)

            cmdupdatesfms.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblqtymoved_Click(sender As Object, e As EventArgs) Handles lblqtymoved.Click

    End Sub

    Private Sub txtwc_TextChanged(sender As Object, e As EventArgs) Handles txtwc.TextChanged
    End Sub
End Class