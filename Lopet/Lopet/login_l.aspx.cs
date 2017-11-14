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

namespace Lopet
{
    public partial class login_l : System.Web.UI.Page
    {
        BLL_Usuario usuario = new BLL_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            FaceBookConnect.API_Key = "460240781009362";
            FaceBookConnect.API_Secret = "64816eb81eb1a926324f19825e6e8f5f";
            if (!IsPostBack)
            {
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                    return;
                }

                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    //Datos de Fcebook
                    string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                    string iduser = faceBookUser.Id;
                    string url_foto = faceBookUser.PictureUrl;
                    string nombre = faceBookUser.Name;
                    string user_name = faceBookUser.UserName;
                    string correo = faceBookUser.Email;

                    if (correo == null || url_foto == null || user_name == null)
                    {
                        correo = "-";
                        url_foto = "vacio.jpg";
                        user_name = "-";
                    }


                    DataTable dtU = new DataTable();

                    BEL_Lopet user = new BEL_Lopet();
                    user.LopeNombre = nombre;
                    user.LopeApellido = user_name;
                    user.LopeCorreo = correo;
                    user.LopeContrasenia = "-";
                    user.LopeCelular = 0;
                    user.LopeDni = iduser;
                    user.LopeFotoPer = faceBookUser.PictureUrl;


                    //Se valida si existe el usuario
                    dtU = usuario.Validar_IniciarSesionLopet_FB(user);

                    if (dtU.Rows.Count > 0)
                    {
                        //Usuario Existe
                        Session["ID"] = iduser;
                        Session["Nombre"] = nombre;
                        Session["Apellido"] = user_name;
                        Session["Correo"] = correo;
                        Session["Foto_Perfil"] = faceBookUser.PictureUrl;
                        Session["DNI"] = iduser;
                        Session["Tipo"] = "Lopet";
                    }
                    else
                    {
                        //Se registra al usuario la primera vez
                        int rpta = usuario.RegistrarLopet(user);
                        if (rpta == 1)
                        {
                            Session["ID"] = iduser;
                            Session["Nombre"] = nombre;
                            Session["Apellido"] = user_name;
                            Session["Correo"] = correo;
                            Session["Foto_Perfil"] = faceBookUser.PictureUrl;
                            Session["DNI"] = iduser;
                            Session["Tipo"] = "3";

                            Response.Redirect("inicio.aspx");

                        }
                        else
                        {

                        }
                    }


                }
            }
        }

        protected void btn_ingresar_Click(object sender, EventArgs e)
        {
            DataTable dtL = new DataTable();
            DataTable dtU = new DataTable();

            BEL_Lopet user = new BEL_Lopet();
            user.LopeCorreo = txt_correo.Text;
            user.LopeContrasenia = txt_con.Text;

            dtL = usuario.IniciarSesionLopet(user);

            if (dtL.Rows.Count > 0)
            {
                //Es Dueño
                Session["ID"] = dtL.Rows[0][0].ToString();
                Session["Nombre"] = dtL.Rows[0][1].ToString();
                Session["Apellido"] = dtL.Rows[0][2].ToString();
                Session["DNI"] = dtL.Rows[0][3].ToString();
                Session["Celular"] = dtL.Rows[0][4].ToString();
                Session["Correo"] = dtL.Rows[0][5].ToString();
                Session["Tipo"] = dtL.Rows[0][6].ToString();
                Session["Distrito"] = dtL.Rows[0][7].ToString();
                Session["Clave"] = dtL.Rows[0][8].ToString();
                Session["Reputacion"] = dtL.Rows[0][9].ToString();
                Session["Foto_Perfil"] = dtL.Rows[0][10].ToString();
                Session["Foto_Portada"] = dtL.Rows[0][11].ToString();
                // Session["Servicio"] = dtL.Rows[0][12].ToString();
                Response.Redirect("~/Lopet/perfil.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_usuario();", true);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
        }

        public class FaceBookUser
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string UserName { get; set; }
            public string PictureUrl { get; set; }
            public string Email { get; set; }
        }
    }
}