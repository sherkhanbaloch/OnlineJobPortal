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
    public partial class ResumeBuild : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ShowUserInfo();
                }
                else
                {
                    Response.Redirect("../User/Login.aspx");
                }
            }
        }

        public void ShowUserInfo()
        {
            try
            {
                string qry = "select * from tbl_Users where UserID = @userid";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@userid", Request.QueryString["id"]);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        usernameTxt.Text = reader["UserName"].ToString();
                        fullNameTxt.Text = reader["Name"].ToString();
                        emailTxt.Text = reader["Email"].ToString();
                        mobileTxt.Text = reader["Mobile"].ToString();
                        tenthTxt.Text = reader["TenthGrade"].ToString();
                        twelfthTxt.Text = reader["TwelfthGrade"].ToString();
                        graduationTxt.Text = reader["GraduationGrade"].ToString();
                        postGraduationTxt.Text = reader["PostGraduationGrade"].ToString();
                        phdTxt.Text = reader["PhDGrade"].ToString();
                        workTxt.Text = reader["WorksOn"].ToString();
                        experienceTxt.Text = reader["Experience"].ToString();
                        addressTxt.Text = reader["Address"].ToString();
                        countryDDL.SelectedValue = reader["Country"].ToString();
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


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    // bool isValidToExecute = false;
                    bool isValid = false;

                    if (FileUpload1.HasFile)
                    {
                        if (Utils.IsValidExtensionForResume(FileUpload1.FileName))
                        {
                            concatQuery = "Resume = @resume,";
                            isValid = true;
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

                    string qry = "update tbl_Users set UserName = @userName, Name = @name, Email = @email, Mobile = @mobile, TenthGrade = @tenthGrade, TwelfthGrade = @twelfthGrade, GraduationGrade = @graduationGrade, PostGraduationGrade = @postGraduationGrade, PhDGrade = @phdGrade, WorksOn = @worksOn, Experience = @experience, " + concatQuery + "Address = @address, Country = @country where UserID = @userid";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@userName", usernameTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", fullNameTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", emailTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobile", mobileTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@tenthGrade", tenthTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@twelfthGrade", twelfthTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@graduationGrade", graduationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@postGraduationGrade", postGraduationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@phdGrade", phdTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@worksOn", workTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@experience", experienceTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", addressTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@country", countryDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@userid", Request.QueryString["id"]);

                    if (FileUpload1.HasFile)
                    {
                        if (Utils.IsValidExtensionForResume(FileUpload1.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            filePath = "Resumes/" + obj.ToString() + FileUpload1.FileName;
                            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + FileUpload1.FileName);

                            cmd.Parameters.AddWithValue("@resume", filePath);
                            isValid = true;
                        }
                        else
                        {
                            lblMessage.Text = "Please Select .Doc, .Docx, .pdf Format.";
                            lblMessage.CssClass = "alert alert-danger";
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        isValid = true;
                    }

                    if (isValid)
                    {
                        con.Open();

                        int a = cmd.ExecuteNonQuery();

                        if (a > 0)
                        {
                            lblMessage.Text = "Resume Updated Successfully.";
                            lblMessage.CssClass = "alert alert-success";
                            lblMessage.Visible = true;

                        }
                        else
                        {
                            lblMessage.Text = "Resume Could Not Be Updated.";
                            lblMessage.CssClass = "alert alert-danger";
                            lblMessage.Visible = true;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Resume Could Not Be Updated. Please Login Again.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
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
    }
}