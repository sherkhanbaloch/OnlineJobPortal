using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace OnlineJobPortal.User
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        string username, password = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginTypeDDL.SelectedValue == "Admin")
                {
                    username = ConfigurationManager.AppSettings["username"];
                    password = ConfigurationManager.AppSettings["password"];

                    if (username == usernameTxt.Text.Trim() && password == passwordTxt.Text.Trim())
                    {
                        Session["admin"] = username;
                        Response.Redirect("../Admin/Dashboard.aspx", false);
                    }
                    else
                    {
                        ShowErrorMessage("Admin");
                    }
                }
                else
                {
                    string qry = "select * from tbl_Users where UserName = @username and Password = @password";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@username", usernameTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", passwordTxt.Text.Trim());

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Session["user"] = reader["UserName"].ToString();
                        Session["userid"] = reader["userID"].ToString();
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        ShowErrorMessage("User");
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
            }
            finally
            {
                con.Close();
            }
        }

        public void ShowErrorMessage(string userType)
        {
            lblMessage.Text = "<b>" + userType + "</b> Credentials Are Incorrect.";
            lblMessage.CssClass = "alert alert-danger";
            lblMessage.Visible = true;
        }
    }
}