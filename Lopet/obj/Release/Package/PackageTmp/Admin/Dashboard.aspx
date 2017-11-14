<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Lopet.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../Content/Charts/fusioncharts.js"></script>
    <script src="../Content/Charts/fusioncharts.charts.js"></script>
    <script src="../Content/Charts/fusioncharts.theme.fint.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.11.1.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.11.1/jquery-ui.js"></script>
    <script src="../Content/js/flexibility.js"></script>
    <link href="../Content/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap-combined.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function validacion_año() {
            alert("Aun no hay información disponible del año seleccionado");
        };

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3 class="box-title" style="color: midnightblue">Dashboard</h3>


            <asp:Label ID="Label1" Style="margin-left: 1%" runat="server" Text="Año:"></asp:Label>
            <asp:DropDownList ID="ddl_año" runat="server" OnSelectedIndexChanged="ddl_año_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem Selected="True">2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
            </asp:DropDownList>

    <div class="box-body">
            <div class="row">
              <div class="col-sm-6">
                   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel3" runat="server">
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
              </div>
              <div class="col-sm-6">
                  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
              </div>

            </div>


    </div>
</asp:Content>
