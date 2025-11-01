<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
    <style>
        body { font-family: Arial; margin: 40px; }
        input { margin: 5px 0; width: 240px; padding: 6px; }
        .btn { background: #0078d7; color: #fff; border: none; padding: 8px 16px; cursor: pointer; }
        .btn:hover { background: #005fa3; }
    </style>
</head>
<body>
    <h2>Login</h2>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" /><br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" /><br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
    
    </form>
</body>
</html>
