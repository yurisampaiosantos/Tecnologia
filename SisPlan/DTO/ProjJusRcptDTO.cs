using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjJusRcptDTO : List<ProjJusRcptDTO> { }
    //====================================================================
    public class ProjJusRcptDTO : BaseDTO
    {
        private decimal id;
        private string idJunta;
        private string plataforma;
        private string modulo;
        private string bloco;
        private string juntaRel;
        private string legendaExecutada;
        private string siglaTipo;
        private string numiso;
        private string fileName;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        //====================================================================
        public enum attributeName { ID, ID_JUNTA, PLATAFORMA, MODULO, BLOCO, JUNTA_REL, LEGENDA_EXECUTADA, SIGLA_TIPO, NUMISO, FILE_NAME, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE };
        public enum propertyName { ID, IdJunta, plataforma, Modulo, Bloco, JuntaRel, LegendaExecutada, SiglaTipo, Numiso, FileName, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate };
        //====================================================================
        private static int length = 14;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string IdJunta { get { return idJunta; } set { idJunta = TruncateValue(value, 200); } }
        public string Plataforma { get { return plataforma; } set { plataforma = TruncateValue(value, 50); } }
        public string Modulo { get { return modulo; } set { modulo = TruncateValue(value, 50); } }
        public string Bloco { get { return bloco; } set { bloco = TruncateValue(value, 100); } }
        public string JuntaRel { get { return juntaRel; } set { juntaRel = TruncateValue(value, 200); } }
        public string LegendaExecutada { get { return legendaExecutada; } set { legendaExecutada = TruncateValue(value, 100); } }
        public string SiglaTipo { get { return siglaTipo; } set { siglaTipo = TruncateValue(value, 100); } }
        public string Numiso { get { return numiso; } set { numiso = TruncateValue(value, 100); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 60); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 60); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
    }
}