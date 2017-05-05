namespace NewspaperKids.Web.Controllers
{
    using System.Web.Mvc;

    using NewspaperKids.Services;

    using PagedList;

    public class ArticleController : Controller
    {
        private readonly ArticleService service;

        public ArticleController()
        {
            this.service = new ArticleService();
        }

        [HttpGet]
        public ActionResult Index(int id, int? page)
        {
            var model = this.service.GetAllArticlesForGivenCategory(id);
            if (model == null)
            {
                return this.HttpNotFound();
            }
            var pageSize = 2;
            var pageNumber = page ?? 1;
            var pr = model.ToPagedList(pageNumber, pageSize);
            this.ViewBag.Id = id;
            this.ViewBag.Title = this.service.GetCategoryName(id);
            return this.View(pr);
        }

        [HttpGet]
        public ActionResult GetArticle(int id)
        {
            var model = this.service.GetArticleDetails(id);
            return this.View(model);
        }
    }
}