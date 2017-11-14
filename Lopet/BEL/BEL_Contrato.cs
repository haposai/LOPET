using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lopet.BEL
{
    public class BEL_Contrato
    {
        private int usuID;
        private int lopetID;
        private int contratoID;
        private String fecha_inicio;
        private String fecha_fin;
        private decimal costoTotal;
        private String estado;
        private int cant_Mascotas;
        private int cant_Dias;

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

        public int ContratoID
        {
            get
            {
                return contratoID;
            }

            set
            {
                contratoID = value;
            }
        }

        public String Fecha_inicio
        {
            get
            {
                return fecha_inicio;
            }

            set
            {
                fecha_inicio = value;
            }
        }

        public String Fecha_fin
        {
            get
            {
                return fecha_fin;
            }

            set
            {
                fecha_fin = value;
            }
        }

        public decimal CostoTotal
        {
            get
            {
                return costoTotal;
            }

            set
            {
                costoTotal = value;
            }
        }

        public String Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int Cant_Mascotas
        {
            get
            {
                return cant_Mascotas;
            }

            set
            {
                cant_Mascotas = value;
            }
        }

        public int Cant_Dias
        {
            get
            {
                return cant_Dias;
            }

            set
            {
                cant_Dias = value;
            }
        }
    }
}