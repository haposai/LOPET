using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lopet.BEL;
using Lopet.BLL;
using System.Data;

namespace Lopet
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        string nombre = null;
        string id = null;
        string foto_perfil = null;
        string foto = null;
        string dni = null;
        BLL_Usuario usuario = new BLL_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            

           
        }
    }
}