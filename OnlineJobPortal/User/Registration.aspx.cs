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
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into tbl_Users (UserName, Password, Name, Address, Mobile, Email, Country) values (@UserName, @Password, @Name, @Address, @Mobile, @Email, @Country)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@UserName", usernameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", confirmPasswordTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", fullNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", addressTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Mobile", mobileTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", emailTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", countryDDL.SelectedValue);

                con.Open();

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    lblMessage.Text = "Registration Successfull.";
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Visible = true;
                    ClearControls();
                }
                else
                {
                    lblMessage.Text = "Registration Failed.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                    ClearControls();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMessage.Text = "<b>" + usernameTxt.Text.Trim() + "</b> User Name Already Exists. Try Another One.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
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

        public void ClearControls()
        {
            usernameTxt.Text = string.Empty;
            passwordTxt.Text = string.Empty;
            confirmPasswordTxt.Text = string.Empty;
            fullNameTxt.Text = string.Empty;
            addressTxt.Text = string.Empty;
            mobileTxt.Text = string.Empty;
            emailTxt.Text = string.Empty;
            countryDDL.ClearSelection();
        }
    }
}