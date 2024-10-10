Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmmachinestart

    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = SFMSMENU.lblempnum.Text


    Private Sub frmmachinestart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblstarttime.Text = Now.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper()
        lbltransdate.Text = Now.ToString("MM/dd/yyyy")
        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")
        lblshift.Text = frmlogin.cmbshift.Text
        Timer1.Enabled = True

        Dim getuserdetails As String = "select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SFMSMENU.lblshift.Text = lblshift.Text
        SFMSMENU.Show()
        frmmachineend.Close()
        Me.Close()

    End Sub

    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
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

        Dim cmdcheckpending As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job = @job AND Suffix = @suffix AND oper_num = @opernum AND end_time IS NULL AND trans_type='C' AND emp_num=@empnum ", con)
        cmdcheckpending.Parameters.AddWithValue("@job", txtjob.Text)
        cmdcheckpending.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdcheckpending.Parameters.AddWithValue("@opernum", txtopernum.Text)
        'cmdcheckpending.Parameters.AddWithValue("@transdate", lbltransdate.Text) AND CAST(trans_date AS DATE) = @transdate
        cmdcheckpending.Parameters.AddWithValue("@empnum", lblempnum.Text)

        'Dim cmdchecknextoperation As SqlCommand = New SqlCommand("select top 1 jrt.job,	jrt.suffix	,jrt.oper_num,	jrt.wc ,wc.description
        '                 from jobroute jrt
        '                 inner join wc on wc.wc=jrt.wc 
        '                 where jrt.job =@jonumber
        '                 and jrt.suffix=@josuffix
        '                 and jrt.oper_num>@operationnum
        '                 order by  jrt.oper_num ASC", con1)
        'cmdchecknextoperation.Parameters.AddWithValue("@jonumber", txtjob.Text)
        'cmdchecknextoperation.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
        'cmdchecknextoperation.Parameters.AddWithValue("@operationnum", txtopernum.Text)

        Dim cmdchecknextoperation As SqlCommand = New SqlCommand(" SELECT min(oper_num) as next_op FROM jobroute where job = @jonumber AND suffix = @josuffix AND oper_num > @operationnum", con1)
        cmdchecknextoperation.Parameters.AddWithValue("@jonumber", txtjob.Text)
        cmdchecknextoperation.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
        cmdchecknextoperation.Parameters.AddWithValue("@operationnum", txtopernum.Text)

        Try
            con.Open()
            con1.Open()

            If txtopernum.Text.Length <= 0 Then
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                lbllot.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblstartint.Text = If(cleartext() = 0, "", cleartext().ToString())
                lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())
            End If

            Dim readsfms As SqlDataReader = cmdcheckpending.ExecuteReader
            If readsfms.HasRows Then

                frmmachineend.txtjob.Text = txtjob.Text
                frmmachineend.txtsuffix.Text = txtsuffix.Text
                'MsgBox("Setup is still on process!")
                btnsave.Enabled = False
                frmmachineend.Show()
                frmmachineend.lblempnum.Text = userid
                frmmachineend.txtopernum.Text = txtopernum.Text
                Me.Close()
            Else
                readsfms.Close()
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
                        Dim readnextop As SqlDataReader = cmdchecknextoperation.ExecuteReader
                        If readnextop.HasRows Then
                            While readnextop.Read
                                lblnextop.Text = readnextop("next_op").ToString
                            End While
                            readnextop.Close()
                            lbllot.Text = txtjob.Text + "-1"

                        End If
                    End If
                Else
                    txtwc.Clear()
                    txtwcdesc.Clear()
                    rtbmach.Clear()
                    lblnextop.Text = If(cleartext() = 0, "", cleartext().ToString())
                    lbllot.Text = If(cleartext() = 0, "", cleartext().ToString())
                    lblstartint.Text = If(cleartext() = 0, "", cleartext().ToString())
                    lblwhse.Text = If(cleartext() = 0, "", cleartext().ToString())
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            con1.Close()
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Try
            con.Open()

            If txtjob.Text.Length = 10 And txtjob.Text.Length >= 1 And txtopernum.Text.Length >= 1 Then

                Dim wc As String() = txtwc.Text.Split(" "c)

                Dim startTime As DateTime

                If DateTime.TryParseExact(lblstarttime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, startTime) Then
                    Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second

                    Dim insertcmd As SqlCommand = New SqlCommand("INSERT INTO sfms_jobtran (
                    [Select],
                    Job,
                    Suffix,
                    oper_num,
                    trans_type,
                    trans_date,
                    qty_complete,
                    qty_scrapped,
                    a_hrs,
                    next_oper,
                    emp_num,
                    start_datetime,
                    start_time,
                    qty_moved,
                    whse,
                    lot,
                    shift,
                    wc,
                    wcdesc,
                    UF_Jobtran_Machine,
                    UF_Jobtran_Output,
                    UF_Jobtran_Rework,
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
                    'C',
                    @transdate,
                    0,
                    0,
                    0,
                    @nextoper,
                    @empnum,
                    @startdatetime,
                    @starttime,
                    0,
                    @whse,
                    @lot,
                    @shift,
                    @wc,
                    @wcdesc,
                    @jobmachine,
                    0,
                    0,
                    'U',
                    @createdby,
                    @createdate
                    )", con)

                    insertcmd.Parameters.AddWithValue("@job", txtjob.Text)
                    insertcmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
                    insertcmd.Parameters.AddWithValue("@opernum", txtopernum.Text)
                    Dim transdate As DateTime = DateTime.Now
                    insertcmd.Parameters.AddWithValue("@transdate", transdate)
                    insertcmd.Parameters.AddWithValue("@nextoper", lblnextop.Text)
                    insertcmd.Parameters.AddWithValue("@empnum", lblempnum.Text)
                    insertcmd.Parameters.AddWithValue("@startdatetime", lblstarttime.Text)
                    lblstartint.Text = startTimeInt
                    insertcmd.Parameters.AddWithValue("@starttime", startTimeInt)
                    insertcmd.Parameters.AddWithValue("@whse", lblwhse.Text)
                    insertcmd.Parameters.AddWithValue("@lot", lbllot.Text)
                    insertcmd.Parameters.AddWithValue("@shift", lblshift.Text)
                    insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
                    insertcmd.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
                    'insertcmd.Parameters.AddWithValue("@jobtranstype", rtbmach.Text)
                    insertcmd.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
                    'insertcmd.Parameters.Add
                    'insertcmd.Parameters.AddWithValue("@jobrework", rtbmach.Text)
                    insertcmd.Parameters.AddWithValue("@createdby", lblempnum.Text)
                    insertcmd.Parameters.AddWithValue("@createdate", DateTime.Now)


                    insertcmd.ExecuteNonQuery()

                    MsgBox("Saved Successfully")
                    btnsave.Enabled = False
                Else
                    MsgBox("Invalid")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("debugging")
        Finally
            con.Close()
        End Try



        'Dim startTime As DateTime = DateTime.Parse(lblstarttime.Text)

        'Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second
        'Try
        '    con.Open()


        '    Dim insertcmd As SqlCommand = New SqlCommand("INSERT INTO sfms_jobtran (
        '            Job,
        '            Suffix,
        '            oper_num,
        '            trans_type,

        '            qty_complete,
        '            qty_scrapped,
        '            a_hrs,
        '            emp_num,

        '            start_time,
        '            qty_moved,
        '            whse,
        '            lot,
        '            shift,
        '            wc,
        '            wcdesc,
        '            UF_Jobtran_Machine,
        '            Createdby,

        '            )
        '        VALUES
        '            (
        '            @job,
        '            @suffix,
        '            @opernum,
        '            'C',

        '            0,
        '            0,
        '            0,
        '            @empnum,

        '            @starttime,
        '            0,
        '            @whse,
        '            @lot,
        '            @shift,
        '            @wc,
        '            @wcdesc,
        '            @jobmachine,
        '            @createdby,

        '            )", con)




        '    insertcmd.Parameters.AddWithValue("@job", txtjob.Text)
        '    insertcmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        '    insertcmd.Parameters.AddWithValue("@opernum", txtopernum.Text)
        '    Dim transdate As DateTime = DateTime.Now
        '    'insertcmd.Parameters.AddWithValue("@transdate", transdate)@transdate,trans_date,
        '    insertcmd.Parameters.AddWithValue("@empnum", lblempnum.Text)
        '    'insertcmd.Parameters.AddWithValue("@startdatetime", lblstarttime.Text)@startdatetime,start_datetime,
        '    lblstartint.Text = startTimeInt
        '    insertcmd.Parameters.AddWithValue("@starttime", startTimeInt)
        '    insertcmd.Parameters.AddWithValue("@whse", lblwhse.Text)
        '    insertcmd.Parameters.AddWithValue("@lot", lbllot.Text)

        '    insertcmd.Parameters.AddWithValue("@shift", lblshift.Text)
        '    insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
        '    insertcmd.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
        '    'insertcmd.Parameters.AddWithValue("@jobtranstype", rtbmach.Text)
        '    insertcmd.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
        '    'insertcmd.Parameters.AddWithValue("@joboutput", rtbmach.Text)
        '    'insertcmd.Parameters.AddWithValue("@jobrework", rtbmach.Text)
        '    insertcmd.Parameters.AddWithValue("@createdby", lblempname.Text)
        '    'insertcmd.Parameters.AddWithValue("@createdate", DateTime.Now)@createdateCreatedate


        '    insertcmd.ExecuteNonQuery()

        '    MsgBox("Saved Successfully")

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    MsgBox("DEBUGGING")
        '    MsgBox(lblstarttime.Text)
        '    MsgBox(startTimeInt)
        'Finally
        '    con.Close()

        'End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmmachineend.txtjob.Text = txtjob.Text
        frmmachineend.txtsuffix.Text = txtsuffix.Text
        frmmachineend.Show()
        frmmachineend.lblempnum.Text = user_id
        lblempname.Text = user_name
        frmmachineend.txtopernum.Text = txtopernum.Text

        Me.Close()


    End Sub

    Private Sub lblempnum_Click(sender As Object, e As EventArgs) Handles lblempnum.Click

    End Sub
End Class