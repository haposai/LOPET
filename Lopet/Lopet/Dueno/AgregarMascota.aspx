<%@ Page Title="" Language="C#" MasterPageFile="~/Dueno/Dueño.Master" AutoEventWireup="true" CodeBehind="AgregarMascota.aspx.cs" Inherits="Lopet.Dueno.AgregarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">
        function validacion_update_exito() {
            alert('Se guardaron los datos exitosamente');
        };
        function validacion_update_error() {
            alert('Error no se guardaron los datos');
        };
            //Solo permite ingresar letras.
            function soloLetras(e) {
                key = e.keyCode || e.which;
                tecla = String.fromCharCode(key).toLowerCase();
                letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
                especiales = "8-37-39-46";

                tecla_especial = false
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        tecla_especial = true;
                        break;
                    }
                }

                if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                    return false;
                }
            };
            // Solo permite ingresar numeros.
            function soloNumeros(e) {
                var key = window.Event ? e.which : e.keyCode
                return (key >= 48 && key <= 57)
            };    
     </script>
        <div class="form-group row">
         <h3>Registrar Mascota</h3>
         <br />
      <div class="col-xs-3">
        <label for="ex2">Nombre</label>
        <asp:TextBox  class="form-control" ID="txt_nombre" onKeyPress="return soloLetras(event)" runat="server"></asp:TextBox>
          <br />
        <label for="ex2">Edad</label>
        <asp:TextBox  class="form-control" ID="txt_edad" onKeyPress="return soloNumeros(event)" runat="server" ></asp:TextBox>
          <br />
         
         
          <asp:Button ID="btn_guardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click"  />
      </div>

      <div class="col-xs-3">
           <label for="ex2">Sexo</label>
          <asp:DropDownList ID="ddl_sexo" class="form-control" runat="server">
              <asp:ListItem Value="0">Seleccionar</asp:ListItem>
              <asp:ListItem Value="Macho">Macho</asp:ListItem>
              <asp:ListItem Value="Hembra">Hembra</asp:ListItem>
          </asp:DropDownList>
          <br />
        <label for="ex2">Foto de perfil</label>
        <asp:FileUpload class="form-control" ID="fp_perfil" runat="server" />
      </div>
      <div class="col-xs-3">
          <label for="ex2">Discapacidad</label>
         <asp:TextBox  class="form-control" ID="txt_discapacidad" runat="server" ></asp:TextBox>
          <br />
          <label for="ex2">Raza</label>
           <asp:DropDownList ID="ddl_raza" class="form-control" runat="server">
          </asp:DropDownList>
         
      </div>
    </div>
</asp:Content>
