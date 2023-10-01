using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineJobPortal.User
{
    public partial class JobDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        public string JobTitle = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ShowJobDetails();
                DataBind();
            }
            else
            {
                Response.Redirect("JobListing.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowJobDetails()
        {
            string qry = "select * from tbl_Jobs where jobID = @id";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataList1.DataSource = dt;
            DataList1.DataBind();

            JobTitle = dt.Rows[0]["Title"].ToString();
        }

        // Setting Default Image If There Is No Image For Any Job
        public string GetImageURL(Object url)
        {
            string url1 = "";

            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "~/Images/No_Image.png";
            }
            else
            {
                url1 = string.Format("~/{0}", url);
            }

            return ResolveUrl(url1);
        }

        bool IsApplied()
        {
            string qry = "select * from tbl_AppliedJobs where JobID = @JobID and UserID = @UserID";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@JobID", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@UserID", Session["userid"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "cmdApplyJob")
            {
                if (Session["user"] != null)
                {
                    try
                    {
                        string qry = "insert into tbl_AppliedJobs values (@JobID, @UserID)";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.Parameters.AddWithValue("@JobID", Request.QueryString["id"]);
                        cmd.Parameters.AddWithValue("@UserID", Session["userid"]);

                        con.Open();
                        int a = cmd.ExecuteNonQuery();

                        if (a > 0)
                        {
                            lblMessage.Text = "Job Applied Successfull.";
                            lblMessage.CssClass = "alert alert-success";
                            lblMessage.Visible = true;
                            ShowJobDetails();
                        }
                        else
                        {
                            lblMessage.Text = "Job Could Not Applied.";
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
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("btnApply") as LinkButton;

                if (IsApplied())
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Applied";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "Apply Now";
                }
            }
        }
    }
}