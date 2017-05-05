using System.Web.Mvc;

namespace NewspaperKids.Web.Areas.Author
{
    public class AuthorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Author";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();
            context.MapRoute(
                "Author_default",
                "Author/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}