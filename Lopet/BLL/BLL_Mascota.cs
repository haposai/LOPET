using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Lopet.BEL;
using Lopet.DAL;
namespace Lopet.BLL
{
    public class BLL_Mascota
    {
        //Registrar mascota
        public int RegistrarMascota(BEL_Mascota mascota)
        {
            DAL_Mascota gestionUsuario = new DAL_Mascota();
            return gestionUsuario.RegistrarMascota(mascota);
        }

        //Eliminar mascota
        public int EliminarMascota(BEL_Mascota mascota)
        {
            DAL_Mascota gestionUsuario = new DAL_Mascota();
            return gestionUsuario.EliminarMascota(mascota);
        }

        //Buscar mascota
        public DataTable ConsultarMascota(BEL_Mascota mascota)
        {
            DAL_Mascota gestionUsuario = new DAL_Mascota();
            return gestionUsuario.ConsultarMascota(mascota);
        }

        //Eliminar mascota
        public int EditarMascota(BEL_Mascota mascota)
        {
            DAL_Mascota gestionUsuario = new DAL_Mascota();
            return gestionUsuario.EditarMascota(mascota);
        }
    }
}