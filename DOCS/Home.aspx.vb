Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Home
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            DropDownList1.AppendDataBoundItems = True

            Dim con As SqlConnection
            Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
            Dim cmd As SqlCommand
            Dim sql As String

            sql = "select ID, SEM from drop_1"
            con = New SqlConnection(cs)
            cmd = New SqlCommand(sql, con)

            Try

                con.Open()
                DropDownList1.DataSource = cmd.ExecuteReader()
                DropDownList1.DataTextField = "SEM"
                DropDownList1.DataValueField = "ID"
                DropDownList1.DataBind()

            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con.Dispose()
            End Try

        End If
    End Sub
    Protected Sub loginbtn_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
        sql = "select * from login where email='" + email.Text + "' and pass='" + psw.Text + "'"
        con = New SqlConnection(cs)

        Try
            con.Open()
            cmd = New SqlCommand(sql, con)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If (dr.HasRows) Then
                If (email.Text = "admin@admin" And psw.Text = "admin") Then
                    Response.Redirect("Admin.aspx")
                Else
                    Response.Redirect("Teacher.aspx")
                End If
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "AlertScript", "alert('Wrong Credentials ! Please try again...');", True)
            End If
            email.Text = ""
            psw.Text = ""
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Select_semester(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        DropDownList2.Items.Clear()
        DropDownList2.Items.Add(New ListItem("Select Subject", ""))
        DropDownList2.AppendDataBoundItems = True

        Dim con As SqlConnection
        Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
        Dim cmd As New SqlCommand
        con = New SqlConnection(cs)

        Dim strQuery As String = "select ID, SUB_NAME from drop_2 " & "where SEM_ID=@SEM_ID"



        cmd.Parameters.AddWithValue("@SEM_ID", DropDownList1.SelectedItem.Value)

        cmd.CommandType = CommandType.Text

        cmd.CommandText = strQuery

        cmd.Connection = con

        Try

            con.Open()

            DropDownList2.DataSource = cmd.ExecuteReader()
            DropDownList2.DataTextField = "SUB_NAME"
            DropDownList2.DataValueField = "ID"
            DropDownList2.DataBind()
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "disp();", True)

            If DropDownList2.Items.Count > 1 Then
                DropDownList2.Enabled = True
            Else
                DropDownList2.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub Select_course() Handles DropDownList2.SelectedIndexChanged
        Dim con As SqlConnection
        Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
        Dim cmd As New SqlCommand
        con = New SqlConnection(cs)
        Dim sql As String = "select ROLL_NO,NAME,MARKS from STUDENT where SUB_NAME='" + DropDownList2.SelectedItem.Text + "' "
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Try
            con.Open()
            cmd = New SqlCommand(sql, con)
            da.SelectCommand = cmd
            da.Fill(ds, "STUDENT")
            GridView1.DataMember = "STUDENT"
            GridView1.DataSource = ds
            GridView1.DataBind()
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "disp();", True)
            con.Close()

        Catch ex As Exception

        End Try

    End Sub
End Class