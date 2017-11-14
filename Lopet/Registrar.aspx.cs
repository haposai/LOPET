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
    public partial class Registrar : System.Web.UI.Page
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

                    if (chk_lopet.Checked == false)
                    {
                        DataTable dtU = new DataTable();

                        BEL_Usuario user = new BEL_Usuario();
                        user.UsuNombre = nombre;
                        user.UsuApellido = user_name;
                        user.UsuCorreo = correo;
                        user.UsuContrasenia = "-";
                        user.UsuCelular = 0;
                        user.UsuDni = iduser;
                        user.UsuFotoPer = url_foto;



                        //Se valida si existe el usuario
                        dtU = usuario.Validar_IniciarSesionUsuario_FB(user);

                        if (dtU.Rows.Count > 0)
                        {
                            //Usuario Existe
                            Session["ID"] = iduser;
                            Session["Nombre"] = nombre;
                            Session["Apellido"] = user_name;
                            Session["Correo"] = correo;
                            Session["Foto_Perfil"] = url_foto;
                            Session["DNI"] = iduser;
                            Session["Tipo"] = "3";
                            Response.Redirect("~/Dueño/inicio.aspx");
                        }
                        else
                        {
                            //Se registra al usuario la primera vez
                            int rpta = usuario.RegistrarUsuario(user);
                            if (rpta == -1 || rpta == 1)
                            {
                                Session["ID"] = iduser;
                                Session["Nombre"] = nombre;
                                Session["Apellido"] = user_name;
                                Session["Correo"] = correo;
                                Session["Foto_Perfil"] = url_foto;
                                Session["DNI"] = iduser;
                                Session["Tipo"] = "3";

                                Response.Redirect("~/Dueño/inicio.aspx");

                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "error_usuario();", true);
                            }
                        }
                    }
                    else
                    {
                        DataTable dtL = new DataTable();

                        BEL_Lopet user = new BEL_Lopet();
                        user.LopeNombre = nombre;
                        user.LopeApellido = user_name;
                        user.LopeCorreo = correo;
                        user.LopeContrasenia = "-";
                        user.LopeCelular = 0;
                        user.LopeDni = iduser;
                        user.LopeFotoPer = url_foto;


                        //Se valida si existe el usuario
                        dtL = usuario.Validar_IniciarSesionLopet_FB(user);

                        if (dtL.Rows.Count > 0)
                        {
                            //Usuario Existe
                            Session["ID"] = iduser;
                            Session["Nombre"] = nombre;
                            Session["Apellido"] = user_name;
                            Session["Correo"] = correo;
                            Session["Foto_Perfil"] = url_foto;
                            Session["DNI"] = iduser;
                            Session["Tipo"] = "2";
                            Response.Redirect("inicio.aspx");
                        }
                        else
                        {
                            //Se registra al usuario la primera vez
                            int rpta = usuario.RegistrarLopet(user);
                            if (rpta == -1 || rpta == 1)
                            {
                                Session["ID"] = iduser;
                                Session["Nombre"] = nombre;
                                Session["Apellido"] = user_name;
                                Session["Correo"] = correo;
                                Session["Foto_Perfil"] = url_foto;
                                Session["DNI"] = iduser;
                                Session["Tipo"] = "2";

                                Response.Redirect("inicio.aspx");

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
        protected void btn_reg_Click(object sender, EventArgs e)
        {
            if(txt_nom_reg.Text=="" || txt_ape_reg.Text == "" || txt_dni_reg.Text=="" || txt_cel_reg.Text == "" || txt_correo_reg.Text == "" || txt_con_reg.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_campos();", true);
            }
            else
            {
                if (chk_lopet.Checked == false)
                {
                    DataTable dtL = new DataTable();
                    DataTable dtU = new DataTable();

                    BEL_Usuario user = new BEL_Usuario();
                    user.UsuNombre = txt_nom_reg.Text.Trim();
                    user.UsuApellido = txt_ape_reg.Text.Trim();
                    user.UsuCorreo = txt_correo_reg.Text.Trim();
                    user.UsuContrasenia = txt_con_reg.Text.Trim();
                    user.UsuCelular = Convert.ToInt32(txt_cel_reg.Text.Trim());
                    user.UsuDni = txt_dni_reg.Text.Trim();
                    user.UsuFotoPer = "vacio.jpg";

                    BEL_Lopet lopet = new BEL_Lopet();
                    lopet.LopeNombre = txt_nom_reg.Text.Trim();
                    lopet.LopeApellido = txt_ape_reg.Text.Trim();
                    lopet.LopeCorreo = txt_correo_reg.Text.Trim();
                    lopet.LopeContrasenia = txt_con_reg.Text.Trim();
                    lopet.LopeCelular = Convert.ToInt32(txt_cel_reg.Text.Trim());
                    lopet.LopeDni = txt_dni_reg.Text.Trim();
                    lopet.LopeFotoPer = "vacio.jpg";

                    dtU = usuario.Validar_IniciarSesionUsuario_FB(user);
                    dtL = usuario.Validar_IniciarSesionLopet_FB(lopet);

                    if (dtU.Rows.Count > 0 || dtL.Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_usuario();", true);
                    }
                    else
                    {
                        int rpta = usuario.RegistrarUsuario(user);
                        if (rpta == -1 || rpta == 1)
                        {
                            Response.Redirect("login.aspx");
                            //lbl_msj.Visible = true;

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "error_usuario();", true);

                        }
                    }


                }
                else
                {
                    BEL_Lopet lopet = new BEL_Lopet();
                    lopet.LopeNombre = txt_nom_reg.Text.Trim();
                    lopet.LopeApellido = txt_ape_reg.Text.Trim();
                    lopet.LopeCorreo = txt_correo_reg.Text.Trim();
                    lopet.LopeContrasenia = txt_con_reg.Text.Trim();
                    lopet.LopeCelular = Convert.ToInt32(txt_cel_reg.Text.Trim());
                    lopet.LopeDni = txt_dni_reg.Text.Trim();
                    lopet.LopeFotoPer = "vacio.jpg";

                    int rpta = usuario.RegistrarLopet(lopet);
                    if (rpta == -1 || rpta == 1)
                    {
                        Response.Redirect("inicio.aspx");
                        //lbl_msj.Visible = true;

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "error_usuario();", true);
                        //lbl_msj.Visible = true;

                    }
                }
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