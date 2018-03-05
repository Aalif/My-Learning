using System.Web.Mvc;

namespace mvclearn2.Areas.employee
{
    public class employeeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "employee";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "employee_default",
                "employee/{controller}/{action}/{id}",
                new { Controller = "home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}