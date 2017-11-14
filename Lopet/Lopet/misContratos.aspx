<%@ Page Title="" Language="C#" MasterPageFile="~/Lopet/GG.Master" AutoEventWireup="true" CodeBehind="misContratos.aspx.cs" Inherits="Lopet.Lopet.misContratos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        function validacion_usuario() {
            alert("Oh cy se puede eliminar");
        };

     </script>
    <div class="form-group row" style="margin-left:5%;overflow-x:auto;">
         <h3>Mis Contratos</h3>
        <hr />
    <asp:GridView ID="gv_contrato" runat="server" CssClass="table table-striped table-bordered table-hover"
   AllowPaging="True" AutoGenerateColumns="False" OnRowDeleting="OnRowDeleting" OnRowDataBound = "OnRowDataBound"
        OnSelectedIndexChanged="gv_contrato_SelectedIndexChanged">
        <Columns>
             <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo">
            </asp:BoundField>
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario">
            </asp:BoundField>
            <asp:BoundField DataField="Lopet" HeaderText="Lopet" SortExpression="Lopet">
            </asp:BoundField>
            <asp:BoundField DataField="Fecha inicio" HeaderText="Fecha inicio" SortExpression="Fecha inicio">
            </asp:BoundField>
             <asp:BoundField DataField="Fecha fin" HeaderText="Fecha fin" SortExpression="Fecha fin">
            </asp:BoundField>
             <asp:BoundField DataField="Importe Total" HeaderText="Importe Total" SortExpression="Importe Total">
            </asp:BoundField>
            <asp:BoundField DataField="Nro Mascotas" HeaderText="Nro Mascotas" SortExpression="Nro Mascotas">
            </asp:BoundField>
            <asp:BoundField DataField="Nro Dias por semana" HeaderText="Nro Dias por semana" SortExpression="Nro Dias por semana">
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
            </asp:BoundField>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Ver" >
             <ControlStyle BackColor="#336699" />
             </asp:CommandField>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Cancelar" >
             <ControlStyle BackColor="#FF3300" />
             </asp:CommandField>
        </Columns>
         </asp:GridView>
    </div>
</asp:Content>
