Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization
Public Class frmmove

    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")

    Private Sub frmmove_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")
        lblempnum.Text = SFMSMENU.lblempnum.Text
        lblshift.Text = frmlogin.cmbshift.Text
        Timer1.Enabled = True

        Dim getuserdetails As String = "select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", lblempnum.Text)

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

    Private Sub populate_details()
        Dim cmdwc As SqlCommand = New SqlCommand(" select top 1 jrt.job,jrt.suffix,jrt.oper_num,jrt.wc ,wc.description,job.whse
                         from jobroute jrt
                         inner join wc on wc.wc=jrt.wc 
						 LEFT join job on jrt.job = job.job
						 AND jrt.suffix = job.suffix
						 AND job.type = 'J'
						 AND job.stat = 'R'
						 INNER JOIN Item on Job.item = item.item 
                         where jrt.job =@jonumber
                         and jrt.suffix=@josuffix
                         and jrt.oper_num=@operationnum
                         order by  jrt.oper_num ASC", con1)
        cmdwc.Parameters.AddWithValue("@jonumber", txtjob.Text)
        cmdwc.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
        cmdwc.Parameters.AddWithValue("@operationnum", txtopernum.Text)

        Dim cmdmach As SqlCommand = New SqlCommand("SELECT jrtrg.job, jrtrg.suffix,jrtrg.oper_num,res.RESID,res.DESCR
                        from jrtresourcegroup jrtrg inner join RGRPMBR000 rg on jrtrg.rgid=rg.rgid
                        inner join RESRC000 res on  rg.RESID=res.RESID where jrtrg.job=@jonumber and jrtrg.suffix = @josuffix and jrtrg.oper_num=@operationnum", con1)
        cmdmach.Parameters.AddWithValue("@jonumber", txtjob.Text)
        cmdmach.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
        cmdmach.Parameters.AddWithValue("@operationnum", txtopernum.Text)

        Dim cmdcheckpending As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job = @job AND Suffix = @suffix AND oper_num = @opernum AND trans_type='M' AND emp_num=@empnum AND status='U'", con)
        cmdcheckpending.Parameters.AddWithValue("@job", txtjob.Text)
        cmdcheckpending.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdcheckpending.Parameters.AddWithValue("@opernum", txtopernum.Text)
        'cmdcheckpending.Parameters.AddWithValue("@transdate", lbltransdate.Text) AND CAST(trans_date AS DATE) = @transdate
        cmdcheckpending.Parameters.AddWithValue("@empnum", lblempnum.Text)


        Dim cmd_get_cntrlpt_nextop As SqlCommand = New SqlCommand("
        begin tran

            declare
            @oper_num nvarchar(30)


            SELECT 	
            @oper_num=min(oper_num) 
            FROM jobroute
            where job = @jonumber AND 
            suffix = @josuffix AND 
            oper_num > @operationnum

            select 
			            job, 
			            suffix, 
			            min(oper_num) as next_op
            INTO #jr1
            from 
	            jobroute 
            where 
			            job = @jonumber AND 
			            suffix = @josuffix and 
			            oper_num > @operationnum
            group by 
			            job,
			            suffix

            select
			            job,
			            suffix,
			            oper_num,
			            cntrl_point
            INTO #jr2
            FROM
	            jobroute
            WHERE
			            job=@jonumber AND
			            suffix=@josuffix AND
			            oper_num=@oper_num

            select
			            a.job,
			            a.suffix,
			            a.next_op,
			            b.cntrl_point
            FROM
	            #jr1 a
		            LEFT JOIN #jr2 b ON
			            a.job = b.job AND
			            a.suffix = b.suffix AND
			            a.next_op = b.oper_num

            DROP TABLE #jr1, #jr2



        rollback tran        
        ", con1)
        cmd_get_cntrlpt_nextop.Parameters.AddWithValue("@jonumber", txtjob.Text)
        cmd_get_cntrlpt_nextop.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
        cmd_get_cntrlpt_nextop.Parameters.AddWithValue("@operationnum", txtopernum.Text)

        Dim cmdum As SqlCommand = New SqlCommand("SELECT top 1 job.job, job.suffix, job.qty_released, job.description, job.whse, item.item, item.u_m FROM jobroute jr
                        LEFT JOIN job on jr.job = job.job AND
                        jr.suffix = job.suffix
                        AND job.type = 'J'
                        AND job.stat = 'R'
                        INNER JOIN item on job.item = item.item
                        where jr.job = @job AND
                        jr.suffix = @suffix", con1)
        cmdum.Parameters.AddWithValue("@job", txtjob.Text)
        cmdum.Parameters.AddWithValue("@suffix", txtsuffix.Text)


        Try
            con.Open()
            con1.Open()

            If txtopernum.Text.Length <= 0 Then
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                txtlot.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())
                cmbreasoncode.Text = ""
                lblreasondesc.Text = If(cleartext() = 0, "", cleartext().ToString())
                dtptransdate.Value = Today
                txtqtyscrapped.Text = 0
                btnsave.Enabled = False
                btnpost.Enabled = False
                txtqtygood.Text = 0
                txtqtyrework.Text = 0
                lblum.Text = ""
                lblum1.Text = ""
                lblum2.Text = ""
                lblum3.Text = ""
                lblum4.Text = ""
                txt_cntrl_pt.Clear()

            Else
                btnsave.Enabled = True
            End If

            'THIS LINE IS FOR DEBUGGING

            Dim readwc As SqlDataReader = cmdwc.ExecuteReader
            If readwc.HasRows Then
                While readwc.Read()
                    txtwc.Text = readwc("wc").ToString
                    txtwcdesc.Text = readwc("description").ToString
                    lblwhse.Text = readwc("whse").ToString
                End While
                readwc.Close()
                Dim readmach As SqlDataReader = cmdmach.ExecuteReader
                If readmach.HasRows Then
                    While readmach.Read()
                        rtbmach.Text = readmach("RESID").ToString
                        '+ " " + readmach("DESCR").ToString
                    End While
                    readmach.Close()
                    txtlot.Text = txtjob.Text + "-1"
                    Dim readnextop As SqlDataReader = cmd_get_cntrlpt_nextop.ExecuteReader
                    If readnextop.HasRows Then
                        While readnextop.Read
                            lblnextop.Text = readnextop("next_op").ToString
                            txt_cntrl_pt.Text = readnextop("cntrl_point").ToString
                        End While
                        readnextop.Close()
                        txtqtygood.Text = 0
                        txtqtyrework.Text = 0
                        txtqtyscrapped.Text = 0
                        txtqtycompleted.Text = 0
                        Dim readum As SqlDataReader = cmdum.ExecuteReader
                        If readum.HasRows Then
                            While readum.Read
                                lblum.Text = readum("u_m").ToString
                                lblum1.Text = readum("u_m").ToString
                                lblum2.Text = readum("u_m").ToString
                                lblum3.Text = readum("u_m").ToString
                                lblum4.Text = readum("u_m").ToString
                            End While
                            readum.Close()

                        End If
                    Else
                        readnextop.Close()
                        lblnextop.Text = ""
                        txt_cntrl_pt.Clear()
                    End If
                End If
            Else
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())
                txt_cntrl_pt.Clear()
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            'MsgBox("DEBUGGING")
        Finally
            con.Close()
            con1.Close()
        End Try
    End Sub
    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        populate_details()
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        SFMSMENU.lblshift.Text = lblshift.Text
        SFMSMENU.Show()
        Me.Close()
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

        'If (lblnextop.Text <> "" OrElse lblnextop.Text IsNot Nothing) AndAlso txt_cntrl_pt.Text = 0 Then
        '    MsgBox("qty is 0")
        'Else
        '    MsgBox("qty is equal to qtycomplete")
        'End If

        If lblnextop.Text = "" OrElse lblnextop.Text = "0" AndAlso txt_cntrl_pt.Text = 1 Then
            txtqtymoved.Text = "0"
        ElseIf txt_cntrl_pt.Text = 1
            txtqtymoved.Text = totalqtycompleted
        Else
            txtqtymoved.Text = "0"
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

        If lblnextop.Text = "" OrElse lblnextop.Text = "0" Then
            txtqtymoved.Text = "0"
        ElseIf txt_cntrl_pt.Text = 1
            txtqtymoved.Text = total
        Else
            txtqtymoved.Text = "0"
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

    Private Function getlatestseq() As Integer
        Dim latestseq As Integer = 0

        Try
            Using con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
                con.Open()
                Dim cmd As SqlCommand = New SqlCommand("SELECT MAX(seq) as Seq from sfms_jobtran where trans_type = 'M' AND job=@job AND Suffix=@suffix AND oper_num=@opernum", con)

                cmd.Parameters.AddWithValue("@job", txtjob.Text)
                cmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
                cmd.Parameters.AddWithValue("opernum", txtopernum.Text)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    latestseq = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'con.Close()
        End Try
        Return latestseq
    End Function
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            con.Open()

            If txtjob.Text.Length = 10 And txtjob.Text.Length >= 1 And txtopernum.Text.Length >= 1 Then

                Dim wc As String() = txtwc.Text.Split(" "c)

                Dim startTime As DateTime


                Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second

                Dim insertcmd As SqlCommand = New SqlCommand("INSERT INTO sfms_jobtran (
                    [Select],
                    Job,
                    Suffix,
                    oper_num,
                    trans_type,
                    trans_date,
                    seq,
                    qty_complete,
                    qty_scrapped,
                    a_hrs,
                    next_oper,
                    emp_num,
                    qty_moved,
                    U_M,
                    whse,
                    loc,
                    lot,
                    shift,
                    reason_code,
                    wc,
                    wcdesc,
                    UF_Jobtran_TransactionType,
                    UF_Jobtran_Machine,
                    UF_Jobtran_Output,
                    UF_Jobtran_Rework,
                    UF_Jobtran_DocNum,
                    Status,
                    Createdby,
                    Createdate
                    )
                VALUES
                    (
                    0,
                    @job,
                    @suffix,
                    @opernum,
                    'M',
                    @transdate,
                    @seq,
                    @qtycomplete,
                    @qtyscrapped,
                    0,
                    @nextoper,
                    @empnum,
                    @qtymoved,
                    @um,
                    @whse,
                    @loc,
                    @lot,
                    @shift,
                    @reasoncode,
                    @wc,
                    @wcdesc,
                    @reasondesc,
                    @jobmachine,
                    @output,
                    @rework,
                    @docnum,
                    'U',
                    @createdby,
                    @createdate
                    )", con)

                insertcmd.Parameters.AddWithValue("@job", txtjob.Text)
                insertcmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
                insertcmd.Parameters.AddWithValue("@opernum", txtopernum.Text)
                Dim transdate As DateTime = DateTime.Now
                insertcmd.Parameters.AddWithValue("@transdate", transdate)
                insertcmd.Parameters.AddWithValue("@qtycomplete", CInt(txtqtycompleted.Text))
                insertcmd.Parameters.AddWithValue("@qtyscrapped", CInt(txtqtyscrapped.Text))
                insertcmd.Parameters.AddWithValue("@nextoper", lblnextop.Text)
                insertcmd.Parameters.AddWithValue("@empnum", lblempnum.Text)
                insertcmd.Parameters.AddWithValue("@whse", lblwhse.Text)

                'Dim qtyCompleted As Integer
                'If Integer.TryParse(txtqtycompleted.Text, qtyCompleted) AndAlso qtyCompleted > 0 AndAlso CInt(txtqtymoved.Text) = 0 Then
                '    insertcmd.Parameters.AddWithValue("@loc", "STOCK")
                'Else
                '    insertcmd.Parameters.AddWithValue("@loc", DBNull.Value)
                'End If

                'Dim qtyCompleted As Integer
                'If Integer.TryParse(txtqtycompleted.Text, qtyCompleted) Then
                '    If qtyCompleted > 0 AndAlso CInt(txtqtymoved.Text) = 0 Then
                '        insertcmd.Parameters.AddWithValue("@loc", "STOCK")
                '    Else
                '        insertcmd.Parameters.AddWithValue("@loc", DBNull.Value)
                '    End If
                'End If
                If CInt(txtqtycompleted.Text) > 0 AndAlso CInt(txtqtymoved.Text) = 0 Then
                    insertcmd.Parameters.AddWithValue("@loc", "STOCK")
                Else
                    insertcmd.Parameters.AddWithValue("@loc", DBNull.Value)
                End If

                Dim latestseq As Integer = getlatestseq()

                latestseq += 1
                insertcmd.Parameters.AddWithValue("@seq", latestseq)

                If cmbreasoncode.Text = "" Then
                    insertcmd.Parameters.AddWithValue("@reasoncode", DBNull.Value)
                Else
                    insertcmd.Parameters.AddWithValue("@reasoncode", cmbreasoncode.Text)
                End If
                insertcmd.Parameters.AddWithValue("@reasondesc", DBNull.Value)
                insertcmd.Parameters.AddWithValue("@lot", txtlot.Text)
                insertcmd.Parameters.AddWithValue("@shift", lblshift.Text)
                insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
                insertcmd.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
                insertcmd.Parameters.AddWithValue("@um", lblum4.Text)
                'insertcmd.Parameters.AddWithValue("@jobtranstype", rtbmach.Text)
                insertcmd.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
                insertcmd.Parameters.AddWithValue("@qtymoved", CInt(txtqtymoved.Text))
                insertcmd.Parameters.AddWithValue("@output", CInt(txtqtygood.Text))
                insertcmd.Parameters.AddWithValue("@rework", CInt(txtqtyrework.Text))

                If txt_docnum.Text = "" Then
                    insertcmd.Parameters.AddWithValue("@docnum", DBNull.Value)
                Else
                    insertcmd.Parameters.AddWithValue("@docnum", txt_docnum.Text)
                End If

                'insertcmd.Parameters.Add
                'insertcmd.Parameters.AddWithValue("@jobrework", rtbmach.Text)
                insertcmd.Parameters.AddWithValue("@createdby", lblempnum.Text)
                insertcmd.Parameters.AddWithValue("@createdate", DateTime.Now)

                If CInt(txtqtyscrapped.Text) > 0 AndAlso cmbreasoncode.SelectedIndex = -1 Then

                    MsgBox("Reason Code is Required")
                    cmbreasoncode.Focus()
                Else

                    If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
                        If txtlot.Text <> "" Then
                            'txtopernum.Clear()
                            insertcmd.ExecuteNonQuery()
                            MsgBox("Saved Successfully")
                            txtqtygood.Focus()

                            'txtwc.Clear()
                            ' txtwcdesc.Clear()
                            ' rtbmach.Clear()
                            txtqtygood.Text = 0
                            txtqtyrework.Text = 0
                            txtqtycompleted.Text = 0
                            txtqtyscrapped.Text = 0
                            ' txtlot.Text = 0
                            txtqtymoved.Text = 0
                            txtlot.ReadOnly = False
                            ' lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                            ' lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())

                            'btnpost.Enabled = True
                            ' txtjob.Clear()
                            ' txtsuffix.Clear()
                            ' txtopernum.Clear()
                            btnsave.Enabled = True

                        Else
                            MsgBox("Lot is Required")
                        End If
                    Else
                        'txtopernum.Clear()
                        insertcmd.ExecuteNonQuery()
                        MsgBox("Saved Successfully")
                        txtqtygood.Focus()
                        txtlot.ReadOnly = True
                        ' txtwc.Clear()
                        ' txtwcdesc.Clear()
                        ' rtbmach.Clear()
                        txtqtygood.Text = 0
                        txtqtyrework.Text = 0
                        txtqtycompleted.Text = 0
                        txtqtyscrapped.Text = 0
                        '  txtlot.Text = 0
                        txtqtymoved.Text = 0
                        'lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                        ' lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())

                        'btnpost.Enabled = True
                        ' txtjob.Clear()
                        '  txtsuffix.Clear()
                        ' txtopernum.Clear()
                        txt_docnum.Clear()
                        btnsave.Enabled = True
                    End If
                End If

            Else
                MsgBox("Invalid")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnpost_Click(sender As Object, e As EventArgs) Handles btnpost.Click
        Dim cmdreadsfms As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job=@job And suffix=@suffix And oper_num=@opernum And emp_num=@empnum And Trans_type = 'M' AND shift=@shift AND CONVERT(varchar, trans_date, 120) LIKE @transdate + '%'", con)
        cmdreadsfms.Parameters.AddWithValue("@job", txtjob.Text)
        cmdreadsfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdreadsfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
        cmdreadsfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
        'cmdreadsfms.Parameters.AddWithValue("@starttime", lblstartint.Text)
        'cmdreadsfms.Parameters.AddWithValue("@endtime", lblendint.Text)
        cmdreadsfms.Parameters.AddWithValue("@shift", lblshift.Text)
        Dim transdatestring As String = dtptransdate.ToString("yyyy-MM-dd HH:mm:ss")
        'Dim transdatestring As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
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
            MsgBox(transdatestring)

            cmdupdatesfms.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub

    Private Sub txtjob_TextChanged(sender As Object, e As EventArgs) Handles txtjob.TextChanged
        populate_details()
    End Sub

    Private Sub txtsuffix_TextChanged(sender As Object, e As EventArgs) Handles txtsuffix.TextChanged
        populate_details()
    End Sub


End Class