using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplaintManagementSystem.Admin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["ComplaintDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadComplaints();
            }
        }

        private void LoadComplaints()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"SELECT c.ComplaintID, c.Title, c.Description, c.Status, c.Remarks,
                                        ISNULL(u.Username, 'Not Assigned') AS AssignedToName
                                 FROM Complaints c
                                 LEFT JOIN Users u ON c.AssignedTo = u.UserID";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvComplaints.DataSource = dt;
                gvComplaints.DataBind();
            }
        }

        protected void gvComplaints_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvComplaints.EditIndex = e.NewEditIndex;
            LoadComplaints();

            DropDownList ddlITStaff = (DropDownList)gvComplaints.Rows[e.NewEditIndex].FindControl("ddlITStaff");

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "SELECT UserID, Username FROM Users WHERE Role='ITStaff'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlITStaff.DataSource = dt;
                ddlITStaff.DataTextField = "Username";
                ddlITStaff.DataValueField = "UserID";
                ddlITStaff.DataBind();
            }
        }

        protected void gvComplaints_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int complaintId = Convert.ToInt32(gvComplaints.DataKeys[e.RowIndex].Value);
            DropDownList ddlITStaff = (DropDownList)gvComplaints.Rows[e.RowIndex].FindControl("ddlITStaff");

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE Complaints SET AssignedTo=@AssignedTo, Status='In Progress' WHERE ComplaintID=@ComplaintID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AssignedTo", ddlITStaff.SelectedValue);
                cmd.Parameters.AddWithValue("@ComplaintID", complaintId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvComplaints.EditIndex = -1;
            LoadComplaints();
        }

        protected void gvComplaints_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvComplaints.EditIndex = -1;
            LoadComplaints();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
