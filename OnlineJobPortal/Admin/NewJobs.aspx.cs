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
    public partial class NewJobs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            Session["title"] = "Add New Job";

            if (!IsPostBack)
            {
                FillData();
            }
        }

        public void FillData()
        {
            if (Request.QueryString["id"] != null)
            {
                string qry = "select * from tbl_Jobs where jobID = '" + Request.QueryString["id"] + "'";
                cmd = new SqlCommand(qry, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        jobTitleTxt.Text = reader["Title"].ToString();
                        noOfPostsTxt.Text = reader["NoOfPosts"].ToString();
                        descriptionTxt.Text = reader["Description"].ToString();
                        qualificationTxt.Text = reader["Qualification"].ToString();
                        experienceTxt.Text = reader["Experience"].ToString();
                        specializationTxt.Text = reader["Specialization"].ToString();
                        lastDateTxt.Text = Convert.ToDateTime(reader["LastDateToApply"]).ToString("yyyy-MM-dd");
                        salaryTxt.Text = reader["Salary"].ToString();
                        jobTypeDDL.SelectedValue = reader["JobType"].ToString();
                        companyNameTxt.Text = reader["CompanyName"].ToString();
                        websiteTxt.Text = reader["Website"].ToString();
                        emailTxt.Text = reader["Email"].ToString();
                        addressTxt.Text = reader["Address"].ToString();
                        countryDDL.SelectedValue = reader["Country"].ToString();
                        stateTxt.Text = reader["State"].ToString();

                        btnAdd.Text = "Update Job";
                        linkBack.Visible = true;
                        Session["title"] = "Update Job";
                    }
                }
                else
                {
                    lblMessage.Text = "Job Not Found.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
                reader.Close();
                con.Close();
            }
        }

        public void ClearControls()
        {
            jobTitleTxt.Text = string.Empty;
            noOfPostsTxt.Text = string.Empty;
            descriptionTxt.Text = string.Empty;
            qualificationTxt.Text = string.Empty;
            experienceTxt.Text = string.Empty;
            specializationTxt.Text = string.Empty;
            lastDateTxt.Text = string.Empty;
            salaryTxt.Text = string.Empty;
            jobTypeDDL.ClearSelection();
            companyNameTxt.Text = string.Empty;
            websiteTxt.Text = string.Empty;
            emailTxt.Text = string.Empty;
            addressTxt.Text = string.Empty;
            countryDDL.ClearSelection();
            stateTxt.Text = string.Empty;
        }

        //public bool IsValidExtension(string fileName)
        //{
        //    bool isValid = false;

        //    string[] fileExtension = { ".jpg", ".jpeg", ".png" };

        //    for (int i = 0; i <= fileExtension.Length - 1; i++)
        //    {
        //        if (fileName.Contains(fileExtension[i]))
        //        {
        //            isValid = true;
        //            break;
        //        }
        //    }
        //    return isValid;
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;

                if (Request.QueryString["id"] != null)
                {
                    if (FileUpload1.HasFile)
                    {
                        if (Utils.IsValidExtension(FileUpload1.FileName))
                        {
                            concatQuery = "CompanyImage = @image,";
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                    string qry = "update tbl_Jobs set Title = @title, NoOfPosts = @noOfPost, Description = @description, Qualification = @qualification, Experience = @experience, Specialization = @specialization, LastDateToApply = @lastdate, Salary = @salary, JobType = @jobType, CompanyName = @companyName, " + concatQuery + " Website = @website, Email = @email, Address = @address, Country = @country, State = @state where jobID = @id";

                    type = "Updated";

                    cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@title", jobTitleTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@noOfPost", noOfPostsTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@description", descriptionTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@qualification", qualificationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@experience", experienceTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@specialization", specializationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@lastdate", lastDateTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@salary", salaryTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@jobType", jobTypeDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@companyName", companyNameTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@website", websiteTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", emailTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", addressTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@country", countryDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@state", stateTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());

                    if (FileUpload1.HasFile)
                    {
                        if (Utils.IsValidExtension(FileUpload1.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + FileUpload1.FileName;
                            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + FileUpload1.FileName);

                            cmd.Parameters.AddWithValue("@companyLogo", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMessage.Text = "Please Select .JPG, .JPEG, .PNG Format.";
                            lblMessage.CssClass = "alert alert-danger";
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        isValidToExecute = true;
                    }
                }
                else
                {
                    string qry = "insert into tbl_Jobs values (@title, @noOfPost, @description, @qualification, @experience, @specialization, @lastdate, @salary, @jobType, @companyName, @companyLogo, @website, @email, @address, @country, @state, @createdDate)";

                    type = "Inserted";

                    cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@title", jobTitleTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@noOfPost", noOfPostsTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@description", descriptionTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@qualification", qualificationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@experience", experienceTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@specialization", specializationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@lastdate", lastDateTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@salary", salaryTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@jobType", jobTypeDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@companyName", companyNameTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@website", websiteTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", emailTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", addressTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@country", countryDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@state", stateTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@createdDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (FileUpload1.HasFile)
                    {
                        if (Utils.IsValidExtension(FileUpload1.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + FileUpload1.FileName;
                            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + FileUpload1.FileName);

                            cmd.Parameters.AddWithValue("@companyLogo", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMessage.Text = "Please Select .JPG, .JPEG, .PNG Format.";
                            lblMessage.CssClass = "alert alert-danger";
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@companyLogo", imagePath);
                        isValidToExecute = true;
                    }
                }

                if (isValidToExecute)
                {
                    con.Open();

                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        lblMessage.Text = "Job " + type + " Successfull.";
                        lblMessage.CssClass = "alert alert-success";
                        lblMessage.Visible = true;
                        ClearControls();
                    }
                    else
                    {
                        lblMessage.Text = "Job Could Not Be " + type;
                        lblMessage.CssClass = "alert alert-danger";
                        lblMessage.Visible = true;
                        ClearControls();
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
    }
}