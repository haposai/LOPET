﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Lopet.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid">
	<div class="row">
		<div class="col-md-12">
			<div class="jumbotron"  style="background-color:white">
                 <h3>Nuestros Mejores Lopets</h3>  
                <div style="overflow:auto;">
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
                                    <%--<asp:Label ID="ReputacionLabel" runat="server" Text='<%# Eval("Reputacion") %>' />--%>
                                  
                                
                                    <br />
                                         <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" >&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" >&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" >&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" >&#9733;</a>
                                    <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 20px" >&#9733;</a>
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>

					<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LopetBDConnectionString %>" SelectCommand="mostrar_top_Lopets" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

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