<%@ Page Title="" Language="C#" MasterPageFile="~/Lopet/GG.Master" AutoEventWireup="true" CodeBehind="MisPagos.aspx.cs" Inherits="Lopet.Lopet.MisPagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="form-group row" style="margin-left:5%;overflow-x:auto;">
         <h3>Mis Pagos</h3>
        <hr />
    <asp:GridView ID="gv_contrato" runat="server" CssClass="table table-striped table-bordered table-hover"
   AllowPaging="True" DataSourceID="SqlDataSource1" >
      
         </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LopetBDConnectionString %>" SelectCommand="SELECT [id_pago], [fecha], [importe] FROM [Pago] WHERE ([id_lopet] = @id_lopet)">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="id_lopet" SessionField="ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
    </div>
</asp:Content>
