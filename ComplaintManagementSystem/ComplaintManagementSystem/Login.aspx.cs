using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Redirect to your Register page
        Response.Redirect("Register.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["ComplaintDBConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT * FROM Users WHERE Username=@Username AND Password=@Password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // Store user data in session
                Session["UserID"] = dr["UserID"];
                Session["Username"] = dr["Username"];
                Session["Role"] = dr["Role"].ToString();

                // Redirect based on role
                string role = dr["Role"].ToString();

                if (role == "Faculty")
                    Response.Redirect("~/Faculty/FacultyDashboard.aspx");
                else if (role == "Admin")
                    Response.Redirect("~/Admin/AdminDashboard.aspx");
                else if (role == "ITStaff")
                    Response.Redirect("~/ITStaff/ITStaffDashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}
