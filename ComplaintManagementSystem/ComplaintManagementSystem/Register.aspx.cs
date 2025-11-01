using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Register : System.Web.UI.Page
{
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // get connection string from Web.config
        string cs = ConfigurationManager.ConnectionStrings["ComplaintDBConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            // insert new faculty user
            string query = "INSERT INTO Users (Username, Password, Role, Email) VALUES (@Username, @Password, @Role, @Email)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Registration successful! You can now log in.";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                // clear form
                txtUsername.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
