<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Lopet.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

   

    

    <link href="Content/css/bootstrap.min.css" rel="stylesheet" 
    <link href="Content/start/jquery.toast.min.css" rel="stylesheet" />
    <script src="Content/start/jquery.toast.min.js"></script>

<%--    <script src="Content/start/modernizr.js"></script>
    <script src="Content/start/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="Content/start/main.js"></script>
    <script src="Content/start/jquery.toast.min.js"></script>--%>


    <title></title>
    <script type="text/javascript" >
        function valorar(numero) {
            if (numero == 1) {
                $.toast({
                    heading: 'Information',

                    text: 'Usted ha valorado con 1 estrella',
                    position: 'top-right',
                    icon: 'success',
                    loader: false,
                });

                $(".stars").html('<a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 35px" onclick="valorar(1)">&#9733;</a>&nbsp;&nbsp;<a class="aa" href="#" data-value="2" title="Votar con 2 estrellas" style="font-size: 35px" onclick="valorar(2)">&#9733;</a>&nbsp;&nbsp;<a class="aa" href="#" data-value="3" title="Votar con 3 estrellas" style="font-size: 35px" onclick="valorar(3)">&#9733;</a>&nbsp;&nbsp;<a class="bb" href="#" data-value="4" title="Votar con 4 estrellas" style="font-size: 35px" onclick="valorar(4)">&#9733;</a>&nbsp;&nbsp;<a class="bb" href="#" data-value="5" title="Votar con 5 estrellas" style="font-size: 35px" onclick="valorar(5)">&#9733;</a>');
            }
            if (numero == 2) {
                $.toast({
                    heading: 'Information',

                    text: 'Usted ha valorado con 2 estrellas',
                    position: 'top-right',
                    icon: 'success',
                    loader: false,
                });
            }
            if (numero == 3) {
                $.toast({
                    heading: 'Information',

                    text: 'Usted ha valorado con 3 estrellas',
                    position: 'top-right',
                    icon: 'success',
                    loader: false,
                });
            }
            if (numero == 4) {
                $.toast({
                    heading: 'Information',

                    text: 'Usted ha valorado con 4 estrellas',
                    position: 'top-right',
                    icon: 'success',
                    loader: false,
                });
            }
            if (numero == 5) {
                $.toast({
                    heading: 'Information',

                    text: 'Usted ha valorado con 5 estrellas',
                    position: 'top-right',
                    icon: 'success',
                    loader: false,
                });
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

          <div class="stars">
                      
           <a class="aa" href="#" data-value="1" title="Votar con 1 estrellas" style="font-size: 35px" onclick="valorar(1)">&#9733;</a>&nbsp;&nbsp;
            <a class="aa" href="#" data-value="2" title="Votar con 2 estrellas" style="font-size: 35px" onclick="valorar(2)">&#9733;</a>&nbsp;&nbsp;
            <a class="aa" href="#" data-value="3" title="Votar con 3 estrellas" style="font-size: 35px" onclick="valorar(3)">&#9733;</a>&nbsp;&nbsp;
            <a class="aa" href="#" data-value="4" title="Votar con 4 estrellas" style="font-size: 35px" onclick="valorar(4)">&#9733;</a>&nbsp;&nbsp;
            <a class="bb" href="#" data-value="5" title="Votar con 5 estrellas" style="font-size: 35px" onclick="valorar(5)">&#9733;</a>
          </div>

    </form>
</body>
</html>
