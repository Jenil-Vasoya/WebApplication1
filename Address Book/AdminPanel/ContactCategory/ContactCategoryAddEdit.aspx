<%@ Page Title="" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCategoryAddEdit.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.ContactCategory.ContactCategoryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container box-shadow" style="overflow: hidden">
        <hr />
    <div class="row">
        <div class="col-md-2 offset-3" style="font-weight:500; padding-top:5px">ContactCategory Name</div>
        <div class="col-md-2">
            <asp:TextBox ID="txtContactCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2" style="padding-top:5px">
        <asp:RequiredFieldValidator ID="revContactCategory" runat="server" ControlToValidate="txtContactCategoryName" Display="Dynamic" ErrorMessage="*Please enter the Category" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
</div>
    </div>
    <br />
        <hr />
      <div class="row">


            <div class="offset-5">
                <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Width="85px" />
         
            
                <asp:HyperLink runat="server" NavigateUrl="~/Address Book/AdminPanel/ContactCategory/ContactCategory.aspx" Text="Cancel" ID="hlCancel" CssClass="btn btn-danger" Width="85px" />
            </div>

        </div>
    <div class="row">
       <div class="col-md text-danger text-center" style="padding-right: 100px;">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="true"></asp:Label>
        </div>

        </div>

        </div>
</asp:Content>
