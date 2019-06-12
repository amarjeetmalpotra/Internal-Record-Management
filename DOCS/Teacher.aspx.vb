Imports System.Data
Imports System.Data.SqlClient

Public Class Teacher
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
        Dim sql As String = "select ROLL_NO,NAME,MARKS from STUDENT where SUB_NAME='" + DropDownList2.SelectedItem.Text + "' and SEM='" + DropDownList1.SelectedItem.Text + "' "
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
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "dis();", True)
            con.Close()

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim ROLL_NO As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("DELETE FROM STUDENT WHERE ROLL_NO=@ROLL_NO")
                cmd.Parameters.AddWithValue("@ROLL_NO", ROLL_NO)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Select_course()
            End Using
        End Using
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        Select_course()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim ROLL_NO As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        Dim NAME As String = TryCast(row.Cells(2).Controls(0), TextBox).Text
        Dim MARKS As String = TryCast(row.Cells(3).Controls(0), TextBox).Text
        Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("UPDATE STUDENT SET NAME = @NAME, MARKS = @MARKS WHERE ROLL_NO = @ROLL_NO")
                cmd.Parameters.AddWithValue("@ROLL_NO", ROLL_NO)
                cmd.Parameters.AddWithValue("@NAME", NAME)
                cmd.Parameters.AddWithValue("@MARKS", MARKS)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        GridView1.EditIndex = -1
        Select_course()
    End Sub
    Protected Sub Insert_btn_Click(sender As Object, e As EventArgs) Handles Insert_btn.Click
        If DropDownList2.SelectedItem.Text = "Select Subject" Or txtroll.Text = "" Or txtname.Text = "" Or txtmarks.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AlertScript", "alert('Some selections or entries are missing !');", True)
            Select_course()
        Else
            Dim con As SqlConnection
            Dim cs As String = " Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mojojojo\source\repos\DOCS\DOCS\App_Data\Database.mdf;Integrated Security=True"
            Dim cmd As SqlCommand
            Dim sql As String

            sql = "insert into STUDENT values('" & txtroll.Text & "','" & txtname.Text & "','" & txtmarks.Text & "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')"

            con = New SqlConnection(cs)
            Try
                con.Open()
                cmd = New SqlCommand(sql, con)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            Finally
                con.Close()
            End Try
            txtname.Text = ""
            txtroll.Text = ""
            txtmarks.Text = ""
            Select_course()
        End If
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        Select_course()
    End Sub
End Class