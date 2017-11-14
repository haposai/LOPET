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
using System.Data.SqlClient;
using System.Configuration;


namespace Lopet.Dueno
{
    public partial class Editarmascota : System.Web.UI.Page
    {
        BLL_Mascota mascota = new BLL_Mascota();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarRazas();

                string accion = Request.QueryString["accion"];
                string nombre = Request.QueryString["nombreM"];
                if (accion=="2")
                {
                    BEL_Mascota mas = new BEL_Mascota();
                    string idUser = Session["ID"] as string;
                    mas.UsuID = Convert.ToInt32(idUser);
                    mas.MasNombre = nombre;

                    int rpta = mascota.EliminarMascota(mas);
                    if (rpta == -1 || rpta == 1)
                    {
                        Response.Redirect("/Dueno/misMascotas.aspx");
                        //lbl_msj.Visible = true;

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_update_error();", true);

                    }
                }
                else
                {
                    DataTable dtM = new DataTable();
                    BEL_Mascota mas = new BEL_Mascota();
                    string idUser = Session["ID"] as string;
                    mas.UsuID = Convert.ToInt32(idUser);
                    mas.MasNombre = nombre;

                    dtM = mascota.ConsultarMascota(mas);
                    if(dtM.Rows.Count>0)
                    {
                        Session["ID_MASCOTA"] = dtM.Rows[0][0].ToString();
                        txt_nombre.Text = dtM.Rows[0][1].ToString();
                        txt_discapacidad.Text = dtM.Rows[0][2].ToString();
                        txt_edad.Text = dtM.Rows[0][3].ToString();
                        ddl_raza.SelectedItem.Text = dtM.Rows[0][5].ToString();
                        //ddl_raza.SelectedIndex = Convert.ToInt32(dtM.Rows[0][5].ToString());
                        ddl_sexo.SelectedItem.Text =  dtM.Rows[0][6].ToString();
                    }
                }
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string foto = Request.QueryString["fotoM"];

            BEL_Mascota mas = new BEL_Mascota();
            string idUser = Session["ID"] as string;
            string idMascota = Session["ID_MASCOTA"] as string;
            mas.UsuID = Convert.ToInt32(idUser);
            mas.MasNombre = txt_nombre.Text.Trim();
            mas.MasTipo = 1;
            mas.MasEdad = Convert.ToInt32(txt_edad.Text.Trim());
            mas.MasRaza = Convert.ToInt32(ddl_raza.SelectedValue);
            mas.MasID = Convert.ToInt32(idMascota);

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
                    mas.MasFotoPer = fp_perfil.FileName;
                }

            }
            else
            {
                mas.MasFotoPer = foto;
            }

            mas.MasIdContrato = 0;
            if (txt_discapacidad.Text == "")
            {
                mas.MasDiscapacidad = "Ninguna";
            }
            else
            {
                mas.MasDiscapacidad = txt_discapacidad.Text.Trim();
            }

            mas.MasSexo = ddl_sexo.SelectedValue;

            int rpta = mascota.EditarMascota(mas);
            if (rpta == -1 || rpta == 1)
            {
                Response.Redirect("/Dueno/misMascotas.aspx");
                //lbl_msj.Visible = true;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_update_error();", true);

            }
        }

        protected void LLenarRazas()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (SqlCommand cmd = new SqlCommand("SELECT id_raza,nombre FROM Raza "))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                ddl_raza.DataSource = cmd.ExecuteReader();
                ddl_raza.DataTextField = "nombre";
                ddl_raza.DataValueField = "id_raza";
                ddl_raza.DataBind();
                cn.Close();
            }
        }

        private void GuardarArchivo(FileUpload file, int tipo_foto)
        {
            string ruta = null;
            // Se carga la ruta física de la carpeta temp del sitio
            ruta = Server.MapPath("~/mascotas");

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
    }
}