Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmdowntime
    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = SFMSMENU.lblempnum.Text

    Private Sub frmdowntime_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")
        lblshift.Text = frmlogin.cmbshift.Text
        lbldtdate.Text = Now.ToString("MM/dd/yyyy")
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

    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged


        If txtopernum.Text.Length <= 0 Then
            lblsection.Text = If(cleartext() = 0, "", cleartext().ToString())
            lblmachine.Text = If(cleartext() = 0, "", cleartext().ToString())
            lblwc.Text = If(cleartext() = 0, "", cleartext().ToString())
            lblwcdesc.Text = If(cleartext() = 0, "", cleartext().ToString())
            btnsave.Enabled = False
        End If


        Try
            con1.Open()

            Dim cmdchksource As SqlCommand = New SqlCommand("select 
		            job.job,
		            job.suffix,
		            job.oper_num,
		            job.wc,
		            wc.description,
		            resrc.Uf_Resrc_Section,
		            rgrp.RESID

            from jobroute job
            INNER JOIN jrtresourcegroup resource on 
		            job.job = resource.job AND
		            job.suffix = resource.suffix AND
		            job.oper_num = resource.oper_num
            INNER JOIN RGRPMBR000 rgrp on
		            resource.rgid = rgrp.RGID
            INNER JOIN RESRC000 resrc on
		            rgrp.RESID = resrc.RESID
            INNER JOIN wc on
		            job.wc = wc.wc
            WHERE
		            job.job = @job AND
		            job.suffix = @suffix AND
		            job.oper_num = @opernum", con1)

            cmdchksource.Parameters.AddWithValue("@job", txtjob.Text)
            cmdchksource.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdchksource.Parameters.AddWithValue("@opernum", txtopernum.Text)



            Dim cmdchkhdr As SqlCommand = New SqlCommand("
            SELECT 
                            dtheader.job, 
                            dtheader.Suffix, 
                            dtheader.OperNum, 
							dtheader.Section,
							dtheader.MachResc,
                            dtheader.rowpointer,
                            wc.wc, 
                            wc.description 
                FROM IT_KPI_DTHeader dtheader
                INNER JOIN jobroute ON dtheader.job = jobroute.job AND
                            dtheader.Suffix = jobroute.suffix AND
                            dtheader.OperNum = jobroute.oper_num
                INNER JOIN WC on jobroute.wc = wc.wc
                WHERE dtheader.job = @job AND
                dtheader.Suffix = @suffix AND
                dtheader.OperNum = @opernum", con1)

            cmdchkhdr.Parameters.AddWithValue("@job", txtjob.Text)
            cmdchkhdr.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdchkhdr.Parameters.AddWithValue("@opernum", txtopernum.Text)

            Dim cmdviewwc As SqlCommand = New SqlCommand("SELECT 
                            dtheader.job, 
                            dtheader.Suffix, 
                            dtheader.OperNum, 
                            wc.wc, 
                            wc.description 
                FROM IT_KPI_DTHeader dtheader
                INNER JOIN jobroute ON dtheader.job = jobroute.job AND
                            dtheader.Suffix = jobroute.suffix AND
                            dtheader.OperNum = jobroute.oper_num
                INNER JOIN WC on jobroute.wc = wc.wc
                WHERE dtheader.job = @job AND
                dtheader.Suffix = @suffix AND
                dtheader.OperNum = @opernum", con1)

            cmdviewwc.Parameters.AddWithValue("@job", txtjob.Text)
            cmdviewwc.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdviewwc.Parameters.AddWithValue("@opernum", txtopernum.Text)

            Dim cmdviewdt As SqlCommand = New SqlCommand("select 
		                job.job,
		                job.suffix,
		                job.oper_num,
		                job.wc,
		                wc.description,
		                resource.rgid,
		                rgrp.RESID
		
                from jobroute job
                INNER JOIN jrtresourcegroup resource on 
		                job.job = resource.job AND
		                job.suffix = resource.suffix AND
		                job.oper_num = resource.oper_num
                INNER JOIN RGRPMBR000 rgrp on
		                resource.rgid = rgrp.RGID
                INNER JOIN RESRC000 resrc on
		                rgrp.RESID = resrc.RESID
                INNER JOIN wc on
		                job.wc = wc.wc
                WHERE
		                job.job = @job AND
		                job.suffix = @suffix AND
		                job.oper_num = @opernum", con1)

            cmdviewdt.Parameters.AddWithValue("@job", txtjob.Text)
            cmdviewdt.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdviewdt.Parameters.AddWithValue("@opernum", txtopernum.Text)

            Dim readcmdchkhdr As SqlDataReader = cmdchkhdr.ExecuteReader
            If readcmdchkhdr.HasRows Then
                While readcmdchkhdr.Read
                    lblsection.Text = readcmdchkhdr("Section").ToString
                    lblmachine.Text = readcmdchkhdr("MachResc").ToString
                    lblwc.Text = readcmdchkhdr("wc").ToString
                    lblwcdesc.Text = readcmdchkhdr("description").ToString
                    frmdtdetails.txtrowpointer.Text = readcmdchkhdr("rowpointer").ToString
                End While
                readcmdchkhdr.Close()

                ' GET LAST SEQUENCE IN DT DETAIL

                ' Dim cmdgetlastseq As SqlCommand = New SqlCommand("SELECT MIN(Seq) as Sequence FROM IT_KPI_DTDetail where RefRowPointer = @rowpointer", con1)
                Dim cmdgetlastseq As SqlCommand = New SqlCommand("SELECT MAX(Seq) as Sequence FROM IT_KPI_DTDetail where RefRowPointer = @rowpointer AND DTHrs IS NULL", con1)
                cmdgetlastseq.Parameters.AddWithValue("@rowpointer", frmdtdetails.txtrowpointer.Text)

                Dim readlastseq As SqlDataReader = cmdgetlastseq.ExecuteReader

                ' DEBUGGING

                'Dim maxSeqResult As Object = cmdgetlastseq.ExecuteScalar()

                'If maxSeqResult Is DBNull.Value Then
                '    MessageBox.Show("No rows found.")
                'Else
                '    maxSeqResult.close
                '    Dim sequence As Integer = Convert.ToInt32(maxSeqResult)
                '    ' Process the sequence value here
                'End If

                ' END OF DEBUGGING

                If readlastseq.HasRows Then
                    While readlastseq.Read
                        frmdtdetails.lblseq.Text = readlastseq("Sequence").ToString
                    End While
                    readlastseq.Close()
                Else
                    readlastseq.Close()
                    frmdtdetails.lblseq.Text = ""
                End If

                ' END OF LINE

                frmdtdetails.txtempnum.Text = lblempnum.Text
                frmdtdetails.lblsection.Text = lblsection.Text
                btnsave.Enabled = False
                frmdtdetails.Show()

            Else

                readcmdchkhdr.Close()
                Dim readsource As SqlDataReader = cmdchksource.ExecuteReader
                If readsource.HasRows Then
                    While readsource.Read()
                        lblsection.Text = readsource("Uf_Resrc_Section").ToString.ToUpper
                        lblmachine.Text = readsource("RESID").ToString.ToUpper
                        lblwc.Text = readsource("wc").ToString
                        lblwcdesc.Text = readsource("description").ToString
                        ' frmdtdetails.txtrowpointer.Text = readcmdchkhdr("rowpointer").ToString
                    End While
                    btnsave.Enabled = True
                    readsource.Close()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SFMSMENU.Show()
        SFMSMENU.lblempnum.Text = lblempnum.Text
        SFMSMENU.lblempname.Text = lblempname.Text
        frmdtdetails.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            con1.Open()
            Dim updatehdr As String = "INSERT INTO IT_KPI_DTHeader (
                        Section, 
                        MachResc, 
                        DTDate, 
                        Shift,
                        Job,
                        Suffix,
                        OperNum,
                        CreatedBy)
                 values(
                         @section,
                         @machresc,
                         @dtdate,
                         @shift,
                         @job,
                         @suffix,
                         @opernum,
                         @empnum)"

            Dim cmd As New SqlCommand(updatehdr, con1)

            cmd.Parameters.AddWithValue("@section", lblsection.Text)
            cmd.Parameters.AddWithValue("@machresc", lblmachine.Text)
            cmd.Parameters.AddWithValue("@dtdate", lbldtdate.Text)
            cmd.Parameters.AddWithValue("@shift", lblshift.Text)
            cmd.Parameters.AddWithValue("@job", txtjob.Text)
            cmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmd.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmd.Parameters.AddWithValue("@empnum", lblempnum.Text)

            If txtopernum.Text = "" Then
                MsgBox("Invalid")
            Else
                If lblsection.Text = "" Then
                    MsgBox("Invalid")
                Else
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Saved Successfully")

                    frmdtdetails.txtempnum.Text = lblempnum.Text
                    frmdtdetails.lblsection.Text = lblsection.Text

                End If
            End If

            'frmdtdetails.Show()
        Catch ex As Exception
            '   MsgBox(ex.Message)
            '  MsgBox("debug")
        Finally
            con1.Close()
        End Try



        Try
            con1.Open()
            Dim cmdrowptr As SqlCommand = New SqlCommand(" SELECT 
                            dtheader.job, 
                            dtheader.Suffix, 
                            dtheader.OperNum, 
							dtheader.Section,
							dtheader.MachResc,
                            dtheader.rowpointer,
                            wc.wc, 
                            wc.description 
                FROM IT_KPI_DTHeader dtheader
                INNER JOIN jobroute ON dtheader.job = jobroute.job AND
                            dtheader.Suffix = jobroute.suffix AND
                            dtheader.OperNum = jobroute.oper_num
                INNER JOIN WC on jobroute.wc = wc.wc
                WHERE dtheader.job = @job AND
                dtheader.Suffix = @suffix AND
                dtheader.OperNum = @opernum", con1)

            cmdrowptr.Parameters.AddWithValue("@job", txtjob.Text)
            cmdrowptr.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdrowptr.Parameters.AddWithValue("@opernum", txtopernum.Text)

            Dim readcmdchkhdr As SqlDataReader = cmdrowptr.ExecuteReader
            If readcmdchkhdr.HasRows Then
                While readcmdchkhdr.Read
                    frmdtdetails.txtrowpointer.Text = readcmdchkhdr("rowpointer").ToString
                End While
                readcmdchkhdr.Close()
                'frmdtdetails.txtempname.Text = lblempname.Text
                'frmdtdetails.lblsection.Text = lblsection.Text
                ' GET LAST SEQUENCE IN DT DETAIL]

                Dim cmdgetlastseq As SqlCommand = New SqlCommand("SELECT MIN(Seq) as Sequence FROM IT_KPI_DTDetail where RefRowPointer = @rowpointer", con1)

                cmdgetlastseq.Parameters.AddWithValue("@rowpointer", frmdtdetails.txtrowpointer.Text)

                Dim readlastseq As SqlDataReader = cmdgetlastseq.ExecuteReader

                If readlastseq.HasRows Then
                    While readlastseq.Read
                        frmdtdetails.lblseq.Text = readlastseq("Sequence").ToString
                    End While
                    readlastseq.Close()
                Else
                    readlastseq.Close()
                    frmdtdetails.lblseq.Text = ""
                End If

                ' END OF LINE
                frmdtdetails.Show()

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try

        Try
            con1.Open()
            Dim cmdrowptr As SqlCommand = New SqlCommand("SELECT * FROM IT_KPI_DTHeader WHERE job = @job AND suffix = @suffix AND opernum=@opernum", con1)

            cmdrowptr.Parameters.AddWithValue("@job", txtjob.Text)
            cmdrowptr.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdrowptr.Parameters.AddWithValue("@opernum", txtopernum.Text)

            Dim readrowptr As SqlDataReader = cmdrowptr.ExecuteReader
            If readrowptr.HasRows Then
                While readrowptr.Read
                    frmdtdetails.txtrowpointer.Text = readrowptr("RowPointer").ToString
                End While
                readrowptr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try

        'If frmdtdetails.Visible Then
        '    MsgBox("Already saved")
        'End If

        Try
            con1.Open()

            Dim tablecmd As SqlCommand = New SqlCommand("SELECT dtdetail.Seq, dtdetail.StartTime, dtdetail.EndTime,CAST(DATEDIFF(MINUTE, dtdetail.StartTime, dtdetail.EndTime) / 60.0 AS DECIMAL(13, 9)) AS DTHrs, dtdetail.Category, dtdetail.CauseCode, dtcause.RootCause , Notes  from IT_KPI_DTDetail dtdetail
                LEFT JOIN IT_KPI_DTCausemaint dtcause on DTDETAIL.CauseCode = dtcause.CauseCode
                WHERE dtdetail.RefRowPointer = @refrowpointer", con1)
            tablecmd.Parameters.AddWithValue("@refrowpointer", frmdtdetails.txtrowpointer.Text)

            Dim insertcmd As New SqlCommand("INSERT INTO IT_KPI_DTDetail (RefRowPointer,Seq, Createdby) values (@refrowpointer,@seq,@createdby)", con1)
            Dim latestseq As Integer = getlatestsequence()

            insertcmd.Parameters.AddWithValue("@refrowpointer", frmdtdetails.txtrowpointer.Text)
            latestseq += 1
            insertcmd.Parameters.AddWithValue("@seq", latestseq)
            insertcmd.Parameters.AddWithValue("@createdby", lblempnum.Text)

            If txtopernum.Text = "" Then

            Else
                If lblsection.Text = "" Then

                Else
                    If frmdtdetails.lblseq.Text <> "" Then
                        MsgBox("Invalid")
                    Else

                        insertcmd.ExecuteNonQuery()
                        ' MsgBox(frmdtdetails.txtrowpointer.Text)
                        ' MsgBox("Sequence add successfully")
                        frmdtdetails.lblseq.Text = latestseq
                    End If
                End If


            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox("debugging here")
        Finally
            con1.Close()
        End Try

        Try
            con1.Open()
            Dim cmd_header_user As SqlCommand = New SqlCommand("update IT_KPI_DTHeader 
            set CreatedBy = @empnum
            WHERE job = @job AND
		            Suffix = @suffix AND
		            OperNum = @opernum
            ", con1)

            cmd_header_user.Parameters.AddWithValue("@empnum", lblempnum.Text)
            cmd_header_user.Parameters.AddWithValue("@job", txtjob.Text)
            cmd_header_user.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmd_header_user.Parameters.AddWithValue("@opernum", txtopernum.Text)

            If txtopernum.Text = "" Then
                'MsgBox("Invalid")
            Else
                If lblsection.Text = "" Then
                    'MsgBox("Invalid")
                Else
                    cmd_header_user.ExecuteNonQuery()
                End If
            End If




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try

        Try
            con1.Open()
            Dim cmd_detail_user As SqlCommand = New SqlCommand("update IT_KPI_DTDetail
            set CreatedBy=@empnum
            WHERE RefRowPointer = @rowpointer", con1)

            cmd_detail_user.Parameters.AddWithValue("empnum", lblempnum.Text)
            cmd_detail_user.Parameters.AddWithValue("rowpointer", frmdtdetails.txtrowpointer.Text)

            If txtopernum.Text = "" Then
                ' MsgBox("Invalid")
            Else
                If lblsection.Text = "" Then
                    'MsgBox("Invalid")
                Else
                    cmd_detail_user.ExecuteNonQuery()
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try
    End Sub

    Private Function getlatestsequence() As Integer
        Dim latestseq As Integer = 0

        Try
            Using con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
                con.Open()

                Using cmd As New SqlCommand("select max(seq) from IT_KPI_DTDetail where RefRowPointer = @refrowpointer", con)
                    cmd.Parameters.AddWithValue("@refrowpointer", frmdtdetails.txtrowpointer.Text)

                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        latestseq = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try

        Return latestseq
    End Function

End Class