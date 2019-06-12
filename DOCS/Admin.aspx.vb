Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Admin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn.Click
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim sql As String
        Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
        sql = "insert into login values('" + txtname.Text + "','" + txtuser.Text + "','" + txtpass.Text + "')"
        con = New SqlConnection(cs)
        Try
            con.Open()
            com = New SqlCommand(sql, con)
            com.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            MsgBox("Connection Failed !")
        End Try
        txtname.Text = ""
        txtuser.Text = ""
        txtpass.Text = ""
        Response.Redirect("Admin.aspx")
    End Sub

End Class