﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Security.Cryptography

Module globalvariable
    Public job_posted As Boolean
    Public checkupdate As Boolean
    Public app_version As String = "1.0"
    Public app_prev_version As String
End Module

Module Module1
    Dim con As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011")
    Dim con1 As New SqlConnection("Data Source=ERP-SVR;Initial Catalog=PI-SP_App;User ID=sa;Password=pi_dc_2011")


    Function check_update()
        Try
            con.Open()
            Dim cmd_checkversion As New SqlCommand("Select Min([version]) as [version], MIN(Maintenance_log) as msg from sfms_Maintenance", con)
            Dim read_cmd As SqlDataReader = cmd_checkversion.ExecuteReader
            If read_cmd.HasRows Then

                While read_cmd.Read
                    app_prev_version = read_cmd("version").ToString
                End While
                read_cmd.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function
    Function openpallettagdb()
        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function

    Function closepallettagdb()
        Try
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function

    Function openpispdb()
        Try
            con1.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function

    Function closepispdb()
        Try
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function

    Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Function cleartext()

        Return 0
    End Function

    Function login(ByVal userid As String, ByVal password As String, ByVal site As String)
        Try
            Dim query As String = "SELECT * FROM Employee WHERE Emp_num=@userid AND Password=@password AND Site=@site"
            Dim cmdquery As New SqlCommand(query, con)

            cmdquery.Parameters.Add("@userid", SqlDbType.NVarChar).Value = userid
            cmdquery.Parameters.Add("@password", SqlDbType.NVarChar).Value = password
            cmdquery.Parameters.Add("@site", SqlDbType.NVarChar).Value = site

            Dim execquery As SqlDataReader = cmdquery.ExecuteReader
            Dim hasrow As Boolean = execquery.Read()

            If hasrow Then
                Dim IsAdmin As Boolean = Convert.ToBoolean(execquery("IsAdmin"))

                If IsAdmin Then
                    'Form4.Show()
                    'Form1.Hide()
                Else
                    SFMSMENU.Show()
                    'frmsetupstart.lblshift.Text = frmlogin.cmbshift.Text
                    'frmsetupstart.lblempnum.Text = frmlogin.txtuserid.Text
                    'frmsetupend.lblempnum.Text = frmlogin.txtuserid.Text
                    SFMSMENU.lbl_site.Text = frmlogin.cmbsite.Text
                    SFMSMENU.lblempnum.Text = frmlogin.txtuserid.Text
                    SFMSMENU.lblshift.Text = frmlogin.cmbshift.Text


                    frmlogin.Hide()
                End If
            Else
                MessageBox.Show("Invalid Credentials!")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        Return 0
    End Function



End Module
