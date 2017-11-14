using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lopet.BEL
{
    public class BEL_Lopet
    {
        private int lopetID;
        private String lopetNombre;
        private String lopetApellido;
        private String lopetCorreo;
        private String lopetContrasenia;
        private String lopetFotoPer;
        private String lopetFotoPor;
        private int lopetCelular;
        private String lopetDni;
        private int lopetIdDistrito;
        private String lopetSexo;
        private int lopetServicio;
        private String lopetDes;
        private decimal lopetprecio;

        public int LopetID
        {
            get
            {
                return lopetID;
            }

            set
            {
                lopetID = value;
            }
        }
        public decimal LopetPrecio
        {
            get
            {
                return lopetprecio;
            }

            set
            {
                lopetprecio = value;
            }
        }
        public string LopeDes
        {
            get
            {
                return lopetDes;
            }
            set
            {
                lopetDes = value;
            }
        }
        public int LopetServicio
        {
            get
            {
                return lopetServicio;
            }

            set
            {
                lopetServicio = value;
            }
        }
        public string LopeNombre
        {
            get
            {
                return lopetNombre;
            }
            set
            {
                lopetNombre = value;
            }
        }
        public string LopeApellido
        {
            get
            {
                return lopetApellido;
            }
            set
            {
                lopetApellido = value;
            }
        }
        public string LopeCorreo
        {
            get
            {
                return lopetCorreo;
            }
            set
            {
                lopetCorreo = value;
            }
        }
        public string LopeContrasenia
        {
            get
            {
                return lopetContrasenia;
            }
            set
            {
                lopetContrasenia = value;
            }
        }
        public string LopeFotoPer
        {
            get
            {
                return lopetFotoPer;
            }
            set
            {
                lopetFotoPer = value;
            }
        }
        public string LopeFotoPor
        {
            get
            {
                return lopetFotoPor;
            }
            set
            {
                lopetFotoPor = value;
            }
        }
        public int LopeCelular
        {
            get
            {
                return lopetCelular;
            }

            set
            {
                lopetCelular = value;
            }
        }
        public string LopeDni
        {
            get
            {
                return lopetDni;
            }

            set
            {
                lopetDni = value;
            }
        }
        public int LopeIdDistrito
        {
            get
            {
                return lopetIdDistrito;
            }

            set
            {
                lopetIdDistrito = value;
            }
        }

        public string LopeSexo
        {
            get
            {
                return lopetSexo;
            }
            set
            {
                lopetSexo = value;
            }
        }

    }
}