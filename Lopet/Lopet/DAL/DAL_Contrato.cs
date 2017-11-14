using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Lopet.BEL;

namespace Lopet.DAL
{
    public class DAL_Contrato
    {
        //Registrar Usuario
        public int RegistrarContrato(BEL_Contrato contrato)
        {
            SqlCommand cmd = DAL_BD.Create_Command_Procedure("SP_INSERT_CONTRATO");
            cmd.Parameters.AddWithValue("@ID_USER", contrato.UsuID.ToString());
            cmd.Parameters.AddWithValue("@ID_LOPET", contrato.LopetID.ToString());
            cmd.Parameters.AddWithValue("@FECHA_INICIO", contrato.Fecha_inicio.ToString());
            cmd.Parameters.AddWithValue("@FECHA_FIN", contrato.Fecha_fin.ToString());
            cmd.Parameters.AddWithValue("@COSTO", contrato.CostoTotal.ToString());
            cmd.Parameters.AddWithValue("@ESTADO", contrato.Estado.ToString());
            cmd.Parameters.AddWithValue("@CANT_MASCOTAS", contrato.Cant_Mascotas.ToString());
            cmd.Parameters.AddWithValue("@CANT_DIAS", contrato.Cant_Dias.ToString());

            return DAL_BD.Execute_Procedure(cmd);
        }
    }
}