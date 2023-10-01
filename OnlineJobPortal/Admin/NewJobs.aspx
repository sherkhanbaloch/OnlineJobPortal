<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJobs.aspx.cs" Inherits="OnlineJobPortal.Admin.NewJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container pt-4 pb-4">

            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                <div class="input-group h-25">
                    <asp:HyperLink ID="linkBack" NavigateUrl="~/Admin/JobLists.aspx" CssClass="btn btn-secondary" Visible="false" runat="server">< Back</asp:HyperLink>
                </div>
            </div>

            <h3 class="text-center"><% Response.Write(Session["title"].ToString()); %></h3>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="jobTitleTxt" style="font-weight: 600;">Job Title</label>
                    <asp:TextBox ID="jobTitleTxt" CssClass="form-control" placeholder="Ex. Web Developer" runat="server" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="noOfPostsTxt" style="font-weight: 600;">No: of Posts</label>
                    <asp:TextBox ID="noOfPostsTxt" CssClass="form-control" placeholder="Enter No: of Positions" TextMode="Number" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3 ">
                    <label for="descriptionTxt" style="font-weight: 600;">Job Description</label>
                    <asp:TextBox ID="descriptionTxt" CssClass="form-control" placeholder="Enter Job Description" TextMode="MultiLine" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="qualificationTxt" style="font-weight: 600;">Qualification/Education</label>
                    <asp:TextBox ID="qualificationTxt" CssClass="form-control" placeholder="Ex. BSCS, BBA, BSc" runat="server" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="experienceTxt" style="font-weight: 600;">Experience</label>
                    <asp:TextBox ID="experienceTxt" CssClass="form-control" placeholder="Ex. 2 Years, 3 Years" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="specializationTxt" style="font-weight: 600;">Specialization</label>
                    <asp:TextBox ID="specializationTxt" CssClass="form-control" placeholder="Enter Specialization" TextMode="MultiLine" runat="server" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="lastDateTxt" style="font-weight: 600;">Last Date To Apply</label>
                    <asp:TextBox ID="lastDateTxt" CssClass="form-control" placeholder="Enter Last Date To Apply" TextMode="Date" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="salaryTxt" style="font-weight: 600;">Salary</label>
                    <asp:TextBox ID="salaryTxt" CssClass="form-control" placeholder="Ex. 25000/Month, 7L/Year" runat="server" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="jobTypeDDL" style="font-weight: 600;">Job Type</label>
                    <asp:DropDownList ID="jobTypeDDL" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Remote</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Job Type Required." ControlToValidate="jobTypeDDL" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="companyNameTxt" style="font-weight: 600;">Company/Organization Name</label>
                    <asp:TextBox ID="companyNameTxt" CssClass="form-control" placeholder="Enter Company Name" runat="server" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="FileUpload1" style="font-weight: 600;">Company/Organization Logo</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" ToolTip="JPG, JPEG, PNG Format Only" runat="server" />
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="websiteTxt" style="font-weight: 600;">Website</label>
                    <asp:TextBox ID="websiteTxt" CssClass="form-control" placeholder="Enter Website" TextMode="Url" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="emailTxt" style="font-weight: 600;">Email</label>
                    <asp:TextBox ID="emailTxt" CssClass="form-control" placeholder="Enter Email" TextMode="Email" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3 ">
                    <label for="addressTxt" style="font-weight: 600;">Address</label>
                    <asp:TextBox ID="addressTxt" CssClass="form-control" placeholder="Enter Work Location" TextMode="MultiLine" runat="server" required></asp:TextBox>
                </div>
            </div>


            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3 ">
                    <label for="countryDDL" style="font-weight: 600;">Country</label>
                    <asp:DropDownList ID="countryDDL" CssClass="form-control w-100" AppendDataBoundItems="True" DataTextField="countryName" DataValueField="countryName" runat="server" DataSourceID="SqlDataSource1">
                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Country Required." ControlToValidate="countryDDL" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcs %>" SelectCommand="SELECT [countryName] FROM [tbl_Countries]"></asp:SqlDataSource>

                </div>
                <div class="col-md-6 pt-3 ">
                    <label for="stateTxt" style="font-weight: 600;">State</label>
                    <asp:TextBox ID="stateTxt" CssClass="form-control" placeholder="Enter State" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary btn-block" BackColor="#7200cf" runat="server" Text="Add Job" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
