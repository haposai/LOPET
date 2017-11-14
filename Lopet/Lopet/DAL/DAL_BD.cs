using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;

namespace Lopet.DAL
{
    public class DAL_BD
    {
        public static SqlConnection con;

        public static SqlConnection Get_Conexion()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            return con;
        }

        public static SqlCommand Create_Command_Procedure(String proc)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand command = new SqlCommand(proc, con);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        public static int Execute_Procedure(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                command.Connection.Dispose();
                command.Connection.Close();
                con.Close();
            }
        }

        public static DataTable Select_Procedure(SqlCommand command)
        {

            DataTable ds = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            try
            {
                command.Connection.Open();
                adaptador.SelectCommand = command;
                adaptador.Fill(ds);
                return ds;
            }
            catch
            {
                command.Connection.Close();
                command.Connection.Dispose();
                return null;
            }
            finally
            {

            }
        }
    }
}