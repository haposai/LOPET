using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lopet.BEL
{
    public class BEL_Mascota
    {
        private int masID;
        private int usuID;
        private String masNombre;
        private int masTipo;
        private int masEdad;
        private int masRaza;
        private String masFotoPer;
        private String masDiscapacidad;
        private int masIdContrato;
        private String masSexo;

        public int MasIdContrato { get => masIdContrato; set => masIdContrato = value; }
        public int MasRaza { get => masRaza; set => masRaza = value; }
        public int MasEdad { get => masEdad; set => masEdad = value; }
        public int MasTipo { get => masTipo; set => masTipo = value; }
        public int UsuID { get => usuID; set => usuID = value; }
        public int MasID { get => masID; set => masID = value; }
        public String MasNombre { get => masNombre; set => masNombre = value; }
        public String MasFotoPer { get => masFotoPer; set => masFotoPer = value; }
        public String MasDiscapacidad { get => masDiscapacidad; set => masDiscapacidad = value; }
        public String MasSexo { get => masSexo; set => masSexo = value; }
    }
}