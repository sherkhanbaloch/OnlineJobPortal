<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineJobPortal.User.Registration" %>

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
                    <h2 class="contact-title text-center">Sign Up</h2>
                </div>
                <div class="col-lg-6 mx-auto">
                    <div class="form-contact contact_form" id="contactForm">
                        <div class="row">
                            <div class="col-12">
                                <h3>Login Information</h3>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>User Name</label>
                                    <asp:TextBox ID="usernameTxt" CssClass="form-control" placeholder="Enter Unique User Name" runat="server" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox ID="passwordTxt" CssClass="form-control" placeholder="Enter Password" TextMode="Password" runat="server" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Confirm Password</label>
                                    <asp:TextBox ID="confirmPasswordTxt" CssClass="form-control" placeholder="Enter Confirm Password" TextMode="Password" runat="server" required></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Does Not Match" ControlToValidate="confirmPasswordTxt" ControlToCompare="passwordTxt" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="col-12">
                                <h3>Personal Information</h3>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox ID="fullNameTxt" CssClass="form-control" placeholder="Enter Full Name" runat="server" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name Should Be In Characters" ControlToValidate="fullNameTxt" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox ID="addressTxt" CssClass="form-control" placeholder="Enter Address" runat="server" TextMode="MultiLine" required></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Mobile Number</label>
                                    <asp:TextBox ID="mobileTxt" CssClass="form-control" placeholder="Enter Mobile Number" runat="server" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile Number Must Have 11 Digits." ControlToValidate="mobileTxt" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[0-9]{11}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="emailTxt" CssClass="form-control" placeholder="Enter Email" runat="server" TextMode="Email" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Country</label>
                                    <asp:DropDownList ID="countryDDL" CssClass="form-control w-100" AppendDataBoundItems="True" DataTextField="countryName" DataValueField="countryName" runat="server" DataSourceID="SqlDataSource1">
                                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country Required." ControlToValidate="countryDDL" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcs %>" SelectCommand="SELECT [countryName] FROM [tbl_Countries]"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="form-group mt-3">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button button-contactForm boxed-btn mr-5" OnClick="btnRegister_Click" />
                            <span class="clickLink"><a href="../User/Login.aspx">Already Registered? Click Here.</a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
