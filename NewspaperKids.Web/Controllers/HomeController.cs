namespace NewspaperKids.Web.Controllers
{
    using System.Web.Mvc;

    using NewspaperKids.Services;

    public class HomeController : Controller
    {
        private readonly HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        public ActionResult Index()
        {
            var models = this.service.GetLatest(3);
            return this.View(models);
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}