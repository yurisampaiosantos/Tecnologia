using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClasses
{
    public class FPSO
    {
        //============================================
        static public string GetEstUnidadeProcesso(string delSubstChapa)
        {
            string sRet = "";
            switch (delSubstChapa)
            {
                case "2D20": sRet = "TQ"; break;
                case "2D24": sRet = "CV"; break;
                case "2C22": sRet = "PM"; break;
                case "2C23": sRet = "PM"; break;
            }
            return sRet;
        }
        //============================================
        static public string GetFPSO(string piece)
        {
            string sRet = "";
            switch (piece)
            {
                case "0F": sRet = "P74"; break;
                case "0G": sRet = "P75"; break;
                case "0H": sRet = "P76"; break;
                case "0J": sRet = "P77"; break;
            }
            return sRet;
        }
        //============================================
        static public string GetTubTreatment(string piece)
        {
            string sRet = "Sem Tratamento";
            switch (piece.ToUpper())
            {
                case "HOLD": sRet = "Em Espera"; break;
                //case "NO TREATMENT": sRet = "Sem Tratamento"; break;
                case "GALVANIZED": sRet = "Galvanizado"; break;
                case "POLYETH.": sRet = "Revestido"; break;
            }
            return sRet;
        }
        //============================================
        static public string GetTubUnit(string shortDesc)
        {
            string sRet = "pç";
            if (shortDesc.ToUpper().IndexOf("PIPE") >= 0) sRet = "m";
            return sRet;
        }
        //============================================
        static public string GetTubDim2(string shortDesc, string partDiam2)
        {
            string sRet = partDiam2;
            if (shortDesc.ToUpper().IndexOf("PIPE") >= 0) sRet = "";
            if (shortDesc.ToUpper().IndexOf("FLANGE") >= 0) sRet = "";
            if (shortDesc.ToUpper().IndexOf("ELBOW") >= 0) sRet = "";
            return sRet;
        }
        //============================================
        static public string GetNumeroJunta(string juntaRel)
        {
            try
            {
                string sRet = juntaRel.Replace(" ","");
                //string[] juntas = juntaRel.Split('/');
                //string[] juntaP1 = juntas[0].Split('-');
                //sRet = juntas[2] + "-" + juntaP1[1];
                
                sRet = "XXXXX";
                return sRet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //============================================
    }
}
