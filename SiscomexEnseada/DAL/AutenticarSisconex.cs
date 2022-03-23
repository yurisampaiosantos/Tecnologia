using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace SiscomexEnseada
{
    public class AutenticarSisconex
    {
        private string token;
        private string xCSRFtoken;
        private string csrfExpirionResponse;
        private string keepAlive;
        private string connection;
        private string contentLength;
        private string contentType;
        private string date;
        private string server;

        private HttpWebResponse response;
        private HttpWebRequest client;
        public Boolean GetTokenAutenticado()
        {
            try
            {
                //HttpWebRequest
                client = (HttpWebRequest)WebRequest.Create(Conexao.ConecaoSiscomex + "/portal/api/autenticar");

                X509Certificate2 oCertificado;
                var oX509Cert = new X509Certificate2();
                var store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                var collection = store.Certificates;

                oX509Cert = collection[0];
                oCertificado = oX509Cert;

                client.ContentType = "application/json";
                client.Headers.Add("Role-Type", "DEPOSIT");
                client.Method = "POST";


                var scollection = X509Certificate2UI.SelectFromCollection(collection,
                    "Certificado(s) Digital(is) disponível(is)", "Selecione o certificado digital para uso no aplicativo",
                    X509SelectionFlag.SingleSelection);

                if (scollection.Count == 0)
                {
                    return false;
                }
                else
                {
                    oX509Cert = scollection[0];
                    client.ClientCertificates.Add(oX509Cert);


                    /*   seleciona o certificado automatico
                      foreach (var item in collection)
                       {
                           if (item.SerialNumber == "152B20081453DD36") )
                           {
                               client.ClientCertificates.Add(item);
                           }
                       }
                     */


                    //Seta a parte de segurança.
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                    //var
                    response = (HttpWebResponse)client.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // var responseStream = response.GetResponseStream();

                        var setToken = response.Headers["Set-Token"];
                        var setCSRFToken = response.Headers["X-CSRF-Token"];
                        var setcsrfExpirionResponse = response.Headers["X-CSRF-Expiration"];
                        var setkeepAlive = response.Headers["Keep-Alive"];
                        var setconnection = response.Headers["Connection"];
                        var setcontentLength = response.Headers["Content-Length"];
                        var setcontentType = response.Headers["Content-Type"];
                        var setdate = response.Headers["Date"];
                        var setserver = response.Headers["Server"];


                        token = setToken;
                        xCSRFtoken = setCSRFToken;
                        csrfExpirionResponse = setcsrfExpirionResponse;

                        keepAlive = setkeepAlive;
                        connection = setconnection;
                        contentLength = setcontentLength;
                        contentType = setcontentType;
                        date = setdate;
                        server = setserver;


                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Autenticação do Certificado");
            }
}
        public string getToken()
        {
            return token;
        }
        public string getCsrfExpirionResponse()
        {
            return csrfExpirionResponse;
        }
        public string getxCSRFtoken()
        {
            return xCSRFtoken;
        }

        public HttpWebRequest getClient()
        {
            return client;
        }
    }
}