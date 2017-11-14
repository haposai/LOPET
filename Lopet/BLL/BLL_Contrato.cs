using Lopet.BEL;
using Lopet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lopet.BLL
{
    public class BLL_Contrato
    {
        //Registrar Usuario
        public int RegistrarContrato(BEL_Contrato contrato)
        {
            DAL_Contrato gestionContrato = new DAL_Contrato();
            return gestionContrato.RegistrarContrato(contrato);

        }
    }
}