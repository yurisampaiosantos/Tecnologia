using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;

namespace GenericClasses
{
    static public class XML
    {
        //=================================================================
        public static void SerializaArquivoXML(object p, string xmlFullFileName)
        {
            //Criar o arquivo XML - usuarios.xml - na raiz da aplicação
            using (TextWriter textWriter = new StreamWriter(xmlFullFileName))
            {
                //Definir o Type e o elemento raiz do XML (usuarios)
                XmlSerializer ser = new XmlSerializer(p.GetType(), new XmlRootAttribute("previsao"));
                //Serializar o list para o TextWriter e salvar os dados no XML
                ser.Serialize(textWriter, p);
            }
        }
        //=================================================================
        public static DTO.CpPrevistoDTO DeserializaArquivoXML(DTO.CpPrevistoDTO p, string xmlFullFileName)
        {
            //Definir o Type no XmlSerializer (List<Usuario>)
            XmlSerializer ser = new XmlSerializer(p.GetType(), new XmlRootAttribute("previsao"));
            //Usar o FileStream para abrir e ler o arquivo XML
            FileStream fs = new FileStream(xmlFullFileName, FileMode.Open);
            //Deserializar o XML para o tipo List<Usuario>
            p = (DTO.CpPrevistoDTO)ser.Deserialize(fs);
            fs.Close();
            return p;
        }




        //=================================================================
        public static void SerializaPunchListTicketXML(object t, string xmlFullFileName)
        {
            //Criar o arquivo XML - usuarios.xml - na raiz da aplicação
            using (TextWriter textWriter = new StreamWriter(xmlFullFileName))
            {
                //Definir o Type e o elemento raiz do XML (usuarios)
                XmlSerializer ser = new XmlSerializer(t.GetType(), new XmlRootAttribute("punchListTicket"));
                //Serializar o list para o TextWriter e salvar os dados no XML
                ser.Serialize(textWriter, t);
            }
        }
        //=================================================================
        public static DTO.CpPunchListTicketDTO DeserializaPunchListTicketXML(DTO.CpPunchListTicketDTO t, string xmlFullFileName)
        {
            //Definir o Type no XmlSerializer (List<Usuario>)
            XmlSerializer ser = new XmlSerializer(t.GetType(), new XmlRootAttribute("punchListTicket"));
            //Usar o FileStream para abrir e ler o arquivo XML
            FileStream fs = new FileStream(xmlFullFileName, FileMode.Open);
            //Deserializar o XML para o tipo List<Usuario>
            t = (DTO.CpPunchListTicketDTO)ser.Deserialize(fs);
            fs.Close();
            return t;
        }
        //=================================================================
    }
}
