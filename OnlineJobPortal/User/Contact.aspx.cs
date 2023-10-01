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
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into tbl_Contact values (@name, @email, @subject, @message)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", name.Value.Trim());
                cmd.Parameters.AddWithValue("@email", email.Value.Trim());
                cmd.Parameters.AddWithValue("@subject", subject.Value.Trim());
                cmd.Parameters.AddWithValue("@message", message.Value.Trim());

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    lblMessage.Text = "Message Has Been Sent.";
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Message Has Not Been Sent.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                    ClearControls();
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
            name.Value = string.Empty;
            email.Value = string.Empty;
            subject.Value = string.Empty;
            message.Value = string.Empty;
        }
    }
}