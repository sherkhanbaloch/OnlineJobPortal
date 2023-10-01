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

namespace OnlineJobPortal.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                Users();
                Jobs();
                AppliedJobs();
                Contact();
            }
        }

        public void Users()
        {
            string qry = "select count(*) from tbl_Users";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["totalUsers"] = dt.Rows[0][0];
            }
            else
            {
                Session["totalUsers"] = 0;
            }
        }

        public void Jobs()
        {
            string qry = "select count(*) from tbl_Jobs";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["totalJobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["totalJobs"] = 0;
            }
        }

        public void AppliedJobs()
        {
            string qry = "select count(*) from tbl_AppliedJobs";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["totalAppliedJobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["totalAppliedJobs"] = 0;
            }
        }

        public void Contact()
        {
            string qry = "select count(*) from tbl_Contact";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["totalContacts"] = dt.Rows[0][0];
            }
            else
            {
                Session["totalContacts"] = 0;
            }
        }
    }
}