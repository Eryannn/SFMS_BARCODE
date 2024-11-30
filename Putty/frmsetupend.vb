Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Globalization
Public Class frmsetupend

    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Private Sub frmsetupend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblendtime.Text = Now.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper()
        lbltransdate.Text = Now.ToString("MM/dd/yyyy")
        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")

        lblempnum.Text = user_id
        lblempname.Text = user_name

        lblshift.Text = login_shift
        Timer1.Enabled = True
        dtptransdate.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SFMSMENU.lblshift.Text = lblshift.Text
        SFMSMENU.Show()
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = Date.Now.ToString("hh:mm:ss tt").ToUpper()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            Try
                con.Open()
                '[Dim endTime As DateTime = DateTime.Parse(lblendtime.Text)

                Dim endTime As DateTime

                If DateTime.TryParseExact(lblendtime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, endTime) Then

                    Dim endTimeInt As Integer = endTime.Hour * 3600 + endTime.Minute * 60 + endTime.Second
                    If txtjob.Text.Length = 10 And txtjob.Text.Length >= 1 And txtopernum.Text.Length >= 1 Then

                        Dim cmdupdatesfms As SqlCommand = New SqlCommand("update sfms_jobtran set end_time = @endtime, a_hrs = @totalhrs, end_datetime = @enddatetime, emp_num = @updatedby where Job = @job AND Suffix = @suffix AND oper_num = @opernum AND end_time IS NULL AND trans_type = 'S'", con)
                        cmdupdatesfms.Parameters.AddWithValue("@endtime", endTimeInt)
                        cmdupdatesfms.Parameters.AddWithValue("@totalhrs", lbltotalhrs.Text)
                        cmdupdatesfms.Parameters.AddWithValue("@enddatetime", lblendtime.Text)
                        cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
                        cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
                        cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)

                        If lbl_updatedby.Text = "" Then
                            cmdupdatesfms.Parameters.AddWithValue("@updatedby", lblempnum.Text)
                        Else
                            cmdupdatesfms.Parameters.AddWithValue("@updatedby", lbl_updatedby.Text)
                        End If

                        cmdupdatesfms.ExecuteNonQuery()
                        Button4.Enabled = True
                        Button2.Enabled = False
                        MsgBox("Saved Successfully")
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        End If

    End Sub


    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
        Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        'AND CAST(trans_date AS DATE) = @transdate
        Dim cmdcheckpending As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job = @job AND Suffix = @suffix AND oper_num = @opernum AND end_time IS NULL AND trans_type = 'S' AND createdby = @empnum", con)
        cmdcheckpending.Parameters.AddWithValue("@job", txtjob.Text)
        cmdcheckpending.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdcheckpending.Parameters.AddWithValue("@opernum", txtopernum.Text)
        ' cmdcheckpending.Parameters.AddWithValue("@transdate", lbltransdate.Text)
        cmdcheckpending.Parameters.AddWithValue("@empnum", lblempnum.Text)
        cmdcheckpending.Parameters.AddWithValue("@shift", lblshift.Text)

        Try
            con.Open()

            If txtopernum.Text.Length <= 1 Then
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lblcode.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblsetupdesc.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblstarttime.Text = If(cleartext() = 0, "", cleartext().ToString())
                lbltotalhrs.Text = If(cleartext() = 0, "", cleartext().ToString())
                lbltransdate.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblintstart.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblintend.Text = If(cleartext() = 0, "", cleartext().ToString())
                dtptransdate.Value = Today
            End If

            'If txtjob.Text.Length <= 8 Then
            '    txtwc.Clear()
            '    txtwcdesc.Clear()
            '    rtbmach.Clear()
            '    lblcode.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lblsetupdesc.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lbltransdate.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lblstarttime.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lbltotalhrs.Text = If(cleartext() = 0, "", cleartext().ToString())
            'End If

            'If txtsuffix.Text.Length <= 0 Then
            '    txtwc.Clear()
            '    txtwcdesc.Clear()
            '    rtbmach.Clear()
            '    lblcode.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lblsetupdesc.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lbltransdate.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lblstarttime.Text = If(cleartext() = 0, "", cleartext().ToString())
            '    lbltotalhrs.Text = If(cleartext() = 0, "", cleartext().ToString())
            'End If


            Dim readsfms As SqlDataReader = cmdcheckpending.ExecuteReader
            If readsfms.HasRows Then
                While readsfms.Read
                    lblcode.Text = readsfms("Uf_Jobtran_TransactionType").ToString
                    txtwc.Text = readsfms("wc").ToString
                    txtwcdesc.Text = readsfms("wcdesc").ToString
                    rtbmach.Text = readsfms("UF_Jobtran_Machine").ToString
                    ' Assuming readsfms("trans_date") is a valid DateTime value
                    Dim transDate As DateTime = DirectCast(readsfms("trans_date"), DateTime)
                    dtptransdate.Value = transDate.ToString("yyyy-MM-dd hh:mm:ss")

                    lbltransdate.Text = transDate.ToString("MM/dd/yyyy")

                    Dim starttime As DateTime = DirectCast(readsfms("start_datetime"), DateTime)
                    lblstarttime.Text = starttime.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper

                    'Read the existing datetime string from the database
                    Dim existingDateTimeString As String = readsfms("start_datetime").ToString
                    'Dim endTime As DateTime = DateTime.Parse(lblendtime.Text)

                    Dim endTime As DateTime

                    If DateTime.TryParseExact(lblendtime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, endTime) Then
                        Dim endTimeInt As Integer = endTime.Hour * 3600 + endTime.Minute * 60 + endTime.Second

                        ' Assuming endTimeInt and startTimeInt are integers representing seconds
                        Dim totalTimeInSeconds As Integer = endTimeInt - CInt(readsfms("start_time"))
                        lblintstart.Text = CInt(readsfms("start_time"))
                        lblintend.Text = endTimeInt
                        ' Calculate total hours and round to 3 decimal places
                        Dim totalHours As Double = Math.Round(totalTimeInSeconds / 3600, 3)
                        If totalHours < 0 Then
                            totalHours = totalHours + 24
                        End If
                        ' Set the formatted total hours to lbltotalhrs.Text
                        lbltotalhrs.Text = totalHours.ToString()
                    End If

                    'Dim endtimedateint As Integer = endTime.Month *



                End While
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub lblcode_TextChanged(sender As Object, e As EventArgs) Handles lblcode.TextChanged
        Dim cmd As New SqlCommand("Select code, description, code + ' / ' + description as codeanddesc from Ptag_Setuptype where code = @code", con)
        cmd.Parameters.AddWithValue("@code", lblcode.Text)

        Try
            con.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                lblsetupdesc.Text = readcmd("Description").ToString
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job AND suffix=@suffix AND oper_num=@opernum AND emp_num=@empnum AND Trans_type = 'S' AND start_time = @starttime and end_time=@endtime AND shift=@shift", con)
        cmdreadsfms.Parameters.AddWithValue("@job", txtjob.Text)
        cmdreadsfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdreadsfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
        cmdreadsfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
        cmdreadsfms.Parameters.AddWithValue("@starttime", lblintstart.Text)
        cmdreadsfms.Parameters.AddWithValue("@endtime", lblintend.Text)
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
            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran set Status='P' WHERE Job=@job AND Suffix = @suffix AND oper_num = @opernum AND emp_num = @empnum AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND Status = 'U'", con)
            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)

            Dim transdate As DateTime = dtptransdate.Value
            Dim transdatestring As String = transdate.ToString("yyyy-MM-dd HH:mm:ss")
            'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdatestring)

            cmdupdatesfms.ExecuteNonQuery()
            Button4.Enabled = False
            Button2.Enabled = False
            'MsgBox("Saved in Posted Job!")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


End Class