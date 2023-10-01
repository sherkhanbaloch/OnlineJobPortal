using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                btnRegisterOrProfile.Text = "Profile";
                btnLoginOrLogout.Text = "Log Out";
            }
            else
            {
                btnRegisterOrProfile.Text = "Register";
                btnLoginOrLogout.Text = "Login";
            }
        }

        protected void btnRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (btnRegisterOrProfile.Text == "Profile")
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }

        protected void btnLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (btnLoginOrLogout.Text == "Login")
            {
                Response.Redirect("Login.aspx");  
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}