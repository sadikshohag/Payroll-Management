<%@ Page Title="" Language="C#" MasterPageFile="~/SideMenu.Master" AutoEventWireup="true" CodeBehind="PayScale_Verification.aspx.cs" Inherits="Account_Management.PayScale_Verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            PayScale Verification
        </div>
        <div class="panel-body" style="padding: 0">
            <div>
                <input type="text" id="myInput" onkeyup="searchTable()" style="width: 100%" class="form-control" placeholder="Search By Employee Name, File No" title="Type in a name" autocomplete="off">
            </div>
            <asp:Repeater ID="rptr" runat="server">
                <headertemplate>
                        <table id="myTable" class="table table-striped table-bordered" style="width: 100%" border="1">
                        <thead style="background-color: #004D40; color: white; font-weight: bold; text-align: center">
                            <tr>
                                <th style="vertical-align: central; text-align: center">Sl</th>
                                <th style="vertical-align: central; text-align: center">Actions</th>

                                <th style="vertical-align: central; text-align: center">ID</th>
                                <th style="vertical-align: central; text-align: center">Name</th>
                                <th style="vertical-align: central; text-align: center">Designation</th>
                                <th style="vertical-align: central; text-align: center">Joining Date</th>
                                <th style="vertical-align: central; text-align: center">Basic</th>
                                <th style="vertical-align: central; text-align: center">Rent</th>
                                <th style="vertical-align: central; text-align: center">Convenience</th>
                                <th style="vertical-align: central; text-align: center">Medical</th>
                                <th style="vertical-align: central; text-align: center">TADA</th>
                                <th style="vertical-align: central; text-align: center">Others</th>
                                <th style="vertical-align: central; text-align: center">Gross Salary</th>
                            </tr>
                        </thead>
                    </headertemplate>
                <itemtemplate>
        <%--<asp:HiddenField ID="lblUserReqDtlsID" runat="server" Value='<%# Eval("FID_ID") %>'></asp:HiddenField>--%>
        <tr style="background-color: #fff; font-size: 12px" id="srcEmp" class="ok">
            <td align="center"><%# Container.ItemIndex + 1 %></td>
            <td style="padding:0">
                <asp:LinkButton runat="server" ID="btnSendPR" CausesValidation="False" CommandArgument='<%# Eval("ID") %>' CommandName="View" CssClass="btn btn-success btn-sm btn-block" OnClick="btnSendPR_Click">
            <span class="glyphicon glyphicon-ok"></span> &nbsp;Verify </asp:LinkButton>
            </td>
            <td align="center"><b><%# Eval("ID") %></b></td>
            <td align="left"><span style="color:darkcyan"><%#Eval("EMP_NAME") %></span></td>
            <td align="center"><b><%# Eval("DSG_NM") %></b></td>
            <td align="center"><%#Convert.ToDateTime(Eval("JOIN_DATE")).ToString("dd-MMM-yyyy")%></td>
            <td align="left"><%#Eval("START_BASIC") %></td>
            <td align="left"><%#Eval("HOUSE_RENT") %></td>
            <td align="left"><%#Eval("CONVEYANCE") %></td>
            <td align="left"><%#Eval("MEDICAL") %></td>
            <td align="left"><%#Eval("TADA") %></td>
            <td align="left"><%#Eval("OTHERS") %></td>
            <td align="left"><%#Eval("GROSS") %></td>                                                
        </tr>
                                                        
    </itemtemplate>
                        <footertemplate>
                    </table>
                </footertemplate>
            </asp:Repeater>
        </div>
    </div>
</form>
    <script type="text/javascript">
        function searchTable() {
            var input, filter, found, table, tr, td, i, j, cstCLASS, empCLASS;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");

            //tr = table.getElementsByClassName("ok");
            tr = table.getElementsByTagName("tr");
            //cstCLASS = document.getElementById("srcCost").className;
            //empCLASS = document.getElementById("srcEmp").className;

            for (i = 1; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td");

                for (j = 0; j < td.length; j++) {
                    if (td[j].innerHTML.toUpperCase().indexOf(filter) > -1) {
                        found = true;
                    }
                }
                if (found) {
                    tr[i].style.display = "";
                    found = false;

                }
                else {
                    tr[i].style.display = "none";

                }
            }
        }
    </script>
</asp:Content>
