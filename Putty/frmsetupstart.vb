Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmsetupstart

    'Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    'Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    'Dim userid As String = frmlogin.txtuserid.Text
    Dim startTime As DateTime
    Dim starttimeint As Integer



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblstarttime.Text = Now.ToString("MM/dd/yyyy hh:mm:ss tt").ToUpper()
        lbltransdate.Text = Now.ToString("MM/dd/yyyy")
        lbldate.Text = Date.Now.ToString("MM/dd/yyyy")
        lblempnum.Text = user_id
        lblempname.Text = user_name
        lblshift.Text = login_shift
        Timer1.Enabled = True

        'Dim getuserdetails As String = "select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        'Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        'cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        'Try
        '    con.Open()
        '    Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
        '    If readuserdetails.HasRows Then
        '        While readuserdetails.Read
        '            lblempname.Text = readuserdetails("Name").ToString
        '        End While
        '        readuserdetails.Close()
        '    End If
        'Catch ex As Exception
        'Finally
        '    con.Close()
        'End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SFMSMENU.lblshift.Text = lblshift.Text
        SFMSMENU.Show()
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = Date.Now.ToString("hh:mm:ss tt").ToUpper()
    End Sub

    Private Sub enable_save()
        If txtwc.Text <> "" AndAlso txtwcdesc.Text <> "" AndAlso rtbmach.Text <> "" AndAlso cmbsetuptype.Text <> "" AndAlso lblsetupdesc.Text <> "" Then
            btnsave.Enabled = True
        Else
            btnsave.Enabled = False
        End If
    End Sub
    Private Sub load_hdr()
        Try
            con.Open()

            Dim cmd_pisp As New SqlCommand("Select_pisp_sfms_jobtran", con)
            cmd_pisp.CommandType = CommandType.StoredProcedure
            cmd_pisp.Parameters.AddWithValue("@jonumber", txtjob.Text)
            cmd_pisp.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
            cmd_pisp.Parameters.AddWithValue("@operationnum", txtopernum.Text)



            Dim cmd_sfms_setup As New SqlCommand("Select_sfms_jobtran_setup", con)
            cmd_sfms_setup.CommandType = CommandType.StoredProcedure
            cmd_sfms_setup.Parameters.AddWithValue("@jonumber", txtjob.Text)
            cmd_sfms_setup.Parameters.AddWithValue("@josuffix", txtsuffix.Text)
            cmd_sfms_setup.Parameters.AddWithValue("@operationnum", txtopernum.Text)
            cmd_sfms_setup.Parameters.AddWithValue("@empnum", lblempnum.Text)

            If txtjob.Text.Length = 10 AndAlso txtsuffix.Text.Length <> 0 AndAlso txtopernum.Text.Length = 2 Then
                Dim read_sfms_setup As SqlDataReader
                read_sfms_setup = cmd_sfms_setup.ExecuteReader
                If read_sfms_setup.HasRows Then
                    While read_sfms_setup.Read

                        'frmsetupend.txtwc.Text = read_sfms_setup("wc").ToString
                        'frmsetupend.txtwcdesc.Text = read_sfms_setup("description").ToString
                        'frmsetupend.rtbmach.Text = read_sfms_setup("Machine").ToString
                        ''whse = read_sfms_setup("whse").ToString
                        'frmsetupend.lblcode.Text = read_sfms_setup("Uf_Jobtran_TransactionType").ToString
                        'frmsetupend.lblstarttime.Text = read_sfms_setup("start_datetime").ToString
                        'frmsetupend.lblempname.Text = user_name
                        'frmsetupend.Show()
                        'frmsetupend.txtjob.Text = txtjob.Text
                        'frmsetupend.txtsuffix.Text = txtsuffix.Text
                        'frmsetupend.txtopernum.Text = txtopernum.Text
                        'Me.Close()
                        frmsetupend.txtjob.Text = txtjob.Text
                        frmsetupend.txtsuffix.Text = txtsuffix.Text
                        frmsetupend.lblempnum.Text = lblempnum.Text
                        MsgBox("Setup is still on process!")
                        frmsetupend.Show()
                        frmsetupend.txtopernum.Text = txtopernum.Text
                        Me.Close()
                    End While
                    read_sfms_setup.Close()
                Else
                    read_sfms_setup.Close()
                    Dim read_cmd_pisp As SqlDataReader
                    read_cmd_pisp = cmd_pisp.ExecuteReader
                    While read_cmd_pisp.Read
                        txtwc.Text = read_cmd_pisp("wc").ToString
                        txtwcdesc.Text = read_cmd_pisp("description").ToString
                        lblwhse.Text = read_cmd_pisp("whse").ToString
                        rtbmach.Text = read_cmd_pisp("Machine").ToString
                    End While
                End If
            Else
                txtwc.Clear()
                txtwcdesc.Clear()
                rtbmach.Clear()
                cmbsetuptype.SelectedIndex = -1
                lblsetupdesc.Text = If(cleartext() = 0, "", cleartext().ToString())
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        load_hdr()
        enable_save()
    End Sub

    Private Sub save_sfms_setup()

        Dim startTime As DateTime

        If DateTime.TryParseExact(lblstarttime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, startTime) Then
            starttimeint = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second
            ' MsgBox(starttimeint)
        End If

        Try
            If txtjob.Text.Length = 10 And txtjob.Text.Length >= 1 And txtopernum.Text.Length >= 1 Then
                con.Open()
                joborder = txtjob.Text
                suffix = txtsuffix.Text
                operationnum = txtopernum.Text
                Dim cmd_insert As New SqlCommand("Insert_sfms_jobtran_setup", con)
                cmd_insert.CommandType = CommandType.StoredProcedure

                cmd_insert.Parameters.AddWithValue("@job", txtjob.Text)
                cmd_insert.Parameters.AddWithValue("@suffix", txtsuffix.Text)
                cmd_insert.Parameters.AddWithValue("@opernum", txtopernum.Text)
                cmd_insert.Parameters.AddWithValue("@transtype", "S")
                Dim transdate As DateTime = DateTime.Now
                cmd_insert.Parameters.AddWithValue("@transdate", transdate)
                cmd_insert.Parameters.AddWithValue("@qtycomplete", 0)
                cmd_insert.Parameters.AddWithValue("@qtyscrapped", 0)
                cmd_insert.Parameters.AddWithValue("@ahrs", 0)
                cmd_insert.Parameters.AddWithValue("@empnum", lblempnum.Text)
                cmd_insert.Parameters.AddWithValue("@startdatetime", lblstarttime.Text)
                cmd_insert.Parameters.AddWithValue("@starttime", starttimeint)
                'cmd_insert.Parameters.AddWithValue("@endtime", endTimeInt)
                cmd_insert.Parameters.AddWithValue("@qtymoved", 0)
                cmd_insert.Parameters.AddWithValue("@whse", lblwhse.Text)
                cmd_insert.Parameters.AddWithValue("@shift", lblshift.Text)
                'cmd_insert.Parameters.AddWithValue("@reasoncode", cmbsetuptype.Text)
                cmd_insert.Parameters.AddWithValue("@wc", txtwc.Text)
                'cmd_insert.Parameters.AddWithValue("@wc", txtwc.Text)
                cmd_insert.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
                cmd_insert.Parameters.AddWithValue("@jobtranstype", cmbsetuptype.Text)
                cmd_insert.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
                cmd_insert.Parameters.AddWithValue("@joboutput", 0)
                cmd_insert.Parameters.AddWithValue("@jobrework", 0)
                cmd_insert.Parameters.AddWithValue("@createdby", lblempnum.Text)
                cmd_insert.Parameters.AddWithValue("@createdate", DateTime.Now)

                cmd_insert.ExecuteNonQuery()
                MsgBox("SAVED SUCCESSFULLY")
                btnsetupend.Enabled = True
                btnsave.Enabled = False
            Else
                MsgBox("Invalid")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        check_update()
        If app_prev_version = app_version Then
            If cmbsetuptype.Text = "" Then
                MsgBox("Setup type required!")
            Else
                save_sfms_setup()
            End If
        End If

        'Try
        '    con.Open()
        '    Dim cmd_insert As New SqlCommand("Insert_sfms_jobtran_setup", con)
        '    cmd_insert.CommandType = CommandType.StoredProcedure

        '    cmd_insert.Parameters.AddWithValue("@job", txtjob.Text)
        '    cmd_insert.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        '    cmd_insert.Parameters.AddWithValue("@opernum", txtopernum.Text)
        '    cmd_insert.Parameters.AddWithValue("@transtype", "S")
        '    Dim transdate As DateTime = DateTime.Now
        '    cmd_insert.Parameters.AddWithValue("@transdate", transdate)
        '    cmd_insert.Parameters.AddWithValue("@qtycomplete", 0)
        '    cmd_insert.Parameters.AddWithValue("@qtyscrapped", 0)
        '    cmd_insert.Parameters.AddWithValue("@ahrs", 0)
        '    cmd_insert.Parameters.AddWithValue("@empnum", lblempnum.Text)
        '    cmd_insert.Parameters.AddWithValue("@startdatetime", lblstarttime.Text)
        '    cmd_insert.Parameters.AddWithValue("@starttime", startTimeInt)
        '    'cmd_insert.Parameters.AddWithValue("@endtime", endTimeInt)
        '    cmd_insert.Parameters.AddWithValue("@qtymoved", 0)
        '    cmd_insert.Parameters.AddWithValue("@whse", lblwhse.Text)
        '    cmd_insert.Parameters.AddWithValue("@shift", lblshift.Text)
        '    'cmd_insert.Parameters.AddWithValue("@reasoncode", cmbsetuptype.Text)
        '    cmd_insert.Parameters.AddWithValue("@wc", txtwc.Text)
        '    'cmd_insert.Parameters.AddWithValue("@wc", txtwc.Text)
        '    cmd_insert.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
        '    cmd_insert.Parameters.AddWithValue("@jobtranstype", cmbsetuptype.Text)
        '    cmd_insert.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
        '    cmd_insert.Parameters.AddWithValue("@joboutput", 0)
        '    cmd_insert.Parameters.AddWithValue("@jobrework", 0)
        '    cmd_insert.Parameters.AddWithValue("@createdby", lblempnum.Text)
        '    cmd_insert.Parameters.AddWithValue("@createdate", DateTime.Now)

        '    cmd_insert.ExecuteNonQuery()
        '    MsgBox("SAVED SUCCESSFULLY")
        '    btnsetupend.Enabled = True
        '    btnsave.Enabled = False

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try

        'Try
        '    con.Open()

        '    If txtjob.Text.Length = 10 And txtjob.Text.Length >= 1 And txtopernum.Text.Length > 1 Then

        '        Dim wc As String() = txtwc.Text.Split(" "c)

        '        'Dim startTime As DateTime = DateTime.Parse(lblstarttime.Text)
        '        Dim startTime As DateTime

        '        If DateTime.TryParseExact(lblstarttime.Text, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, startTime) Then
        '            Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second


        '            ' Dim startTimeInt As Integer = startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second

        '            Dim insertcmd As SqlCommand = New SqlCommand("INSERT INTO sfms_jobtran
        '                ([Select],
        '                JOB,
        '                Suffix,
        '                oper_num,
        '                trans_type,
        '                trans_date,
        '                qty_complete,
        '                qty_scrapped,
        '                a_hrs,
        '                emp_num,
        '                start_datetime,
        '                start_time,
        '                qty_moved,
        '                whse,
        '                shift,
        '                wc,
        '                wcdesc,
        '                Uf_Jobtran_TransactionType,
        '                UF_Jobtran_Machine,
        '                UF_Jobtran_Output,
        '                UF_Jobtran_Rework,
        '                Status,
        '                Createdby,
        '                Createdate
        '                )
        'VALUES
        '                (0,
        '                @job,
        '                @suffix,
        '                @opernum,
        '                @transtype,
        '                @transdate,
        '                @qtycomplete,
        '                @qtyscrapped,
        '                @ahrs,
        '                @empnum,
        '                @startdatetime,
        '                @starttime,
        '                @qtymoved,
        '                @whse,
        '                @shift,
        '                @wc,
        '                @wcdesc,
        '                @jobtranstype,
        '                @jobmachine,
        '                @joboutput,
        '                @jobrework,
        '                'U',
        '                @createdby,
        '                @createdate
        '                )", con)

        '            insertcmd.Parameters.AddWithValue("@job", txtjob.Text)
        '            insertcmd.Parameters.AddWithValue("@suffix", txtsuffix.Text)
        '            insertcmd.Parameters.AddWithValue("@opernum", txtopernum.Text)
        '            insertcmd.Parameters.AddWithValue("@transtype", "S")
        '            Dim transdate As DateTime = DateTime.Now
        '            insertcmd.Parameters.AddWithValue("@transdate", transdate)
        '            insertcmd.Parameters.AddWithValue("@qtycomplete", 0)
        '            insertcmd.Parameters.AddWithValue("@qtyscrapped", 0)
        '            insertcmd.Parameters.AddWithValue("@ahrs", 0)
        '            insertcmd.Parameters.AddWithValue("@empnum", lblempnum.Text)
        '            insertcmd.Parameters.AddWithValue("@startdatetime", lblstarttime.Text)
        '            insertcmd.Parameters.AddWithValue("@starttime", startTimeInt)
        '            'insertcmd.Parameters.AddWithValue("@endtime", endTimeInt)
        '            insertcmd.Parameters.AddWithValue("@qtymoved", 0)
        '            insertcmd.Parameters.AddWithValue("@whse", lblwhse.Text)
        '            insertcmd.Parameters.AddWithValue("@shift", lblshift.Text)
        '            'insertcmd.Parameters.AddWithValue("@reasoncode", cmbsetuptype.Text)
        '            insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
        '            'insertcmd.Parameters.AddWithValue("@wc", txtwc.Text)
        '            insertcmd.Parameters.AddWithValue("@wcdesc", txtwcdesc.Text)
        '            insertcmd.Parameters.AddWithValue("@jobtranstype", cmbsetuptype.Text)
        '            insertcmd.Parameters.AddWithValue("@jobmachine", rtbmach.Text)
        '            insertcmd.Parameters.AddWithValue("@joboutput", 0)
        '            insertcmd.Parameters.AddWithValue("@jobrework", 0)
        '            insertcmd.Parameters.AddWithValue("@createdby", lblempnum.Text)
        '            insertcmd.Parameters.AddWithValue("@createdate", DateTime.Now)

        '            If cmbsetuptype.Text = "" Then
        '                MsgBox("Setup Type Required!")
        '            Else
        '                insertcmd.ExecuteNonQuery()
        '                MsgBox("SAVED SUCCESSFULLY")
        '                btnsetupend.Enabled = True
        '                btnsave.Enabled = False
        '            End If
        '        Else
        '            btnsetupend.Enabled = False
        '            btnsave.Enabled = True
        '            MsgBox("Invalid")
        '        End If
        '    Else
        '        MsgBox("Invalid")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'Finally
        '    con.Close()
        'End Try



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
        enable_save()
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

    Private Sub txtsuffix_TextChanged(sender As Object, e As EventArgs) Handles txtsuffix.TextChanged
        load_hdr()
        enable_save()
    End Sub

    Private Sub txtjob_TextChanged(sender As Object, e As EventArgs) Handles txtjob.TextChanged
        load_hdr()
        enable_save()
    End Sub
End Class
