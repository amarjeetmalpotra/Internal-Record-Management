<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="DOCS.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Pragma" content="no-cache"/>
    <link href="Style/home.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css"/> 
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Prosto+One" rel="stylesheet"/>
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script> 
   <script src="Script/home.js"></script>
   <script src="Script/sketch.js"></script>

    <title>DOCS | Home</title>
    <link href="Style/master.css" rel="stylesheet" />
</head>
<body>
<div class="loader"></div>
    
    <div class="header">
        <a href="Home.aspx"><img src="Images/logo.png" height="70" width="100" style="padding-top:8px;"/></a>
        <span style="cursor:default;">Department Of Computer Science</span>
    </div>
    
   
<div class="topnav" id="myTopnav">
  <a href="Home.aspx" class="active" style="color:white;"><i class="fas fa-home"></i></a>
  <a onclick="disp()"><i class="fas fa-user-graduate"></i>&nbsp;Students</a>
  <a id="login" onclick="openForm()" class="right_login"><i class="fas fa-sign-in-alt"></i>&nbsp;Login</a>
  <a href="javascript:void(0);" class="icon" onclick="myFunction()">
    <i class="fas fa-bars"></i>
  </a>
</div>

    <form  runat="server" >
    <div class="form-popup" id="myForm">
     
<div class="form-container">
    <h1>Login</h1>

    <label for="email"><b>Email</b></label>
    <asp:TextBox ID="email" placeholder="Enter Email" type="email" runat="server" autocomplete="off"></asp:TextBox>

    <label for="psw"><b>Password</b></label>
    <asp:TextBox ID="psw" pattern=".{4,}" title="Must contain at least 4 or more characters" placeholder="Enter Password" type="password" runat="server" autocomplete="off"></asp:TextBox>

    <asp:Button ID="Loginbtn" type="submit" CssClass="btn login" runat="server" Text="Login"></asp:Button>
    <button type="button" class="btn cancel" onclick="closeForm()">Close</button>
 
    </div>
</div>
 <div class="responsive_img">

     <!-----------------------------WORKSPACE---------------------------------->

     <div class="workspace" id="stud">
         <div class="heading">  <h3>Students</h3> </div>
         <div class="drop">
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Select_semester" CssClass="drop_list" >
             <asp:ListItem Text = "Select Semester" Value = ""></asp:ListItem>
         </asp:DropDownList> 

          <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Select_course" Enabled="false" CssClass="drop_list" >
             <asp:ListItem Text = "Select Subject" Value = ""></asp:ListItem>
         </asp:DropDownList>
         </div>
     
         <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
             <AlternatingRowStyle BackColor="White" />
             <EditRowStyle BackColor="#7C6F57" />
             <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#00D98B" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#E3EAEB"  HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F8FAFA" />
             <SortedAscendingHeaderStyle BackColor="#246B61" />
             <SortedDescendingCellStyle BackColor="#D4DFE1" />
             <SortedDescendingHeaderStyle BackColor="#15524A" />
             </asp:GridView>
     </div>

<!-----------------------------WORKSPACE---------------------------------->
 </div> 
   </form>
    <footer style="float:right;padding-right:10px;"><i class="far fa-copyright"></i>&nbsp;IngeniousTekki</footer>
</body>
</html>
