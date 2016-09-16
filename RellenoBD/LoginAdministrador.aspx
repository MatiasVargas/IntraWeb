<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdministrador.aspx.cs" Inherits="RellenoBD.Views.LoginAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
        .auto-style2 {
            width: 108px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Usuario:</td>
                <td>
                    <asp:TextBox ID="txtUsu" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Contraseña:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtContra" runat="server" Width="198px" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" Width="67px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
