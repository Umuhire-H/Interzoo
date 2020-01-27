using System.Web.Mvc;

namespace Interzoo.Web.Areas.Parrain
{
    public class ParrainAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Parrain";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Parrain_default",
                "Parrain/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "Interzoo.Web.Areas.Parrain.Controllers" }
            );
        }
    }
}