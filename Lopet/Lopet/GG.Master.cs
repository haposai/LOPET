using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lopet.BEL;
using Lopet.BLL;
using System.Data;

namespace Lopet.Lopet
{
    public partial class GG : System.Web.UI.MasterPage
    {
        string nombre = null;
        string id = null;
        string foto_perfil = null;
        string foto = null;
        string dni = null;
        BLL_Usuario usuario = new BLL_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nombre = Session["Nombre"] as string;
                id = Session["ID"] as string;
                dni = Session["DNI"] as string;

                DataTable dtU = new DataTable();
                BEL_Lopet user = new BEL_Lopet();
                user.LopeDni = dni;
                dtU = usuario.Mostrar_mi_perfil_Lopet(user);
                if (dtU.Rows.Count > 0)
                {
                    Session["ID"] = dtU.Rows[0][0].ToString();
                    Session["Nombre"] = dtU.Rows[0][1].ToString();
                    Session["Apellido"] = dtU.Rows[0][2].ToString();
                    Session["DNI"] = dtU.Rows[0][3].ToString();
                    Session["Celular"] = dtU.Rows[0][4].ToString();
                    Session["Correo"] = dtU.Rows[0][5].ToString();
                    Session["Distrito"] = dtU.Rows[0][6].ToString();
                    Session["Clave"] = dtU.Rows[0][7].ToString();
                    Session["Foto_Perfil"] = dtU.Rows[0][8].ToString();
                    Session["Foto_Portada"] = dtU.Rows[0][9].ToString();
                    Session["Sexo"] = dtU.Rows[0][10].ToString();

                    Session["Descripcion"] = dtU.Rows[0][11].ToString();
                    Session["Precio"] = dtU.Rows[0][12].ToString();
                    Session["Servicio"] = dtU.Rows[0][13].ToString();
                }
                foto_perfil = Session["Foto_Perfil"] as string;
                string foto_portada = Session["Foto_Portada"] as string;
                img_portada.ImageUrl = "~/portada/" + foto_portada;
                img_portada2.ImageUrl = "~/portada/" + foto_portada;

                if (foto_perfil != null)
                {
                    foto = foto_perfil.Substring(0, 5);
                }

                if (foto == "https")
                {
                    img_per.ImageUrl = foto_perfil;
                }
                else
                {
                    img_per.ImageUrl = "~/perfil/" + foto_perfil;
                }

                if (nombre != null)
                {
                    lbl_nombre.Text = nombre;
                }
                else
                {
                    lbl_nombre.Text = "-";
                }

            }
        }
    }
}