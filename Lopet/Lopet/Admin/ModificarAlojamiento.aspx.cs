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
    public partial class ModificarAlojamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_id.Text = Session["ID_ALOJ"] as string;
                txt_nombre.Text = Session["NOMBRE_ALOJ"] as string;
                txt_direccion.Text = Session["DIRECCION_ALOJ"] as string;
                txt_latitud.Text = Session["LATITUD_ALOJ"] as string;
                txt_longitud.Text = Session["LONGITUD_ALOJ"] as string;
                txt_telefono.Text = Session["TELEFONO_ALOJ"] as string;
                ddl_estado.Text = Session["ESTADO_ALOJ"] as string;
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cn.Open();

            string query;

            query = string.Format("update Alojamiento set nombre='" + txt_nombre.Text + "',direccion='"+ txt_direccion.Text + "',latitud=" + txt_latitud.Text + ",longitud=" + txt_longitud.Text + ",telefono=" + txt_telefono.Text + ",estado='" + ddl_estado.Text + "' where id_aloj=" + txt_id.Text);


            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            Response.Redirect("Alojamientos.aspx");
        }
    }
}