using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lopet.BEL;
using Lopet.BLL;
using System.IO;
using System.Data;

namespace Lopet.Admin
{
    public partial class ModificarDueño : System.Web.UI.Page
    {
        BLL_Usuario usuario = new BLL_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtU = new DataTable();
                BEL_Usuario user = new BEL_Usuario();
                user.UsuDni = Session["DUEÑO_ID"] as string;
                dtU = usuario.Mostrar_datos_Usuario(user);
                if (dtU.Rows.Count > 0)
                {
                    Session["DUEÑO_ID"] = dtU.Rows[0][0].ToString();
                    Session["DUEÑO_Nombre"] = dtU.Rows[0][1].ToString();
                    Session["DUEÑO_Apellido"] = dtU.Rows[0][2].ToString();
                    Session["DUEÑO_DNI"] = dtU.Rows[0][3].ToString();
                    Session["DUEÑO_Celular"] = dtU.Rows[0][4].ToString();
                    Session["DUEÑO_Correo"] = dtU.Rows[0][5].ToString();
                    Session["DUEÑO_Distrito"] = dtU.Rows[0][6].ToString();
                    Session["DUEÑO_Clave"] = dtU.Rows[0][7].ToString();
                    Session["DUEÑO_Foto_Perfil"] = dtU.Rows[0][8].ToString();
                    Session["DUEÑO_Foto_Portada"] = dtU.Rows[0][9].ToString();
                    Session["DUEÑO_Sexo"] = dtU.Rows[0][10].ToString();
                }

                txt_nombre.Text = Session["DUEÑO_Nombre"] as string;
                txt_apellido.Text = Session["DUEÑO_Apellido"] as string;
                txt_dni.Text = Session["DUEÑO_DNI"] as string;
                txt_celular.Text = Session["DUEÑO_Celular"] as string;
                txt_correo.Text = Session["DUEÑO_Correo"] as string;
                string distrito = Session["DUEÑO_Distrito"] as string;
                if (distrito == "La Molina")
                {
                    ddl_distrito2.SelectedIndex = 1;
                }
                else
                {
                    ddl_distrito2.SelectedIndex = 0;
                }

                string clave = Session["DUEÑO_Clave"] as string;
                txt_con.Text = Encriptar(clave);
                //txt_con.TextMode = TextBoxMode.Password;
                ddl_sexo.Text = Session["DUEÑO_Sexo"] as string;

            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            BEL_Usuario user = new BEL_Usuario();
            user.UsuNombre = txt_nombre.Text.Trim();
            user.UsuApellido = txt_apellido.Text.Trim();
            user.UsuDni = txt_dni.Text.Trim();
            user.UsuCelular = Convert.ToInt32(txt_celular.Text.Trim());
            user.UsuCorreo = txt_correo.Text.Trim();
            user.UsuContrasenia = DesEncriptar(txt_con.Text.Trim());
            user.UsuIdDistrito = Convert.ToInt32(ddl_distrito2.SelectedValue);
            user.UsuSexo = ddl_sexo.Text;
            if (fp_perfil.HasFile)
            {
                string ext = fp_perfil.PostedFile.FileName;
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                string[] formatos =
                new string[] { "jpg", "jpeg", "bmp", "png", "gif" };

                if (Array.IndexOf(formatos, ext) < 0)
                {
                    //formato no valido
                }
                else
                {
                    GuardarArchivo(fp_perfil, 1);
                    user.UsuFotoPer = fp_perfil.FileName;
                }

            }
            else
            {
                user.UsuFotoPer = Session["DUEÑO_Foto_Perfil"] as string;
            }
            if (fp_portada.HasFile)
            {
                string ext = fp_portada.PostedFile.FileName;
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                string[] formatos =
                new string[] { "jpg", "jpeg", "bmp", "png", "gif" };

                if (Array.IndexOf(formatos, ext) < 0)
                {
                    //formato no valido
                }
                else
                {
                    GuardarArchivo(fp_portada, 2);
                    user.UsuFotoPor = fp_portada.FileName;
                }
            }
            else
            {
                user.UsuFotoPor = Session["DUEÑO_Foto_Portada"] as string;
            }



            int rpta = usuario.ActualizarUsuario(user);
            if (rpta == -1 || rpta == 1)
            {
                Response.Redirect("Dueños.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_update_error();", true);
            }
        }
        private void GuardarArchivo(FileUpload file, int tipo_foto)
        {
            string ruta = null;
            if (tipo_foto == 1)
            {
                // Se carga la ruta física de la carpeta temp del sitio
                ruta = Server.MapPath("~/perfil");
            }
            else
            {
                // Se carga la ruta física de la carpeta temp del sitio
                ruta = Server.MapPath("~/portada");
            }


            // Si el directorio no existe, crearlo
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

            // Verificar que el archivo no exista
            if (File.Exists(archivo))
            {
                //foto ya existe
            }
            else
            {
                file.SaveAs(archivo);
            }
        }

        /// Encripta una cadena
        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}