<%@ Page Title="" Language="C#" MasterPageFile="~/Dueno/Dueño.Master" AutoEventWireup="true" CodeBehind="misMascotas.aspx.cs" Inherits="Lopet.Dueño.misMascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
	<div class="row">
		<div class="col-md-12">
            <asp:Button ID="btn_reg" class="btn btn-default" style="float:right;" runat="server" Text="Agregar Mascota" PostBackUrl="~/Dueno/AgregarMascota.aspx" />
			<div class="jumbotron"  style="background-color:white;">
                 <h3>Mis Mascotas</h3>  
                <div style="width:auto;">
				<table class="table table-responsive" style="margin-left:15%;">
				<tbody>     
                    <tr>
                        <td>
                                                                                
                            <asp:Label ID="lblAgregado" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                          <%--  <asp:ImageButton ID="ImageButton1" width="120" height="120" runat="server" ImageUrl="~/Imagenes/carro-de-compras.jpg" OnClick="ImageButton1_Click" />--%>
                        </td>
                    </tr>               
					<tr>
						<td>							

						    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="3" >
                                <ItemTemplate>
       <asp:Image ID="Image1" width="220" height="150" runat="server" ImageUrl='<%# "~/mascotas/"+Eval  ("foto_perfil_mascota") %>' />
                                    <br />
                                    Nombre:
                                    <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
                                    <br />
                                    Raza:
                                    <asp:Label ID="razaLabel" runat="server" Text='<%# Eval("raza") %>' />
                                    <br />
                            <asp:LinkButton ID="IDimagen" runat="server" CommandName="ImgiD" CommandArgument='<%# Eval("nombre") %>'
                                Text="Editar" ToolTip="Editar mascota" PostBackUrl='<%# "~/Dueno/Editarmascota.aspx?nombreM="+Eval("Nombre")+"&accion=1"+"&fotoM="+Eval("foto_perfil_mascota") %>'></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ImgiD" CommandArgument='<%# Eval("nombre") %>'
                                Text="Eliminar" ToolTip="Eliminar mascota" PostBackUrl='<%# "~/Dueno/Editarmascota.aspx?nombreM="+Eval("Nombre")+"&accion=2" %>'></asp:LinkButton>
                                    <br />
                                </ItemTemplate>

                            </asp:DataList>

					<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LopetBDConnectionString %>" SelectCommand="mostrar_mis_mascotas" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="DNI" SessionField="ID" Type="String" />
                        </SelectParameters>
                            </asp:SqlDataSource>

						</td>
                        						
					</tr>

					
				</tbody>
			</table>
               </div>   
			</div>
		</div>
	</div>
</div>
</asp:Content>
