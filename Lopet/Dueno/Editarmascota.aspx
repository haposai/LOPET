<%@ Page Title="" Language="C#" MasterPageFile="~/Dueno/Dueño.Master" AutoEventWireup="true" CodeBehind="Editarmascota.aspx.cs" Inherits="Lopet.Dueno.Editarmascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        function validacion_update_exito() {
            alert('Se guardaron los datos exitosamente');
        };
        function validacion_update_error() {
            alert('Error no se elimino la mascota');
        };
     </script>
        <div class="form-group row">
         <h3>Modificar Mascota</h3>
         <br />
      <div class="col-xs-3">
        <label for="ex2">Nombre</label>
        <asp:TextBox  class="form-control" ID="txt_nombre" runat="server"></asp:TextBox>
          <br />
        <label for="ex2">Edad</label>
        <asp:TextBox  class="form-control" ID="txt_edad" runat="server" ></asp:TextBox>
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
