Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization

Public Class frm_update_move_wmcnum
    Private Sub txtopernum_TextChanged(sender As Object, e As EventArgs) Handles txtopernum.TextChanged
        Try
            con.Open()

            Dim cmdviewitems As SqlCommand = New SqlCommand("SELECT * 
               from sfms_jobtran 
               where job=@job AND
               suffix=@suffix AND
               oper_num=@opernum AND
               createdby=@empnum AND
	           trans_type=@type AND
               CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)
            'CONVERT(VARCHAR, trans_date, 120) LIKE @transdate
            cmdviewitems.Parameters.AddWithValue("@job", txtjob.Text)
            cmdviewitems.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdviewitems.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdviewitems.Parameters.AddWithValue("@empnum", lblempnum.Text)
            'cmdviewitems.Parameters.AddWithValue("@empname", lblempname.Text)
            cmdviewitems.Parameters.AddWithValue("@type", txttranstype.Text)
            Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            cmdviewitems.Parameters.AddWithValue("@transdate", transdateString)

            Dim readitems As SqlDataReader = cmdviewitems.ExecuteReader
            If readitems.HasRows Then
                While readitems.Read()
                    'lblstartint.Text = CInt(readitems("start_time").ToString)


                    txtwc.Text = readitems("wc").ToString
                    txtwcdesc.Text = readitems("wcdesc").ToString
                    lblreasondesc.Text = readitems("Uf_Jobtran_TransactionType").ToString
                    cmbreasoncode.Text = readitems("reason_code").ToString
                    rtbmach.Text = readitems("UF_Jobtran_Machine").ToString
                    lblnextop.Text = readitems("next_oper").ToString
                    Dim dtpcurrent As DateTime = Today
                    Dim enddate As String = readitems("end_datetime").ToString
                    txt_qtyredtags.Text = readitems("qty_redtags")
                    txtlot.Text = readitems("Lot").ToString
                    'lbltransdate.Text = readitems("trans_date").ToString
                    txtqtymoved.Text = readitems("qty_moved").ToString
                    txtqtycompleted.Text = readitems("qty_complete").ToString
                    txtqtyscrapped.Text = readitems("qty_scrapped").ToString
                    txt_mcnum.Text = readitems("mcnum").ToString
                    txtqtygood.Text = readitems("UF_Jobtran_Output").ToString
                    txtqtyrework.Text = readitems("UF_Jobtran_Rework").ToString
                End While
            Else
                readitems.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        Try
            con1.Open()

            Dim cmd As SqlCommand = New SqlCommand("select reason_class, reason_code, description, reason_code + ' / ' + description as codeanddesc from reason where reason_code = @reasoncode", con1)

            cmd.Parameters.AddWithValue("@reasoncode", cmbreasoncode.Text)

            Dim read_cmd As SqlDataReader = cmd.ExecuteReader
            While read_cmd.Read
                lblreasondesc.Text = read_cmd("description").ToString

            End While
            read_cmd.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try
    End Sub

    Private Sub Update_Data()
        Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            con.Open()

            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
            SET reason_code=@reasoncode,
            qty_complete=@qtycomplete,
            qty_scrapped=@qtyscrapped,
            qty_moved=@qtymoved,
            lot=@lot,
            mcnum=@mcnum,
            UF_Jobtran_Output=@qtygood,
            UF_Jobtran_Rework=@qtyrework,
            emp_num=@updatedby,
            
            WHERE job=@job AND
            Suffix=@suffix AND
            Oper_num=@opernum AND
            trans_type='M' AND
            Status='U' AND
            createdby=@empnum AND
            CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)



            If cmbreasoncode.Text = "" Then
                cmdupdatesfms.Parameters.AddWithValue("@reasoncode", DBNull.Value)
            Else

                cmdupdatesfms.Parameters.AddWithValue("@reasoncode", cmbreasoncode.Text)
            End If

            'cmdupdatesfms.Parameters.AddWithValue("@reasondesc", lblreasondesc.Text)
            cmdupdatesfms.Parameters.AddWithValue("@qtycomplete", CInt(txtqtycompleted.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtyscrapped", CInt(txtqtyscrapped.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtymoved", CInt(txtqtymoved.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtyrework", CInt(txtqtyrework.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtygood", CInt(txtqtygood.Text))

            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdateString)
            cmdupdatesfms.Parameters.AddWithValue("@lot", txtlot.Text)
            cmdupdatesfms.Parameters.AddWithValue("@updatedby", lbl_updatedby.Text)

            If txt_mcnum.Text = "" Then
                cmdupdatesfms.Parameters.AddWithValue("@docnum", DBNull.Value)
            Else
                cmdupdatesfms.Parameters.AddWithValue("@docnum", txt_mcnum.Text)
            End If


            If CInt(txtqtyscrapped.Text) > 0 AndAlso lblreasondesc.Text = "" Then

                MsgBox("Reason Code is Required")
            Else

                If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
                    If txtlot.Text <> "" Then
                        cmdupdatesfms.ExecuteNonQuery()

                        MsgBox("Updated Successfully!")

                        btnpost.Enabled = True

                    Else
                        MsgBox("Lot is Required")
                    End If
                Else
                    cmdupdatesfms.ExecuteNonQuery()

                    MsgBox("Updated Successfully!")

                    btnpost.Enabled = True

                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btn_update.Click

        Dim transdateString As String = dtptransdate.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            con.Open()

            Dim cmdupdatesfms As SqlCommand = New SqlCommand("UPDATE sfms_jobtran
            SET reason_code=@reasoncode,
            qty_complete=@qtycomplete,
            qty_scrapped=@qtyscrapped,
            qty_moved=@qtymoved,
            lot=@lot,
            mcnum=@mcnum,
            UF_Jobtran_Output=@qtygood,
            UF_Jobtran_Rework=@qtyrework,
            emp_num=@updatedby
            WHERE job=@job AND
            Suffix=@suffix AND
            Oper_num=@opernum AND
            trans_type='M' AND
            Status='U' AND
            createdby=@empnum AND
            CONVERT(VARCHAR, trans_date, 120) LIKE @transdate + '%'", con)


            If cmbreasoncode.Text = "" Then
                cmdupdatesfms.Parameters.AddWithValue("@reasoncode", DBNull.Value)
            Else

                cmdupdatesfms.Parameters.AddWithValue("@reasoncode", cmbreasoncode.Text)
            End If

            'cmdupdatesfms.Parameters.AddWithValue("@reasondesc", lblreasondesc.Text)
            cmdupdatesfms.Parameters.AddWithValue("@qtycomplete", CInt(txtqtycompleted.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtyscrapped", CInt(txtqtyscrapped.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtymoved", CInt(txtqtymoved.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtyrework", CInt(txtqtyrework.Text))
            cmdupdatesfms.Parameters.AddWithValue("@qtygood", CInt(txtqtygood.Text))

            cmdupdatesfms.Parameters.AddWithValue("@job", txtjob.Text)
            cmdupdatesfms.Parameters.AddWithValue("@suffix", txtsuffix.Text)
            cmdupdatesfms.Parameters.AddWithValue("@opernum", txtopernum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@empnum", lblempnum.Text)
            cmdupdatesfms.Parameters.AddWithValue("@transdate", transdateString)
            cmdupdatesfms.Parameters.AddWithValue("@lot", txtlot.Text)
            cmdupdatesfms.Parameters.AddWithValue("@updatedby", lbl_updatedby.Text)

            If txt_mcnum.Text = "" Then
                cmdupdatesfms.Parameters.AddWithValue("@mcnum", DBNull.Value)
            Else
                cmdupdatesfms.Parameters.AddWithValue("@mcnum", txt_mcnum.Text)
            End If


            If CInt(txtqtyscrapped.Text) > 0 AndAlso lblreasondesc.Text = "" Then

                MsgBox("Reason Code is Required")
            Else

                If txtwc.Text = "P230" OrElse txtwc.Text = "P921" OrElse txtwc.Text = "P922" OrElse txtwc.Text = "P924" OrElse txtwc.Text = "F210" OrElse txtwc.Text = "F221" OrElse txtwc.Text = "F230" OrElse txtwc.Text = "F921" OrElse txtwc.Text = "F922" OrElse txtwc.Text = "F924" OrElse txtwc.Text = "M210" OrElse txtwc.Text = "M221" OrElse txtwc.Text = "M230" OrElse txtwc.Text = "M921" OrElse txtwc.Text = "M922" OrElse txtwc.Text = "M924" Then
                    If txtlot.Text <> "" Then
                        cmdupdatesfms.ExecuteNonQuery()

                        MsgBox("Updated Successfully!")

                        btnpost.Enabled = True

                    Else
                        MsgBox("Lot is Required")
                    End If
                Else
                    cmdupdatesfms.ExecuteNonQuery()

                    MsgBox("Updated Successfully!")

                    btnpost.Enabled = True

                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
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
        Else
            txtqtymoved.Text = total
        End If
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

        'If lblnextop.Text Is Nothing OrElse lblnextop.Text = "0" Then
        '    txtqtymoved.Text = "0"
        'Else
        '    txtqtymoved.Text = totalqtycompleted
        'End If

        If lblnextop.Text = "" OrElse lblnextop.Text = "0" Then
            txtqtymoved.Text = "0"
        Else
            txtqtymoved.Text = totalqtycompleted
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        frmviewunposted.Show()
        Me.Close()

        If app_prev_version = app_version Then
            If user_position = "Operator" Then
                load_table_for_operator()
            Else
                load_table_for_supervisor()
            End If
        End If

    End Sub

    Private Sub load_table_for_operator()

        Try
            con.Open()
            Dim cmd_select_sfms_operator As New SqlCommand("Select_sfms_jobtran_operator", con)
            cmd_select_sfms_operator.CommandType = CommandType.StoredProcedure
            cmd_select_sfms_operator.Parameters.AddWithValue("@empnum", frmviewunposted.txtempnum.Text)
            cmd_select_sfms_operator.Parameters.Add("@startdate", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
            cmd_select_sfms_operator.Parameters.Add("@enddate", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)

            Dim sda_operator As New SqlDataAdapter(cmd_select_sfms_operator)
            Dim dt_operator As New DataTable
            sda_operator.Fill(dt_operator)
            frmviewunposted.DataGridView1.DataSource = dt_operator
            AutofitColumns(frmviewunposted.DataGridView1)
            enablecheckbox()
            Me.Close()
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


    Private Function enablecheckbox()
        For Each row As DataGridViewRow In frmviewunposted.DataGridView1.Rows
            row.ReadOnly = True
            row.Cells("Select").ReadOnly = False
        Next
        Return 0
    End Function

    Private Sub load_table_for_supervisor()
        Try
            con.Open()
            Dim cmd_view_unposted_supervisor As New SqlCommand("Select_sfms_jobtran_supervisor", con)
            cmd_view_unposted_supervisor.CommandType = CommandType.StoredProcedure
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@sectionS", frmviewunposted.cmb_section.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@sectionE", frmviewunposted.cmb_section.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@machineS", frmviewunposted.cmb_machine.Text)
            cmd_view_unposted_supervisor.Parameters.AddWithValue("@machineE", frmviewunposted.cmb_machine.Text)
            cmd_view_unposted_supervisor.Parameters.Add("@startdate", SqlDbType.DateTime).Value = frmviewunposted.dtp_start.Value.Date
            cmd_view_unposted_supervisor.Parameters.Add("@enddate", SqlDbType.DateTime).Value = frmviewunposted.dtp_end.Value.AddDays(1)

            Dim sda_supervisor As New SqlDataAdapter(cmd_view_unposted_supervisor)
            Dim dt_supervisor As New DataTable
            sda_supervisor.Fill(dt_supervisor)
            frmviewunposted.DataGridView1.DataSource = dt_supervisor

            'Dim btn As New DataGridViewButtonColumn
            'DataGridView1.Columns.Add(btn)
            'btn.HeaderText = ""
            'btn.Text = "Delete"
            'btn.Name = "btn_delete"
            'btn.UseColumnTextForButtonValue = True
            'DataGridView1.Columns.Insert(1, btn)



            AutofitColumns(frmviewunposted.DataGridView1)
            enablecheckbox()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub
End Class