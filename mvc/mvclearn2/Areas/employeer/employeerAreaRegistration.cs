using System.Web.Mvc;

namespace mvclearn2.Areas.employeer
{
    public class employeerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "employeer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "employeer_default",
                "employeer/{controller}/{action}/{id}",
                new { Controller = "home" ,action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}