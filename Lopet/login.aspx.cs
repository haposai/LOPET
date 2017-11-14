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
    public partial class login : System.Web.UI.Page
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

                    if (correo==null || url_foto==null || user_name==null)
                    {
                        correo = "-";
                        url_foto = "vacio.jpg";
                        user_name = "-";
                    }


                    DataTable dtU = new DataTable();

                    BEL_Usuario user = new BEL_Usuario();
                    user.UsuNombre = nombre;
                    user.UsuApellido = user_name;
                    user.UsuCorreo = correo;
                    user.UsuContrasenia = "-";
                    user.UsuCelular = 0;
                    user.UsuDni = iduser;
                    user.UsuFotoPer = faceBookUser.PictureUrl; 



                    //Se valida si existe el usuario
                    dtU = usuario.Validar_IniciarSesionUsuario_FB(user);

                    if (dtU.Rows.Count > 0)
                    {
                        //Usuario Existe
                        Session["ID"] = iduser;
                        Session["Nombre"] = nombre;
                        Session["Apellido"] = user_name;
                        Session["Correo"] = correo;
                        Session["Foto_Perfil"] = faceBookUser.PictureUrl;
                        Session["DNI"] = iduser;
                        Session["Tipo"] = "Dueño";

                        Response.Redirect("~/Dueno/inicio.aspx");
                    }
                    else
                    {
                        //Se registra al usuario la primera vez
                        int rpta = usuario.RegistrarUsuario(user);
                        if (rpta == 1)
                        {
                            Session["ID"] = iduser;
                            Session["Nombre"] = nombre;
                            Session["Apellido"] = user_name;
                            Session["Correo"] = correo;
                            Session["Foto_Perfil"] = faceBookUser.PictureUrl;
                            Session["DNI"] = iduser;
                            Session["Tipo"] = "Dueño";

                            Response.Redirect("~/Dueno/inicio.aspx");

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

            BEL_Usuario user = new BEL_Usuario();
            user.UsuCorreo = txt_correo.Text;
            user.UsuContrasenia = txt_con.Text;

            dtU = usuario.IniciarSesionUsuario(user);

            if (dtU.Rows.Count > 0)
            {
                //Es Dueño
                Session["ID"] = dtU.Rows[0][0].ToString();
                Session["Nombre"] = dtU.Rows[0][1].ToString();
                Session["Apellido"] = dtU.Rows[0][2].ToString();
                Session["Correo"] = dtU.Rows[0][3].ToString();
                Session["Clave"] = dtU.Rows[0][4].ToString();
                Session["Foto_Perfil"] = dtU.Rows[0][5].ToString();
                Session["Foto_Portada"] = dtU.Rows[0][6].ToString();
                Session["DNI"] = dtU.Rows[0][7].ToString();
                Session["Celular"] = dtU.Rows[0][8].ToString();
                Session["Distrito"] = dtU.Rows[0][9].ToString();
                Session["Tipo"] = dtU.Rows[0][10].ToString();

                Response.Redirect("~/Dueno/inicio.aspx");
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