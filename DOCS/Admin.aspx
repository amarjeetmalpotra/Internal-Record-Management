<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="DOCS.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Pragma" content="no-cache"/>
    <link href="Style/admin.css" rel="stylesheet" />
    <link href="Style/master.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Style/loading.css"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css"/> 
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Prosto+One" rel="stylesheet"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="Script/admin.js"></script>

    <title>DOCS | Admin Hub</title>

    <style>
        .dropdown-content a:hover{
          border-bottom: none;
        }
    </style>

</head>

<body onload="changeHashOnLoad();">
    <div class="loader"></div>
    <div class="header">
        <a href="Home.aspx"><img src="Images/logo.png" height="70" width="100" style="padding-top:8px;"/></a>
        <span style="cursor:default;">Admin Hub</span>
    </div>
    
<div class="topnav" id="myTopnav">
  <a onclick="logout()" class="active" style="color:white;"><i class="fas fa-home"></i></a>
<div class="dropdown">
  <div class="dropbtn">Users&nbsp;<i class="fas fa-caret-down"></i></div>
  <div class="dropdown-content">
      <a href="#" onclick="adduser()">Add User</a>
      <a href="Admin.aspx">Dashboard</a>
  </div>
</div>
  <a onclick="logout()" class="right_login"><i class="fas fa-sign-out-alt"></i>&nbsp;Logout</a>
  <a href="javascript:void(0);" class="icon" onclick="myFunction()">
    <i class="fas fa-bars"></i>
  </a>
</div>
    <div class="responsive_img">
    <form id="form1" runat="server" visible="true"> 
<!-----------------------------WORKSPACE---------------------------------->
         <div class="workspace" id="add_user">
               <div class="heading">  <h3> User Registration</h3> </div> 
    
                <div class="row">
                <div class="column1" >
                     <div class="div1">
                          <label> Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                          <asp:TextBox ID="txtname" runat="server" onclick="dis()" Type="text" required="required" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                      </div>
                    <br />
                        <div class="div1">
                           <label>Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                           <asp:TextBox ID="txtuser" runat="server" type="email" required="required" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                      </div>
                    <br />
                      <div class="div1">
                           <label> Password&nbsp;</label>
                           <asp:TextBox ID="txtpass" runat="server" required="required" type="password" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                      </div>
                </div>                      
              </div>
                <div class="row">
                    <div class="column3">
                     <asp:Button ID="Btn" runat="server" CssClass="btn"  Text="Register" />
                        <button  onclick="wrkspce()" class="close">Close</button>
                </div>
                    <div id="note" class="column4" style="color:red; display:none;">
                     <p><i class="fas fa-exclamation-circle ld ld-fade"></i>&nbsp;Remember credentials while creating a new User .... !</p>
      
                    </div>
                </div>
            </div>
<!-----------------------------WORKSPACE---------------------------------------->

<!-----------------------------DASHBOARD---------------------------------------->
<div class="dashboard" id="dash_board">
    <div class="heading">  <h3>Dashboard</h3>
    </div>

      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [login] WHERE [email] = @original_email" InsertCommand="INSERT INTO [login] ([name], [email], [pass]) VALUES (@name, @email, @pass)" SelectCommand="SELECT * FROM [login]" UpdateCommand="UPDATE [login] SET [name] = @name, [pass] = @pass WHERE [email] = @original_email" OldValuesParameterFormatString="original_{0}">
          <DeleteParameters>
              <asp:Parameter Name="original_email" Type="String" />
          </DeleteParameters>
          <InsertParameters>
              <asp:Parameter Name="name" Type="String" />
              <asp:Parameter Name="email" Type="String" />
              <asp:Parameter Name="pass" Type="String" />
          </InsertParameters>
          <UpdateParameters>
              <asp:Parameter Name="name" Type="String" />
              <asp:Parameter Name="pass" Type="String" />
              <asp:Parameter Name="original_email" Type="String" />
          </UpdateParameters>
      </asp:SqlDataSource>
      <br/>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="email" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="140px" Width="100%">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
              <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" SortExpression="email" />
              <asp:BoundField DataField="pass" HeaderText="Password" SortExpression="pass" />
              <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" DeleteImageUrl="~/Images/del.png" EditImageUrl="~/Images/edit.png" EditText="Modify" HeaderText="Actions" >
              <ControlStyle CssClass="action_btn" />
              </asp:CommandField>
          </Columns>
          <EditRowStyle BackColor="#bababa" />
          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#00D98B" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center"/>
          <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#F8FAFA" />
          <SortedAscendingHeaderStyle BackColor="#246B61" />
          <SortedDescendingCellStyle BackColor="#D4DFE1" />
          <SortedDescendingHeaderStyle BackColor="#15524A" />
          
      </asp:GridView>

</div>
<!-----------------------------DASHBOARD---------------------------------------->
</form>
</div>
    <footer style="float:right;padding-right:10px"><i class="far fa-copyright"></i>&nbsp;IngeniousTekki</footer>

</body>
</html>
