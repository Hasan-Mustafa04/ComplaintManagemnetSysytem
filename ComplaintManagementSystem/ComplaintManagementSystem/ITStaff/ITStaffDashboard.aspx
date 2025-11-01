<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="ITStaffDashboard.aspx.cs"
    Inherits="ComplaintManagementSystem.ITStaff.ITStaffDashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>IT Staff Dashboard</title>
    <style>
        body { font-family: Arial; margin: 40px; }
        h2 { color: #0078d7; }
        .btn { background: #0078d7; color: white; border: none; padding: 5px 10px; cursor: pointer; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>IT Staff Dashboard</h2>

        <asp:GridView ID="gvMyComplaints" runat="server"
                      AutoGenerateColumns="False"
                      DataKeyNames="ComplaintID"
                      OnRowEditing="gvMyComplaints_RowEditing"
                      OnRowUpdating="gvMyComplaints_RowUpdating"
                      OnRowCancelingEdit="gvMyComplaints_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="ComplaintID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" />
                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                <asp:CommandField ShowEditButton="True" HeaderText="Actions" />
            </Columns>
        </asp:GridView>

        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
    </form>
</body>
</html>
