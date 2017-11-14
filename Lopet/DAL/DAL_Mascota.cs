using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Lopet.BEL;

namespace Lopet.DAL
{
    public class DAL_Mascota
    {
        //Registrar Usuario
        public int RegistrarMascota(BEL_Mascota mascota)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_INSERT_MASCOTA");
            cmd.Parameters.AddWithValue("@ID_USER", mascota.UsuID.ToString());
            cmd.Parameters.AddWithValue("@NOMBRE", mascota.MasNombre.ToString());
            cmd.Parameters.AddWithValue("@TIPO", mascota.MasTipo.ToString());
            cmd.Parameters.AddWithValue("@EDAD", mascota.MasEdad.ToString());
            cmd.Parameters.AddWithValue("@RAZA", mascota.MasRaza.ToString());
            cmd.Parameters.AddWithValue("@FOTO", mascota.MasFotoPer.ToString());
            cmd.Parameters.AddWithValue("@ID_CONTRATO", mascota.MasIdContrato.ToString());
            cmd.Parameters.AddWithValue("@DISCAPACIDAD", mascota.MasDiscapacidad.ToString());
            cmd.Parameters.AddWithValue("@SEXO", mascota.MasSexo.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }

        //Eliminar Mascota
        public int EliminarMascota(BEL_Mascota mascota)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_DELETE_MASCOTA");
            cmd.Parameters.AddWithValue("@ID_USER", mascota.UsuID.ToString());
            cmd.Parameters.AddWithValue("@NOMBRE", mascota.MasNombre.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }

        //Buscar Mascota
        public DataTable ConsultarMascota(BEL_Mascota mascota)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("mostrar_mis_mascotas_update");
            cmd.Parameters.AddWithValue("@ID_USER", mascota.UsuID.ToString());
            cmd.Parameters.AddWithValue("@NOMBRE", mascota.MasNombre.ToString());

            return DAL_BD.Select_Procedure(cmd);
        }

        //Eliminar Mascota
        public int EditarMascota(BEL_Mascota mascota)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_UPDATE_MASCOTA");
            cmd.Parameters.AddWithValue("@ID_USER", mascota.UsuID.ToString());
            cmd.Parameters.AddWithValue("@ID_MASCOTA", mascota.MasID.ToString());
            cmd.Parameters.AddWithValue("@NOMBRE", mascota.MasNombre.ToString());
            cmd.Parameters.AddWithValue("@TIPO", mascota.MasTipo.ToString());
            cmd.Parameters.AddWithValue("@EDAD", mascota.MasEdad.ToString());
            cmd.Parameters.AddWithValue("@RAZA", mascota.MasRaza.ToString());
            cmd.Parameters.AddWithValue("@FOTO", mascota.MasFotoPer.ToString());
            cmd.Parameters.AddWithValue("@ID_CONTRATO", mascota.MasIdContrato.ToString());
            cmd.Parameters.AddWithValue("@DISCAPACIDAD", mascota.MasDiscapacidad.ToString());
            cmd.Parameters.AddWithValue("@SEXO", mascota.MasSexo.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }
    }
}