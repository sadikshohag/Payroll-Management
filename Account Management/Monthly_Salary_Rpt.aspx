<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="Monthly_Salary_Rpt.aspx.cs" Inherits="Account_Management.Monthly_Salary_Rpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="sdsHRYear" runat="server"
        ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT DISTINCT YR_ID FROM HR_MONTH"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsMonth" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT ID, MONTH_NAME FROM HR_MONTH ORDER BY ID ASC">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlYear" Name="YR_ID" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <form runat="server">
        <div class="row">
            <div class="col-md-3">
                <div class="row">
                    <div class="form-group col-md-12">
                        <label for="">Year&nbsp;<abbr title="Required" class="required"></abbr></label>
                        <asp:DropDownList ID="ddlYear" class='form-control' runat="server" DataSourceID="sdsHRYear" DataTextField="YR_ID" DataValueField="YR_ID">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <div class="form-group col-md-12">
                        <label for="">Month&nbsp;<abbr title="Required" class="required"></abbr></label><asp:DropDownList ID="ddlMonth" class='form-control' runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true" DataSourceID="sdsMonth" DataTextField="MONTH_NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>  
            <div class="col-md-3">
                <label for="">From Date&nbsp;<abbr title="Required" class="required"></abbr></label>
                <input type="date" runat="server" class="form-control" value="" id="cboFromDate" name="cboFromDate" placeholder="From" disabled/>

            </div>
            <div class="col-md-3">
                <label for="">To Date&nbsp;<abbr title="Required" class="required"></abbr></label>
                <input type="date" runat="server" class="form-control" value="" id="cboTODate" name="cboTODate" placeholder="To" disabled/>
            </div>
        </div>
        <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnExport_Click"> <span class="glyphicon glyphicon-download-alt"></span>&nbsp;Export
                                                    </asp:LinkButton>
        <div id="requiView" style="background-color: white; width: 100%" runat="server"></div>
    </form>
    
</asp:Content>
