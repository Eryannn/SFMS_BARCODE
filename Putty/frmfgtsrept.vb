Imports System.Data.SqlClient
Imports System.Globalization
Public Class frmfgtsrept
    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = frmmachinestart.lblempnum.Text
    Private Sub fgtslist()

        Dim cmd As New SqlCommand("select trans_file from sfms_lasttran GROUP BY trans_file", con)

        Try
            con.Open()
            Dim readcmd As SqlDataReader = cmd.ExecuteReader
            While readcmd.Read
                Dim transfile As String = readcmd("trans_file")
                cmbstart.Items.Add(transfile)
                'cmbend.Items.Add(transfile)
            End While
            readcmd.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles cmbstart.DropDown
        cmbstart.Items.Clear()
        fgtslist()
    End Sub

    Private Sub cmbend_DropDown(sender As Object, e As EventArgs)
        'cmbend.Items.Clear()
        'fgtslist()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim report1 As New CrystalReport1
        Dim user As String = "sa"
        Dim pwd As String = "pi_dc_2011"
        Dim paramdate As String = Date.Today.ToString("MM/dd/yyyy")

        If cmbstart.SelectedIndex = -1 Then
            MsgBox("Please Select fgts number")
        Else
            report1.SetParameterValue("empname", txtempname.Text)
            report1.SetParameterValue("empnum", txtempnum.Text)
            report1.SetParameterValue("fgtsnumstart", cmbstart.Text)
            report1.SetParameterValue("Date", Date.Today)

            report1.SetDatabaseLogon(user, pwd)
            frmreport.CrystalReportViewer1.ReportSource = report1
            frmreport.CrystalReportViewer1.Refresh()
            frmreport.CrystalReportViewer1.Zoom(100)
            frmreport.Show()
        End If




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmfgts.Show()
        Me.Close()
    End Sub

    Private Sub frmfgtsrept_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class