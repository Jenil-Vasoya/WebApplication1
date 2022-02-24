<%@ Page Title="" Language="C#" MasterPageFile="~/Address Book/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="WebApplication1.Address_Book.AdminPanel.City.CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container box-shadow" style="overflow: hidden">
        <hr />
    <div class="row">
      <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">State</div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlState" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>

    </div>
    <br />

    <div class="row">
        <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">City Name</div>
        <div class="col-md-2">
            <asp:TextBox ID="txtCityName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

    </div>
    <br />


    <div class="row">
        <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">STD Code</div>
        <div class="col-md-2">
            <asp:TextBox ID="txtSTDCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

    </div>
    <br />

    <div class="row">
       <div class="col-md-2 offset-4" style="font-weight: 500; padding-top: 5px">PIN Code</div>
        <div class="col-md-2">
            <asp:TextBox ID="txtPINCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

    </div>
    <br />
        <hr />


   <div class="row">


            <div class="offset-5">
                <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Width="85px" />
         
            
                <asp:HyperLink runat="server" NavigateUrl="~/Address Book/AdminPanel/City/City.aspx" Text="Cancel" ID="hlCancel" CssClass="btn btn-danger" Width="85px" />
            </div>

        </div>
    <div class="row">
       <div class="col-md-6 offset-4 text-danger">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="true"></asp:Label>
        </div>

        </div>
    </div>
    
</asp:Content>
