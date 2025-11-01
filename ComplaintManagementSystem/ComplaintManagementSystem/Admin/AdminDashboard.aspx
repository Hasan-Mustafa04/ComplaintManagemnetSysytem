<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="AdminDashboard.aspx.cs"
    Inherits="ComplaintManagementSystem.Admin.AdminDashboard" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Dashboard</title>
    <style>
        body { font-family: Arial; margin: 40px; }
        h2 { color: #0078d7; }
        grid { margin-top: 20px; }
        .btn { background: #0078d7; color: white; border: none; padding: 5px 10px; cursor: pointer; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Admin Dashboard</h2>
            <asp:GridView ID="gvComplaints" runat="server"
              AutoGenerateColumns="False"
              DataKeyNames="ComplaintID"
              OnRowEditing="gvComplaints_RowEditing"
              OnRowUpdating="gvComplaints_RowUpdating"
              OnRowCancelingEdit="gvComplaints_RowCancelingEdit">

            <Columns>
                <asp:BoundField DataField="ComplaintID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                <asp:TemplateField HeaderText="Assigned To (IT Staff)">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlITStaff" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAssignedTo" runat="server" Text='<%# Eval("AssignedToName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                    
   

            </Columns>
        </asp:GridView>

        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
    </form>
</body>
</html>
