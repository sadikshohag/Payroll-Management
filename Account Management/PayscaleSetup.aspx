<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="PayscaleSetup.aspx.cs" Inherits="Account_Management.PayscaleSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="sdsGrade" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT GRD_ID, GRD_NM FROM GRADE"></asp:SqlDataSource>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="container" style="border: 1px solid #52ffd9; border-radius: 8px">
                    
                    <div class="form-group">
                        <label class="control-label col-sm-1">Grade:</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlGrade" runat="server" CssClass="form-control" DataSourceID="sdsGrade" DataTextField="GRD_NM" DataValueField="GRD_ID" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <label class="control-label col-sm-2">House Rent:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txthouseRent" CssClass="form-control" onkeyup="return checkVal(this.id);" runat="server" placeholder="House Rent"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-1">St.Basic:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtStartBasic" CssClass="form-control" runat="server" onkeyup="return checkVal(this.id);" placeholder="Start Basic"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2">Inc. Rate:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtIncRate" CssClass="form-control" onkeyup="return checkVal(this.id);" runat="server" placeholder="Increment Rent"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-1">Medical:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtMedical" CssClass="form-control" ClientIDMode="Static" runat="server" placeholder="Medical"></asp:TextBox><%--onkeyup="return checkVal(this.id);"--%>
                        </div>
                        <label class="control-label col-sm-2">Conveyance:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtConveyance" CssClass="form-control" onkeyup="return checkVal(this.id);" runat="server" placeholder="Conveyance"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-1">TADA :</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtTadaAllow" CssClass="form-control" onkeyup="return checkVal(this.id);" runat="server" placeholder="TADA Allowance"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2">Others:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtOthers" CssClass="form-control" onkeyup="return checkVal(this.id);" runat="server" placeholder="Others"></asp:TextBox>
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
        <div class="card" style="background-color:#fff; padding-top:20px;">
                <div class="card-body" >
                    <div class="row">
                        <div class="col-md-12">
            
                    <asp:Repeater ID="rpt" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-responsive">
                            <tr>
                                <th scope="col">Grade Name</th>
                                <th scope="col">Basic</th>
                                <th scope="col">In. Rate</th>
                                <th scope="col">House Rent</th>
                                <th scope="col">Convenience</th>
                                <th scope="col">Medical</th>
                                <th scope="col">TADA</th>
                                <th scope="col">Others</th>
                                <th scope="col">Action</th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("GRD_NM") %></td>
                                <td><%# Eval("START_BASIC") %></td>
                                <td><%# Eval("INCR_RATE") %></td>
                                <td><%# Eval("HOUSE_RENT") %></td>
                                <td><%# Eval("CONVEYANCE") %></td>
                                <td><%# Eval("MEDICAL") %></td>
                                <td><%# Eval("TADA") %></td>
                                <td><%# Eval("OTHERS") %></td>
                                <td>
                                    <%--<asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" OnClick="OnEdit" />
                                    <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="OnUpdate" />
                                    <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this row?');" />--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</asp:Content>
