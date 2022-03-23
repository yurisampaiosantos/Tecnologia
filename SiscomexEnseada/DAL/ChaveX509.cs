using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace SiscomexEnseada
{

    public class ChaveX509
    {
        public static HttpClient client;
        public static WebRequestHandler requestHandler;

        // Metodo padrão X509 para ler o certificado.
        // os sertificados deverão está na pasta ~/certificado/
        // Parametros certificado = "nome sem a extensão" / senha do certificado
        private static X509Certificate2 GetClientCertificate()
        {
            try
            {
                X509Certificate2 oCertificado;
                var oX509Cert = new X509Certificate2();
                var store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                var collection = store.Certificates;

                oX509Cert = collection[0];
                oCertificado = oX509Cert;

                return oCertificado;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Certificado");
            }
        }

        public static HttpClient ClienteHttp()
        {
            try
            {
                X509Certificate2 clientCert = GetClientCertificate();
                requestHandler = new WebRequestHandler();
                requestHandler.ClientCertificates.Add(clientCert);

                //Seta a parte de segurança.
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

                client = new HttpClient(requestHandler);

                return client;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Certificado");
            }
}

        public static X509Certificate2 GetCertificate()
        {
            X509Certificate2 clientCert = GetClientCertificate();

            return clientCert;
        }

    }
}