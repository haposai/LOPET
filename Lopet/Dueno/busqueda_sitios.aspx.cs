using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lopet.Dueño
{
    public partial class busqueda_sitios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String MostrarSitios()
        {
            StringBuilder xmlData = new StringBuilder();


            //original
            xmlData.Append("<iframe ");
            xmlData.Append("id =\"myIframe\" ");
            xmlData.Append("width=\"100%\" ");
            xmlData.Append("height=\"400\" ");
            xmlData.Append("frameborder=\"0\" ");
            xmlData.Append("style=\"border:0\" ");
            xmlData.Append("src=\"https://www.google.com/maps/embed/v1/search?key=AIzaSyD3eM0JDMpUI1rMfFhImTko7nmZ8ZnY2kg&q=record+veterinary+care+Lima+La+Molina\" ");
            //xmlData.Append("src=\"https://www.google.com/maps/embed/v1/place?key=AIzaSyCFUc4fzmEaZFphd8RVsA_jvzSZHTcV1I4&q=Veterinaria+AGRARIS,Lima+La+Molina\" ");
            xmlData.Append("owfullscreen ");
            xmlData.Append("</iframe>");




            return xmlData.ToString();


        }

        protected void ddl_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_tipo.SelectedValue == "1")
            {
                vet.Visible = true;
                // map.Visible = false;

            }
            else
            {
                vet.Visible = false;
                // map.Visible = true;
            }
        }
    }
}