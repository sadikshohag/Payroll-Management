<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="Account_Management.Designation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:SqlDataSource ID="sdsGrade" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
                       ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
                       SelectCommand="SELECT GRD_ID, GRD_NM FROM GRADE"></asp:SqlDataSource>
<form id="info" runat="server">
    <div class="card" style="margin-bottom: 10px">
            <div class="card-header">
                <i class="fa fa-calendar"></i>&nbsp;Designation Setup
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Grade Name&nbsp;<abbr title="Required" class="required"></abbr></label>
                                <asp:DropDownList ID="ddlGrade" class='form-control' runat="server" DataSourceID="sdsGrade" DataTextField="GRD_NM" DataValueField="GRD_ID">
                            </asp:DropDownList>
                                
                            </div>                         
                           </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Designation&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtCompany" id="designation">
                            </div>                         
                           </div>
                    </div>
                    <div class="col-md-12 btn-form-control">
                         <asp:LinkButton ID="btnSave" class="btn btn-primary" runat="server" OnClick="btnSave_Click">
                             <i class="fa fa-plus-circle" aria-hidden="true"></i>&nbsp;Save</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="card" style="background-color:#fff">
                <div class="card-body" >
                    <div class="row">
                        <div class="col-md-12">
            
                    <asp:Repeater ID="rptDsg" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-responsive">
                            <tr>
                                <th scope="col">Grade Name</th>
                                <th scope="col">Designation</th>
                                <th scope="col">Action</th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("GRD_NM") %></td>
                                <td><%# Eval("DSG_NM") %></td>
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
