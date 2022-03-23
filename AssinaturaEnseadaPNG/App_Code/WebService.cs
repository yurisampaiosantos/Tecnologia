using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () { }

    [WebMethod()]
    public string SalvarImagem(string base64)
    {
        //MemoryStream com o base64 recebido por parâmetro
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64)))
        {
            //Criar um novo Bitmap baseado na MemoryStream
            using (Bitmap bmp = new Bitmap(ms))
            {
                //Local onde vamos salvar a imagem (raiz do site + /canvas.png)
                string path = Server.MapPath("~/canvas.png");

                //Salvar a imagem no formato PNG
                bmp.Save(path, ImageFormat.Png);
            }
        }
        return "Imagem foi salva com sucesso";
    }
    
}
