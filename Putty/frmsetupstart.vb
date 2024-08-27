Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmsetupstart

    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblstarttime.Text = Now.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper()
        lbltransdate.Text = Now.ToString("MM/dd/yyyy")
        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")
        lblempnum.Text = userid
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SFMSMENU.lblshift.Text = lblshift.Text
        SFMSMENU.Show()
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = Date.Now.ToString("hh:mm:ss tt").ToUpper()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
        Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")

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

        'AND CAST(trans_date AS DATE) = @transdate
        Dim cmdcheckpending As SqlCommand = New SqlCommand("Select * from sfms_jobtran where job = @job AND Suffix = @suffix AND oper_num = @opernum AND emp_num=@empnum AND end_time IS NULL AND trans_type = 'S' ", con)
        cmdcheckpending.Parameters.AddWithValue("@job", txtjob.Text)
        cmdcheckpending.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        cmdcheckpending.Parameters.AddWithValue("@opernum", txtopernum.Text)
        cmdcheckpending.Parameters.AddWithValue("@transdate", lbltransdate.Text)
        cmdcheckpending.Parameters.AddWithValue("@empnum", lblempnum.Text)

        Try
            con.Open()
            con1.Open()
            'And txtjob.Text.Length <= 9 And txtsuffix.Text.Length <= 0 
            'If txtopernum.Text.Length <= 1 Or txtjob.Text.Length <= 9 Then
            '    txtwc.Clear()
            '    txtwcdesc.Clear()
            '    rtbmach.Clear()
            '    cmbsetuptype.SelectedIndex = -1
            '    lblsetupdesc.Text = If(cleartext() = 0, "", cleartext().ToString())
            'End If

            Dim readsfms As SqlDataReader = cmdcheckpending.ExecuteReader
            If readsfms.HasRows Then
                frmsetupend.txtjob.Text = txtjob.Text
                frmsetupend.txtsuffix.Text = txtsuffix.Text
                frmsetupend.lblempnum.Text = lblempnum.Text
                MsgBox("Setup is still on process!")
                frmsetupend.Show()
                frmsetupend.txtopernum.Text = txtopernum.Text
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
                    End If
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

            If txtjob.Text.Length = 10 And txtjob.Text.Length >= 1 And txtopernum.Text.Length > 1 Then

                Dim wc As String() = txtwc.Text.Split(" "c)

                'Dim startTime As DateTime = DateTime.Parse(lblstarttime.Text)
                Dim startTime As DateTime

                If DateTime.TryParseExact(lblstarttime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, startTime) Then
                    Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second


                    ' Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second

                    Dim insertcmd As SqlCommand = New SqlCommand("INSERT INTO sfms_jobtran
                        ([Select],
                        JOB,
                        Suffix,
                        oper_num,
                        trans_type,
                        trans_date,
                        qty_complete,
                        qty_scrapped,
                        a_hrs,
                        emp_num,
                        start_datetime,
                        start_time,
                        qty_moved,
                        whse,
                        shift,
                        wc,
                        wcdesc,
                        Uf_Jobtran_TransactionType,
                        UF_Jobtran_Machine,
                        UF_Jobtran_Output,
                        UF_Jobtran_Rework,
                        Status,
                        Createdby,
                        Createdate
                        )
                  VALUES
                        (0,
                        @job,
                        @suffix,
                        @opernum,
                        @transtype,
                        @transdate,
                        @qtycomplete,
                        @qtyscrapped,
                        @ahrs,
                        @empnum,
                        @startdatetime,
                        @starttime,
                        @qtymoved,
                        @whse,
                        @shift,
                        @wc,
                        @wcdesc,
                        @jobtranstype,
                        @jobmachine,
                        @joboutput,
                        @jobrework,
                        'U',
                        @createdby,
                        @createdate
                        )", con)

                    insertcmd.Parameters.AddWithValue("@job", txtjob.Text)
                    insertcmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
                    insertcmd.Parameters.AddWithValue("@opernum", txtopernum.Text)
                    insertcmd.Parameters.AddWithValue("@transtype", "S")
                    Dim transdate As DateTime = DateTime.Now
                    insertcmd.Parameters.AddWithValue("@transdate", transdate)
                    insertcmd.Parameters.AddWithValue("@qtycomplete", 0)
                    insertcmd.Parameters.AddWithValue("@qtyscrapped", 0)
                    insertcmd.Parameters.AddWithValue("@ahrs", 0)
                    insertcmd.Parameters.AddWithValue("@empnum", lblempnum.Text)
                    insertcmd.Parameters.AddWithValue("@startdatetime", lblstarttime.Text)
                    insertcmd.Parameters.AddWithValue("@starttime", startTimeInt)
                    'insertcmd.Parameters.AddWithValue("@endtime", endTimeInt)
                    insertcmd.Parameters.AddWithValue("@qtymoved", 0)
                    insertcmd.Parameters.AddWithValue("@whse", lblwhse.Text)
                    insertcmd.Parameters.AddWithValue("@shift", lblshift.Text)
                    'insertcmd.Parameters.AddWithValue("@reasoncode", cmbsetuptype.Text)
                    insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
                    'insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
                    insertcmd.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
                    insertcmd.Parameters.AddWithValue("@jobtranstype", cmbsetuptype.Text)
                    insertcmd.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
                    insertcmd.Parameters.AddWithValue("@joboutput", 0)
                    insertcmd.Parameters.AddWithValue("@jobrework", 0)
                    insertcmd.Parameters.AddWithValue("@createdby", lblempnum.Text)
                    insertcmd.Parameters.AddWithValue("@createdate", DateTime.Now)

                    If cmbsetuptype.Text = "" Then
                        MsgBox("Setup Type Required!")
                    Else
                        insertcmd.ExecuteNonQuery()
                        MsgBox("SAVED SUCCESSFULLY")
                        btnsetupend.Enabled = True
                        btnsave.Enabled = False
                    End If
                Else
                    btnsetupend.Enabled = False
                    btnsave.Enabled = True
                    MsgBox("Invalid")
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

    Private Sub btnendsetup_Click(sender As Object, e As EventArgs) Handles btnsetupend.Click

        frmsetupend.txtjob.Text = txtjob.Text
        frmsetupend.txtsuffix.Text = txtsuffix.Text
        ' MsgBox("Setup is still on process!")
        frmsetupend.Show()
        frmsetupend.lblempnum.Text = lblempnum.Text
        frmsetupend.txtopernum.Text = txtopernum.Text
        Me.Close()

    End Sub

    Private Sub cmbsetuptype_DropDown(sender As Object, e As EventArgs) Handles cmbsetuptype.DropDown
        cmbsetuptype.Items.Clear()
        setupcodewithdescription()
    End Sub

    Private Sub setupcodewithdescription()
        Dim cmd As New SqlCommand("Select * from Ptag_Setuptype", con)

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

End Class
