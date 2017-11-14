<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" EnableEventValidation="false"CodeBehind="ModificarAlojamiento.aspx.cs" Inherits="Lopet.Admin.ModificarAlojamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        // Solo permite ingresar numeros.
        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }
    </script>
    <h3 class="box-title" style="color:midnightblue">Editar Alojamiento</h3>
     <div class="box-body">
          <form action="#" method="post">
               <div class="form-group" style="width:30%;">
                   Codigo:
                   <asp:TextBox ID="txt_id" class="form-control" runat="server"></asp:TextBox>
                   Nombre:
                   <asp:TextBox ID="txt_nombre" class="form-control" runat="server"></asp:TextBox>
                   Direccion:
                   <asp:TextBox ID="txt_direccion" class="form-control" runat="server"></asp:TextBox>
                   Latitud:
                   <asp:TextBox ID="txt_latitud" class="form-control" runat="server"></asp:TextBox>
                   Longitud:
                   <asp:TextBox ID="txt_longitud" class="form-control" runat="server"></asp:TextBox>
                   Telefono:
                   <asp:TextBox ID="txt_telefono" onKeyPress="return soloNumeros(event)" class="form-control" runat="server"></asp:TextBox>
                   Estado:
                   <asp:DropDownList ID="ddl_estado" class="form-control" runat="server">
                       <asp:ListItem>Seleccionar</asp:ListItem>
                       <asp:ListItem>Disponible</asp:ListItem>
                       <asp:ListItem>Ocupado</asp:ListItem>
                   </asp:DropDownList>
                   <p></p>
                    <asp:Button ID="btn_guardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click"  />
               </div>
           </form>
    </div>
</asp:Content>
