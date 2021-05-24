<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Blackjack.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language=javascript>

             

    </script>
    
    
    <asp:Button ID="Button1" runat="server" Text="start" OnClick="Button1_Click" /><br />
    <asp:Label ID="M1" runat="server" Text="master"></asp:Label>
    <asp:ListView ID="ListView" runat="server" >
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Image ID='Img' runat='server' ImageUrl='<%#string.Format("~/Images/{0}_{1}.png",Eval("Color"),Eval("point")) %>' width="100"  height="150" />
            </td>
            </tr>
    </ItemTemplate>
    </asp:ListView>


    <asp:Button ID="Up" runat="server" Text="Up" OnClick="Up_Click" />
    <asp:Button ID="Close" runat="server" Text="Close" OnClick="Close_Click" /><br />
    
    <asp:Label ID="U1" runat="server" Text="Mycard"></asp:Label><br />
    <asp:Image ID="Image2" runat="server" />
    
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <asp:ListView ID="ListView1" runat="server" >
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Image ID='Image1' runat='server' ImageUrl='<%#string.Format("~/Images/{0}_{1}.png",Eval("Color"),Eval("point")) %>' width="100"  height="150" />
            </td>
            </tr>
    </ItemTemplate>
       
    </asp:ListView>
     
</asp:Content>
