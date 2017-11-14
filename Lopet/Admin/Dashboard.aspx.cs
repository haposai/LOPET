using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text;
using InfosoftGlobal;
using Lopet.BLL;

namespace Lopet.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataTable dtPie = null;
        DataTable dtFec = null;
        DataTable dtCon = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grafiasPie();
                grafiasEstadoxCosto();
                grafiasFechaxCosto();
            }
           
        }

        protected void grafiasPie()
        {
            BLL_Usuario usuario = new BLL_Usuario();
            dtPie = usuario.GraficaEstadoXContrato();

            StringBuilder xmlData = new StringBuilder();
            StringBuilder stringbuilder = new StringBuilder();

            int numColumns = 0;
            int numRows = 0;
            String tituloGrafica = null;
            tituloGrafica = "Pie";

            xmlData.Append("<chart caption='Contrato por Estado' subcaption='Año 2017' legendposition='right' palettecolors='#0075c2,#1aaf5d,#f2c500,#f45b00,#8e0000' bgcolor='#ffffff' showborder='0' use3dlighting='0' showshadow='0' enablesmartlabels='0' startingangle='0' showpercentvalues='1' showpercentintooltip='0' decimals='1' captionfontsize='14' subcaptionfontsize='14' subcaptionfontbold='0' tooltipcolor='#ffffff' tooltipborderthickness='0' tooltipbgcolor='#000000' tooltipbgalpha='80' tooltipborderradius='2' tooltippadding='5' showhovereffect='1' showlegend='1' legendbgcolor='#ffffff' legendborderalpha='0' legendshadow='0' legenditemfontsize='10' legenditemfontcolor='#666666' usedataplotcolorforlabels='1' > ");

            for(int i=0;i< dtPie.Rows.Count;i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    xmlData.Append(" <set label='" + dtPie.Rows[i][0].ToString() + "' value='" + dtPie.Rows[i][j].ToString() + "' /> ");
                }
                
            }
            xmlData.Append(" </chart>");
            //Clear Panel control which will contain the chart
            Panel1.Controls.Clear();
            String outPut = FusionCharts.RenderChart("../Content/Charts/pie2d.swf", "", xmlData.ToString(), "chat1", "650", "300", false, false);
            //Add Litaral control to Panel which adds the chart from outPut string
            Panel1.Controls.Add(new LiteralControl(outPut));
        }

        protected void grafiasEstadoxCosto()
        {
            BLL_Usuario usuario = new BLL_Usuario();
            dtCon = usuario.GraficaMontoXContrato();

            StringBuilder xmlData = new StringBuilder();
            StringBuilder stringbuilder = new StringBuilder();

            String tituloGrafica = null;
            tituloGrafica = "Pie";

            xmlData.Append("<chart caption='Monto por Contrato' subcaption='Año 2017' xaxisname='Estados' yaxisname='Montos en (S/.)' numberprefix='S/.' palettecolors='#0075c2' bgcolor='#ffffff' borderalpha='20' canvasborderalpha='0' useplotgradientcolor='0' plotborderalpha='10' placevaluesinside='1' rotatevalues='1' valuefontcolor='#ffffff' showxaxisline='1' xaxislinecolor='#999999' divlinecolor='#999999' divlinedashed='1' showalternatehgridcolor='0' subcaptionfontbold='0' subcaptionfontsize='14'> ");
            for (int i = 0; i < dtCon.Rows.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    xmlData.Append(" <set label='" + dtCon.Columns[j].ColumnName + "' value='" + dtCon.Rows[i][j].ToString() + "' /> ");
                }

            }
            xmlData.Append(" </chart>");


            //Clear Panel control which will contain the chart
            Panel2.Controls.Clear();
            String outPut = FusionCharts.RenderChart("../Content/Charts/column2d.swf", "", xmlData.ToString(), "chat2", "600", "200", false, false);
            //Add Litaral control to Panel which adds the chart from outPut string
            Panel2.Controls.Add(new LiteralControl(outPut));
        }

        protected void grafiasFechaxCosto()
        {
            BLL_Usuario usuario = new BLL_Usuario();
            dtFec = usuario.GraficaFechaXCosto();

            StringBuilder xmlData = new StringBuilder();
            StringBuilder stringbuilder = new StringBuilder();

            String tituloGrafica = null;
            tituloGrafica = "Pie";

            xmlData.Append("<chart caption='Ingresos por Pago(Lopets)' subcaption='Año 2017' xaxisname='Meses' yaxisname='Montos en (S/.)' numberprefix='S/.' palettecolors='#0075c2' bgcolor='#ffffff' borderalpha='20' canvasborderalpha='0' useplotgradientcolor='0' plotborderalpha='10' placevaluesinside='1' rotatevalues='1' valuefontcolor='#ffffff' showxaxisline='1' xaxislinecolor='#999999' divlinecolor='#999999' divlinedashed='1' showalternatehgridcolor='0' subcaptionfontbold='0' subcaptionfontsize='14'> ");
            for (int i = 0; i < dtFec.Rows.Count; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    xmlData.Append(" <set label='" + dtFec.Columns[j].ColumnName + "' value='" + dtFec.Rows[0][j].ToString() + "' /> ");
                }

            }

            //xmlData.Append("<chart caption='Ingresos por Pago(Lopets)' subcaption='Año 2017' xaxisname='Meses' yaxisname='Montos en (S/.)' numberprefix='S/.' palettecolors='#0075c2' bgcolor='#ffffff' borderalpha='20' canvasborderalpha='0' useplotgradientcolor='0' plotborderalpha='10' placevaluesinside='1' rotatevalues='1' valuefontcolor='#ffffff' showxaxisline='1' xaxislinecolor='#999999' divlinecolor='#999999' divlinedashed='1' showalternatehgridcolor='0' subcaptionfontbold='0' subcaptionfontsize='14'> ");
            //xmlData.Append(" <set label = 'Ene-17' value = '0' /> ");
            //xmlData.Append(" <set label = 'Feb-17' value = '0' /> ");
            //xmlData.Append(" <set label = 'Mar-17' value = '0' /> ");
            //xmlData.Append(" <set label = 'Abr-17' value = '0' /> ");
            //xmlData.Append(" <set label = 'May-17' value = '100' /> ");
            //xmlData.Append(" <set label = 'Jun-17' value = '80' /> ");
            //xmlData.Append(" <set label = 'Jul-17' value = '70' /> ");
            //xmlData.Append(" <set label = 'Ago-17' value = '120' /> ");
            //xmlData.Append(" <set label = 'Set-17' value = '0' /> ");
            //xmlData.Append(" <set label = 'Oct-17' value = '30' /> ");
            //xmlData.Append(" <set label = 'Nov-17' value = '0' /> ");
            //xmlData.Append(" <set label = 'Dic-17' value = '0' /> ");
            xmlData.Append(" </chart>");


            //Clear Panel control which will contain the chart
            Panel3.Controls.Clear();
            String outPut = FusionCharts.RenderChart("../Content/Charts/column2d.swf", "", xmlData.ToString(), "chat3", "600", "200", false, false);
            //Add Litaral control to Panel which adds the chart from outPut string
            Panel3.Controls.Add(new LiteralControl(outPut));
        }

        protected void ddl_año_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_año.SelectedValue=="2017")
            {
                grafiasPie();
                grafiasEstadoxCosto();
                grafiasFechaxCosto();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "validacion_año();", true);
            }
        }
    }
}