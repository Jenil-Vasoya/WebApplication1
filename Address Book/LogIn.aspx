<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
    <title>Log In</title>
    <style>
        html {
            display: flex;
            flex-flow: row nowrap;
            justify-content: center;
            align-content: center;
            align-items: center;
            height: 100%;
            margin: 0;
            padding: 0;
            background: #ffffff;
            /*background-image: linear-gradient(315deg, #feae96 0%, #fe0944 74%);*/
        }

        body {
            margin: 0;
            flex: 0 1 auto;
            align-self: auto;
            /*recommend 1920 / 1080 max based on usage stats, use 100% to that point*/
            width: 100%;
            max-width: 390px;
            height: 100%;
            max-height: 600px;
            background: linear-gradient(315deg, #feae96 0%, #fe0944 74%);
            -webkit-box-shadow: 0px 0px 96px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: 0px 0px 96px 0px rgba(0,0,0,0.75);
            box-shadow: 0px 0px 96px 0px rgba(0,0,0,0.75);
            border-radius: 25px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center;">Log In</h1>
        <hr />
        <div class="row" style="font-family:Berlin Sans FB;">
            UserName: 
        <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox></div>
        <asp:Label ID="lblUserName" runat="server" Font-Size="Small" ForeColor="#003300"></asp:Label>
        <br /><br />
        <div class="row" style="font-family:Berlin Sans FB;">
        Password : 
            <asp:TextBox ID="txtPassword" type="password" runat="server"></asp:TextBox>
            
       </div>
        <asp:Label ID="lblPassword" runat="server" Font-Size="Small" ForeColor="#003300"></asp:Label>
        <br />
        <hr />
        <asp:Button ID="btnLogIn" CssClass="btn btn-danger" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
        
    </form>

</body>
</html>
