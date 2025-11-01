using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ComplaintManagementSystem.Faculty
{
    public partial class FacultyDashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["ComplaintDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Faculty")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
                LoadComplaints();
        }

        private void LoadComplaints()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"SELECT ComplaintID, Title, Description, Status, Remarks
                                 FROM Complaints
                                 WHERE CreatedBy = @UserID";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvMyComplaints.DataSource = dt;
                gvMyComplaints.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                lblMessage.Text = "Please fill in all fields.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO Complaints (Title, Description, Status, Remarks, CreatedBy) VALUES (@Title, @Description, 'New', '', @CreatedBy)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@CreatedBy", Session["UserID"]);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Complaint submitted successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            txtTitle.Text = "";
            txtDescription.Text = "";

            LoadComplaints();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
