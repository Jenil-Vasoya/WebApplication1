<%@ Page Title="City" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="City.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.City.City" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div class="row">
    <div class="col-md-12">
        <h2  style="font-family:News706 BT;">City List</h2>
    </div>
</div>
    <div class="row">
    <div class="col-md-2"><asp:HyperLink ID="hlAddCity" runat="server"  Text="Add City" CssClass="btn btn-outline-dark btn-align-content-center" NavigateUrl="~/Address Book/AdminPanel/City/CityAddEdit.aspx"></asp:HyperLink></div>
         <div style="padding-left:10px">
             <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

         </div>
        </div>
<div class="row">
    <div class="col-md-12" style="overflow-x:auto">
        <asp:GridView runat="server" ID="gvCity" CssClass="table  table-hover" AlternatingRowStyle-BackColor="#efecec" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
            <Columns>
                <asp:BoundField DataField="CityID" HeaderText="ID"/>
                <asp:BoundField DataField="StateName" HeaderText="StateName"/>
                <asp:BoundField DataField="CityName" HeaderText="City" />
                <asp:BoundField DataField="PinCode" HeaderText="Pin Code" />
                <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-success" NavigateUrl='<%#"~/Address Book/AdminPanel/City/CityAddEdit.aspx?CityID=" +Eval("CityID").ToString().Trim()%>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</div>

</asp:Content>
