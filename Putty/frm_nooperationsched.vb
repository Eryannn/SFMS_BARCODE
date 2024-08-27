Imports System.Data.SqlClient

Public Class frm_nooperationsched
    Dim con_pallettagging As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con_pisp As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = SFMSMENU.lblempnum.Text
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub cmb_machine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_machine.SelectedIndexChanged

        ' Dim latestseq As Integer = getlatestsequence()

        'MsgBox(cmb_machine.Text)
        'MsgBox(latestseq)
        'latestseq += 1
        'MsgBox(latestseq)

        Try
            Dim latestseq As Integer = getlatestsequence()

            latestseq += 1

            lbl_seq.Text = latestseq

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Dim cmd_getlastseq As SqlCommand = New SqlCommand("SELECT MAX(Seq) as Seq FROM sfms_NoOpSchedule WHERE MACHINE = @machine AND totalhrs IS NULL  group by Machine", con_pallettagging)


        'Dim cmd_getlastseq As New SqlCommand("IT_View_lastseqpermachine", con_pallettagging)
        'cmd_getlastseq.CommandType = CommandType.StoredProcedure

        'cmd_getlastseq.Parameters.Add("@machine", SqlDbType.NVarChar).Value = cmb_machine.Text

        'Try
        '    con_pallettagging.Open()

        '    Dim read_cmd_getlastseq As SqlDataReader = cmd_getlastseq.ExecuteReader

        '    If read_cmd_getlastseq.HasRows Then
        '        While read_cmd_getlastseq.Read
        '            lbl_seq.Text = read_cmd_getlastseq("seq").ToString
        '            lbl_seq.Text = CInt(lbl_seq.Text) + 1
        '        End While
        '        read_cmd_getlastseq.Close()
        '    Else
        '        read_cmd_getlastseq.Close()
        '        lbl_seq.Text = 1
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con_pallettagging.Close()
        'End Try

    End Sub
    Private Function getlatestsequence() As Integer
        Dim latestseq As Integer = 0

        Try
            Using con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
                con.Open()

                Using cmd As New SqlCommand("IT_View_lastseqpermachine", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@machine", SqlDbType.NVarChar).Value = cmb_machine.Text

                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        latestseq = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return latestseq
    End Function

    Private Sub cmb_machine_DropDown(sender As Object, e As EventArgs) Handles cmb_machine.DropDown
        cmb_machine.Items.Clear()
        machinelist()
    End Sub

    Private Sub machinelist()
        Dim cmd As New SqlCommand("select RESTYPE, RESID, DESCR, Uf_Resrc_Section from RESRC000 WHERE Uf_Resrc_Section = @section", con_pisp)
        cmd.Parameters.AddWithValue("@section", cmb_section.Text)
        Try
            con_pisp.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                Dim codeanddesc As String = readcmd("RESID").ToString
                cmb_machine.Items.Add(codeanddesc)
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con_pisp.Close()
        End Try
    End Sub

    Private Sub frm_nooperationsched_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblshift.Text = frmlogin.cmbshift.Text
        lblempnum.Text = userid

        Dim cmd_emp_section As SqlCommand = New SqlCommand("select site, Emp_num, name,Dept,Section from Employee where Emp_num = @empnum", con_pallettagging)
        cmd_emp_section.Parameters.AddWithValue("@empnum", userid)

        Try
            con_pallettagging.Open()

            cmd_emp_section.ExecuteNonQuery()

            Dim read_cmd_emp_section As SqlDataReader = cmd_emp_section.ExecuteReader
            If read_cmd_emp_section.HasRows Then
                While read_cmd_emp_section.Read
                    lblempname.Text = read_cmd_emp_section("name").ToString
                    cmb_section.Text = read_cmd_emp_section("Section").ToString
                End While
                read_cmd_emp_section.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con_pallettagging.Close()
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        SFMSMENU.lblshift.Text = lblshift.Text
        SFMSMENU.lbl_site.Text = lbl_site.Text
        SFMSMENU.Show()
        Me.Close()
    End Sub


    Private Sub dtpend_TextChanged(sender As Object, e As EventArgs) Handles dtpend.TextChanged
        Dim dtpendint As Integer = dtpend.Value.Hour * 3600 + dtpend.Value.Minute * 60 + dtpstart.Value.Second

        Dim totaltimeinseconds As Integer = CInt(lbl_endint.Text) - CInt(lbl_startint.Text)

        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        If totalhours < 0 Then
            totalhours = totalhours + 24
        End If



        lbl_endint.Text = dtpendint
        'txttotalhrs.Text = totalhours

        Dim dtpstartint As Integer = dtpstart.Value.Hour * 3600 + dtpstart.Value.Minute * 60 + dtpstart.Value.Second

        Dim totaltimeinseconds1 As Integer = CInt(lbl_endint.Text) - CInt(lbl_startint.Text)

        Dim totalhours1 As Double = Math.Round(totaltimeinseconds1 / 3600, 3)
        If totalhours1 < 0 Then
            totalhours1 = totalhours1 + 24
        End If

        lbl_startint.Text = dtpstartint


    End Sub

    Private Sub dtpstart_TextChanged(sender As Object, e As EventArgs) Handles dtpstart.TextChanged
        Dim dtpstartint As Integer = dtpstart.Value.Hour * 3600 + dtpstart.Value.Minute * 60 + dtpstart.Value.Second

        Dim totaltimeinseconds As Integer = CInt(lbl_endint.Text) - CInt(lbl_startint.Text)

        Dim totalhours As Double = Math.Round(totaltimeinseconds / 3600, 3)
        If totalhours < 0 Then
            totalhours = totalhours + 24
        End If

        lbl_startint.Text = dtpstartint

        Dim dtpendint As Integer = dtpend.Value.Hour * 3600 + dtpend.Value.Minute * 60 + dtpstart.Value.Second

        Dim totaltimeinseconds1 As Integer = CInt(lbl_endint.Text) - CInt(lbl_startint.Text)

        Dim totalhours1 As Double = Math.Round(totaltimeinseconds1 / 3600, 3)
        If totalhours1 < 0 Then
            totalhours1 = totalhours1 + 24
        End If



        lbl_endint.Text = dtpendint
    End Sub

    Private Sub lbl_endint_TextChanged(sender As Object, e As EventArgs) Handles lbl_endint.TextChanged
        Dim totaltime As Integer = CInt(lbl_endint.Text) - CInt(lbl_startint.Text)
        Dim totalhours As Double = totaltime / 3600

        ' Adjust total hours if it's negative or exceeds 24
        If totalhours < 0 Then
            totalhours += 24
        ElseIf totalhours >= 24 Then
            totalhours -= 24
        End If

        lbl_totalhrs.Text = Math.Round(totalhours, 3).ToString()
    End Sub

    Private Sub lbl_startint_TextChanged(sender As Object, e As EventArgs) Handles lbl_startint.TextChanged
        If lbl_endint.Text = "" Then
            lbl_endint.Text = 0
        End If

        Dim totaltime As Integer = CInt(lbl_endint.Text) - CInt(lbl_startint.Text)
        Dim totalhours As Double = totaltime / 3600

        ' Adjust total hours if it's negative or exceeds 24
        If totalhours < 0 Then
            totalhours += 24
        ElseIf totalhours >= 24 Then
            totalhours -= 24
        End If

        lbl_totalhrs.Text = Math.Round(totalhours, 3).ToString()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dtpstartstring As String = dtpstart.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
        Dim dtpendstring As String = dtpend.Value.ToString("MM/dd/yyyy hh:mm:ss tt")


        Try
            con_pallettagging.Open()
            Dim cmd_insert_noopsched As New SqlCommand("IT_Insert_Noopschedule", con_pallettagging)
            cmd_insert_noopsched.CommandType = CommandType.StoredProcedure
            cmd_insert_noopsched.Parameters.Add("@site", SqlDbType.NVarChar).Value = lbl_site.Text
            cmd_insert_noopsched.Parameters.Add("@machine", SqlDbType.NVarChar).Value = cmb_machine.Text
            cmd_insert_noopsched.Parameters.Add("@seq", SqlDbType.SmallInt).Value = CInt(lbl_seq.Text)
            cmd_insert_noopsched.Parameters.Add("@start_datetime", SqlDbType.DateTime).Value = dtpstartstring
            cmd_insert_noopsched.Parameters.Add("@end_datetime", SqlDbType.DateTime).Value = dtpendstring
            cmd_insert_noopsched.Parameters.Add("@Totalhrs", SqlDbType.Decimal).Value = CDbl(lbl_totalhrs.Text)
            cmd_insert_noopsched.Parameters.Add("@NoOpCode", SqlDbType.NVarChar).Value = cmb_reason.Text
            cmd_insert_noopsched.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = txtnotes.Text
            cmd_insert_noopsched.Parameters.Add("@empnum", SqlDbType.NVarChar).Value = lblempnum.Text
            cmd_insert_noopsched.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DateTime.Now
            cmd_insert_noopsched.Parameters.Add("@startint", SqlDbType.Int).Value = CInt(lbl_startint.Text)
            cmd_insert_noopsched.Parameters.Add("@endint", SqlDbType.Int).Value = CInt(lbl_endint.Text)

            If cmb_reason.Text = "" Then
                MsgBox("Reason Code Required")
            Else
                If cmb_machine.Text = "" Then
                    MsgBox("Invalid")
                ElseIf cmb_reason.Text.Length >= 7 Then
                    MsgBox("Invalid Reason Code")
                Else
                    If cmd_insert_noopsched.ExecuteNonQuery = True Then
                        MsgBox("Insert Successfully")

                        Dim latestseq As Integer = getlatestsequence()
                        latestseq += 1
                        lbl_seq.Text = latestseq
                    End If
                End If
            End If



            'cmd_insert_noopsched.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con_pallettagging.Close()
        End Try
    End Sub

    Private Sub cmb_reason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_reason.SelectedIndexChanged
        Dim cmd As New SqlCommand("select NoOpCode, [desc], NoOpCode + ' / ' +  [desc] as codeanddesc from sfms_NoOpCodes where (NoOpCode + ' / ' + [desc]) = @code", con_pallettagging)

        'Dim cmd As New SqlCommand("Select code, description, code + ' / ' + description as codeanddesc from Ptag_Setuptype where (Code + ' / ' + Description) = @code", con)
        cmd.Parameters.AddWithValue("@code", cmb_reason.Text)

        Try
            con_pallettagging.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                lbl_reason_desc.Text = readcmd("desc").ToString
                Dim codeanddesc As String = readcmd("NoOpCode")
                cmb_reason.Items.Add(codeanddesc)
                cmb_reason.Text = readcmd("NoOpCode").ToString
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con_pallettagging.Close()
        End Try
    End Sub

    Private Sub cmb_reason_DropDown(sender As Object, e As EventArgs) Handles cmb_reason.DropDown
        cmb_reason.Items.Clear()
        No_Operation_Reason()
    End Sub

    Private Sub No_Operation_Reason()
        Dim cmd As New SqlCommand("EXEC IT_View_NooperationReason", con_pallettagging)

        Try
            con_pallettagging.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                Dim codeanddesc As String = readcmd("NoOpCode") + " / " + readcmd("desc")
                cmb_reason.Items.Add(codeanddesc)
            End While
            readcmd.Close()
        Catch ex As Exception
        Finally
            con_pallettagging.Close()
        End Try

    End Sub

    Private Sub cmb_section_DropDown(sender As Object, e As EventArgs) Handles cmb_section.DropDown
        lbl_seq.Text = 0
    End Sub
End Class