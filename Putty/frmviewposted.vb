Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization
Public Class frmviewposted
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else

            Dim cmd As New SqlCommand("Select_sfms_posted", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@section", cmb_section.Text)
            cmd.Parameters.AddWithValue("@machine", cmb_machine.Text)
            cmd.Parameters.Add("@startdate", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@enddate", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)

            Dim a As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt


            AutofitColumns(DataGridView1)

            '    Dim viewunposted As SqlCommand = New SqlCommand("SELECT 
            '    jobtran.job, 
            '    jobtran.Suffix, 
            '    jobtran.oper_num,
            '    jobtran.trans_date,
            '    CASE 
            '        WHEN jobtran.trans_type = 'C' THEN 'Mch Run'
            '        WHEN jobtran.trans_type = 'S' THEN 'Setup'
            '        WHEN jobtran.trans_type = 'M' THEN 'Move'
            '        ELSE 'Lbr Run'
            '    END AS [TRX TYPE],
            '    jobtran.wcdesc,
            '    jobtran.UF_Jobtran_Machine,
            '    job.description,
            ' CONVERT(VARCHAR, jobtran.start_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.start_datetime, 100), 7) AS [TIME START],
            ' CONVERT(VARCHAR, jobtran.end_datetime, 101) + ' ' + RIGHT(CONVERT(VARCHAR, jobtran.end_datetime, 100), 7) AS [TIME END],
            ' jobtran.a_hrs,
            ' jobtran.qty_complete,
            ' jobtran.qty_scrapped
            'FROM 
            '   Pallet_Tagging.dbo.sfms_jobtran jobtran
            'INNER JOIN 
            ' [PI-SP_App].dbo.job job ON jobtran.job = job.job AND jobtran.Suffix = job.suffix
            'INNER JOIN
            '    Employee emp ON jobtran.CreatedBy = emp.Emp_num
            'WHERE 
            '    emp.Section = @section AND 
            '    jobtran.trans_date BETWEEN @date1 AND @date2 AND
            '    jobtran.UF_Jobtran_Machine = @machine AND
            '    Status='P'", con)

            '    viewunposted.Parameters.AddWithValue("@section", cmb_section.Text)
            '    viewunposted.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            '    viewunposted.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
            '    viewunposted.Parameters.AddWithValue("@machine", cmb_machine.Text)



        End If

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
        SFMSMENU.Show()
        Me.Close()
    End Sub

    Private Sub frmviewposted_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtempnum.Text = user_id

        Dim getuserdetails As String = "Select Site, Emp_num, Name, position, dept, section from Employee where Emp_num = @empnum"
        Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        Try
            con.Open()
            Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
            If readuserdetails.HasRows Then
                While readuserdetails.Read
                    txtempname.Text = readuserdetails("Name").ToString
                    txt_section.Text = readuserdetails("section").ToString
                    txt_position.Text = readuserdetails("position").ToString
                    cmb_section.Text = readuserdetails("section").ToString
                End While
                readuserdetails.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmb_machine_DropDown(sender As Object, e As EventArgs) Handles cmb_machine.DropDown
        cmb_machine.Items.Clear()
        populaterscmach()
    End Sub

    Private Sub populaterscmach()
        Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
        'Dim cmd1 As SqlCommand = New SqlCommand("SELECT RS.RESID,RS.DESCR FROM wc INNER JOIN wcresourcegroup WCR ON WC.wc=WCR.wc INNER JOIN RGRPMBR000 RG ON RG.RGID=WCR.rgid INNER JOIN RESRC000 RS ON RS.RESID=RG.RESID where wc.wc=@wc", con1)
        Dim cmd1 As SqlCommand = New SqlCommand("SELECT DISTINCT RS.RESID,RS.DESCR, RS.Uf_Resrc_Section FROM wc INNER JOIN wcresourcegroup WCR ON WC.wc=WCR.wc INNER JOIN RGRPMBR000 RG ON RG.RGID=WCR.rgid RIGHT JOIN RESRC000 RS ON RS.RESID=RG.RESID WHERE RS.Uf_Resrc_Section = @section", con1)
        cmd1.Parameters.AddWithValue("@section", cmb_section.Text)
        Try
            con1.Open()
            Dim reader As SqlDataReader = cmd1.ExecuteReader
            If reader.HasRows Then
                While reader.Read()
                    cmb_machine.Items.Add(reader("RESID").ToString())
                End While
                reader.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub cmb_section_DropDown(sender As Object, e As EventArgs) Handles cmb_section.DropDown
        cmb_machine.SelectedIndex = -1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SFMSMENU.Show()
        Me.Close()
    End Sub

    Private Sub txt_job_search_TextChanged(sender As Object, e As EventArgs) Handles txt_job_search.TextChanged
        check_update()


        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            Dim cmd As New SqlCommand("Select_sfms_posted_searchjob", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@section", cmb_section.Text)
            cmd.Parameters.AddWithValue("@machine", cmb_machine.Text)
            cmd.Parameters.Add("@startdate", SqlDbType.DateTime).Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@enddate", SqlDbType.DateTime).Value = DateTimePicker2.Value.AddDays(1)
            cmd.Parameters.AddWithValue("@job", txt_job_search.Text)
            Dim a As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            a.Fill(dt)
            DataGridView1.DataSource = dt


            AutofitColumns(DataGridView1)
        End If
    End Sub
End Class