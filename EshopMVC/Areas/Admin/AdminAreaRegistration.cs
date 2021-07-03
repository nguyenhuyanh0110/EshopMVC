using System.Web.Mvc;

namespace EshopMVC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Admin_default",
                "admin/{controller}/{action}/{id}",
                new {Controller= "LogIn", action = "Index", id = "" } 
            );
        }
    }
}