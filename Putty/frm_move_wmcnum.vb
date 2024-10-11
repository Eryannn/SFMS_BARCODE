Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization
Public Class frm_move_wmcnum
    Private Sub frm_move_wmcnum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_date.Text = Date.Now.ToString("MM/dd/yyyy")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim saved As Boolean

        If CInt(txt_qtyscrap.Text) > 0 AndAlso cmb_reasoncode.SelectedIndex = -1 Then

            MsgBox("Reason Code is Required")
            cmb_reasoncode.Focus()
        Else

            If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse
                txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" _
                OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" _
                OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" _
                OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" _
                OrElse txtwc.Text = "M924" Then
                If txt_lot.Text <> "" Then
                    Insert_sfms_jobtran()
                    'MsgBox("Saved Successfully")
                    saved = True
                    txt_qtygood.Focus()
                    txt_qtygood.Text = 0
                    txt_qtyrework.Text = 0
                    txt_qtycomplete.Text = 0
                    txt_qtyscrap.Text = 0
                    txt_qtymove.Text = 0
                    txt_qtyredtags.Text = 0
                    btn_save.Enabled = True
                Else
                    MsgBox("Lot is Required")
                    saved = False
                End If
            Else
                Insert_sfms_jobtran()
                ' MsgBox("Saved Successfully")
                saved = True
                txt_qtygood.Focus()
                txt_qtygood.Text = 0
                txt_qtyrework.Text = 0
                txt_qtycomplete.Text = 0
                txt_qtyscrap.Text = 0
                txt_qtymove.Text = 0
                txt_qtyredtags.Text = 0
                txt_mcnum.Clear()
                btn_save.Enabled = True
            End If
        End If

        If saved Then
            MsgBox("Saved Successfully")
        Else
            MsgBox("Invalid ")
        End If

    End Sub

    Private Sub Insert_sfms_jobtran()
        Try
            Dim latestseq As Integer = getlatestseq()
            con.Open()

            Dim cmd_insert As New SqlCommand("Insert_sfms_jobtran_wmcnum", con)
            cmd_insert.CommandType = CommandType.StoredProcedure
            cmd_insert.Parameters.AddWithValue("@job", txt_job.Text)
            cmd_insert.Parameters.AddWithValue("@suffix", txt_suffix.Text)
            cmd_insert.Parameters.AddWithValue("@opernum", txt_opernum.Text)
            cmd_insert.Parameters.AddWithValue("@transdate", Date.Now)
            latestseq += 1
            cmd_insert.Parameters.AddWithValue("@seq", latestseq)
            cmd_insert.Parameters.AddWithValue("@qtycomplete", CInt(txt_qtycomplete.Text))
            cmd_insert.Parameters.AddWithValue("@qtyscrapped", CInt(txt_qtyscrap.Text))
            cmd_insert.Parameters.AddWithValue("@qtyredtags", CInt(txt_qtyredtags.Text))
            cmd_insert.Parameters.AddWithValue("@nextoper", lbl_nextop.Text)
            cmd_insert.Parameters.AddWithValue("@empnum", lbl_empnum.Text)
            cmd_insert.Parameters.AddWithValue("@qtymoved", CInt(txt_qtymove.Text))
            cmd_insert.Parameters.AddWithValue("@um", lbl_um_qtycomplete.Text)
            cmd_insert.Parameters.AddWithValue("@whse", lblwhse.Text)
            If CInt(txt_qtycomplete.Text) > 0 AndAlso CInt(txt_qtymove.Text) = 0 Then
                cmd_insert.Parameters.AddWithValue("@loc", "STOCK")
            Else
                cmd_insert.Parameters.AddWithValue("@loc", DBNull.Value)
            End If

            cmd_insert.Parameters.AddWithValue("@lot", txt_lot.Text)
            cmd_insert.Parameters.AddWithValue("@shift", login_shift)
            cmd_insert.Parameters.AddWithValue("@reasoncode", cmb_reasoncode.Text)
            cmd_insert.Parameters.AddWithValue("@wc", txtwc.Text)
            cmd_insert.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
            If cmb_reasoncode.Text = "" Then
                cmd_insert.Parameters.AddWithValue("@reasondesc", DBNull.Value)
            Else
                cmd_insert.Parameters.AddWithValue("@reasondesc", cmb_reasoncode.Text)
            End If

            'cmd_insert.Parameters.AddWithValue("@reasondesc", DBNull.Value)
            cmd_insert.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
            cmd_insert.Parameters.AddWithValue("@output", CInt(txt_qtygood.Text))
            cmd_insert.Parameters.AddWithValue("@rework", CInt(txt_qtyrework.Text))

            If txt_mcnum.Text = "" Then
                cmd_insert.Parameters.AddWithValue("@mcnum", DBNull.Value)
            Else
                cmd_insert.Parameters.AddWithValue("@mcnum", txt_mcnum.Text)
            End If

            cmd_insert.Parameters.AddWithValue("@createdby", lbl_empnum.Text)
            cmd_insert.Parameters.AddWithValue("@createdate", Date.Now)

            cmd_insert.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function getlatestseq()
        Dim latestseq As Integer = 0

        Try
            Using con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")

                Dim cmd As New SqlCommand("SELECT MAX(seq) as Seq from sfms_jobtran where trans_type = 'M' AND job=@job AND Suffix=@suffix AND oper_num=@opernum", con)

                cmd.Parameters.AddWithValue("@job", txt_job.Text)
                cmd.Parameters.AddWithValue("@suffix", txt_suffix.Text)
                cmd.Parameters.AddWithValue("opernum", txt_opernum.Text)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    latestseq = Convert.ToInt32(result)
                End If

            End Using
        Catch ex As Exception

        End Try
        Return latestseq
    End Function

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        SFMSMENU.Show()
        Me.Close()
    End Sub

    Private Sub txt_opernum_TextChanged(sender As Object, e As EventArgs) Handles txt_opernum.TextChanged
        populate_details()
    End Sub

    Private Sub populate_details()
        Dim cmdwc As SqlCommand = New SqlCommand("select top 1 jrt.job,jrt.suffix,jrt.oper_num,jrt.wc ,wc.description,job.whse
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
        cmdwc.Parameters.AddWithValue("@jonumber", txt_job.Text)
        cmdwc.Parameters.AddWithValue("@josuffix", txt_suffix.Text)
        cmdwc.Parameters.AddWithValue("@operationnum", txt_opernum.Text)

        Dim cmdmach As SqlCommand = New SqlCommand("SELECT jrtrg.job, jrtrg.suffix,jrtrg.oper_num,res.RESID,res.DESCR
                        from jrtresourcegroup jrtrg inner join RGRPMBR000 rg on jrtrg.rgid=rg.rgid
                        inner join RESRC000 res on  rg.RESID=res.RESID where jrtrg.job=@jonumber and jrtrg.suffix = @josuffix and jrtrg.oper_num=@operationnum", con1)
        cmdmach.Parameters.AddWithValue("@jonumber", txt_job.Text)
        cmdmach.Parameters.AddWithValue("@josuffix", txt_suffix.Text)
        cmdmach.Parameters.AddWithValue("@operationnum", txt_opernum.Text)

        Dim cmdcheckpending As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job = @job AND Suffix = @suffix AND oper_num = @opernum AND trans_type='M' AND emp_num=@empnum AND status='U'", con)
        cmdcheckpending.Parameters.AddWithValue("@job", txt_job.Text)
        cmdcheckpending.Parameters.AddWithValue("@suffix", txt_suffix.Text)
        cmdcheckpending.Parameters.AddWithValue("@opernum", txt_opernum.Text)
        'cmdcheckpending.Parameters.AddWithValue("@transdate", lbltransdate.Text) AND CAST(trans_date AS DATE) = @transdate
        cmdcheckpending.Parameters.AddWithValue("@empnum", lbl_empnum.Text)


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
        cmd_get_cntrlpt_nextop.Parameters.AddWithValue("@jonumber", txt_job.Text)
        cmd_get_cntrlpt_nextop.Parameters.AddWithValue("@josuffix", txt_suffix.Text)
        cmd_get_cntrlpt_nextop.Parameters.AddWithValue("@operationnum", txt_opernum.Text)

        Dim cmdum As SqlCommand = New SqlCommand("SELECT top 1 job.job, job.suffix, job.qty_released, job.description, job.whse, item.item, item.u_m FROM jobroute jr
                        LEFT JOIN job on jr.job = job.job AND
                        jr.suffix = job.suffix
                        AND job.type = 'J'
                        AND job.stat = 'R'
                        INNER JOIN item on job.item = item.item
                        where jr.job = @job AND
                        jr.suffix = @suffix", con1)
        cmdum.Parameters.AddWithValue("@job", txt_job.Text)
        cmdum.Parameters.AddWithValue("@suffix", txt_suffix.Text)


        Try
            con.Open()
            con1.Open()

            If txt_opernum.Text.Length <= 0 Then
                cleartext()
            Else
                btn_save.Enabled = True
            End If


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
                    txt_lot.Text = txt_job.Text + "-1"
                    Dim readnextop As SqlDataReader = cmd_get_cntrlpt_nextop.ExecuteReader
                    If readnextop.HasRows Then
                        While readnextop.Read
                            lbl_nextop.Text = readnextop("next_op").ToString
                            txt_cntrl_pt.Text = readnextop("cntrl_point").ToString
                        End While
                        readnextop.Close()
                        txt_qtygood.Text = 0
                        txt_qtyrework.Text = 0
                        txt_qtyscrap.Text = 0
                        txt_qtycomplete.Text = 0
                        Dim readum As SqlDataReader = cmdum.ExecuteReader
                        If readum.HasRows Then
                            While readum.Read
                                lbl_um_qtygood.Text = readum("u_m").ToString
                                lbl_um_qtyrework.Text = readum("u_m").ToString
                                lbl_um_qtycomplete.Text = readum("u_m").ToString
                                lbl_um_qtymove.Text = readum("u_m").ToString
                                lbl_um_qtyredtags.Text = readum("u_m").ToString
                                lbl_um_qtyscrap.Text = readum("u_m").ToString
                            End While
                            readum.Close()
                        End If
                    End If
                End If
            Else
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lbl_nextop.Text = ""
                lblwhse.Text = ""

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

    Private Sub cleartext()
        txtwc.Clear()
        txtwcdesc.Clear()
        rtbmach.Clear()
        txt_cntrl_pt.Clear()
        txt_qtygood.Text = 0
        txt_qtyrework.Text = 0
        txt_qtycomplete.Text = 0
        txt_qtyredtags.Text = 0
        txt_qtyscrap.Text = 0
        cmb_reasoncode.SelectedIndex = -1
        lbl_reason_desc.Text = ""
        txt_qtymove.Text = 0
        txt_lot.Clear()
        txt_mcnum.Clear()
        lbl_um_qtycomplete.Text = ""
        lbl_um_qtygood.Text = ""
        lbl_um_qtyrework.Text = ""
        lbl_um_qtyredtags.Text = ""
        lbl_um_qtyscrap.Text = ""
        lbl_um_qtymove.Text = ""
    End Sub

    Private Sub txt_suffix_TextChanged(sender As Object, e As EventArgs) Handles txt_suffix.TextChanged
        populate_details()
    End Sub

    Private Sub txt_job_TextChanged(sender As Object, e As EventArgs) Handles txt_job.TextChanged
        populate_details()
    End Sub

    Private Sub cmb_reasoncode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_reasoncode.SelectedIndexChanged
        Dim cmd As New SqlCommand("select reason_class, reason_code, description, reason_code + ' / ' + description as codeanddesc from reason where (reason_code + ' / ' + description) = @code", con1)

        cmd.Parameters.AddWithValue("@code", cmb_reasoncode.Text)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                lbl_reason_desc.Text = readcmd("description").ToString
                Dim codeanddesc As String = readcmd("reason_code")
                cmb_reasoncode.Items.Add(codeanddesc)
                cmb_reasoncode.Text = readcmd("reason_code").ToString

            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub cmb_reasoncode_DropDown(sender As Object, e As EventArgs) Handles cmb_reasoncode.DropDown
        cmb_reasoncode.Items.Clear()
        reasoncodewithdesc()
    End Sub

    Private Sub reasoncodewithdesc()
        Dim cmd As New SqlCommand("Select * from reason", con1)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                Dim codeanddesc As String = readcmd("reason_code") + " / " + readcmd("description")
                cmb_reasoncode.Items.Add(codeanddesc)
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub txt_qtyscrap_TextChanged(sender As Object, e As EventArgs) Handles txt_qtyscrap.TextChanged

        If String.IsNullOrEmpty(txt_qtyscrap.Text) Then
            txt_qtyscrap.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txt_qtyscrap.Text, qtyScrapped) Then
                txt_qtyscrap.Text = qtyScrapped.ToString("n0")
                txt_qtyscrap.Select(txt_qtyscrap.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        If CInt(txt_qtyscrap.Text) <= 0 Then
            cmb_reasoncode.Enabled = False
            cmb_reasoncode.SelectedIndex = -1
            cmb_reasoncode.Text = ""
            lbl_reason_desc.Text = ""
        Else
            cmb_reasoncode.Enabled = True
        End If

    End Sub

    Private Sub txt_qtygood_TextChanged(sender As Object, e As EventArgs) Handles txt_qtygood.TextChanged
        Dim totalqtycompleted As Integer
        If String.IsNullOrEmpty(txt_qtygood.Text) Then
            txt_qtygood.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txt_qtygood.Text, qtyScrapped) Then
                txt_qtygood.Text = qtyScrapped.ToString("n0")
                txt_qtygood.Select(txt_qtygood.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        If txt_qtygood IsNot Nothing AndAlso Not String.IsNullOrEmpty(txt_qtygood.Text) AndAlso IsNumeric(txt_qtygood.Text) Then
            If txt_qtyrework IsNot Nothing AndAlso Not String.IsNullOrEmpty(txt_qtyrework.Text) AndAlso IsNumeric(txt_qtyrework.Text) Then
                totalqtycompleted = (CInt(txt_qtygood.Text) + CInt(txt_qtyrework.Text)).ToString()
                txt_qtycomplete.Text = (CInt(txt_qtygood.Text) + CInt(txt_qtyrework.Text)).ToString()
            End If
        End If

        If lbl_nextop.Text = "" OrElse lbl_nextop.Text = "0" Then
            txt_qtymove.Text = "0"
        ElseIf txt_cntrl_pt.Text = 1
            txt_qtymove.Text = totalqtycompleted
        Else
            txt_qtymove.Text = "0"
        End If
    End Sub

    Private Sub txt_qtyrework_TextChanged(sender As Object, e As EventArgs) Handles txt_qtyrework.TextChanged
        If String.IsNullOrEmpty(txt_qtyrework.Text) Then
            txt_qtyrework.Text = "0"
        Else
            Dim qtyScrapped As Double
            If Double.TryParse(txt_qtyrework.Text, qtyScrapped) Then
                txt_qtyrework.Text = qtyScrapped.ToString("n0")
                txt_qtyrework.Select(txt_qtyrework.Text.Length, 0)
            Else
                MsgBox("Invalid quantity scrapped value.")
            End If
        End If

        Dim total As Double
        total = CInt(txt_qtygood.Text) + CInt(txt_qtyrework.Text)
        txt_qtycomplete.Text = total

        If lbl_nextop.Text = "" OrElse lbl_nextop.Text = "0" Then
            txt_qtymove.Text = "0"
        ElseIf txt_cntrl_pt.Text = 1
            txt_qtymove.Text = total
        Else
            txt_qtymove.Text = "0"
        End If

    End Sub
End Class