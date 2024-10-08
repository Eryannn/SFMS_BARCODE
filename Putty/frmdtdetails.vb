Imports System.Data.SqlClient
Imports System.Globalization
Public Class frmdtdetails
    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
    Dim userid As String = SFMSMENU.lblempnum.Text
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



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con1.Open()
            'Dim updateCommandText As String = "UPDATE IT_KPI_DTDetail SET StartTime=@starttime, EndTime=@endtime, Category=@category, CauseCode=@causecode, RecordDate=@recorddate, Notes=@notes WHERE RefRowPointer=@refrowpointer AND Seq=@seq"
            Dim updateCommandText As String = "UPDATE IT_KPI_DTDetail SET StartTime=@starttime, EndTime=@endtime, DTHrs=@dthrs, Category=@category, CauseCode=@causecode, RecordDate=@recorddate, CreatedBy=@createdby, Notes=@notes WHERE RefRowPointer=@refrowpointer AND Seq=@seq"
            Dim tablecmd As SqlCommand = New SqlCommand("SELECT dtdetail.Seq, dtdetail.StartTime, dtdetail.EndTime,CAST(DATEDIFF(MINUTE, dtdetail.StartTime, dtdetail.EndTime) / 60.0 AS DECIMAL(13, 9)) AS DTHrs, dtdetail.Category, dtdetail.CauseCode, dtcause.RootCause , Notes  from IT_KPI_DTDetail dtdetail
                LEFT JOIN IT_KPI_DTCausemaint dtcause on DTDETAIL.CauseCode = dtcause.CauseCode
                WHERE dtdetail.RefRowPointer = @refrowpointer", con1)
            tablecmd.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)

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
        Catch ex As Exception
            MsgBox(ex.Message)
            ' MsgBox("debug")
        Finally
            con1.Close()
        End Try

        Try
            con1.Open()
            Dim cmdviewdtdetails As SqlCommand = New SqlCommand("SELECT MIN(Seq) as sequence FROM IT_KPI_DTDetail WHERE RefRowPointer = @refrowpointer AND DTHrs IS NULL", con1)

            cmdviewdtdetails.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)

            Dim readseq As SqlDataReader = cmdviewdtdetails.ExecuteReader
            While readseq.Read
                lblseq.Text = readseq("sequence").ToString
            End While
            readseq.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try

    End Sub

    Private Sub cleartext()
        dtpstart.Value = Now
        dtpend.Value = Now
        lbltotalhrs.Text = ""
        cmbcategory.SelectedItem = -1
        cmbcategory.Text = ""
        cmbcause.SelectedItem = -1
        lblrootcause.Text = ""
        txtnotes.Clear()
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
        getcauseandroot.Parameters.AddWithValue("@section", frmdowntime.lblsection.Text)

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
        cmd.Parameters.AddWithValue("@section", frmdowntime.lblsection.Text)

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmdowntime.Show()
        Me.Close()
    End Sub


    Private Sub dtpstart_ValueChanged(sender As Object, e As EventArgs) Handles dtpstart.ValueChanged
        Dim startTime As DateTime = dtpstart.Value
        Dim endTime As DateTime = dtpend.Value

        ' Set seconds component to 0 for both DateTime objects
        startTime = New DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, 0)
        endTime = New DateTime(endTime.Year, endTime.Month, endTime.Day, endTime.Hour, endTime.Minute, 0)

        ' Calculate the difference in minutes
        Dim minutesDifference As Double = DateDiff(DateInterval.Minute, startTime, endTime)

        ' Calculate the difference in hours without rounding
        Dim hoursDifference As Decimal = CDec(minutesDifference / 60.0)

        If hoursDifference < 0 Then
            hoursDifference += 24
        ElseIf hoursDifference >= 24 Then
            hoursDifference -= 24
        End If

        ' Display the result with at least 6 decimal places
        lbltotalhrs.Text = hoursDifference.ToString("0.######")

    End Sub

    Private Sub dtpend_ValueChanged(sender As Object, e As EventArgs) Handles dtpend.ValueChanged
        Dim startTime As DateTime = dtpstart.Value
        Dim endTime As DateTime = dtpend.Value

        ' Set seconds component to 0 for both DateTime objects
        startTime = New DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, 0)
        endTime = New DateTime(endTime.Year, endTime.Month, endTime.Day, endTime.Hour, endTime.Minute, 0)

        ' Calculate the difference in minutes
        Dim minutesDifference As Double = DateDiff(DateInterval.Minute, startTime, endTime)

        ' Calculate the difference in hours without rounding
        Dim hoursDifference As Decimal = CDec(minutesDifference / 60.0)

        If hoursDifference < 0 Then
            hoursDifference += 24
        ElseIf hoursDifference >= 24 Then
            hoursDifference -= 24
        End If

        ' Display the result with at least 6 decimal places
        lbltotalhrs.Text = hoursDifference.ToString("0.######")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Try
            con1.Open()

            Dim tablecmd As SqlCommand = New SqlCommand("SELECT dtdetail.Seq, dtdetail.StartTime, dtdetail.EndTime,CAST(DATEDIFF(MINUTE, dtdetail.StartTime, dtdetail.EndTime) / 60.0 AS DECIMAL(13, 9)) AS DTHrs, dtdetail.Category, dtdetail.CauseCode, dtcause.RootCause , Notes  from IT_KPI_DTDetail dtdetail
                LEFT JOIN IT_KPI_DTCausemaint dtcause on DTDETAIL.CauseCode = dtcause.CauseCode
                WHERE dtdetail.RefRowPointer = @refrowpointer", con1)
            tablecmd.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)

            Dim insertcmd As New SqlCommand("INSERT INTO IT_KPI_DTDetail (RefRowPointer,Seq) values (@refrowpointer,@seq)", con1)
            Dim latestseq As Integer = getlatestsequence()

            insertcmd.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)
            latestseq += 1
            insertcmd.Parameters.AddWithValue("@seq", latestseq)

            'Dim readtable As SqlDataReader = tablecmd.ExecuteReader
            'Dim lastseq As String = readtable("Seq").ToString
            'If readtable.HasRows Then

            '    MsgBox("with rows")
            '    'While readtable.Read
            '    '    Dim validateseq As String = readtable("Seq").ToString
            '    '    MsgBox(validateseq)
            '    '    insertcmd.ExecuteNonQuery()
            '    'End While
            '    'readtable.Close()
            'Else
            '    MsgBox("no rows")
            '    'readtable.Close()
            '    'MsgBox("ERROR")
            'End If


            If lblseq.Text <> "" Then
                MsgBox("Invalid")
            Else

                insertcmd.ExecuteNonQuery()
                ' MsgBox("Sequence add successfully")
                lblseq.Text = latestseq
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con1.Close()
        End Try

        'Try
        '    con1.Open()
        '    Dim updateCommandText As SqlCommand = New SqlCommand("UPDATE IT_KPI_DTDetail SET CreatedBy=@createdby WHERE RefRowPointer=@refrowpointer AND seq=@seq", con1)
        '    updateCommandText.Parameters.AddWithValue("createdby", txtempname.Text)
        '    updateCommandText.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)
        '    updateCommandText.Parameters.AddWithValue("@seq", lblseq.Text)

        '    updateCommandText.ExecuteNonQuery()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con1.Close()
        'End Try

    End Sub
    Private Function getlatestsequence() As Integer
        Dim latestseq As Integer = 0

        Try
            Using con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")
                con.Open()

                Using cmd As New SqlCommand("select max(seq) from IT_KPI_DTDetail where RefRowPointer = @refrowpointer", con)
                    cmd.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)

                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        latestseq = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try

        Return latestseq
    End Function

    Private Sub frmdtdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        '    con1.Open()

        '    Dim cmdviewdtdetails As SqlCommand = New SqlCommand("SELECT MIN(Seq) as sequence FROM IT_KPI_DTDetail WHERE RefRowPointer = @refrowpointer AND DTHrs IS NULL", con1)

        '    cmdviewdtdetails.Parameters.AddWithValue("@refrowpointer", txtrowpointer.Text)

        '    Dim readseq As SqlDataReader = cmdviewdtdetails.ExecuteReader
        '    Dim chksequence As String = readseq("sequence").ToString
        '    MsgBox(chksequence)
        '    'While readseq.Read



        '    '    If chksequence = "" Then
        '    '        lblseq.Text = ""
        '    '    Else
        '    '        lblseq.Text = chksequence
        '    '    End If

        '    '    'lblseq.Text = readseq("sequence").ToString
        '    'End While
        '    'readseq.Close()
        '    MsgBox(chksequence)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    MsgBox("walang seq")
        'Finally
        '    con1.Close()
        'End Try
    End Sub

    Private Sub txtrowpointer_TextChanged(sender As Object, e As EventArgs) Handles txtrowpointer.TextChanged

    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged

    End Sub
End Class