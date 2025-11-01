<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="FacultyDashboard.aspx.cs"
    Inherits="ComplaintManagementSystem.Faculty.FacultyDashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Faculty Dashboard</title>
    <style>
        body { font-family: Arial; margin: 40px; }
        h2 { color: #0078d7; }
        input, textarea { width: 300px; margin: 5px 0; padding: 6px; }
        .btn { background: #0078d7; color: white; border: none; padding: 6px 12px; cursor: pointer; }
        .btn:hover { background: #005fa3; }
        table { margin-top: 20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Faculty Dashboard</h2>

        <h3>Submit New Complaint</h3>
        <asp:TextBox ID="txtTitle" runat="server" Placeholder="Complaint Title"></asp:TextBox><br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" Placeholder="Description"></asp:TextBox><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Complaint" CssClass="btn" OnClick="btnSubmit_Click" /><br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

        <hr />

        <h3>Your Complaints</h3>
        <asp:GridView ID="gvMyComplaints" runat="server" AutoGenerateColumns="True"></asp:GridView>

        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
    </form>
</body>
</html>
