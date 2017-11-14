<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lopet.aspx.cs" Inherits="Lopet.Dueno.Lopet" %>

<!DOCTYPE HTML>
<html>
	<head>
		<title>LOPET</title>
		<link href="../Content/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
		<link href="../Content/css/bootstrap.css" rel='stylesheet' type='text/css' />

         <script type="text/javascript" src="../Content/js/jquery.min.js"></script>	

		<script type="text/javascript" src="../Content/js/bootstrap.js"></script>
		<script type="text/javascript" src="../Content/js/bootstrap.min.js"></script>
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		</script>
		<!----webfonts---->
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>
		<link href='http://fonts.googleapis.com/css?family=Oswald:400,300,700' rel='stylesheet' type='text/css'>
		<!----//webfonts---->
		<link href="../Content/css/theme.css" rel='stylesheet' type='text/css' />
			
        <!--start slider -->
	    <link rel="stylesheet" href="../Content/css/fwslider.css" media="all">
	    <script src="../Content/js/jquery-ui.min.js"></script>
        <script src="../Content/js/css3-mediaqueries.js"></script>
		<script src="../Content/js/fwslider.js"></script>
	        <!--end slider -->
	       <!--  jquery plguin -->
		<script src="../Content/js/login.js"></script>		
		<script src="../Content/js/modernizr.custom.js"></script>
          <!--  MULTISELECT -->
            <script src="../Content/js/jquery_min_gg.js"></script>
        <link href="../Content/css/bootstrap_min_gg.css" rel="stylesheet" />
        <script src="../Content/js/bootsrap_multiselect_gg.js"></script>
            <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
            <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
        <script type="text/javascript">
            function valorar(valor) {
                alert("Valoro al Lopet con " + valor + " estrellas");
            }
        </script>
            <script type="text/javascript">
                $(function () {
                    $('[id*=ddl_dias]').multiselect({
                        includeSelectAllOption: true
                    });

                    $('[id*=ddl_mascotas_con]').multiselect({
                        includeSelectAllOption: true
                    });
                });
            </script>
        <!--  AJAX -->
           <%-- <script src="../Content/js/hapo.js"></script>--%>
            <script type = "text/javascript">
               
                function ShowCurrentTime() {
                    var listDias = new Array();
                    var dia = document.getElementById('ddl_dias').value
                    var mascotas = 0
                    var cont = 0
                    var precio = document.getElementById('txt_precio').value
                    
                    $.each($('#ddl_dias :selected'), function () {

                        listDias = listDias + document.getElementById('ddl_dias').value
                        cont = cont + 1
                    });

                    $.each($('#ddl_mascotas_con :selected'), function () {
                        mascotas = mascotas + 1
                    });

                    var precioTotal = precio * cont
                    document.getElementById('txt_total').value = precioTotal

                    var r = confirm("El importe total a pagar es: S/." + precioTotal + " ¿Esta seguro de contratar el servicio?");
                    if (r == true) {
                        
                        var data = {
                            "fecha_ini": document.getElementById('fecha_inicio').value,
                            "fecha_fin": document.getElementById('fecha_fin').value,
                            "precio": precioTotal,
                            "dias": cont,
                            "mascotas": mascotas
                        };
                        data = JSON.stringify(data);
                        $.ajax({
                            type: "POST",
                            url: "Lopet.aspx/GetCurrentTime",
                            data: data,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: OnSuccess,

                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                    } else {
                       
                    }


                }
                function OnSuccess(response) {
                    location.href = "/Dueno/misContratos.aspx";
                    //alert(response.d);
                }
    </script>
	    <!--scroll-->
 		<script type="text/javascript">
			$(document).ready(function() {
			
				var defaults = {
		  			containerID: 'toTop', // fading element id
					containerHoverID: 'toTopHover', // fading element hover id
					scrollSpeed: 1200,
					easingType: 'linear' 
		 		};
				
				
				$().UItoTop({ easingType: 'easeOutQuart' });
				
             });

             $('#myModal').on('shown.bs.modal', function () {
                 $('#myInput').focus()
             })

            
		</script>
		<!--//scroll-->
	<!-- Add fancyBox light-box -->
	<link rel="stylesheet" type="text/css" href="../Content/css/magnific-popup1.css">
		<script src="js/jquery.magnific-popup.js" type="text/javascript"></script>
				<script>
					$(document).ready(function() {
						$('.popup-with-zoom-anim').magnificPopup({
							type: 'inline',
							fixedContentPos: false,
							fixedBgPos: true,
							overflowY: 'auto',
							closeBtnInside: true,
							preloader: false,
							midClick: true,
							removalDelay: 300,
							mainClass: 'my-mfp-zoom-in'
					});
				});
		</script>
		<!-- //End fancyBox light-box -->	
	</head>
	<body>
    <form id="form1" runat="server">
		   <!-- start magnific-->

		<!-- end magnific-->

		<!----start-container----->
		<div class="header-bg" id="home">
			<div class="container">
				<div class="row">
					<div class="col-md-4">
						<div class="logo"><h1><a href="inicio.aspx">
                            <asp:Image ID="img_per" style="width:60px;height:60px;" runat="server"  />  
                            <asp:Label ID="lbl_nombre" runat="server" Text=""></asp:Label></a></h1></div>
					</div>
					<div class="col-md-8" style="margin-top:1%;">					
	 					<div class="h_right">
	 						<div class="left">
							<ul class="menu list-unstyled">		
								<li class="active"><a href="/Dueno/inicio.aspx" class="scroll">Inicio</a></li>
								<%--<li><a href="#features" class="scroll">Quienes Somos</a></li>--%>
								<li><a href="/Dueno/buscarLopets.aspx" class="scroll">Buscar Lopets</a></li>
								<li><a href="/Dueno/busqueda_sitios.aspx" class="scroll">Sitios de Interes</a></li>
								<li><a href="/Dueno/perfil.aspx" class="scroll">Mi Perfil</a></li>
                                <li><a href="../inicio.aspx" class="scroll">Salir</a></li>
							</ul>
						   </div>	
								
												
							<!-- start smart_nav * -->
					        <nav class="nav">
					            <ul class="nav-list">
					                <li class="nav-item"><a href="/Dueno/inicio.aspx">Inicio</a></li>
					               	<li><a href="/Dueno/buscarLopets.aspx" class="scroll">Buscar Lopets</a></li>
								    <li><a href="/Dueno/busqueda_sitios.aspx" class="scroll">Sitios de Interes</a></li>
								    <li><a href="/Dueno/perfil.aspx" class="scroll">Mi Perfil</a></li>
                                    <li><a href="../inicio.aspx" class="scroll">Salir</a></li>
	               
					                <div class="clearfix"></div>		
					            </ul>					            
				
					        <div class="nav-mobile"></div></nav>
					        
					        <script type="text/javascript" src="../Content/js/responsive.menu.js"></script>
							<!-- end smart_nav * -->
						</div>
						
					</div>	      
				</div>
			</div>
        </div>	
       <!----start-images-slider---->
		<div class="images-slider" >
			<!-- start slider -->
		    <div id="fwslider" >
		        <div class="slider_container" >
		            <div class="slide"> 
		                <!-- Slide image -->
		                   <%-- <img src="../Content/images/banner.jpg" alt=""/>--%>
                        <asp:Image ID="img_portada" runat="server" />
		            </div>
		            <!-- /Duplicate to create more slides -->
		            <div class="slide">
		                <%--<img src="../Content/images/banner.jpg" alt=""/>--%>
                        <asp:Image ID="img_portada2"  runat="server" />

		            </div>
		            <!--/slide -->
		        </div>
		        <div class="timers"> </div>
		        <div class="slidePrev"><span> </span></div>
		        <div class="slideNext"><span> </span></div>
		    </div>
		    <!--/slider -->
		</div>	
	


<!-----------start-pricing----------->
<div class="pricing-plans" id="prices">
		<div class="container" style="height:700px;">
             <%--INFO LOPET--%>
               <div class="form-group row">
                 <div class="col-xs-3">
                     <asp:Image ID="img_lopet" style="width:220px;height:200px;margin-top:15%;" class="img-circle" runat="server" />

                     <br />
                     <h4><asp:Label ID="lbl_nombre_Lopet" style="font-family:cursive;font-size:xx-large;font-weight:bolder;color:steelblue;" runat="server" Text=""></asp:Label></h4>
                     <br />
                     <h4><asp:Label ID="lbl_servicio" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text=""></asp:Label></h4>
                     <br />
                     <h4><asp:Label ID="lbl_distrito" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text=""></asp:Label></h4>
                     <br />
                    <h4><asp:Label ID="lbl_precio" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text=""></asp:Label></h4>
                     <br />
                     <%--metodo de reputacion--%>
                      <%=MostrarReputacion()%>

                 
                     <br />
                      <br />
               <%-- <asp:Button ID="btn_contratar" class="btn btn-primary" data-toggle="modal" data-target="#myModal" runat="server" Text="Contratar" />--%>
                     <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
  Contratar
</button>
                 </div>

                 <div class="col-xs-8" style="margin-top:5%;">
                     <h4><asp:Label ID="Label1" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text="Sobre Mi"></asp:Label></h4>
                     <asp:TextBox ID="txt_des" class="form-control" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>

                     <br />
                      <h4><asp:Label ID="Label3" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text="Informacion Adicional"></asp:Label></h4>
                        <asp:TextBox ID="txt_info" class="form-control" runat="server" TextMode="MultiLine" Rows="5">- Cuento con auto para emergencias
- Puedo administrar medicametos</asp:TextBox>
                     <br />
                     <h4><asp:Label ID="Label4" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text="Mapa"></asp:Label></h4>
                        <asp:Image ID="img_mapa"  runat="server" ImageUrl="~/Content/images/mapa.png" Width="90%" Height="200px" />
                     <br />
                      <h4><asp:Label ID="Label2" style="font-family:cursive;font-size:x-large;font-weight:bolder;color:steelblue;" runat="server" Text="Comentarios Sobre Mi"></asp:Label></h4>

                     <asp:TextBox ID="txt_comentarios" class="form-control" runat="server" TextMode="MultiLine" Rows="2" Visible="true" placeholder="ingresar comentario..."></asp:TextBox>
                       <br />
                     <asp:Button ID="btn_comentario" class="btn btn-primary" runat="server" Visible="false" Text="Enviar comentario" OnClick="btn_comentario_Click" />
                     <br />
         <table class="table table-striped" style="margin-left:1%;overflow-y:400px;">
				<tbody>     
          
					<tr>
						<td>							

						    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="1" >
                                <ItemTemplate>
                                    <asp:Label ID="nombresLabel" runat="server" Text='<%# Eval("nombres") %>' />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                                     <br />
                                    <asp:Label ID="comentarioLabel" runat="server" Text='<%# Eval("comentario") %>' />
                                    <br />
                                     <br />
                                </ItemTemplate>
                            </asp:DataList>

					<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LopetBDConnectionString %>" SelectCommand="mostrar_comentario_Lopet" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="null" Name="NOMBRE" QueryStringField="nombreL" Type="String" />
                            <asp:QueryStringParameter DefaultValue="null" Name="FOTO" QueryStringField="foto" Type="String" />
                        </SelectParameters>
                            </asp:SqlDataSource>

						</td>
                        						
					</tr>

					
				</tbody>
			</table>
                 </div>

             </div>
             <%--INFO LOPET--%>
		</div>
</div>

<div class="footer" style="background-color:white;">
	<div class="container">
		<div class="row">
 			<div class="col-md-12">	
				<div class="copy-right">
					<p>&#169Copyright 2017 All Rights Reserved<a href=""></a></p>	
				</div>	
			</div>
		</div>
    </div>
</div>


<!-- scroll_top_btn -->
		<script type="text/javascript" src="../Content/js/move-top.js"></script>
		<script type="text/javascript" src="../Content/js/easing.js"></script>
		<script type="text/javascript">
		jQuery(document).ready(function($) {
			$(".scroll").click(function(event){		
				event.preventDefault();
				$('html,body').animate({scrollTop:$(this.hash).offset().top},1200);
			});
		});
	</script>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>

      
<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Contratar LOPET</h4>
        </div>
        <div class="modal-body" style="height:270px;">
            <div class="col-xs-4">
                Lopet
                <asp:TextBox ID="txt_lopet" ReadOnly="true" style="width: 80%" class="form-control" runat="server"></asp:TextBox>
                Fecha de inicio
                <input id="fecha_inicio" type="date" class="form-control form-group" style="width: 80%">
                Dias:
                <asp:ListBox ID="ddl_dias" runat="server" SelectionMode="Multiple" >
                    <asp:ListItem Text="Lunes" Value="0" />
                    <asp:ListItem Text="Martes" Value="1" />
                    <asp:ListItem Text="Miercoles" Value="2" />
                    <asp:ListItem Text="Jueves" Value="3" />
                    <asp:ListItem Text="Viernes" Value="4" />
                    <asp:ListItem Text="Sabado" Value="5" />
                    <asp:ListItem Text="Domingo" Value="6" />
                </asp:ListBox>
             </div>
            <div class="col-xs-4">
                Servicio
                 <asp:TextBox ID="txt_servicio" ReadOnly="true" style="width: 80%" class="form-control" runat="server" Text="Cuidador"></asp:TextBox>
                Fecha de Fin
                <input id="fecha_fin" type="date"  class="form-control form-group" style="width: 80%">
                Mascotas
                <asp:ListBox ID="ddl_mascotas_con" runat="server" SelectionMode="Multiple" >
                </asp:ListBox>
                
             </div>
            <div class="col-xs-4">
                Precio
                <asp:TextBox ID="txt_precio" ReadOnly="true" style="width: 80%" class="form-control" runat="server" Text="30.00"></asp:TextBox>
                Importe Total
                <asp:TextBox ID="txt_total" Visible="true" ReadOnly="true" style="width: 80%" class="form-control" runat="server" Text="00.00"></asp:TextBox>
                <strong>Terminos y condiciones:</strong> 
                <hr />
                <h6 style="font-size:x-small;"> Al hacer clic en "Contratar" se le enviara una solicitud de contrato al Lopet,
                cuando el Lopet-apruebe tu solicitud se procedera con el servicio.
                Tiempo de respuesta 1 hora aproximadamente.</h6>
               
            </div>
        </div>
        <div class="modal-footer" >
          <button type="button"  class="btn btn-danger" data-dismiss="modal">Cancelar</button>
           <%-- <asp:Button ID="btn_contratar"  class="btn btn-primary" runat="server" Text="Contratar" OnClick="btn_contratar_Click" />--%>
            
            <input id="btnGetTime" class="btn btn-primary" type="button" value="Contratar"
                onclick = "ShowCurrentTime()" />

  
        </div>
      </div>
    </div>
  </div>
           

    
    </form>
 
<!-- Modal -->

 

</body>
</html>

