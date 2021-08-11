<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="userVerify.aspx.cs" Inherits="Account_Management.userVerify" %>

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
        
        <div class="card" style="background-color: #fff; margin-bottom:80px">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12">

                        <asp:Repeater ID="rptDsg" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered table-responsive">
                                    <tr>
                                        <th scope="col">Name</th>
                                        <th scope="col">Email</th>
                                        <th scope="col">Mobile</th>
                                        <th scope="col">Password</th>
                                        <th scope="col">User Type</th>
                                        <th scope="col">Status</th>
                                        <th scope="col">Action</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("ID") %>' Visible = "false" />
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("USER_NAME") %>' />
                                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Text='<%# Eval("USER_NAME") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EMAIL") %>' />
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Text='<%# Eval("EMAIL") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMob" runat="server" Text='<%# Eval("MOBILE") %>' />
                                        <asp:TextBox ID="txtMob" CssClass="form-control" runat="server" Text='<%# Eval("MOBILE") %>'
                                            Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPass" runat="server" Text='<%# Eval("PASSWORD") %>' />
                                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" Text='<%# Eval("PASSWORD") %>'
                                            Visible="false" />
                                    </td>
                                    <%--<td>
                                        <asp:Label ID="lblJoin" runat="server" Text='<%# Eval("JOIN_DATE","{0:dd/MMM/yy}") %>' />
                                        <asp:TextBox ID="txtJoin" CssClass="form-control" runat="server" Text='<%# Eval("JOIN_DATE","{0:dd/MMM/yy}") %>'
                                            Visible="false" />
                                    </td>--%>
                                    <td>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("USER_TYPE").ToString()=="N" ? "Normal" : "Admin" %>' />
                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control" Visible="false" SelectedValue='<%# Eval("USER_TYPE") %>'>
                                            <asp:ListItem Value="N">Normal</asp:ListItem>
                                            <asp:ListItem Value="A">Admin</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("STATUS").ToString()=="P" ? "Not Verified" : "Verified" %>' />
                                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" Visible="false"  SelectedValue='<%# Eval("STATUS") %>'>
                                            <%--<asp:ListItem Selected="True" Value="Probationary">Probationary</asp:ListItem>--%>
                                            <asp:ListItem Value="P">Not Verified</asp:ListItem>
                                            <asp:ListItem Value="A">Verified</asp:ListItem>
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
