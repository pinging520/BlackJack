<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Blackjack.Web.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
    .imgwh{ width:100px; height100px;}
    </style>
    <from runat="server">

    <img src="~/images/2_1.png"  />
 <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
 <asp:Image ID="Image1" runat="server" CssClass="imgwh" ImageUrl="~/images/2_1.png" />
        </from>
</asp:Content>
