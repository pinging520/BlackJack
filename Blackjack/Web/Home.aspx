<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Blackjack.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language=javascript>

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <div>
        <h2 style="text-align:center">
            Round：<asp:Label ID="Rd" runat="server" Text=""></asp:Label>
            &nbsp;
            Decks：<asp:Label ID="Deck" runat="server" Text=""></asp:Label>
        </h2>
    </div>
    <hr>

    <asp:Button ID="Button1" runat="server" Text="start" OnClick="Button1_Click" /><br />
    <div style="text-align:center">
    <asp:Label ID="M1" runat="server" Text=""></asp:Label><br>
    <asp:ListView ID="ListView" runat="server" >
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Image ID='Img' runat='server' ImageUrl='<%#string.Format("~/Images/{0}_{1}.png",Eval("Color"),Eval("point")) %>' width="100"  height="150" />
            </td>
            </tr>
    </ItemTemplate>
    </asp:ListView><br />
    

    <div><br />
        <asp:Label ID="Game" runat="server" Text=""></asp:Label>
    </div><br />
    <div>
    <asp:Label ID="U1" runat="server" Text=""></asp:Label>
    </div>
    <asp:ListView ID="ListView1" runat="server" >
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Image ID='Image1' runat='server' ImageUrl='<%#string.Format("~/Images/{0}_{1}.png",Eval("Color"),Eval("point")) %>' width="100"  height="150" />
            </td>
            </tr>
    </ItemTemplate></asp:ListView><br /><br />
        <div class="btn-group " >
            <asp:Button ID="Hit" runat="server" class="btn btn-default" style="width:150px" Text="  Hit  " OnClick="Hit_Click" />
            <asp:Button ID="Close" runat="server" class="btn btn-default" style="width:150px" Text="Stand" OnClick="Close_Click" /><br />
        </div
     </div>
</ContentTemplate>
  </asp:UpdatePanel>     

</asp:Content>
