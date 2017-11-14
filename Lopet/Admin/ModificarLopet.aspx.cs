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
    public partial class ModificarLopet : System.Web.UI.Page
    {
        BLL_Usuario usuario = new BLL_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtU = new DataTable();
                BEL_Lopet user = new BEL_Lopet();
                user.LopeDni = Session["LOPET_DNI"] as string;
                dtU = usuario.Mostrar_mi_perfil_Lopet(user);
                if (dtU.Rows.Count > 0)
                {
                    Session["LOPET_ID"] = dtU.Rows[0][0].ToString();
                    Session["LOPET_Nombre"] = dtU.Rows[0][1].ToString();
                    Session["LOPET_Apellido"] = dtU.Rows[0][2].ToString();
                    Session["LOPET_DNI"] = dtU.Rows[0][3].ToString();
                    Session["LOPET_Celular"] = dtU.Rows[0][4].ToString();
                    Session["LOPET_Correo"] = dtU.Rows[0][5].ToString();
                    Session["LOPET_Distrito"] = dtU.Rows[0][6].ToString();
                    Session["LOPET_Clave"] = dtU.Rows[0][7].ToString();
                    Session["LOPET_Foto_Perfil"] = dtU.Rows[0][8].ToString();
                    Session["LOPET_Foto_Portada"] = dtU.Rows[0][9].ToString();
                    Session["LOPET_Sexo"] = dtU.Rows[0][10].ToString();

                    Session["LOPET_Descripcion"] = dtU.Rows[0][11].ToString();
                    Session["LOPET_Precio"] = dtU.Rows[0][12].ToString();
                    Session["LOPET_Servicio"] = dtU.Rows[0][13].ToString();
                }

                txt_nombre.Text = Session["LOPET_Nombre"] as string;
                txt_apellido.Text = Session["LOPET_Apellido"] as string;
                txt_dni.Text = Session["LOPET_DNI"] as string;
                txt_celular.Text = Session["LOPET_Celular"] as string;
                txt_correo.Text = Session["LOPET_Correo"] as string;
                txt_precio.Text = Session["LOPET_Precio"] as string;
                txt_des.Text = Session["LOPET_Descripcion"] as string;
                string distrito = Session["LOPET_Distrito"] as string;
                string servicio = Session["LOPET_Servicio"] as string;
                if (distrito == "La Molina")
                {
                    ddl_distrito2.SelectedIndex = 1;
                }
                else
                {
                    ddl_distrito2.SelectedIndex = 0;
                }

                if (servicio == "Paseador")
                {
                    ddl_servicio.SelectedIndex = 1;
                }
                else if (servicio == "Cuidador")
                {
                    ddl_servicio.SelectedIndex = 2;
                }
                else
                {
                    ddl_servicio.SelectedIndex = 0;
                }

                string clave = Session["LOPET_Clave"] as string;
                txt_con.Text = Encriptar(clave);
                //txt_con.TextMode = TextBoxMode.Password;
                ddl_sexo.Text = Session["LOPET_Sexo"] as string;

            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            BEL_Lopet user = new BEL_Lopet();
            user.LopeNombre = txt_nombre.Text.Trim();
            user.LopeApellido = txt_apellido.Text.Trim();
            user.LopeDni = txt_dni.Text.Trim();
            user.LopeCelular = Convert.ToInt32(txt_celular.Text.Trim());
            user.LopeCorreo = txt_correo.Text.Trim();
            user.LopeContrasenia = DesEncriptar(txt_con.Text.Trim());
            user.LopeIdDistrito = Convert.ToInt32(ddl_distrito2.SelectedValue);
            user.LopeSexo = ddl_sexo.Text;
            user.LopeDes = txt_des.Text.Trim();
            user.LopetPrecio = Convert.ToDecimal(txt_precio.Text.Trim());
            user.LopetServicio = Convert.ToInt32(ddl_servicio.SelectedValue);
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
                    user.LopeFotoPer = fp_perfil.FileName;
                }

            }
            else
            {
                user.LopeFotoPer = Session["LOPET_Foto_Perfil"] as string;
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
                    user.LopeFotoPor = fp_portada.FileName;
                }
            }
            else
            {
                user.LopeFotoPor = Session["LOPET_Foto_Portada"] as string;
            }



            int rpta = usuario.ActualizarLopet(user);
            if (rpta == -1 || rpta == 1)
            {
                Response.Redirect("Lopets.aspx");
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