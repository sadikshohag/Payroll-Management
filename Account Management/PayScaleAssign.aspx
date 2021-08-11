<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="PayScaleAssign.aspx.cs" Inherits="Account_Management.PayScaleAssign" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ToolkitScriptManager1" />--%>
    <asp:SqlDataSource ID="sdsCanList" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>" 
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>" 
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsGrade" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT GRD_ID, GRD_NM FROM GRADE"></asp:SqlDataSource>
    <form id="form1" class="form-horizontal" runat="server">
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
       <%-- <div class="card" style="background-color: #fff">--%>
            <%--<div class="card-body">--%>
                <div class="row">
                    <div class="col-md-2">
                        <%--<tr>
                            <td valign="top">--%>
                <asp:Repeater ID="rpt" runat="server" OnItemCommand="Repeater1_Command">
                    <headertemplate>
                        <table class="table table-bordered">
                            <tr>
                                <td style="background-color: #d9ffb3; text-align: center"><b>Employee ID & Name</b></td>
                            </tr>
                    </headertemplate>
                    <itemtemplate>
                            <tr>
                                <asp:HiddenField ID="canID" runat="server" Value='<%# Eval("ID")  %>' />
                                <asp:HiddenField ID="grd" runat="server" Value='<%# Eval("GRD_ID")  %>' />
                                <td style='<%#Eval("PAYROLL_ASSIGN").ToString() == "Yes"? "background-color:#33ff33": "background-color:white"%>'>
                                    <asp:Button ID="Button1" runat="server" Width="150px" Style="background-color: #ffffff; border-radius: 5px" Text='<%# Eval("ENAME") %>' />
                                    
                                </td>
                            </tr>
                        </itemtemplate>
                    <footertemplate>
                    </table>
                    </footertemplate>
                </asp:Repeater>
                    </div>
                    <div class="col-md-10">
                        <div class="container" style="border: 1px solid #52ffd9; border-radius: 8px">
                            
                            
                                        <div class="form-group">
                                            <label class="control-label col-sm-1" for="pwd">Emp. ID:</label>
                                            <div class="col-sm-2">
                                                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="false" class="form-control" placeholder="Candidate ID" Style="border: 1px solid #ccc"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-1" style="text-align: right">
                                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-info" Style="padding: 5px;" ToolTip="Type Candidate ID" AutoPostBack="true" OnClick="btnSearch_CLick" CausesValidation="false"><i class="glyphicon glyphicon-search"></i> </asp:LinkButton>
                                            </div>
                                            <label class="control-label col-sm-2" for="pwd">Payment Type:</label>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlPayType" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPayType_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                                                    <asp:ListItem Text="As Per Pay Scale" Value="PS" />
                                                    <asp:ListItem Value="NS">Negotiable Salary</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-1">Employee:</label>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlApplicantN" runat="server" CssClass="form-control" DataSourceID="sdsEmp" DataTextField="EMP_NAME" DataValueField="ID" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="control-label col-sm-2">Start Basic:</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtStartBasic" CssClass="form-control" runat="server" Enabled="false" onkeyup="return checkVal(this.id);" placeholder="Start Basic"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-1">Grade:</label>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlGrade" runat="server" CssClass="form-control" DataSourceID="sdsGrade" DataTextField="GRD_NM" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" DataValueField="GRD_ID" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="control-label col-sm-2">House Rent:</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txthouseRent" CssClass="form-control" Enabled="false" onkeyup="return checkVal(this.id);" runat="server" placeholder="House Rent"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-1">Medical:</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtMedical" CssClass="form-control" Enabled="false" ClientIDMode="Static" runat="server" placeholder="Medical"></asp:TextBox><%--onkeyup="return checkVal(this.id);"--%>
                                            </div>
                                            <label class="control-label col-sm-2">Conveyance:</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtConveyance" CssClass="form-control" Enabled="false" onkeyup="return checkVal(this.id);" runat="server" placeholder="Conveyance"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-1">TADA :</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtTadaAllow" CssClass="form-control" Enabled="false" onkeyup="return checkVal(this.id);" runat="server" placeholder="TADA Allowance"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-sm-2">Others:</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtOthers" CssClass="form-control" Enabled="false" onkeyup="return checkVal(this.id);" runat="server" placeholder="Others"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-offset-2 col-sm-10">
                                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Style="padding: 6px; width: 90px"><i></i> Submit <i class="glyphicon glyphicon-upload"></i></asp:LinkButton>
                                            </div>
                                        </div>
                            </div>
                        </div>
                </div>
            <%--</div>--%>
        <%--</div>--%>
                <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</asp:Content>
