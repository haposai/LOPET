﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Lopet/GG.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Lopet.Lopet.perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        function validacion_update_exito() {
            alert('Se guardaron los datos exitosamente');
        };
        function validacion_update_error() {
            alert('Error no se guardaron los datos');
        };
     </script>
    <div class="form-group row">
         <h3>Mi Perfil</h3>
         <br />
      <div class="col-xs-3">
        <label for="ex2">Nombres</label>
        <asp:TextBox  class="form-control" ID="txt_nombre" runat="server"></asp:TextBox>

        <label for="ex2">Apellidos</label>
        <asp:TextBox  class="form-control" ID="txt_apellido" runat="server"></asp:TextBox>

        <label for="ex2">DNI</label>
        <asp:TextBox  class="form-control" ID="txt_dni" runat="server" ReadOnly="True"></asp:TextBox>

        <label for="ex2">Celular</label>
        <asp:TextBox  class="form-control" ID="txt_celular" runat="server"></asp:TextBox>

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
         
      </div>

      <div class="col-xs-3">
        <label for="ex2">Sobre mi</label>
        <asp:TextBox  class="form-control" ID="txt_des" TextMode="MultiLine" Rows="10" runat="server" ></asp:TextBox>

          <label for="ex2">Servicio</label>
           <asp:DropDownList ID="ddl_servicio" class="form-control" runat="server">
              <asp:ListItem Value="0">Seleccionar</asp:ListItem>
              <asp:ListItem Value="1">Paseador</asp:ListItem>
              <asp:ListItem Value="2">Cuidador</asp:ListItem>
          </asp:DropDownList>

          <label for="ex2">Precio por perro/hora</label>
        <asp:TextBox  class="form-control" ID="txt_precio" runat="server" ></asp:TextBox>

           <br />
          <asp:Button ID="btn_guardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
      </div>
          <div class="col-xs-3">

    <asp:Image ID="Image2" style="width:220px;height:200px;margin-top:15%;" class="img-rounded" runat="server" ImageUrl="~/Content/images/bienvenidoGif.gif" />
              <div class="logo" style="margin-left:18%">
                  <h1><asp:Label ID="lbl_texto" runat="server" Text="Bienvenido"></asp:Label></h1>
              </div>
      </div>
    </div>
</asp:Content>