<%@ Page Title="" Language="C#" MasterPageFile="~/Dueno/Dueño.Master" AutoEventWireup="true" CodeBehind="buscarLopets.aspx.cs" Inherits="Lopet.Dueno.buscarLopets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>Buscar Lopets</h3>  
     <table>
        <tr>
            <td>Distrito:&nbsp;&nbsp;</td>
            <td><asp:DropDownList ID="ddl_distrito" runat="server">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">La Molina</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
            <td>Tipo:&nbsp;&nbsp;</td>
            <td><asp:DropDownList ID="ddl_tipo" runat="server" AutoPostBack="true" >
                <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
                <asp:ListItem Value="1" >Paseadores</asp:ListItem>
                <asp:ListItem Value="2">Cuidadores</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
           
        </tr>

    </table>
    <div class="container-fluid">
	<div class="row">
		<div class="col-md-12">
			<div class="jumbotron"  style="background-color:white;">
                
                <div style="overflow:auto;width:auto;">
				<table class="table table-responsive" style="margin-left:15%;">
				<tbody>     
                    <tr>
                        <td>
                                                                                
                            <asp:Label ID="lblAgregado" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>               
					<tr>
						<td>							

						    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="5" >
                                <ItemTemplate>
                    <asp:Image ID="Image1" width="140" height="120" runat="server" ImageUrl='<%# "~/perfil/"+Eval  ("Foto") %>' />
                                    <br />
                                    Nombre:
                                    <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                                    <br />
                                    Distrito:
                                    <asp:Label ID="DistritoLabel" runat="server" Text='<%# Eval("Distrito") %>' />
                                    <br />
                                    Tipo:
                                    <asp:Label ID="TipoLabel" runat="server" Text='<%# Eval("Tipo") %>' />
                                    <br />
                                  
                                
                                    Reputacion:
                                     <br />
          
                                     <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" onclick="valorar(1)">&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" onclick="valorar(2)">&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" onclick="valorar(3)">&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" onclick="valorar(4)">&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" onclick="valorar(5)">&#9733;</a>
                                
                                    <br />
       <asp:LinkButton ID="IDimagen" runat="server" CommandName="ImgiD" CommandArgument='<%# Eval("Nombre") %>'
     Text="Ver" PostBackUrl='<%# "~/Dueno/Lopet.aspx?nombreL="+Eval("Nombre")+"&foto="+Eval("Foto")+"&repu="+Eval("Reputacion") %>' ></asp:LinkButton>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>

					<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LopetBDConnectionString %>" SelectCommand="buscar_Lopets" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_tipo" DefaultValue="0" Name="ID_SERVICIO" PropertyName="SelectedValue" Type="Int32" />
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
