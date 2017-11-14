using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Lopet.BEL;
using Lopet.BLL;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;

namespace Lopet.Admin
{
    public partial class Registrar_Lopet : System.Web.UI.Page
    {
        BLL_Usuario usuario = new BLL_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "" || txt_apellido.Text == "" || txt_dni.Text == "" || txt_celular.Text == "" || txt_correo.Text == "" || txt_con.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_campos();", true);
            }
            else
            {
                DataTable dtU = new DataTable();

                BEL_Lopet user = new BEL_Lopet();
                user.LopeNombre = txt_nombre.Text.Trim();
                user.LopeApellido = txt_apellido.Text.Trim();
                user.LopeCorreo = txt_correo.Text.Trim();
                user.LopeContrasenia = txt_con.Text.Trim();
                user.LopeCelular = Convert.ToInt32(txt_celular.Text.Trim());
                user.LopeDni = txt_dni.Text.Trim();
                user.LopeFotoPer = "vacio.jpg";

                dtU = usuario.Validar_IniciarSesionLopet_FB(user);

                if (dtU.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_usuario();", true);
                }
                else
                {
                    int rpta = usuario.RegistrarLopet(user);
                    if (rpta == -1 || rpta == 1)
                    {
                        Response.Redirect("Lopets.aspx");
                        //lbl_msj.Visible = true;

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "error_usuario();", true);

                    }
                }




            }
        }
    }
}