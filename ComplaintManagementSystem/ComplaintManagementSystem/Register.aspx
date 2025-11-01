<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtUsername" runat="server" />
        <asp:TextBox ID="txtEmail" runat="server" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        <asp:DropDownList ID="ddlRole" runat="server">
            <asp:ListItem>Faculty</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <asp:Label ID="lblMessage" runat="server" />
    </form>
</body>
</html>
