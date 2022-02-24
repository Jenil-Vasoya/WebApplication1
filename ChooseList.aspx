<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseList.aspx.cs" Inherits="WebApplication1.ChooseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choose List</title>
     <style>
     .Color {
    background-color: #feae96;
background-image: linear-gradient(315deg, #feae96 0%, #fe0944 74%);
    }</style>
</head>
<body>
    <form id="form1" runat="server">

       <div class="Color col-lg-5"><asp:ImageButton ID="imgbtnDU" runat="server" ToolTip-="Darshan University" PostBackUrl="~/hlHomePage.aspx" ImageUrl="~/Images/DUlogo.svg" />
        </div>
        <h1 class="Color">RadioButton</h1>
        Select the Department : 
        <asp:RadioButton ID="rbtnDU" Text="DU-Degree" runat="server" GroupName="collage" ToolTip="Darshan University Degree Department" OnCheckedChanged="rbtnDU_CheckedChanged" AutoPostBack="True"/>
        <asp:RadioButton ID="rbtnDUD" Text="DU-Diploma" runat="server" GroupName="collage" ToolTip="Darshan University Diploma Department" AutoPostBack="True" OnCheckedChanged="rbtnDUD_CheckedChanged" />
        <hr />
        <asp:Label ID="lblrMessage" runat="server" Visible="true"></asp:Label><div />
        
        <asp:RadioButton ID="rbtnCE" Text="Computer Engineering - Degree"  runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div/>
        <asp:RadioButton ID="rbtnME" Text="Mechanical Engineering - Degree" runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div/>
        <asp:RadioButton ID="rbtnEE" Text="Electrical Engineering - Degree" runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div/>
        <asp:RadioButton ID="rbtnCI" Text="Civil Engineering - Degree" runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div/>
        <asp:RadioButton ID="rbtnCED" Text="Computer Engineering - Diploma"  runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div />
        <asp:RadioButton ID="rbtnMED" Text="Mechanical Engineering - Diploma" runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div />
        <asp:RadioButton ID="rbtnEED" Text="Electrical Engineering - Diploma" runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div />
        <asp:RadioButton ID="rbtnCID" Text="Civil Engineering - Diploma" runat="server" GroupName="Department" Visible="false" AutoPostBack="True" /><div />
        <asp:Button ID="btnrShow" runat="server" Text="Button" Visible="false" OnClick="btnrShow_Click" /><div />
        
        <asp:Label ID="lblrShow" runat="server" Text=""></asp:Label>

        <%-- CheckBox --%>

        <h1 class="Color">CheckBox</h1>
        Select the Department : 
        <asp:CheckBox ID="chkbDU" runat="server" Text="DU-Degree" AutoPostBack="True" OnCheckedChanged="chkbDU_CheckedChanged" />
        <asp:CheckBox ID="chkbDUD" runat="server" Text="DU-Diploma" AutoPostBack="True" OnCheckedChanged="chkbDUD_CheckedChanged" />
        <asp:CheckBox ID="chkbSelectAll" runat="server" Text="Select All" AutoPostBack="True" OnCheckedChanged="chkbSelectAll_CheckedChanged" />
        <div />
        <asp:Label ID="lblcMessage" runat="server" Visible="true"></asp:Label><div />
        <asp:CheckBox ID="chkbCE" runat="server" Text="Computer Engineering - Degree" Visible="false" /><div/>
        <asp:CheckBox ID="chkbME" runat="server" Text="Mechanical Engineering - Degree" Visible="false" /><div />
        <asp:CheckBox ID="chkbEE" runat="server" Text="Electrical Engineering - Degree" Visible="false" /><div />
        <asp:CheckBox ID="chkbCI" runat="server" Text="Civil Engineering - Degree" Visible="false" /><div />
        <asp:CheckBox ID="chkbCED" runat="server" Text="Computer Engineering - Diploma" Visible="false" /><div/>
        <asp:CheckBox ID="chkbMED" runat="server" Text="Mechanical Engineering - Diploma" Visible="false" /><div />
        <asp:CheckBox ID="chkbEED" runat="server" Text="Electrical Engineering - Diploma" Visible="false" /><div />
        <asp:CheckBox ID="chkbCID" runat="server" Text="Civil Engineering - Diploma" Visible="false" /><div />
        <asp:Button ID="btncShow" runat="server" Text="Button" Visible="false" OnClick="btncShow_Click"  /><div />
        <asp:Label ID="lblcShow" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
