using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () 
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public User Validation(string domain, string username, string password)
    {
        Process process = new Process();
        return process.ValidationDomain(domain, username, password);
    }
    [WebMethod]
    public bool ValidationDomainGeneration(string domain, string username, string password)
    {
        Process process = new Process();
        return process.ValidationDomainGeneration(domain, username, password);
    } 
    [WebMethod]
    public bool ValidationDomainGenerationParameter(string domain, string login, string password, string name, string departament, string tel, string cel, string email)
    {
        Process process = new Process();
        return process.ValidationDomainGeneration(domain, login, password, name, departament, tel, cel, email);
    }
    
}


