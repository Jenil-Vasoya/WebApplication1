<%@ Page Title="" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.Contact.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row">
    <div class="col-md-12">
        <h2 style="font-family:News706 BT;">Contact List</h2>
    </div>
</div>
    <div class="row">
    <div class="col-md-2"><asp:HyperLink ID="hlAddContact" runat="server"  Text="Add Contact" CssClass="btn btn-outline-dark" NavigateUrl="~/Address Book/AdminPanel/Contact/ContactAddEdit.aspx"></asp:HyperLink></div>
         <div style="padding-left:10px">
             <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

         </div>
        </div>
<div class="row">
    <div class="col-md-12"  style="overflow:auto">
        <asp:GridView runat="server" ID="gvContact" CssClass="table  table-hover" AlternatingRowStyle-BackColor="#efecec" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
            <Columns>
                <asp:BoundField DataField="ContactID" HeaderText="ID"/>
                <asp:BoundField DataField="ContactName" HeaderText="Contact" />
                <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                <asp:BoundField DataField="StateName" HeaderText="State"/>
                <asp:BoundField DataField="CityName" HeaderText="City"/>
                <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory"/>
                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                <asp:BoundField DataField="WhatsappNo" HeaderText="Whatsapp No" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                <asp:BoundField DataField="FacebookID" HeaderText="Facebook ID" />
                <asp:BoundField DataField="LinkedINID" HeaderText="LinkedINID" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-success" NavigateUrl='<%# "~/Address Book/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" +Eval("ContactID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</div>

</asp:Content>
