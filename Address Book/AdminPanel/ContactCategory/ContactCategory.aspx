<%@ Page Title="ContactCategory" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCategory.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.ContactCategory.ContactCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
    <div class="col-md-12">
        <h2 style="font-family:News706 BT;">ContactCategory List</h2>
    </div>
</div>
     <div class="row">
    <div class="col-md-2">
        <asp:HyperLink ID="hlAddContactCategory" runat="server"  Text="Add ContactCategory" CssClass="btn btn-outline-dark" NavigateUrl="~/Address Book/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx"></asp:HyperLink></div>
         <div style="padding-left:10px">
             <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

         </div>
        </div>
   
<div class="row">
    <div class="col-md-12" style="overflow-x:auto">
        <asp:GridView runat="server" ID="gvContactCategory" CssClass="table  table-hover" AlternatingRowStyle-BackColor="#efecec" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
            <Columns>
                <asp:BoundField DataField="ContactCategoryID" HeaderText="ID"/>
                <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-success" NavigateUrl='<%#"~/Address Book/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" +Eval("ContactCategoryID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</div>
</asp:Content>
