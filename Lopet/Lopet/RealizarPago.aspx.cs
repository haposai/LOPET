using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lopet.Lopet
{
    public partial class RealizarPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_pago_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cn.Open();

            string query;
            int id_lopet = Convert.ToInt32(Session["ID"] as string);

            query = string.Format("declare @id int set @id=(select max(id_pago)+1 from pago)  insert into pago (id_pago,id_lopet,fecha,importe) values(@id,'" + id_lopet + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + 30 + "' )");


            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            Response.Redirect("MisPagos.aspx");
        }
    }
}