Imports System.Data.SqlClient
Public Class frmfgts
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")

    Dim curryear As String = Date.Today.ToString("yy") + "-"
    'Dim curryear As String = "25-"
    Dim latesttran As Integer = getlasttran()


    ' Determine the number of zeros needed based on the length of latesttran
    Dim numZerosNeeded As Integer = Math.Max(0, 7 - latesttran.ToString().Length)
    Dim zeros As String = New String("0"c, numZerosNeeded)

    ' Concatenate curryear, zeros, and latesttran
    Dim fgtsnum As String = curryear + zeros + latesttran.ToString()

    Private Function getlasttran() As Integer

        Dim latesttran As Integer = 0

        Try
            con.Open()

            Using cmd As New SqlCommand("select last_tran from sfms_lasttran where prefix = @prefix", con)
                cmd.Parameters.AddWithValue("@prefix", curryear)
                Dim result As Object = cmd.ExecuteScalar
                If result IsNot DBNull.Value Then
                    latesttran = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return latesttran

        'Dim latesttran As Integer = 0

        'Try
        '    con.Open()

        '    Using cmd As New SqlCommand("select last_tran from sfms_lasttran", con)

        '        Dim result As Object = cmd.ExecuteScalar
        '        If result IsNot DBNull.Value Then
        '            latesttran = Convert.ToInt32(result)
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try
        'Return latesttran


    End Function
    Dim userid As String = frmlogin.txtuserid.Text
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
			jobtran.[Select],
            jobtran.job, 
            jobtran.Suffix,
            CASE 
                WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                WHEN jobtran.trans_type = 'S' THEN 'Setup'
                WHEN jobtran.trans_type = 'M' THEN 'Move'
                ELSE 'Lbr Run'
            END AS [TRX TYPE],
			jobtran.wc,
            jobtran.wcdesc,
            jobtran.UF_Jobtran_Machine,
            job.description,
			jobtran.lot,
	        jobtran.qty_complete,
            jobtran.seq,
			CASE 
                WHEN UF_Jobtran_Notes IS NULL then ''
                ELSE UF_Jobtran_Notes
            END AS REMARKS,
            jobtran.emp_num,
            CONVERT(varchar, jobtran.trans_date, 120) AS trans_date
        FROM 
           Pallet_Tagging.dbo.sfms_jobtran jobtran
        INNER JOIN 
	        [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        WHERE 
            jobtran.trans_type = 'M' AND
            jobtran.emp_num = @empnum AND
            UF_Jobtran_DocNum IS NULL AND
            jobtran.wc IN ('P610', 'P992') AND
            jobtran.shift = @shift AND
            jobtran.trans_date BETWEEN @date1 AND @date2
            ", con)
            'Status ='P' AND
            viewunposted.Parameters.AddWithValue("@empnum", txtempnum.Text)
            viewunposted.Parameters.AddWithValue("@shift", txtshift.Text)


            viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)

            Dim a As New SqlDataAdapter(viewunposted)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt

            DataGridView1.Columns(12).Visible = False
            'Dim transdate As String = DataGridView1.Columns(12)
            ' DataGridView1.Columns(12).Visible = False

            AutofitColumns(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub

    Private Sub AutofitColumns(dataGridView As DataGridView)
        ' Auto-resize columns to fit their content
        For Each column As DataGridViewColumn In dataGridView.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        ' Perform the actual auto-resizing based on content
        dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Try
            con.Open()

            Dim cmdupdate As SqlCommand = New SqlCommand("UPDATE sfms_jobtran SET [Select] = 0 WHERE emp_num=@empnum AND [Select] = 1", con)

            cmdupdate.Parameters.AddWithValue("@empnum", txtempnum.Text)
            cmdupdate.ExecuteNonQuery()



            SFMSMENU.Show()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub frmfgts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtempnum.Text = userid

        latesttran += 1
        Dim fgtsnum As String = curryear + zeros + latesttran.ToString()
        txtfgtsnum.Text = fgtsnum
        txtshift.Text = frmlogin.cmbshift.Text


        Dim getuserdetails As String = "select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        Try
            con.Open()
            Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
            If readuserdetails.HasRows Then
                While readuserdetails.Read
                    txtempname.Text = readuserdetails("Name").ToString
                End While
                readuserdetails.Close()
            End If
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub DataGridView1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.ColumnIndex = DataGridView1.Columns("select").Index AndAlso e.RowIndex >= 0 Then
            ' This code will make sure the checkbox value is toggled immediately
            DataGridView1.EndEdit()
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            con.Open()

            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim ischecked As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                Dim trxtype As String = row.Cells("TRX TYPE").Value.ToString

                If trxtype = "Setup" Then
                    trxtype = "S"
                ElseIf trxtype = "Mch Run" Then
                    trxtype = "C"
                ElseIf trxtype = "Lbr Run" Then
                    trxtype = "R"
                Else
                    trxtype = "M"
                End If

                Dim anyRowChecked As Boolean = False

                If ischecked Then

                    'btnaddtonewfgts.Enabled = True
                    'btnaddexistfgts.Enabled = True

                    Dim cmdchecked As New SqlCommand("
                    UPDATE sfms_jobtran 
                            Set [Select] = 1 
                    WHERE 
                            Job = @job And 
                            Suffix = @suffix and 
                            trans_type='M' and 
                            emp_num = @empnum and
                            seq=@seq", con)

                    cmdchecked.Parameters.AddWithValue("@job", row.Cells(1).Value)
                    cmdchecked.Parameters.AddWithValue("@suffix", row.Cells(2).Value)
                    cmdchecked.Parameters.AddWithValue("@empnum", txtempnum.Text)
                    cmdchecked.Parameters.AddWithValue("@seq", row.Cells(10).Value)

                    cmdchecked.ExecuteNonQuery()
                    'ElseIf ischecked AndAlso txtfgtsnum.Text <> "" Then
                    '    btnaddtonewfgts.Enabled = True

                    '    Dim cmdchecked As New SqlCommand("
                    '    UPDATE sfms_jobtran 
                    '            Set [Select] = 1 
                    '    WHERE 
                    '            Job = @job And 
                    '            Suffix = @suffix and 
                    '            trans_type='M' and 
                    '            emp_num = @empnum and
                    '            seq=@seq", con)

                    '    cmdchecked.Parameters.AddWithValue("@job", row.Cells(1).Value)
                    '    cmdchecked.Parameters.AddWithValue("@suffix", row.Cells(2).Value)
                    '    cmdchecked.Parameters.AddWithValue("@empnum", txtempnum.Text)
                    '    cmdchecked.Parameters.AddWithValue("@seq", row.Cells(10).Value)

                    '    cmdchecked.ExecuteNonQuery()
                    'ElseIf ischecked AndAlso cmbfgtsnum.Text = "" Then
                    '    btnaddexistfgts.Enabled = False

                    '    Dim cmdchecked As New SqlCommand("
                    '    UPDATE sfms_jobtran 
                    '            Set [Select] = 1 
                    '    WHERE 
                    '            Job = @job And 
                    '            Suffix = @suffix and 
                    '            trans_type='M' and 
                    '            emp_num = @empnum and
                    '            seq=@seq", con)

                    '    cmdchecked.Parameters.AddWithValue("@job", row.Cells(1).Value)
                    '    cmdchecked.Parameters.AddWithValue("@suffix", row.Cells(2).Value)
                    '    cmdchecked.Parameters.AddWithValue("@empnum", txtempnum.Text)
                    '    cmdchecked.Parameters.AddWithValue("@seq", row.Cells(10).Value)

                    '    cmdchecked.ExecuteNonQuery()

                Else

                    btnaddtonewfgts.Enabled = False
                    btnaddexistfgts.Enabled = False
                    Dim cmdunchecked As New SqlCommand("
                    UPDATE sfms_jobtran 
                            Set [Select] = 0
                    WHERE 
                            Job = @job And 
                            Suffix = @suffix and 
                            trans_type='M' and 
                            emp_num = @empnum and
                            seq=@seq", con)

                    cmdunchecked.Parameters.AddWithValue("@job", row.Cells(1).Value)
                    cmdunchecked.Parameters.AddWithValue("@suffix", row.Cells(2).Value)
                    cmdunchecked.Parameters.AddWithValue("@empnum", txtempnum.Text)
                    cmdunchecked.Parameters.AddWithValue("@seq", row.Cells(10).Value)

                    cmdunchecked.ExecuteNonQuery()

                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        Try
            con.Open()

            Dim cmd_enablebtn As SqlCommand = New SqlCommand("Select * from sfms_jobtran where emp_num = @empnum AND [SELECT] = 1 and trans_type = 'M' and UF_Jobtran_DocNum IS NULL", con)

            cmd_enablebtn.Parameters.AddWithValue("@empnum", txtempnum.Text)
            Dim read_cmd As SqlDataReader = cmd_enablebtn.ExecuteReader
            If read_cmd.HasRows Then
                If cmbfgtsnum.Text <> "" And txtfgtsnum.Text = "" Then
                    btnaddexistfgts.Enabled = True
                ElseIf txtfgtsnum.Text <> "" And cmbfgtsnum.Text = "" Then
                    btnaddtonewfgts.Enabled = True
                ElseIf cmbfgtsnum.Text = "" Then
                    btnaddexistfgts.Enabled = False
                ElseIf cmbfgtsnum.Text = "" Then
                    btnaddtonewfgts.Enabled = False
                ElseIf cmbfgtsnum.Text <> "" And txtfgtsnum.Text <> "" Then
                    btnaddtonewfgts.Enabled = True
                    btnaddexistfgts.Enabled = True
                Else
                    btnaddexistfgts.Enabled = False
                    btnaddexistfgts.Enabled = False
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        'Try
        '    con.Open()

        '    Dim cmd_validaterows As SqlCommand = New SqlCommand("select * from sfms_jobtran where emp_num = @empnum And [Select] = 1 And trans_type = 'M' and UF_Jobtran_DocNum IS NULL", con)

        '    cmd_validaterows.Parameters.AddWithValue("@empnum", txtempnum.Text)

        '    Dim readcmd As SqlDataReader = cmd_validaterows.ExecuteReader
        '    If readcmd.Read Then
        '        btnaddexistfgts.Enabled = True
        '        btnaddtonewfgts.Enabled = True
        '    Else
        '        btnaddexistfgts.Enabled = False
        '        btnaddtonewfgts.Enabled = False
        '    End If
        '    readcmd.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            con.Open()

            Dim cmdupdate As SqlCommand = New SqlCommand("
        UPDATE sfms_jobtran
        SET UF_Jobtran_Notes = @notes
        WHERE
            Job = @job AND
            suffix = @suffix AND
            trans_type = 'M' AND
            CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND
            qty_Complete = @qtycomplete AND
            emp_num = @empnum
        ", con)

            ' Add parameters to the command object
            cmdupdate.Parameters.Add("@notes", SqlDbType.NVarChar)
            cmdupdate.Parameters.Add("@job", SqlDbType.NVarChar)
            cmdupdate.Parameters.Add("@suffix", SqlDbType.Int)
            cmdupdate.Parameters.Add("@transdate", SqlDbType.NVarChar)
            cmdupdate.Parameters.Add("@qtycomplete", SqlDbType.Int)
            cmdupdate.Parameters.Add("@empnum", SqlDbType.NVarChar)

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmdupdate.Parameters("@notes").Value = row.Cells("REMARKS").Value.ToString()
                    cmdupdate.Parameters("@job").Value = row.Cells("job").Value.ToString()
                    cmdupdate.Parameters("@suffix").Value = Convert.ToInt32(row.Cells("Suffix").Value)
                    cmdupdate.Parameters("@transdate").Value = row.Cells("trans_date").Value.ToString()
                    cmdupdate.Parameters("@qtycomplete").Value = Convert.ToInt32(row.Cells("qty_complete").Value)
                    cmdupdate.Parameters("@empnum").Value = row.Cells("emp_num").Value.ToString

                    cmdupdate.ExecuteNonQuery()
                End If
            Next

            MsgBox("Update successful")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


        'Try
        '    con.Open()

        '    Dim cmdupdate As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
        '    SET UF_Jobtran_Notes=@notes
        '    WHERE
        '    Job=@job AND
        '    suffix=@suffix AND
        '    trans_type = M AND
        '    CONVERT(varchar, trans_date, 120) LIKE @transdate + '%' AND
        '    qty_Complete = @qtycomplete AND
        '    emp_num = @empnum    
        '    ", con)

        '    For Each row As DataGridViewRow In DataGridView1.Rows

        '        If Not row.IsNewRow Then
        '            cmdupdate.Parameters("@notes").Value = row.Cells("REMARKS")

        '            cmdupdate.Parameters("@job").Value = row.Cells("job").Value
        '            cmdupdate.Parameters("@suffix").Value = row.Cells("Suffix").Value
        '            cmdupdate.Parameters("@empnum").Value = row.Cells("emp_num").Value
        '            cmdupdate.Parameters("@transdate").Value = row.Cells("trans_date").Value
        '            cmdupdate.Parameters("@qtycomplete").Value = row.Cells("qty_complete").Value

        '            cmdupdate.ExecuteNonQuery()

        '        End If

        '    Next
        '    MsgBox("Update successfully")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try


        'backup=====
        'Try
        '    con.Open()

        '    Dim cmdinsert As SqlCommand = New SqlCommand("INSERT INTO sfms_lasttran 
        '    (
        '    trans_file,
        '    prefix,
        '    last_tran,
        '    CreateDate)
        '    VALUES
        '    (
        '    @transfile,
        '    @prefix,
        '    @lasttran,
        '    @createdate
        '    )", con)

        '    cmdinsert.Parameters.AddWithValue("@transfile", txtfgtsnum.Text)
        '    cmdinsert.Parameters.AddWithValue("@prefix", curryear)
        '    cmdinsert.Parameters.AddWithValue("@lasttran", latesttran)
        '    cmdinsert.Parameters.AddWithValue("@createdate", DateTime.Now)

        '    cmdinsert.ExecuteNonQuery()

        '    MsgBox("Inserted Successfully!")

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try

        'Try
        '    con.Open()

        '    Dim cmdupdate As SqlCommand = New SqlCommand("UPDATE sfms_jobtran 
        '    Set UF_Jobtran_DocNum=@docnum 
        '    WHERE emp_num=@empnum AND [Select] = 1", con)

        '    cmdupdate.Parameters.AddWithValue("@docnum", txtfgtsnum.Text)
        '    cmdupdate.Parameters.AddWithValue("@empnum", txtempnum.Text)

        '    cmdupdate.ExecuteNonQuery()

        '    MsgBox("Updated Successfully")

        '    latesttran += 1
        '    Dim fgtsnum As String = curryear + zeros + latesttran.ToString()
        '    txtfgtsnum.Text = fgtsnum

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try

        'Try
        '    con1.Open()

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        frmfgtsrept.Show()
        frmfgtsrept.txtempnum.Text = txtempnum.Text
        frmfgtsrept.txtempname.Text = txtempname.Text
        Me.Close()

    End Sub

    Private Sub fgtslist()

        'Dim cmd As New SqlCommand("select trans_file from sfms_lasttran group by trans_file", con)
        Dim cmd As New SqlCommand("select UF_Jobtran_DocNum from sfms_jobtran where UF_Jobtran_DocNum is not null group by UF_Jobtran_DocNum", con)
        Try
            con.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                'Dim transfile As String = readcmd("trans_file")
                Dim transfile As String = readcmd("UF_Jobtran_DocNum")
                cmbfgtsnum.Items.Add(transfile)
                'cmbend.Items.Add(transfile)
            End While
            readcmd.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles cmbfgtsnum.DropDown
        cmbfgtsnum.Items.Clear()
        fgtslist()
    End Sub

    Private Sub btnaddtofgts_Click(sender As Object, e As EventArgs) Handles btnaddtonewfgts.Click

        Try
            con.Open()

            Dim cmdupdate As SqlCommand = New SqlCommand("UPDATE sfms_lasttran 
            SET last_tran=@lasttran,
                prefix=@prefix,
                trans_file=@transfile,
                CreateDate=@createdate", con)

            cmdupdate.Parameters.AddWithValue("@transfile", txtfgtsnum.Text)
            cmdupdate.Parameters.AddWithValue("@prefix", curryear)
            cmdupdate.Parameters.AddWithValue("@lasttran", latesttran)
            cmdupdate.Parameters.AddWithValue("@createdate", DateTime.Now)

            Dim cmd_lasttran As SqlCommand = New SqlCommand("select * from sfms_lasttran where prefix = @prefix", con)

            cmd_lasttran.Parameters.AddWithValue("@prefix", curryear)

            Dim cmdinsert As SqlCommand = New SqlCommand("INSERT INTO sfms_lasttran 
                    (
                    trans_file,
                    prefix,
                    last_tran,
                    CreateDate)
                    VALUES
                    (
                    @transfile,
                    @prefix,
                    @lasttran,
                    @createdate
                    )", con)

            cmdinsert.Parameters.AddWithValue("@transfile", txtfgtsnum.Text)
            cmdinsert.Parameters.AddWithValue("@prefix", curryear)
            cmdinsert.Parameters.AddWithValue("@lasttran", latesttran)
            cmdinsert.Parameters.AddWithValue("@createdate", DateTime.Now)

            Dim cmd_readlasttran As SqlDataReader = cmd_lasttran.ExecuteReader
            If cmd_readlasttran.HasRows Then
                cmd_readlasttran.Close()
                cmdupdate.ExecuteNonQuery()
                'cmd_readlasttran.Close()
            Else

                cmd_readlasttran.Close()
                'MsgBox("cmdreadlastran has rows!")
                cmdinsert.ExecuteNonQuery()
            End If




            'MsgBox("Inserted Successfully!")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        'BACKUP
        'Try
        '    con.Open()

        '    Dim cmdinsert As SqlCommand = New SqlCommand("INSERT INTO sfms_lasttran 
        '    (
        '    trans_file,
        '    prefix,
        '    last_tran,
        '    CreateDate)
        '    VALUES
        '    (
        '    @transfile,
        '    @prefix,
        '    @lasttran,
        '    @createdate
        '    )", con)

        '    cmdinsert.Parameters.AddWithValue("@transfile", txtfgtsnum.Text)
        '    cmdinsert.Parameters.AddWithValue("@prefix", curryear)
        '    cmdinsert.Parameters.AddWithValue("@lasttran", latesttran)
        '    cmdinsert.Parameters.AddWithValue("@createdate", DateTime.Now)

        '    cmdinsert.ExecuteNonQuery()

        '    'MsgBox("Inserted Successfully!")

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try

        'Update docnum of existing fgts
        Try
            con.Open()

            Dim cmdaddtofgts As SqlCommand = New SqlCommand("
            Update sfms_jobtran
            SET UF_Jobtran_DocNum=@docnum,
            CreatedBy=@createdby
            WHERE emp_num=@empnum AND [Select] = 1
            ", con)

            Dim cmdupdate As SqlCommand = New SqlCommand("UPDATE sfms_jobtran 
            Set UF_Jobtran_DocNum=@docnum 
            WHERE emp_num=@empnum AND [Select] = 1", con)

            cmdupdate.Parameters.AddWithValue("@docnum", txtfgtsnum.Text)
            cmdupdate.Parameters.AddWithValue("@createdby", txtempnum.Text)
            cmdupdate.Parameters.AddWithValue("@empnum", txtempnum.Text)

            cmdupdate.ExecuteNonQuery()

            MsgBox("Updated Successfully")

            latesttran += 1
            Dim fgtsnum As String = curryear + zeros + latesttran.ToString()
            txtfgtsnum.Text = fgtsnum

        Catch ex As Exception
        Finally
            con.Close()
        End Try

        'Turn select into false
        Try
            con.Open()

            Dim cmd_resetselection As SqlCommand = New SqlCommand("
            Update sfms_jobtran
            Set [Select] = 0
            WHERE emp_num=@empnum", con)

            cmd_resetselection.Parameters.AddWithValue("@empnum", txtempnum.Text)

            cmd_resetselection.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


        'Refresh Table
        Try
            con.Open()
            Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
			jobtran.[Select],
            jobtran.job, 
            jobtran.Suffix,
            CASE 
                WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                WHEN jobtran.trans_type = 'S' THEN 'Setup'
                WHEN jobtran.trans_type = 'M' THEN 'Move'
                ELSE 'Lbr Run'
            END AS [TRX TYPE],
			jobtran.wc,
            jobtran.wcdesc,
            jobtran.UF_Jobtran_Machine,
            job.description,
			jobtran.lot,
	        jobtran.qty_complete,
            jobtran.seq,
			CASE 
                WHEN UF_Jobtran_Notes IS NULL then ''
                ELSE UF_Jobtran_Notes
            END AS REMARKS,
            jobtran.emp_num,
            CONVERT(varchar, jobtran.trans_date, 120) AS trans_date
        FROM 
           Pallet_Tagging.dbo.sfms_jobtran jobtran
        INNER JOIN 
	        [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        WHERE 
            jobtran.trans_type = 'M' AND
            jobtran.emp_num = @empnum AND
            UF_Jobtran_DocNum IS NULL AND
            jobtran.wc IN ('P610', 'P992') AND
            jobtran.shift = @shift AND
            jobtran.trans_date BETWEEN @date1 AND @date2
            ", con)
            'Status ='P' AND
            viewunposted.Parameters.AddWithValue("@empnum", txtempnum.Text)
            viewunposted.Parameters.AddWithValue("@shift", txtshift.Text)


            viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)

            Dim a As New SqlDataAdapter(viewunposted)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt

            DataGridView1.Columns(11).Visible = False
            'Dim transdate As String = DataGridView1.Columns(12)
            ' DataGridView1.Columns(12).Visible = False

            AutofitColumns(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnaddexistfgts.Click
        Try
            con.Open()
            If cmbfgtsnum.Text = "" Then
                MsgBox("Invalid")
            Else

                Dim cmd_addtoexistingfgts As SqlCommand = New SqlCommand("UPDATE sfms_jobtran 
            Set UF_Jobtran_DocNum=@docnum 
            WHERE emp_num=@empnum AND [Select] = 1", con)

                cmd_addtoexistingfgts.Parameters.AddWithValue("@docnum", cmbfgtsnum.Text)
                cmd_addtoexistingfgts.Parameters.AddWithValue("@empnum", txtempnum.Text)

                cmd_addtoexistingfgts.ExecuteNonQuery()

                MsgBox("Updated Successfully")

                MsgBox("Added to fgts No. " + cmbfgtsnum.Text)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        Try
            con.Open()
            Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
			jobtran.[Select],
            jobtran.job, 
            jobtran.Suffix,
            CASE 
                WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
                WHEN jobtran.trans_type = 'S' THEN 'Setup'
                WHEN jobtran.trans_type = 'M' THEN 'Move'
                ELSE 'Lbr Run'
            END AS [TRX TYPE],
			jobtran.wc,
            jobtran.wcdesc,
            jobtran.UF_Jobtran_Machine,
            job.description,
			jobtran.lot,
	        jobtran.qty_complete,
            jobtran.seq,
			CASE 
                WHEN UF_Jobtran_Notes IS NULL then ''
                ELSE UF_Jobtran_Notes
            END AS REMARKS,
            jobtran.emp_num,
            CONVERT(varchar, jobtran.trans_date, 120) AS trans_date
        FROM 
           Pallet_Tagging.dbo.sfms_jobtran jobtran
        INNER JOIN 
	        [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
        WHERE 
            jobtran.trans_type = 'M' AND
            jobtran.emp_num = @empnum AND
            UF_Jobtran_DocNum IS NULL AND
            jobtran.wc IN ('P610', 'P992') AND
            jobtran.shift = @shift AND
            jobtran.trans_date BETWEEN @date1 AND @date2
            ", con)
            'Status ='P' AND
            viewunposted.Parameters.AddWithValue("@empnum", txtempnum.Text)
            viewunposted.Parameters.AddWithValue("@shift", txtshift.Text)


            viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)

            Dim a As New SqlDataAdapter(viewunposted)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt

            DataGridView1.Columns(11).Visible = False
            'Dim transdate As String = DataGridView1.Columns(12)
            ' DataGridView1.Columns(12).Visible = False

            AutofitColumns(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub

    Private Sub cmbfgtsnum_TextChanged(sender As Object, e As EventArgs) Handles cmbfgtsnum.TextChanged

        If cmbfgtsnum.Text = "" Then
            btnaddexistfgts.Enabled = False
        Else
            btnaddexistfgts.Enabled = True
        End If

    End Sub


End Class