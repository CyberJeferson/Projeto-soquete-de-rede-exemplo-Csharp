using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportTwo;

public partial class nivel9 : System.Web.UI.Page
{
    CAVALO cv = new CAVALO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static  string Executar(string m)
    {
        using (var pot = new SportTwo.TABELASDataContext())
        {
            var filtro = pot.CAVALO;
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(filtro);
            return json;
        }
        string ad;
        ad = "Olá mundo";


            return "{" +
            "\"A\": \"ola mundo\"" +
            "}";
    }
}