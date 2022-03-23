using System.Net;
using System.IO;
using System;

namespace SiscomexEnseada
{
    public class SiscomexController
    {
        public string  token = null;
        public string xCSRFtoken = null;
        public string csrfExpirionResponse = null;

        private AutenticarSisconex autenticar;
        private HttpWebRequest client;
        public SiscomexController()
        {
            autenticar = new AutenticarSisconex();
        }
        // GET api/SiscomexController/GetDUE
        // Parametros numero due, servicoParametros
        public void Enviar(string xml)
        {
            try
            {
              //  autenticar = new AutenticarSisconex(); // Autentica 

                //Caso o token seja nulo solita autenticação.
                if (token == null)
                {
                    if (autenticar.GetTokenAutenticado())
                    {
                        token = autenticar.getToken();
                        xCSRFtoken = autenticar.getxCSRFtoken();
                        csrfExpirionResponse = autenticar.getCsrfExpirionResponse();
                    }

                    client = autenticar.getClient(); // Usa client já configurado
                }

                EnvioXML(xml, token, xCSRFtoken, csrfExpirionResponse);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Enviar");
            }
        }
        private void EnvioXML(string requestXml, string tokenResponse, string csrfTokenResponse, string csrfExpirionResponse)
        {

            string destinationUrl = Conexao.ConecaoSiscomex+ "/cct/api/ext/carga/recepcao-nfe";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);

            byte[] bytes;
            bytes = System.Text.Encoding.UTF8.GetBytes(requestXml);

            request.ContentType = "application/xml";
 
            request.Headers.Add("Authorization", tokenResponse);
            request.Headers.Add("X-CSRF-Token", csrfTokenResponse);
            request.ContentLength = bytes.Length;
            request.Method = "POST";
                       
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream responseStream1 = response.GetResponseStream();
                    }
                }

            }
            catch (WebException e)
            {
                throw new System.ArgumentException(e.Message, "Inserir Carga");
            }
        }
    }
}
