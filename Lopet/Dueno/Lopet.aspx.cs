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
using System.Text;

namespace Lopet.Dueno
{
    public partial class Lopet : System.Web.UI.Page
    {
        BEL_Lopet lopet = new BEL_Lopet();
        DataTable dtL = new DataTable();
        DataTable dtC = new DataTable();
        BLL_Usuario usuario = new BLL_Usuario();
        int reputacion = 1;
        int id_user = 0;
        int id_lopet = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
          

                string foto_perfil="~/perfil/" + Session["Foto_Perfil"] as string;
                string foto_portada = "~/portada/" + Session["Foto_Portada"] as string;
               
                lbl_nombre.Text = Session["Nombre"] as string;
                img_per.ImageUrl = foto_perfil;

                //Infomracion Lopet
                lopet.LopeNombre = Request.QueryString["nombreL"];
                lopet.LopeFotoPer = Request.QueryString["foto"];
                reputacion = Convert.ToInt32(Request.QueryString["repu"]);
                Session["REPUTACION"] = reputacion;
                dtL = usuario.ConsultarLopet(lopet);

                if (dtL.Rows.Count > 0)
                {
                    string foto_perfil_lopet = "~/perfil/" + dtL.Rows[0][9].ToString();
                    string foto_portada_lopet = "~/portada/" + dtL.Rows[0][10].ToString();
                    Session["ID_LOPET"]= dtL.Rows[0][0].ToString();
                    lbl_nombre_Lopet.Text = dtL.Rows[0][1].ToString();
                    lbl_servicio.Text = dtL.Rows[0][11].ToString();
                    lbl_distrito.Text = dtL.Rows[0][6].ToString();
                    img_lopet.ImageUrl = foto_perfil_lopet;
                    img_portada.ImageUrl = foto_portada_lopet;
                    img_portada2.ImageUrl = foto_portada_lopet;
                    txt_des.Text = dtL.Rows[0][13].ToString();
                    //txt_comentarios.Text= dtL.Rows[0][13].ToString();
                    lbl_precio.Text= "1 perro x S/." + dtL.Rows[0][14].ToString() + "/hora";
                    txt_lopet.Text= dtL.Rows[0][1].ToString();
                    txt_precio.Text = dtL.Rows[0][14].ToString();
                    txt_servicio.Text = dtL.Rows[0][11].ToString();

                    id_user = Convert.ToInt32(Session["ID"] as string);
                    id_lopet = Convert.ToInt32(dtL.Rows[0][0].ToString());
                    dtC = usuario.ValidarContrato(id_user, id_lopet);

                    if(dtC.Rows.Count>0)
                    {
                        Session["FLAG"] = "1";
                        txt_comentarios.Visible = true;
                        btn_comentario.Visible = true;
                    }
                    else
                    {
                        Session["FLAG"] = "0";
                        txt_comentarios.Visible = false;
                        btn_comentario.Visible = false;
                    }
                    LLenarMascotas();
                    

                }
            }
        }

        protected void btn_contratar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Dueno/misContratos.aspx");
        }

        [System.Web.Services.WebMethod]
        public static void GetCurrentTime(string fecha_ini,string fecha_fin, decimal precio, int dias,int mascotas)
        {
            string id_lopet = System.Web.HttpContext.Current.Session["ID_LOPET"] as string;
            string idUser = System.Web.HttpContext.Current.Session["ID"] as string;
            string estado = "pendiente";

            BLL_Contrato con = new BLL_Contrato();
            BEL_Contrato contrato = new BEL_Contrato();
            contrato.ContratoID = 0;
            contrato.CostoTotal = precio;
            contrato.Fecha_inicio = fecha_ini;
            contrato.Fecha_fin = fecha_fin;
            contrato.UsuID = Convert.ToInt32(idUser);
            contrato.LopetID = Convert.ToInt32(id_lopet);
            contrato.Estado = estado;
            contrato.Cant_Dias = dias;
            contrato.Cant_Mascotas = mascotas;
            string query;
            int rpta = con.RegistrarContrato(contrato);

             for(int i=1;i<mascotas;i++)
             {
                 
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cn.Open();
                query = string.Format("update mascotas set id_contrato=(select distinct id_contrato from contrato c where c.id_user="+ idUser + ")" +
                    "where id_mascota=" + i);


                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }

        }

        protected void LLenarMascotas()
        {
            string idUser = Session["ID"] as string;

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (SqlCommand cmd = new SqlCommand("SELECT id_mascota,nombre FROM Mascotas WHERE id_user=" + idUser))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                ddl_mascotas_con.DataSource = cmd.ExecuteReader();
                ddl_mascotas_con.DataTextField = "nombre";
                ddl_mascotas_con.DataValueField = "id_mascota";
                ddl_mascotas_con.DataBind();
                cn.Close();
            }
        }

        public String MostrarReputacion()
        {
            StringBuilder xmlData = new StringBuilder();
            int reput = reputacion;

            string flag = System.Web.HttpContext.Current.Session["FLAG"] as string;

            if(flag=="1")
            {
                if (reput == 1)
                {
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(1)' >&#9733;</a> ");
                }
                else if (reput == 2)
                {
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(1)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(2)' >&#9733;</a> ");
                }
                else if (reput == 3)
                {
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(1)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(2)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(3)' >&#9733;</a> ");
                }
                else if (reput == 4)
                {
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(1)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(2)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(3)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(4)' >&#9733;</a> ");
                }
                else
                {
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(1)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(2)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(3)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(4)' >&#9733;</a> ");
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(5)' >&#9733;</a> ");
                }
            }
            else
            {
                for (int i = 1; i <= reput; i++)
                {
                    xmlData.Append("<a class='aa' href='#' data-value='1' title='' style='font-size: 25px' >&#9733;</a> ");
                }
            }


            //original
            //for (int i=1;i<= reput; i++)
            //{
            //    xmlData.Append("<a class='aa' href='#' data-value='1' title='Votar con 1 estrellas' style='font-size: 25px' onclick='valorar(1)' >&#9733;</a> ");
            //}



            return xmlData.ToString();
        }

        protected void btn_comentario_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cn.Open();

            id_user = Convert.ToInt32(Session["ID"] as string);
            id_lopet = Convert.ToInt32(Session["ID_LOPET"] as string);

            string query;

            query = string.Format("declare @id int set @id=(select max(id_comen)+1 from Comentario)  insert into Comentario (id_comen,id_lopet,id_user,comentario,fecha) values(@id,'" + id_lopet + "','" + id_user + "','" + txt_comentarios.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "' )");


            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            string nombre= Request.QueryString["nombreL"];
            string foto = Request.QueryString["foto"];
            Response.Redirect("Lopet.aspx?nombreL="+ nombre + "&foto="+ foto +"");


        }
    }
}