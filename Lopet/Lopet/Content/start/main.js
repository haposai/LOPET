$(document).ready(function(){
    $('.tooltips-general').tooltip('hide');
    $('.mobile-menu-button').on('click', function(){
        var mobileMenu=$('.navbar-lateral');	
        if(mobileMenu.css('display')=='none'){
            mobileMenu.fadeIn(300);
        }else{
            mobileMenu.fadeOut(300);
        }
    });
    $('.dropdown-menu-button').on('click', function(){
        var dropMenu=$(this).next('ul');
        dropMenu.slideToggle('slow');
    });
    $('.exit-system-button').on('click', function(e){
        e.preventDefault();
        var LinkExitSystem=$(this).attr("data-href");
        swal({
            title: "¿Estás seguro?",
            text: "Quieres salir del sistema y cerrar la sesión actual",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#5cb85c",
            confirmButtonText: "Si, salir",
            cancelButtonText: "No, cancelar",
            animation: "slide-from-bottom",
            closeOnConfirm: false 
        },function(){
            window.location=LinkExitSystem; 
        });  
    });
    $('.search-doctor-button').click(function(e){
        e.preventDefault();
        var nombres = ["Jair","Antony","Henry"];
        var LinkSearchDoctor=$(this).attr("data-href");
        swal({
           title: "¿Cual es el nombre o código del doctor?",
           text: "Por favor escribe el nombre o código del doctor",
           type: "input",   
           showCancelButton: true,
           closeOnConfirm: false,
           animation: "slide-from-top",
           cancelButtonText: "Cancelar",
           confirmButtonText: "Buscar",
           confirmButtonColor: "#3598D9",
           inputPlaceholder: "Escribe aquí el nombre o codigo del doctor" }, 
      function(inputValue){
           if (inputValue === false) return false;  

           if (inputValue === "") {
               swal.showInputError("Debes escribir el nombre o codigo del doctor");     
               return false;   
           } 
           if(nombres.includes(inputValue)){
            window.location.href = "#"+inputValue;
            swal.close();
            }else{
              swal.showInputError("No se encontró al doctor");
            }
       });
    });
    $('.btn-help').on('click', function(){
        $('#ModalHelp').modal({
            show: true,
            backdrop: "static"
        });
    });
});
(function($){
    $(window).load(function(){
        $(".custom-scroll-containers").mCustomScrollbar({
            theme:"dark-thin",
            scrollbarPosition: "inside",
            autoHideScrollbar: true,
            scrollButtons:{ enable: true }
        });
    });
})(jQuery);