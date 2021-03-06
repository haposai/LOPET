﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Dueños.aspx.cs" Inherits="Lopet.Admin.Dueños" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3 class="box-title" style="color:midnightblue">Dueños</h3>
      <asp:Button ID="btn_guardar" style="float:right;" class="btn btn-default" runat="server" Text="Registrar Dueño"   PostBackUrl="~/Admin/Registrar_Dueño.aspx" />
    <p></p>
     <div class="box-body">
          <form action="#" method="post">
               <div class="form-group">

                             <asp:GridView ID="gv_contrato" runat="server" CssClass="table table-striped table-bordered table-hover"
                       AllowPaging="True" AutoGenerateColumns="False" OnRowDeleting="OnRowDeleting" 
                        OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged="gv_contrato_SelectedIndexChanged">
                            <Columns>
                                 <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo">
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                </asp:BoundField>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido">
                                </asp:BoundField>
                                <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI">
                                </asp:BoundField>
                                 <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular">
                                </asp:BoundField>
                                 <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo">
                                </asp:BoundField>
                                <asp:BoundField DataField="Distrito" HeaderText="Distrito" SortExpression="Distrito">
                                </asp:BoundField>
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo">
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
