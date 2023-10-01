<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuild.aspx.cs" Inherits="OnlineJobPortal.User.ResumeBuild" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container pt-50 pb-40">
            <div class="row">
                <div class="col-12 pb-20">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="col-12">
                    <h2 class="contact-title text-center">Build Resume</h2>
                </div>
                <div class="col-md-12">
                    <div class="form-contact contact_form" id="contactForm">
                        <div class="row">
                            <div class="col-12">
                                <h3>Personal Information</h3>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox ID="fullNameTxt" CssClass="form-control" placeholder="Enter Full Name" runat="server" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name Should Be In Characters" ControlToValidate="fullNameTxt" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>User Name</label>
                                    <asp:TextBox ID="usernameTxt" CssClass="form-control" placeholder="Enter Unique User Name" runat="server" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox ID="addressTxt" CssClass="form-control" placeholder="Enter Address" runat="server" TextMode="MultiLine" required></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Mobile Number</label>
                                    <asp:TextBox ID="mobileTxt" CssClass="form-control" placeholder="Enter Mobile Number" runat="server" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile Number Must Have 11 Digits." ControlToValidate="mobileTxt" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[0-9]{11}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="emailTxt" CssClass="form-control" placeholder="Enter Email" runat="server" TextMode="Email" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Country</label>
                                    <asp:DropDownList ID="countryDDL" CssClass="form-control w-100" AppendDataBoundItems="True" DataTextField="countryName" DataValueField="countryName" runat="server" DataSourceID="SqlDataSource1">
                                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country Required." ControlToValidate="countryDDL" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcs %>" SelectCommand="SELECT [countryName] FROM [tbl_Countries]"></asp:SqlDataSource>
                                </div>
                            </div>

                            <div class="col-12 pt-4">
                                <h6>Education/Resume Information</h6>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>10th Percentage/Grade</label>
                                    <asp:TextBox ID="tenthTxt" CssClass="form-control" placeholder="Ex. 90% or A-1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>12th Percentage/Grade</label>
                                    <asp:TextBox ID="twelfthTxt" CssClass="form-control" placeholder="Ex. 90% or A-1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Graduation With CGPA/Grade</label>
                                    <asp:TextBox ID="graduationTxt" CssClass="form-control" placeholder="Ex. Computer Science With 3.59 CGPA" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Post Graduation With Percentage/Grade</label>
                                    <asp:TextBox ID="postGraduationTxt" CssClass="form-control" placeholder="Ex. Post Graduation With A Grade" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>PhD With Percentage/Grade</label>
                                    <asp:TextBox ID="phdTxt" CssClass="form-control" placeholder="Ex. PhD With A Grade" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Job Profile/Works On</label>
                                    <asp:TextBox ID="workTxt" CssClass="form-control" placeholder="Job Profile" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Work Experience</label>
                                    <asp:TextBox ID="experienceTxt" CssClass="form-control" placeholder="Work Experience" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Upload Resume</label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control pt-2" ToolTip=".doc, .docx, .pdf Files are Supported." runat="server" />
                                </div>
                            </div>
                            <div class="form-group mt-3">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button button-contactForm boxed-btn mr-5" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </section>

</asp:Content>
