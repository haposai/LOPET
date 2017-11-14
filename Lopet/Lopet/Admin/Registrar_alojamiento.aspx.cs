using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lopet.Admin
{
    public partial class Registrar_alojamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cn.Open();

            string query;

            query = string.Format("declare @id int set @id=(select max(id_aloj)+1 from Alojamiento)  insert into Alojamiento (id_aloj,nombre,direccion,latitud,longitud,telefono,estado) values(@id,'" + txt_nombre.Text + "','" + txt_direccion.Text + "'," + txt_latitud.Text + "," + txt_longitud.Text + "," + txt_telefono.Text + ",'" + ddl_estado.Text + "' )");


            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            Response.Redirect("Alojamientos.aspx");
        }
    }
}