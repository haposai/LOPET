using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Lopet.BEL;
namespace Lopet.DAL
{
    public class DAL_Usuario
    {

        //Registrar Usuario
        public int RegistrarUsuario(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_INSERT_USUARIO");
            cmd.Parameters.AddWithValue("@NOMBRES", usuario.UsuNombre.ToString());
            cmd.Parameters.AddWithValue("@APELLIDOS", usuario.UsuApellido.ToString());
            cmd.Parameters.AddWithValue("@CORREO", usuario.UsuCorreo.ToString());
            cmd.Parameters.AddWithValue("@CONTRASENIA", usuario.UsuContrasenia.ToString());
            cmd.Parameters.AddWithValue("@DNI", usuario.UsuDni.ToString());
            cmd.Parameters.AddWithValue("@CELULAR", usuario.UsuCelular.ToString());
            cmd.Parameters.AddWithValue("@FOTO_PERFIL", usuario.UsuFotoPer.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }

        //Registrar Lopet
        public int RegistrarLopet(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_INSERT_LOPET");
            cmd.Parameters.AddWithValue("@NOMBRES", lopet.LopeNombre.ToString());
            cmd.Parameters.AddWithValue("@APELLIDOS", lopet.LopeApellido.ToString());
            cmd.Parameters.AddWithValue("@CORREO", lopet.LopeCorreo.ToString());
            cmd.Parameters.AddWithValue("@CONTRASENIA", lopet.LopeContrasenia.ToString());
            cmd.Parameters.AddWithValue("@DNI", lopet.LopeDni.ToString());
            cmd.Parameters.AddWithValue("@CELULAR", lopet.LopeCelular.ToString());
            cmd.Parameters.AddWithValue("@FOTO_PERFIL", lopet.LopeFotoPer.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }

        //Iniciar sesion Usuario
        public DataTable IniciarSesionUsuario(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_LOGIN_USUARIO");
            cmd.Parameters.AddWithValue("@CORREO", usuario.UsuCorreo.ToString());
            cmd.Parameters.AddWithValue("@CONTRASENIA", usuario.UsuContrasenia.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Validar Iniciar sesion Usuario Facebook
        public DataTable Validar_IniciarSesionUsuario_FB(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_VALIDAR_USUARIO");
            cmd.Parameters.AddWithValue("@DNI", usuario.UsuDni.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Iniciar sesion Lopet
        public DataTable IniciarSesionLopet(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_LOGIN_LOPET");
            cmd.Parameters.AddWithValue("@CORREO", lopet.LopeCorreo.ToString());
            cmd.Parameters.AddWithValue("@CONTRASENIA", lopet.LopeContrasenia.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Validar Iniciar sesion Lopet Facebook
        public DataTable Validar_IniciarSesionLopet_FB(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_VALIDAR_LOPET");
            cmd.Parameters.AddWithValue("@DNI", lopet.LopeCorreo.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Mostrar datos de Usuario
        public DataTable Mostrar_datos_Usuario(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("mostrar_mis_datos");
            cmd.Parameters.AddWithValue("@DNI", usuario.UsuDni.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Actualizar Usuario
        public int ActualizarUsuario(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("actualizar_mis_datos");
            cmd.Parameters.AddWithValue("@NOMBRES", usuario.UsuNombre.ToString());
            cmd.Parameters.AddWithValue("@APELLIDOS", usuario.UsuApellido.ToString());
            cmd.Parameters.AddWithValue("@DNI", usuario.UsuDni.ToString());
            cmd.Parameters.AddWithValue("@CELULAR", usuario.UsuCelular.ToString());
            cmd.Parameters.AddWithValue("@CORREO", usuario.UsuCorreo.ToString());
            cmd.Parameters.AddWithValue("@CLAVE", usuario.UsuContrasenia.ToString());
            cmd.Parameters.AddWithValue("@DISTRITO", usuario.UsuIdDistrito.ToString());
            cmd.Parameters.AddWithValue("@SEXO", usuario.UsuSexo.ToString());
            cmd.Parameters.AddWithValue("@FOTO_PERFIL", usuario.UsuFotoPer.ToString());
            cmd.Parameters.AddWithValue("@FOTO_PORTADA", usuario.UsuFotoPor.ToString());


            return DAL_BD.Execute_Procedure(cmd);
        }

        //Consultar Lopet
        public DataTable ConsultarLopet(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("mostrar_mis_datos_lopet");
            cmd.Parameters.AddWithValue("@NOMBRE", lopet.LopeNombre.ToString());
            cmd.Parameters.AddWithValue("@FOTO", lopet.LopeFotoPer.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Mostrar mi perfil Lopet
        public DataTable Mostrar_mi_perfil_Lopet(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("mostrar_mi_perfil_lopet");
            cmd.Parameters.AddWithValue("@DNI", lopet.LopeDni.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Actualizar Lopet
        public int ActualizarLopet(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("actualizar_mis_datos_lopet");
            cmd.Parameters.AddWithValue("@NOMBRES", lopet.LopeNombre.ToString());
            cmd.Parameters.AddWithValue("@APELLIDOS", lopet.LopeApellido.ToString());
            cmd.Parameters.AddWithValue("@CELULAR", lopet.LopeCelular.ToString());
            cmd.Parameters.AddWithValue("@CORREO", lopet.LopeCorreo.ToString());
            cmd.Parameters.AddWithValue("@DISTRITO", lopet.LopeIdDistrito.ToString());
            cmd.Parameters.AddWithValue("@CLAVE", lopet.LopeContrasenia.ToString());
            cmd.Parameters.AddWithValue("@FOTO_PERFIL", lopet.LopeFotoPer.ToString());
            cmd.Parameters.AddWithValue("@FOTO_PORTADA", lopet.LopeFotoPor.ToString());
            cmd.Parameters.AddWithValue("@SERVICIO", lopet.LopetServicio.ToString());
            cmd.Parameters.AddWithValue("@SEXO", lopet.LopeSexo.ToString());
            cmd.Parameters.AddWithValue("@DESCRIPCCION", lopet.LopeDes.ToString());
            cmd.Parameters.AddWithValue("@PRECIO", lopet.LopetPrecio.ToString());
            cmd.Parameters.AddWithValue("@DNI", lopet.LopeDni.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }

        //Mostrar Contratos Dueño
        public DataTable MostrarContratosDueño(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("mostrar_mis_contratos");
            cmd.Parameters.AddWithValue("@ID", usuario.UsuID.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Mostrar Contratos Lopet
        public DataTable MostrarContratosLopet(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("mostrar_mis_contratos_lopet");
            cmd.Parameters.AddWithValue("@ID", lopet.LopetID.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Mostrar Lopet
        public DataTable Mostrar_Lopets(BEL_Lopet lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("adm_mostrar_Lopets");

            return DAL_BD.Select_Procedure(cmd);
        }

        //Mostrar Dueño
        public DataTable Mostrar_Dueños(BEL_Usuario usuario)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("adm_mostrar_Dueños");

            return DAL_BD.Select_Procedure(cmd);
        }

        //Mostrar Alojamientos
        public DataTable Mostrar_Alojamientos()
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("adm_mostrar_Alojamientos");

            return DAL_BD.Select_Procedure(cmd);
        }

        //Grafica
        public DataTable GraficaEstadoXContrato()
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("ADM_GRAFICA_ESTADO_X_REGISTROS");

            return DAL_BD.Select_Procedure(cmd);
        }

        //Grafica
        public DataTable GraficaMontoXContrato()
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("ADM_GRAFICA_ESTADO_X_COSTO");

            return DAL_BD.Select_Procedure(cmd);
        }

        //Grafica
        public DataTable GraficaFechaXCosto()
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("ADM_GRAFICA_FECHA_X_COSTO");

            return DAL_BD.Select_Procedure(cmd);
        }

        //Consultar Lopet
        public DataTable ValidarContrato(int id_user,int id_lopet)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("validar_contrato");
            cmd.Parameters.AddWithValue("@ID_USER", id_user.ToString());
            cmd.Parameters.AddWithValue("@ID_LOPET", id_lopet.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }
    }
}