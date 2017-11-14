using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Lopet.BEL;
using Lopet.DAL;

namespace Lopet.BLL
{
    public class BLL_Usuario
    {
 
        //Registrar Usuario
        public int RegistrarUsuario(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.RegistrarUsuario(usuario);

        }
        //Registrar Lopet
        public int RegistrarLopet(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.RegistrarLopet(lopet);

        }
        //Iniciar Sesion Usuario
        public DataTable IniciarSesionUsuario(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.IniciarSesionUsuario(usuario);

        }

        //Validar Iniciar Sesion Usuario Facebook
        public DataTable Validar_IniciarSesionUsuario_FB(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Validar_IniciarSesionUsuario_FB(usuario);

        }

        //Iniciar Sesion Lopet
        public DataTable IniciarSesionLopet(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.IniciarSesionLopet(lopet);

        }

        //Validar Iniciar Sesion Lopet Facebook
        public DataTable Validar_IniciarSesionLopet_FB(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Validar_IniciarSesionLopet_FB(lopet);

        }

        //Actualizar datos de Usuario
        public DataTable Mostrar_datos_Usuario(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Mostrar_datos_Usuario(usuario);

        }

        //Actualizar Usuario
        public int ActualizarUsuario(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.ActualizarUsuario(usuario);

        }

        //Consultar Lopet
        public DataTable ConsultarLopet(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.ConsultarLopet(lopet);

        }

        //Actualizar mi perfil Lopet
        public DataTable Mostrar_mi_perfil_Lopet(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Mostrar_mi_perfil_Lopet(lopet);

        }

        //Actualizar Lopet
        public int ActualizarLopet(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.ActualizarLopet(lopet);

        }

        //Mostrar Contrato
        public DataTable MostrarContratosDueño(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.MostrarContratosDueño(usuario);

        }

        //Mostrar Contrato lOPET
        public DataTable MostrarContratosLopet(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.MostrarContratosLopet(lopet);

        }

        //Mostrar Lopets
        public DataTable Mostrar_Lopets(BEL_Lopet lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Mostrar_Lopets(lopet);

        }

        //Mostrar Dueños
        public DataTable Mostrar_Dueños(BEL_Usuario usuario)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Mostrar_Dueños(usuario);

        }

        //Mostrar Alojamientos
        public DataTable Mostrar_Alojamientos()
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.Mostrar_Alojamientos();

        }

        //Grafica Pie
        public DataTable GraficaEstadoXContrato()
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.GraficaEstadoXContrato();

        }

        //Grafica Monto por contrato
        public DataTable GraficaMontoXContrato()
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.GraficaMontoXContrato();

        }

        //Grafica Monto por contrato
        public DataTable GraficaFechaXCosto()
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.GraficaFechaXCosto();

        }


        //Consultar Lopet
        public DataTable ValidarContrato(int id_user,int id_lopet)
        {
            DAL_Usuario gestionUsuario = new DAL_Usuario();
            return gestionUsuario.ValidarContrato(id_user, id_lopet);

        }
    }
}