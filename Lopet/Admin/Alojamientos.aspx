<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Alojamientos.aspx.cs" Inherits="Lopet.Admin.Alojamientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h3 class="box-title" style="color:midnightblue">Alojamientos</h3>
     <asp:Button ID="btn_guardar" style="float:right;" class="btn btn-default" runat="server" Text="Crear Alojamiento"   PostBackUrl="~/Admin/Registrar_alojamiento.aspx" />
    <p></p>
     <div class="box-body">
          <form action="#" method="post">
               <div class="form-group">

                    <asp:GridView ID="gv_contrato" runat="server" CssClass="table table-striped table-bordered table-hover"
                       AllowPaging="True" AutoGenerateColumns="False" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged="gv_contrato_SelectedIndexChanged" OnRowDeleting="OnRowDeleting"  >
                            <Columns>
                                 <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo">
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                </asp:BoundField>
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion">
                                </asp:BoundField>
                                <asp:BoundField DataField="Latitud" HeaderText="Latitud" SortExpression="Latitud">
                                </asp:BoundField>
                                 <asp:BoundField DataField="Logintud" HeaderText="Logintud" SortExpression="Logintud">
                                </asp:BoundField>
                                 <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                </asp:BoundField>

                               <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Editar" >
                                 <ControlStyle BackColor="#FFFFFF" />
                                 </asp:CommandField>
      
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Eliminar" >
                                 <ControlStyle BackColor="#FF3300" />
                                 </asp:CommandField>
                            </Columns>
                             </asp:GridView>                      
                 </div>
           </form>
     </div>
</asp:Content>
