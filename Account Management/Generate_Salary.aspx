<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="Generate_Salary.aspx.cs" Inherits="Account_Management.Generate_Salary" %>

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
    <form id="info" runat="server">
        <div class="row">
            <div class="col-md-6">
                <div class="row">
                    <div class="form-group col-md-12">
                        <label for="">Year&nbsp;<abbr title="Required" class="required"></abbr></label>
                        <asp:DropDownList ID="ddlYear" class='form-control' runat="server" DataSourceID="sdsHRYear" DataTextField="YR_ID" DataValueField="YR_ID">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="form-group col-md-12">
                        <label for="">Month&nbsp;<abbr title="Required" class="required"></abbr></label><asp:DropDownList ID="ddlMonth" class='form-control' runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true" DataSourceID="sdsMonth" DataTextField="MONTH_NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>            
        </div>
        <div class="row">
            <div class="col-md-6">
                <label for="">From Date&nbsp;<abbr title="Required" class="required"></abbr></label>
                <input type="date" runat="server" class="form-control" value="" id="cboFromDate" name="cboFromDate" placeholder="From" disabled/>

            </div>
            <div class="col-md-6">
                <label for="">To Date&nbsp;<abbr title="Required" class="required"></abbr></label>
                <input type="date" runat="server" class="form-control" value="" id="cboTODate" name="cboTODate" placeholder="To" disabled/>
            </div>
            
        </div>
        <div class="row" style="padding-top:100px; padding-bottom:100px; text-align:center">
            <div class="col-md-12">
                <asp:LinkButton ID="btnSave" class="btn btn-danger" runat="server" OnClick="btnSave_Click">
                             <i class="fa fa-plus-circle" aria-hidden="true"></i>&nbsp;Generate</asp:LinkButton>
            </div>
            </div>
    </form>
</asp:Content>
