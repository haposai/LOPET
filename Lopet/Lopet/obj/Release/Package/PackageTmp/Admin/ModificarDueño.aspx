<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarDueño.aspx.cs" Inherits="Lopet.Admin.ModificarDueño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        function validacion_update_exito() {
            alert('Se guardaron los datos exitosamente');
        };
        function validacion_update_error() {
            alert('Error no se guardaron los datos');
         };

         // Solo permite ingresar numeros.
         function soloNumeros(e) {
             var key = window.Event ? e.which : e.keyCode
             return (key >= 48 && key <= 57)
         }
     </script>
     <h3 class="box-title" style="color:midnightblue">Editar Dueño</h3>
    <div class="form-group row">
         
         <br />
      <div class="col-xs-3">
        <label for="ex2">Nombres</label>
        <asp:TextBox  class="form-control" ID="txt_nombre" runat="server"></asp:TextBox>

        <label for="ex2">Apellidos</label>
        <asp:TextBox  class="form-control" ID="txt_apellido" runat="server"></asp:TextBox>

        <label for="ex2">DNI</label>
        <asp:TextBox  class="form-control" ID="txt_dni" onKeyPress="return soloNumeros(event)" runat="server" ></asp:TextBox>

        <label for="ex2">Celular</label>
        <asp:TextBox  class="form-control" ID="txt_celular" onKeyPress="return soloNumeros(event)" runat="server"></asp:TextBox>

        <label for="ex2">Correo</label>
        <asp:TextBox  class="form-control" ID="txt_correo" runat="server"></asp:TextBox>

        <label for="ex2">Contraseña</label>
        <asp:TextBox  class="form-control" ID="txt_con" runat="server" MaxLength="30"></asp:TextBox>

         <label for="ex2">Distrito</label>
          <asp:DropDownList ID="ddl_distrito2" class="form-control" runat="server">
              <asp:ListItem Value="0">Seleccionar</asp:ListItem>
              <asp:ListItem Value="1">La Molina</asp:ListItem>
          </asp:DropDownList>

        <label for="ex2">Sexo</label>
          <asp:DropDownList ID="ddl_sexo" class="form-control" runat="server">
              <asp:ListItem Value="0">Seleccionar</asp:ListItem>
              <asp:ListItem Value="Masculino">Masculino</asp:ListItem>
              <asp:ListItem Value="Femenino">Femenino</asp:ListItem>
          </asp:DropDownList>

        <label for="ex2">Foto de perfil</label>
        <asp:FileUpload class="form-control" ID="fp_perfil" runat="server" />

        <label for="ex2">Foto de portada</label>
        <asp:FileUpload class="form-control" ID="fp_portada" runat="server" />
          <br />
          <asp:Button ID="btn_guardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
      </div>

      <div class="col-xs-3">
       <%--   <asp:Image ID="Image1" style="width:220px;height:200px;" class="img-circle" runat="server" ImageUrl="~/perfil/foto2.jpg" />--%>

      </div>
          <div class="col-xs-3">

    <asp:Image ID="Image2" style="width:220px;height:200px;margin-top:15%;" class="img-rounded" runat="server" ImageUrl="~/Content/images/bienvenidoGif.gif" />
              <div class="logo" style="margin-left:18%">
                  <h1><asp:Label ID="lbl_texto" runat="server" Text="Bienvenido"></asp:Label></h1>
              </div>
      </div>
    </div>
</asp:Content>
