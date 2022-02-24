<%@ Page Title="CountryAddEdit" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryAddEdit.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.Country.AddCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="Container box-shadow" style="overflow: hidden">
      <hr />
       <div class="row"><asp:Label ID="lblMessageMode" runat="server"></asp:Label></div>
    <div class="row">
         <div class="col-md-2 offset-4" style="font-weight:500; padding-top:5px">Country</div>
       <div class="col-md-2">
            <asp:TextBox ID="txtCountryName" CssClass="form-control" runat="server"></asp:TextBox>
       </div>
        
   </div>
    <br />  

       <div class="row">
         <div class="col-md-2 offset-4" style="font-weight:500; padding-top:5px">Country Code</div>
       <div class="col-md-2">
            <asp:TextBox ID="txtCountryCode" CssClass="form-control" runat="server"></asp:TextBox>
       </div>
        
   </div>
    <br /> 
        <hr />
  
   <div class="row">


            <div class="offset-5">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" Width="85px" OnClick="btnSave_Click" />
            
                <asp:HyperLink runat="server" NavigateUrl="~/Address Book/AdminPanel/Country/Country.aspx" Text="Cancel" ID="hlCancel" CssClass="btn btn-danger" Width="85px" />
            </div>

        </div>
    <div class="row">
        <div class="col-md-6 offset-4 text-danger">
            <asp:label runat="server" ID="lblMessage" EnableViewState="true"></asp:label></div>
        
    </div>
       </div>
</asp:Content>
