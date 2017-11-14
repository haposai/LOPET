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
    public partial class Registrar_Dueño : System.Web.UI.Page
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

                BEL_Usuario user = new BEL_Usuario();
                user.UsuNombre = txt_nombre.Text.Trim();
                user.UsuApellido = txt_apellido.Text.Trim();
                user.UsuCorreo = txt_correo.Text.Trim();
                user.UsuContrasenia = txt_con.Text.Trim();
                user.UsuCelular = Convert.ToInt32(txt_celular.Text.Trim());
                user.UsuDni = txt_dni.Text.Trim();
                user.UsuFotoPer = "vacio.jpg";

                dtU = usuario.Validar_IniciarSesionUsuario_FB(user);

                if (dtU.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_usuario();", true);
                }
                else
                {
                    int rpta = usuario.RegistrarUsuario(user);
                    if (rpta == -1 || rpta == 1)
                    {
                        Response.Redirect("Dueños.aspx");
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