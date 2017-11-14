<%@ Page Title="" Language="C#" MasterPageFile="~/Lopet/GG.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="busqueda_sitios.aspx.cs" Inherits="Lopet.Lopet.busqueda_sitios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100%;
      }
      /* Optional: Makes the sample page fill the window. */
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
    </style>
    <table>
        <tr>
            <td>Distrito:&nbsp;&nbsp;</td>
            <td><asp:DropDownList ID="ddl_distrito" runat="server">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">La Molina</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                
        </tr>
        <tr>
            <td>Tipo:&nbsp;&nbsp;</td>
            <td><asp:DropDownList ID="ddl_tipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_tipo_SelectedIndexChanged">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">Veterianarias y albergues</asp:ListItem>
                <asp:ListItem Value="2">Alojamientos temporales</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Buscar" CssClass="btn-primary"  /></td>
        </tr>
    </table>
    <br/>
    <br/>
    <asp:Panel ID="vet" runat="server">
         <%=MostrarSitios()%>
    </asp:Panel>

       <div id="map" style="width:100%;height:500px;"></div>
    <script>

      // The following example creates complex markers to indicate beaches near
      // Sydney, NSW, Australia. Note that the anchor is set to (0,32) to correspond
      // to the base of the flagpole.

      function initMap() {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 16,
            //minimo valor latitud - maximo valor longitud
          center: { lat: -12.0650430033943, lng: -76.9529074}
        });

        setMarkers(map);
      }

      // Data for the markers consisting of a name, a LatLng and a zIndex for the
      // order in which these markers should display on top of each other.
      var beaches = [
          ['ca. Los sanitarios 129', -12.0650430033943, -76.9527118, 4],
          ['Ca. Los Forestales 448', -12.0657224033945, -76.9529074, 5],
          ['Ca. Los Forestales 446', -12.0657087033945, -76.9529096, 3]
      ];

      function setMarkers(map) {
        // Adds markers to the map.

        // Marker sizes are expressed as a Size of X,Y where the origin of the image
        // (0,0) is located in the top left of the image.

        // Origins, anchor positions and coordinates of the marker increase in the X
        // direction to the right and in the Y direction down.
        var image = {
          url: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png',
          // This marker is 20 pixels wide by 32 pixels high.
          size: new google.maps.Size(20, 32),
          // The origin for this image is (0, 0).
          origin: new google.maps.Point(0, 0),
          // The anchor for this image is the base of the flagpole at (0, 32).
          anchor: new google.maps.Point(0, 32)
        };
        // Shapes define the clickable region of the icon. The type defines an HTML
        // <area> element 'poly' which traces out a polygon as a series of X,Y points.
        // The final coordinate closes the poly by connecting to the first coordinate.
        var shape = {
          coords: [1, 1, 1, 20, 18, 20, 18, 1],
          type: 'poly'
        };
        for (var i = 0; i < beaches.length; i++) {
          var beach = beaches[i];
          var marker = new google.maps.Marker({
            position: {lat: beach[1], lng: beach[2]},
            map: map,
            icon: image,
            shape: shape,
            title: beach[0],
            zIndex: beach[3]
          });
        }
      }
    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD0RBXIvMTl5vzBkyHUDF1YEBQy0YuYS8Q&callback=initMap">
    </script>
</asp:Content>
