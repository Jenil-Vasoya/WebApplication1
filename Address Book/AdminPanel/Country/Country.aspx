<%@ Page Title="Country" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs"  Inherits="WebApplication1.Address_Book.AdminPanel.Country.Country" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-md-12">
        <h2 style="font-family:News706 BT;">Country List</h2>
    </div>
</div>
     <div class="row" style="overflow-x:auto">
    <div class="col-md-2"><asp:HyperLink ID="hlAddCountry" runat="server"  Text="Add Country" CssClass="btn btn-outline-dark btn-align-content-center" NavigateUrl="~/Address Book/AdminPanel/Country/CountryAddEdit.aspx"></asp:HyperLink></div>
         <div style="padding-left:10px"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></div>
        </div>
<div class="row">
    <div class="col-md-12">
        <asp:GridView runat="server" ID="gvCountry" CssClass="table  table-hover" AlternatingRowStyle-BackColor="#efecec" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
            <Columns>

                <asp:BoundField DataField="CountryID" HeaderText="ID"/>
                <asp:BoundField DataField="CountryName" HeaderText="Country" />
                <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger text-black-50" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        
                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-success" CommandName="EditRecord" NavigateUrl='<%# "~/Address Book/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" +  Eval("CountryID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</div>
   
</asp:Content>
