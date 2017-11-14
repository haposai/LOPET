﻿using System;
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

namespace Lopet.Admin
{
    public partial class Lopets : System.Web.UI.Page
    {
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BEL_Lopet user = new BEL_Lopet();
                string idUser = "1";
                user.LopetID = Convert.ToInt32(idUser);

                BLL_Usuario usuario = new BLL_Usuario();
                dt = usuario.Mostrar_Lopets(user);

                if (dt.Rows.Count > 0)
                {
                    gv_contrato.DataSource = dt;
                    gv_contrato.DataBind();
                }
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[9].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('¿Esta seguro de cancelar el contrato nro: ? " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex);
            int contrato = Convert.ToInt32(gv_contrato.Rows[e.RowIndex].Cells[0].Text);

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cn.Open();

            string query;

            query = string.Format("delete from Lopet where id_Lopet=" + contrato);


            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            Response.Redirect("Lopets.aspx");

        }

        protected void gv_contrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = ((GridView)sender).SelectedRow.Cells[3].Text;


            Session["LOPET_DNI"] = id;


            Response.Redirect("ModificarLopet.aspx");
        }

    }
}