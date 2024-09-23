Imports System.Data.SqlClient
Imports System.Globalization
Public Class SFMSMENU
    Dim con As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmlogin.txtuserid.Text
    Private Sub SFMSMENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True
        lbldate.Text = Now.ToString("MM/dd/yyyy").ToUpper()

        lbl_user.Text = userid + " " + user_name + " / " + login_shift

        'Timer1.Enabled = True
        'lbldate.Text = Now.ToString("MM/dd/yyyy").ToUpper()
        'lblshift.Text = frmlogin.cmbshift.Text
        'lblempnum.Text = userid
        ''MsgBox(userid)
        'Dim getuserdetails As String = "select Site, Emp_num, Name from Employee where Emp_num = @empnum"
        'Dim cmdgetuserdetails As New SqlCommand(getuserdetails, con)
        'cmdgetuserdetails.Parameters.AddWithValue("@empnum", userid)

        'Try
        '    con.Open()
        '    Dim readuserdetails As SqlDataReader = cmdgetuserdetails.ExecuteReader
        '    If readuserdetails.HasRows Then
        '        While readuserdetails.Read
        '            Dim empname As String = readuserdetails("Name").ToString
        '            lblempname.Text = readuserdetails("Name").ToString + " / " + frmlogin.cmbshift.Text
        '            'lblempnum.Text = userid + " " + empname + " / " + frmlogin.cmbshift.Text
        '            lbl_user.Text = userid + " " + empname + " / " + frmlogin.cmbshift.Text
        '        End While
        '        readuserdetails.Close()
        '    End If
        'Catch ex As Exception
        'Finally
        '    con.Close()
        'End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = Now.ToString("hh:mm:ss tt").ToUpper()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmsetupstart.lblshift.Text = lblshift.Text
            frmsetupstart.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        frmlogin.txtpassword.Clear()
        frmlogin.Show()
        Me.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmmachinestart.lblempnum.Text = lblempnum.Text
            frmmachinestart.Show()
            Me.Close()
        End If

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmdowntime.lblempnum.Text = lblempnum.Text
            frmdowntime.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmlaborstart.lblempnum.Text = lblempnum.Text
            frmlaborstart.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmmove.Show()
            frmmove.lblempnum.Text = lblempnum.Text
            Me.Hide()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmviewunposted.Show()
            frmviewunposted.txtempnum.Text = user_id
            frmviewunposted.txtempname.Text = user_name
            Me.Hide()
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmviewposted.Show()
            frmviewposted.txtempnum.Text = lblempnum.Text
            Me.Close()
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frmfgts.Show()
            frmfgts.txtempnum.Text = lblempnum.Text
            frmfgts.txtshift.Text = lblshift.Text
            Me.Close()
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frm_view_dt.Show()
            frm_view_dt.txtempnum.Text = lblempnum.Text
            Me.Hide()
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        check_update()
        If app_prev_version <> app_version Then
            MsgBox("Please Update the SFMS Application")
        Else
            frm_nooperationsched.Show()
            frm_nooperationsched.lbl_site.Text = lbl_site.Text
            frm_nooperationsched.lblempnum.Text = lblempnum.Text
            Me.Close()
        End If

    End Sub
End Class