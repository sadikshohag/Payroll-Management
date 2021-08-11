<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="employeeEntry.aspx.cs" Inherits="Account_Management.employeeEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet" />
<script src="js/jquery2.0.3.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    <script>
        function showContent(msg) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "progressBar": true,
                "preventDuplicates": false,
                "positionClass": "toast-top-right",
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "7000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["success"](msg);

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="sdsGrade" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT GRD_ID, GRD_NM FROM GRADE"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsDsg" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT DSG_ID, DSG_NM FROM [dbo].[DESIGNATION]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsDsgR" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
        ProviderName="<%$ ConnectionStrings:conString.ProviderName %>"
        SelectCommand="SELECT DSG_ID, DSG_NM FROM [dbo].[DESIGNATION]"></asp:SqlDataSource>
    <form id="info" runat="server">
        <div class="card" style="margin-bottom: 10px">
            <div class="card-header">
                <i class="fa fa-user"></i>&nbsp;Employee Register
           
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Employee Name&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtName" id="txtName" required="">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Employee Type&nbsp;<abbr title="Required" class="required"></abbr></label>
                                <asp:DropDownList ID="ddlEmpType" runat="server" class='form-control' Font-Size="11px">
                                    <asp:ListItem Selected="True" Value="Probationary">Probationary</asp:ListItem>
                                    <asp:ListItem Value="Permanent">Permanent</asp:ListItem>
                                    <asp:ListItem Value="Contractual">Contractual</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Father Name&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtFather" id="txtFather" required="">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Grade Name&nbsp;<abbr title="Required" class="required"></abbr></label>
                                <asp:DropDownList ID="ddlGrade" class='form-control' runat="server" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" AutoPostBack="true" DataSourceID="sdsGrade" DataTextField="GRD_NM" DataValueField="GRD_ID">
                            </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Mother Name&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtMother" id="txtMother" required="">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Designation&nbsp;<abbr title="Required" class="required"></abbr></label>
                                <asp:DropDownList ID="ddlDesignation" class='form-control' runat="server" DataSourceID="sdsDsg" DataTextField="DSG_NM" DataValueField="DSG_ID">
                            </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Joining Date&nbsp;<abbr title="Required" class="required"></abbr></label><input type="date" runat="server" class="form-control" name="txtFather" id="txtJoin" required="">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Mobile No.&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtMobile" id="txtMobile" required="">

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <%--<div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Mother Name&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtMother" id="txtMother" required="">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="">Designation&nbsp;<abbr title="Required" class="required"></abbr></label><input type="text" runat="server" class="form-control" name="txtCompany" id="designation">
                            </div>
                        </div>
                    </div>--%>
                    <div class="col-md-12 btn-form-control">
                        <asp:LinkButton ID="btnSave" class="btn btn-primary" runat="server" OnClick="btnSave_Click">
                             <i class="fa fa-plus-circle" aria-hidden="true"></i>&nbsp;Save</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="card" style="background-color: #fff">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12">

                        <asp:Repeater ID="rptDsg" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered table-responsive">
                                    <tr>
                                        <th scope="col">Name</th>
                                        <th scope="col">Father Name</th>
                                        <th scope="col">Mobile</th>
                                        <th scope="col">Join Date</th>
                                        <th scope="col">Grade</th>
                                        <th scope="col">Designation</th>
                                        <th scope="col">Type</th>
                                        <th scope="col">Action</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("ID") %>' Visible = "false" />
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("EMP_NAME") %>' />
                                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Text='<%# Eval("EMP_NAME") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFather" runat="server" Text='<%# Eval("FATHER_NAME") %>' />
                                        <asp:TextBox ID="txtFather" CssClass="form-control" runat="server" Text='<%# Eval("FATHER_NAME") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMob" runat="server" Text='<%# Eval("MOBILE") %>' />
                                        <asp:TextBox ID="txtMob" CssClass="form-control" runat="server" Text='<%# Eval("MOBILE") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblJoin" runat="server" Text='<%# Eval("JOIN_DATE","{0:dd/MMM/yy}") %>' />
                                        <asp:TextBox ID="txtJoin" CssClass="form-control" runat="server" Text='<%# Eval("JOIN_DATE","{0:dd/MMM/yy}") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGrd" runat="server" Text='<%# Eval("GRD_NM") %>' />
                                        <asp:DropDownList ID="ddlGrade" runat="server" class="form-control" Visible="false" DataSourceID="sdsGrade" DataTextField="GRD_NM" DataValueField="GRD_ID" SelectedValue='<%# Eval("GRD_ID") %>'>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDsg" runat="server" Text='<%# Eval("DSG_NM") %>' />
                                        <asp:DropDownList ID="ddlDsg" runat="server" class="form-control" Visible="false" DataSourceID="sdsDsgR" DataTextField="DSG_NM" DataValueField="DSG_ID" SelectedValue='<%# Eval("DSG_ID") %>'>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("EMP_TYPE") %>' />
                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control" Visible="false" DataTextField="EMP_TYPE" DataValueField="EMP_TYPE" SelectedValue='<%# Eval("EMP_TYPE") %>'>
                                            <asp:ListItem Selected="True" Value="Probationary">Probationary</asp:ListItem>
                                            <asp:ListItem Value="Permanent">Permanent</asp:ListItem>
                                            <asp:ListItem Value="Contractual">Contractual</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="OnEdit" Class="edit" Style="color: #FFC107;" ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="OnUpdate" />
                                        <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                                        &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Class="delete" Style="color: #F44336;" ToolTip="Delete" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this row?');"><i class="fa fa-trash"></i></i></asp:LinkButton>
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
