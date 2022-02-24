<%@ Page Title="State" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="State.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.State.State" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
    <div class="col-md-12">
        <h2 style="font-family:News706 BT;">State List</h2>
    </div>
</div>
      <div class="row" style="overflow-x:auto">
    <div class="col-md-2"><asp:HyperLink ID="hlAddState" runat="server"  Text="Add State" CssClass="btn btn-outline-dark btn-align-content-center" NavigateUrl="~/Address Book/AdminPanel/State/StateAddEdit.aspx"></asp:HyperLink></div>
         <div style="padding-left:10px"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></div>
        </div>
<div class="row">
    <div class="col-md-12">
        <asp:GridView runat="server" ID="gvState" CssClass="table  table-hover" AlternatingRowStyle-BackColor="#efecec" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
            <Columns>
                <asp:BoundField DataField="StateID" HeaderText="ID"/>
                <asp:BoundField DataField="CountryName" HeaderText="CountryName"/>
                <asp:BoundField DataField="StateName" HeaderText="State" />
                <asp:BoundField DataField="StateCode" HeaderText="State Code" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-success" NavigateUrl='<%# "~/Address Book/AdminPanel/State/StateAddEdit.aspx?StateID=" +  Eval("StateID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</div>
   
</asp:Content>
