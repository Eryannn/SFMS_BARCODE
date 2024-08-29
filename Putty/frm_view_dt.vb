Imports System.Data.SqlClient
Public Class frm_view_dt
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text

    Private Sub joblist()
        Dim cmd As New SqlCommand("select distinct job from IT_KPI_Dtheader Where CreatedBy = @empnum", con1)

        cmd.Parameters.AddWithValue("empnum", txtempnum.Text)
        Try
            con1.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                cmb_joblist.Items.Add(readcmd("Job"))
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con1.Close()
        End Try
    End Sub
    Private Sub cmb_joblist_DropDown(sender As Object, e As EventArgs) Handles cmb_joblist.DropDown
        cmb_joblist.Items.Clear()
        joblist()
    End Sub

    Private Sub frm_view_dt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtempnum.Text = userid

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Try
            con1.Open()
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

            cmd_viewdt.Parameters.AddWithValue("@startdate", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            cmd_viewdt.Parameters.AddWithValue("@enddate", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
            cmd_viewdt.Parameters.AddWithValue("@empnum", txtempnum.Text)
            cmd_viewdt.Parameters.AddWithValue("@job", cmb_joblist.Text)

            Dim a As New SqlDataAdapter(cmd_viewdt)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt

            DataGridView1.Columns(14).Visible = False
            enablenotes()
            AutofitColumns(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try



    End Sub

    Private Function enablenotes()
        For Each row As DataGridViewRow In DataGridView1.Rows
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

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        SFMSMENU.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim seq As String = DataGridView1.SelectedCells(5).Value?.ToString()
        Dim rowptr As String = DataGridView1.SelectedCells(14).Value.ToString
        Dim startdate As DateTime = DataGridView1.SelectedCells(6).Value.ToString
        Dim enddate As DateTime = DataGridView1.SelectedCells(7).Value.ToString
        Dim sec As String = DataGridView1.SelectedCells(0).Value.ToString

        frm_updatedt.lblseq.Text = seq
        frm_updatedt.lblstartint.Text = 0
        frm_updatedt.lblendint.Text = 0
        frm_updatedt.txtempnum.Text = txtempnum.Text
        frm_updatedt.dtpstart.Value = startdate
        frm_updatedt.dtpend.Value = enddate
        frm_updatedt.lblsection.Text = sec
        frm_updatedt.Show()
        frm_updatedt.txtrowpointer.Text = rowptr
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            con1.Open()

            Dim cmd_updatetable As New SqlCommand("Update IT_KPI_DTDetail SET Notes=@notes WHERE RefRowPointer=@refrowpointer AND Seq=@seq AND CreatedBy=@empnum", con1)

            For Each row As DataGridViewRow In DataGridView1.Rows

                If Not row.IsNewRow Then

                    cmd_updatetable.Parameters.Clear()

                    cmd_updatetable.Parameters.AddWithValue("@refrowpointer", row.Cells("rowpointer").Value)
                    cmd_updatetable.Parameters.AddWithValue("@seq", row.Cells("Seq").Value)
                    cmd_updatetable.Parameters.AddWithValue("@empnum", txtempnum.Text)

                    cmd_updatetable.Parameters.AddWithValue("@notes", row.Cells("Notes").Value)

                    cmd_updatetable.ExecuteNonQuery()
                End If
            Next
            MsgBox("Saved successfully")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try
    End Sub

End Class