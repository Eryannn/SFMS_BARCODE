Imports System.Data.SqlClient
Public Class frm_updatedt
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text

    Private Sub txtrowpointer_TextChanged(sender As Object, e As EventArgs) Handles txtrowpointer.TextChanged
        Try
            con1.Open()
            Dim cmd_viewdetail As SqlCommand = New SqlCommand("Select * from IT_KPI_DTDetail where Refrowpointer = @rowptr and CreatedBy=@empnum AND seq=@seq", con1)

            cmd_viewdetail.Parameters.AddWithValue("@rowptr", txtrowpointer.Text)
            cmd_viewdetail.Parameters.AddWithValue("@empnum", txtempnum.Text)
            cmd_viewdetail.Parameters.AddWithValue("@seq", lblseq.Text)

            Dim read_cmd_viewdetail As SqlDataReader = cmd_viewdetail.ExecuteReader

            While read_cmd_viewdetail.Read
                lbltotalhrs.Text = read_cmd_viewdetail("DTHrs").ToString
                cmbcategory.Text = read_cmd_viewdetail("Category").ToString
                cmbcause.Text = read_cmd_viewdetail("CauseCode").ToString
                txtnotes.Text = read_cmd_viewdetail("Notes").ToString
            End While
            read_cmd_viewdetail.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try

        Try
            con1.Open()
            Dim cmd_viewmaint As SqlCommand = New SqlCommand("select category, causecode, RootCause, CauseCode + ' - ' + RootCause as codecause from IT_KPI_DTCausemaint where causeCode = @causecode", con1)
            cmd_viewmaint.Parameters.AddWithValue("@causecode", cmbcause.Text)

            Dim readcmd As SqlDataReader = cmd_viewmaint.ExecuteReader
            If readcmd.HasRows Then
                While readcmd.Read()
                    lblrootcause.Text = readcmd("RootCause").ToString
                End While
            End If
            readcmd.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frm_view_dt.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        '    con1.Open()

        '    Dim cmd_update_dtdetails As SqlCommand = New SqlCommand("UPDATE")
        'Catch ex As Exception

        'End Try

        Try
            con1.Open()
            'Dim updateCommandText As String = "UPDATE IT_KPI_DTDetail SET StartTime=@starttime, EndTime=@endtime, Category=@category, CauseCode=@causecode, RecordDate=@recorddate, Notes=@notes WHERE RefRowPointer=@refrowpointer AND Seq=@seq"
            Dim updateCommandText As String = "UPDATE IT_KPI_DTDetail SET StartTime=@starttime, EndTime=@endtime, DTHrs=@dthrs, Category=@category, CauseCode=@causecode, RecordDate=@recorddate, CreatedBy=@createdby, Notes=@notes WHERE RefRowPointer=@refrowpointer AND Seq=@seq"

            Dim cmd As New SqlCommand(updateCommandText, con1)

            cmd.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)
            cmd.Parameters.AddWithValue("@seq", lblseq.Text)
            cmd.Parameters.AddWithValue("@starttime", dtpstart.Value)
            cmd.Parameters.AddWithValue("@endtime", dtpend.Value)
            cmd.Parameters.AddWithValue("@dthrs", lbltotalhrs.Text)
            cmd.Parameters.AddWithValue("@category", cmbcategory.Text)
            cmd.Parameters.AddWithValue("@causecode", cmbcause.Text)
            cmd.Parameters.AddWithValue("@recorddate", Today())
            cmd.Parameters.AddWithValue("@createdby", txtempnum.Text)
            cmd.Parameters.AddWithValue("@notes", txtnotes.Text)

            cmd.ExecuteNonQuery()

            MsgBox("Update Successfully!")
            cleartext()
            frm_view_dt.Show()
            Me.Close()

            Dim cmd_viewdt As SqlCommand = New SqlCommand("select 
		            dtheader.Section, 
		            dtheader.MachResc,
		            dtheader.job,
		            dtheader.Suffix,
		            dtheader.OperNum,
		            dtdetail.Seq,
		            dtdetail.StartTime,
		            dtdetail.EndTime,
		            dtdetail.DTHrs,
		            dtdetail.Category,
		            dtdetail.CauseCode,
		            dtcause.RootCause,
		            dtdetail.notes,
		            dtdetail.CreatedBy,
                    dtheader.rowpointer
		
            from IT_KPI_dtheader dtheader

	            inner join IT_KPI_DTDetail dtdetail on dtheader.RowPointer = dtdetail.RefRowPointer
	            inner join IT_KPI_DTCausemaint dtcause on dtdetail.CauseCode = dtcause.CauseCode

	            where dtheader.DTDate between @startdate and  @enddate
	            and dtdetail.CreatedBy =@empnum
                and dtheader.job=@job", con1)

            cmd_viewdt.Parameters.AddWithValue("@startdate", SqlDbType.DateTime).Value = frm_view_dt.DateTimePicker1.Value.Date
            cmd_viewdt.Parameters.AddWithValue("@enddate", SqlDbType.DateTime).Value = frm_view_dt.DateTimePicker2.Value.AddDays(1)
            cmd_viewdt.Parameters.AddWithValue("@empnum", frm_view_dt.txtempnum.Text)
            cmd_viewdt.Parameters.AddWithValue("@job", frm_view_dt.cmb_joblist.Text)

            Dim a As New SqlDataAdapter(cmd_viewdt)
            Dim dt As New DataTable
            a.Fill(dt)

            frm_view_dt.DataGridView1.DataSource = dt
            frm_view_dt.DataGridView1.Columns(14).Visible = False
            enablenotes()
            AutofitColumns(frm_view_dt.DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
            ' MsgBox("debug")
        Finally
            con1.Close()
        End Try


    End Sub
    Private Function enablenotes()
        For Each row As DataGridViewRow In frm_view_dt.DataGridView1.Rows
            row.ReadOnly = True
            row.Cells("Notes").ReadOnly = False
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

    Private Sub dtpstart_TextChanged(sender As Object, e As EventArgs) Handles dtpstart.TextChanged
        Dim dtpstartint As Integer = dtpstart.Value.Hour * 3600 + dtpstart.Value.Minute * 60 + dtpstart.Value.Second
        Dim dtpendint As Integer = dtpend.Value.Hour * 3600 + dtpend.Value.Minute * 60 + dtpstart.Value.Second
        lblendint.Text = dtpendint
        lblstartint.Text = dtpstartint
        Dim totaltimeinseconds As Integer = CInt(lblendint.Text) - CInt(lblendint.Text)

        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        If totalhours < 0 Then
            totalhours = totalhours + 24
        End If

        'lblstartint.Text = dtpstartint
        'lbltotalhrs.Text = totalhours.ToString
    End Sub

    Private Sub dtpend_TextChanged(sender As Object, e As EventArgs) Handles dtpend.TextChanged
        Dim dtpendint As Integer = dtpend.Value.Hour * 3600 + dtpend.Value.Minute * 60 + dtpstart.Value.Second
        Dim dtpstartint As Integer = dtpstart.Value.Hour * 3600 + dtpstart.Value.Minute * 60 + dtpstart.Value.Second

        If lblendint.Text = "" Then
            lblendint.Text = 0
        End If
        Dim totaltimeinseconds As Integer = CInt(lblendint.Text) - CInt(lblstartint.Text)

        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        If totalhours < 0 Then
            totalhours = totalhours + 24
        End If


        lblstartint.Text = dtpstartint
        lblendint.Text = dtpendint
        'lbltotalhrs.Text = totalhours.ToString
    End Sub

    Private Sub lblendint_TextChanged(sender As Object, e As EventArgs) Handles lblendint.TextChanged

        If lblstartint.Text = "" Then
            lblstartint.Text = 0
        End If

        Dim totaltime As Integer = CInt(lblendint.Text) - CInt(lblstartint.Text)
        Dim totalhours As Double = totaltime / 3600

        ' Adjust total hours if it's negative or exceeds 24
        If totalhours < 0 Then
            totalhours += 24
        ElseIf totalhours >= 24 Then
            totalhours -= 24
        End If

        lbltotalhrs.Text = Math.Round(totalhours, 3).ToString()
    End Sub

    Private Sub lblstartint_TextChanged(sender As Object, e As EventArgs) Handles lblstartint.TextChanged
        If lblendint.Text = "" Then
            lblendint.Text = 0
        End If

        Dim totaltime As Integer = CInt(lblendint.Text) - CInt(lblstartint.Text)
        Dim totalhours As Double = totaltime / 3600

        ' Adjust total hours if it's negative or exceeds 24
        If totalhours < 0 Then
            totalhours += 24
        ElseIf totalhours >= 24 Then
            totalhours -= 24
        End If

        lbltotalhrs.Text = Math.Round(totalhours, 3).ToString()
    End Sub

    Private Sub cmbcategory_DropDown(sender As Object, e As EventArgs) Handles cmbcategory.DropDown
        cmbcategory.Items.Clear()
        lblrootcause.Text = ""
        cmbcause.SelectedIndex = -1
        categoryitems()
    End Sub

    Private Sub categoryitems()

        Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        Dim cmd As New SqlCommand("Select Category , Section from IT_KPI_SecDTCause where Section =@section", con1)
        cmd.Parameters.AddWithValue("@section", lblsection.Text)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader()
            While readcmd.Read()
                cmbcategory.Items.Add(readcmd("Category"))
            End While
        Catch ex As Exception
        Finally
            con1.Close()
        End Try

        'Dim cmd As New SqlCommand("Select Category , Section from IT_KPI_SecDTCause where Section = @section", con1)
        'cmd.Parameters.AddWithValue("@section", lblsection.Text)

        'Try
        '    con1.Open()
        '    Dim readcmd As SqlDataReader = cmd.ExecuteReader()
        '    While readcmd.Read()
        '        cmbcategory.Items.Add(readcmd("Category"))
        '    End While
        'Catch ex As Exception
        'Finally
        '    'con1.Close()
        'End Try
    End Sub

    Private Sub cmbcause_DropDown(sender As Object, e As EventArgs) Handles cmbcause.DropDown
        cmbcause.Items.Clear()
        causeitems()
    End Sub
    Private Sub causeitems()

        Dim cmd As New SqlCommand("select distinct dtcausemaint.CauseCode, dtcausemaint.RootCause, dtcause.RowPointer, dtcausedetail.RefRowpointer,  dtcause.Section from IT_KPI_SecDTCause dtcause
        inner join IT_KPI_DTCategory dtcategory on dtcause.Category = dtcategory.Category
        inner join IT_KPI_SecDTCauseDetail dtcausedetail on dtcause.RowPointer = dtcausedetail.RefRowpointer
        inner join IT_KPI_DTCausemaint dtcausemaint on dtcausedetail.CauseCode = dtcausemaint.CauseCode
        where dtcause.Category = @category AND
        dtcause.Section = @section
        order by dtcausemaint.CauseCode
        asc", con1)

        cmd.Parameters.AddWithValue("@category", cmbcategory.Text)
        cmd.Parameters.AddWithValue("@section", lblsection.Text)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read()
                Dim codeandcause As String = readcmd("CauseCode") + " - " + readcmd("RootCause")
                cmbcause.Items.Add(codeandcause)
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try


        'Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        'Dim cmd As New SqlCommand("Select Category, CauseCode, RootCause from IT_KPI_DTCausemaint where Category=@category", con1)
        'cmd.Parameters.AddWithValue("@category", cmbcategory.Text)

        'Try
        '    con1.Open()
        '    Dim readcmd As SqlDataReader = cmd.ExecuteReader()
        '    While readcmd.Read()
        '        Dim codeandcause As String = readcmd("CauseCode") + " - " + readcmd("RootCause")
        '        cmbcause.Items.Add(codeandcause)
        '    End While
        '    readcmd.Close()
        'Catch ex As Exception
        'Finally
        '    con1.Close()
        'End Try
    End Sub

    Private Sub populatecausecode()

        Dim getcauseandroot As New SqlCommand("select distinct dtcausemaint.CauseCode, dtcause.RowPointer, dtcausedetail.RefRowpointer,  dtcause.Section from IT_KPI_SecDTCause dtcause
        inner join IT_KPI_DTCategory dtcategory on dtcause.Category = dtcategory.Category
        inner join IT_KPI_SecDTCauseDetail dtcausedetail on dtcause.RowPointer = dtcausedetail.RefRowpointer
        inner join IT_KPI_DTCausemaint dtcausemaint on dtcausedetail.CauseCode = dtcausemaint.CauseCode
        where dtcause.Category = @category AND
        dtcause.Section = @section
        order by dtcausemaint.CauseCode
        asc", con1)

        getcauseandroot.Parameters.AddWithValue("@category", cmbcategory.Text)
        getcauseandroot.Parameters.AddWithValue("@section", lblsection.Text)

        Try
            con1.Open()
            Dim readcauseandroot As SqlDataReader = getcauseandroot.ExecuteReader
            While readcauseandroot.Read
                Dim cc As String = readcauseandroot("CauseCode").ToString
                cmbcause.Items.Add(cc)
            End While
            readcauseandroot.Close()

        Catch ex As Exception
        Finally
            con1.Close()
        End Try

        'Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        'Dim cmd As New SqlCommand("select Category, CauseCode, RootCause from IT_KPI_DTCausemaint", con1)

        'Try
        '    con1.Open()
        '    Dim readcmd As SqlDataReader = cmd.ExecuteReader
        '    While readcmd.Read
        '        Dim cc As String = readcmd("CauseCode").ToString
        '        cmbcause.Items.Add(cc)
        '    End While
        '    readcmd.Close()
        'Catch ex As Exception
        'Finally
        '    con1.Close()
        'End Try
    End Sub

    Private Sub cmbcause_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcause.SelectedIndexChanged
        Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        Dim cmd As New SqlCommand("select category, causecode, RootCause, CauseCode + ' - ' + RootCause as codecause from IT_KPI_DTCausemaint where (CauseCode + ' - ' + RootCause) = @causecode", con1)
        cmd.Parameters.AddWithValue("@causecode", cmbcause.Text)

        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            If readcmd.HasRows Then
                While readcmd.Read()
                    lblrootcause.Text = readcmd("RootCause").ToString
                    populatecausecode()
                    cmbcause.Text = readcmd("causecode").ToString
                End While
            End If
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try
    End Sub
End Class