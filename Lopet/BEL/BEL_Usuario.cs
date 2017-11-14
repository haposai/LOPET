using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lopet.BEL
{
    public class BEL_Usuario
    {
        private int usuID;
        private String usuNombre;
        private String usuApellido;
        private String usuCorreo;
        private String usuContrasenia;
        private String usuFotoPer;
        private String usuFotoPor;
        private int usuCelular;
        private String usuDni;
        private int usuIdDistrito;
        private string usuSexo;

        public int UsuID
        {
            get
            {
                return usuID;
            }

            set
            {
                usuID = value;
            }
        }
        public string UsuNombre
        {
            get
            {
                return usuNombre;
            }
            set
            {
                usuNombre = value;
            }
        }
        public string UsuApellido
        {
            get
            {
                return usuApellido;
            }
            set
            {
                usuApellido = value;
            }
        }
        public string UsuCorreo
        {
            get
            {
                return usuCorreo;
            }
            set
            {
                usuCorreo = value;
            }
        }
        public string UsuContrasenia
        {
            get
            {
                return usuContrasenia;
            }
            set
            {
                usuContrasenia = value;
            }
        }
        public string UsuFotoPer
        {
            get
            {
                return usuFotoPer;
            }
            set
            {
                usuFotoPer = value;
            }
        }
        public string UsuFotoPor
        {
            get
            {
                return usuFotoPor;
            }
            set
            {
                usuFotoPor = value;
            }
        }
        public int UsuCelular
        {
            get
            {
                return usuCelular;
            }

            set
            {
                usuCelular = value;
            }
        }
        public string UsuDni
        {
            get
            {
                return usuDni;
            }

            set
            {
                usuDni = value;
            }
        }
        public int UsuIdDistrito
        {
            get
            {
                return usuIdDistrito;
            }

            set
            {
                usuIdDistrito = value;
            }
        }

        public string UsuSexo
        {
            get
            {
                return usuSexo;
            }

            set
            {
                usuSexo = value;
            }
        }


    }
}