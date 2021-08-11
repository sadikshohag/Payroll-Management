<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Account_Management.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <section class="wrapper">
            <!-- //market-->
            <div class="market-updates" style="padding-bottom:40px;">
                <div class="col-md-3 market-update-gd">
                    <div class="market-update-block clr-block-2">
                        <div class="col-md-4 market-update-right">
                            <i class="fa fa-eye"></i>
                        </div>
                        <div class="col-md-8 market-update-left">
                            <h4>Joining</h4>
                            <h3><asp:Label ID="lblJoin" runat="server"></asp:Label></h3>
                            <p>Employee join in this month</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="col-md-3 market-update-gd">
                    <div class="market-update-block clr-block-1">
                        <div class="col-md-4 market-update-right">
                            <i class="fa fa-users"></i>
                        </div>
                        <div class="col-md-8 market-update-left">
                            <h4>Employee</h4>
                            <h3><asp:Label ID="lblEmp" runat="server"></asp:Label></h3>
                            <p>Person active till now.</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="col-md-3 market-update-gd">
                    <div class="market-update-block clr-block-3">
                        <div class="col-md-4 market-update-right">
                            <i class="fa fa-usd"></i>
                        </div>
                        <div class="col-md-8 market-update-left">
                            <h4>Total Salary</h4>
                            <h3><asp:Label ID="lblSal" runat="server"></asp:Label></h3>
                            <p>In previous month</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="col-md-3 market-update-gd">
                    <div class="market-update-block clr-block-4">
                        <div class="col-md-4 market-update-right">
                            <i class="fa fa-rss-square" style="font-size: 3em;color: #fff;text-align: left;" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-8 market-update-left">
                            <h4>Payroll</h4>
                            <h3><asp:Label ID="lblPay" runat="server"></asp:Label></h3>
                            <p>Employee need to verify</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <!-- //market-->
        </section>
</asp:Content>
