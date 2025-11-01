using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplaintManagementSystem.ITStaff
{
    public partial class ITStaffDashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["ComplaintDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "ITStaff")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
                LoadMyComplaints();
        }

        private void LoadMyComplaints()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"SELECT ComplaintID, Title, Description, Status, Remarks
                                 FROM Complaints
                                 WHERE AssignedTo = @UserID";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvMyComplaints.DataSource = dt;
                gvMyComplaints.DataBind();
            }
        }

        protected void gvMyComplaints_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMyComplaints.EditIndex = e.NewEditIndex;
            LoadMyComplaints();
        }

        protected void gvMyComplaints_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvMyComplaints.DataKeys[e.RowIndex].Value);
            string status = ((TextBox)gvMyComplaints.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string remarks = ((TextBox)gvMyComplaints.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE Complaints SET Status=@Status, Remarks=@Remarks WHERE ComplaintID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Remarks", remarks);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvMyComplaints.EditIndex = -1;
            LoadMyComplaints();
        }

        protected void gvMyComplaints_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMyComplaints.EditIndex = -1;
            LoadMyComplaints();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
