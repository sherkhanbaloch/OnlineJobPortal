<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineJobPortal.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblMessage" Visible="false" runat="server"></asp:Label>
        </div>
    </div>

    <div class="pcoded-inner-content">
        <div class="main-body">
            <div class="page-wrapper">

                <div class="page-body">
                    <div class="row">
                        <!-- card1 start -->
                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-users bg-c-blue card1-icon"></i>
                                    <span class="text-c-blue f-w-600">Total Users</span>
                                    <h4>
                                        <% Response.Write(Session["totalUsers"]); %>
                                    </h4>
                                </div>
                            </div>
                        </div>
                        <!-- card1 end -->
                        <!-- card1 start -->
                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-briefcase bg-c-pink card1-icon"></i>
                                    <span class="text-c-pink f-w-600">Total Jobs</span>
                                    <h4>
                                        <% Response.Write(Session["totalJobs"]); %>
                                    </h4>
                                </div>
                            </div>
                        </div>
                        <!-- card1 end -->
                        <!-- card1 start -->
                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-tick-boxed bg-c-green card1-icon"></i>
                                    <span class="text-c-green f-w-600">Applied Jobs</span>
                                    <h4>
                                        <% Response.Write(Session["totalAppliedJobs"]); %>
                                    </h4>
                                </div>
                            </div>
                        </div>
                        <!-- card1 end -->
                        <!-- card1 start -->
                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-speech-comments bg-c-yellow card1-icon"></i>
                                    <span class="text-c-yellow f-w-600">Contacts</span>
                                    <h4>
                                        <% Response.Write(Session["totalContacts"]); %>
                                    </h4>
                                </div>
                            </div>
                        </div>
                        <!-- card1 end -->
                    </div>
                </div>
            </div>

            <div id="styleSelector">
            </div>
        </div>
    </div>

</asp:Content>
