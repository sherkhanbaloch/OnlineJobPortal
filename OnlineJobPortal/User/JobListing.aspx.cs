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
    public partial class JobListing : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);
        public int jobCount = 0;

        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowJobList();
                RBSelectedColorChange();
            }
        }

        public void ShowJobList()
        {
            if (dt == null)
            {
                string qry = "select jobID, Title, Salary, JobType, CompanyName, CompanyLogo, Country, State, CreatedDate from tbl_Jobs";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            DataList1.DataSource = dt;
            DataList1.DataBind();
            lblJobCount.Text = JobCount(dt.Rows.Count);
        }

        public string JobCount(int count)
        {
            if (count > 1)
            {
                return "Total <b>" + count + "</b> Jobs Found.";
            }
            else if (count == 1)
            {
                return "Total <b>" + count + "</b> Job Found.";
            }
            else
            {
                return "No Jobs Found.";
            }
        }

        public void RBSelectedColorChange()
        {
            if (RadioButtonList1.SelectedItem.Selected == true)
            {
                RadioButtonList1.SelectedItem.Attributes.Add("class", "selectedradio");
            }
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

        // Getting Relative Date For Given Date Like -- 1 Month Ago
        public static string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();

            int minutes = 60;
            int hour = 60 * minutes;
            int day = 24 * hour;

            thresholds.Add(60, "{0} Seconds Ago");
            thresholds.Add(minutes * 2, "A Minute Ago");
            thresholds.Add(45 * minutes, "{0} Minutes Ago");
            thresholds.Add(120 * minutes, "An Hour Ago");
            thresholds.Add(day, "{0} Hours Ago");
            thresholds.Add(day * 2, "Yesterday");
            thresholds.Add(day * 30, "{0} Days Ago");
            thresholds.Add(day * 365, "{0} Months Ago");
            thresholds.Add(long.MaxValue, "{0} Years Ago");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;

            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }

            return "";
        }

        public string SelectedCheckBox()
        {
            string jobType = string.Empty;

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    jobType += "'" + CheckBoxList1.Items[i].Text + "',"; // Full Time,Remote
                }
            }
            return jobType = jobType.TrimEnd(',');
        }

        public string SelectedRadioButton()
        {
            string postedDate = string.Empty;
            DateTime date = DateTime.Today;

            if (RadioButtonList1.SelectedValue == "1")
            {
                postedDate = "= Convert(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd") + "') and Convert(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd") + "') and Convert(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd") + "') and Convert(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }
            else
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + "') and Convert(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }

            return postedDate;
        }

        protected void countryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (countryDDL.SelectedValue != "0")
            {
                string qry = "select jobID, Title, Salary, JobType, CompanyName, CompanyLogo, Country, State, CreatedDate from tbl_Jobs where Country = '" + countryDDL.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                ShowJobList();
                RBSelectedColorChange();
            }
            else
            {
                ShowJobList();
                RBSelectedColorChange();
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobtype = string.Empty;
            jobtype = SelectedCheckBox();

            if (jobtype != "")
            {
                string qry = "select jobID, Title, Salary, JobType, CompanyName, CompanyLogo, Country, State, CreatedDate from tbl_Jobs where JobType IN (" + jobtype + ")";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                ShowJobList();
                RBSelectedColorChange();
            }
            else
            {
                ShowJobList();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue != "0")
            {
                string postedDate = string.Empty;
                postedDate = SelectedRadioButton();

                string qry = "select jobID, Title, Salary, JobType, CompanyName, CompanyLogo, Country, State, CreatedDate from tbl_Jobs where Convert(DATE, CreatedDate) " + postedDate + "";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                ShowJobList();
                RBSelectedColorChange();
            }
            else
            {
                ShowJobList();
                RBSelectedColorChange();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                bool isCondition = false;
                string subQuery = string.Empty;
                string jobType = string.Empty;
                string postedDate = string.Empty;
                string addAnd = string.Empty;
                string query = string.Empty;

                List<string> queryList = new List<string>();

                if (countryDDL.SelectedValue != "0")
                {
                    queryList.Add(" Country = '" + countryDDL.SelectedValue + "'");
                    isCondition = true;
                }

                jobType = SelectedCheckBox();

                if (jobType != "")
                {
                    queryList.Add(" JobType IN (" + jobType + ")");
                    isCondition = true;
                }


                if (RadioButtonList1.SelectedValue != "0")
                {
                    postedDate = SelectedRadioButton();
                    queryList.Add(" Convert(DATE, CreatedDate) " + postedDate);
                    isCondition = true;
                }

                if (isCondition)
                {
                    foreach (string a in queryList)
                    {
                        subQuery += a + " and ";
                    }
                    subQuery = subQuery.Remove(subQuery.LastIndexOf("and"), 3);
                    query = "select jobID, Title, Salary, JobType, CompanyName, CompanyLogo, Country, State, CreatedDate from tbl_Jobs where " + subQuery + "";
                }
                else
                {
                    query = "select jobID, Title, Salary, JobType, CompanyName, CompanyLogo, Country, State, CreatedDate from tbl_Jobs";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);

                ShowJobList();
                RBSelectedColorChange();
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            countryDDL.ClearSelection();
            CheckBoxList1.ClearSelection();
            RadioButtonList1.SelectedValue = "0";
            RBSelectedColorChange();
            ShowJobList();
        }
    }
}