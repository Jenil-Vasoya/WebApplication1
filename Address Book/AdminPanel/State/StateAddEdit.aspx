<%@ Page Title="" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.State.StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container"><div class="Container box-shadow" style="overflow: hidden">
        <hr />
        <div class="row">
            <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">
                Country
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlCountryID" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>


        </div>
        <br />

        <div class="row">
            <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">
                State Name
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtStateName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>


        </div>
        <br />


        <div class="row">
            <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">
                State Code
            </div>

            <div class="col-md-2">
                <asp:TextBox ID="txtStateCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>


        </div>
        <br />
        <hr />

        <div class="row">


            <div class="offset-5">
                <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Width="85px" />
         
            
                <asp:HyperLink runat="server" NavigateUrl="~/Address Book/AdminPanel/State/State.aspx" Text="Cancel" ID="hlCancel" CssClass="btn btn-danger" Width="85px" />
            </div>

        </div>
        <div class="row">
            <div class="col-md-6 offset-4 text-danger">

                <asp:Label runat="server" ID="lblMessage" EnableViewState="true"></asp:Label>
            </div>

        </div>


    </div>
      </div>
</asp:Content>
