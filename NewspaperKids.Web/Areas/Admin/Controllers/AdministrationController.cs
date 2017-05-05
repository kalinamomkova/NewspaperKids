namespace NewspaperKids.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using NewspaperKids.Models.BindingModels;
    using NewspaperKids.Models.ViewModels.Comment;
    using NewspaperKids.Services;

    using PagedList;

    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly AdministrationService service;

        public AdministrationController()
        {
            this.service = new AdministrationService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult GetAllArticlesForApproval(int? page)
        {
            var model = this.service.GetArticlesForApproval();
            var pageSize = 2;
            var pageNumber = page ?? 1;
            var pr = model.ToPagedList(pageNumber, pageSize);
            return this.View(pr);
        }

        [HttpPost]
        public ActionResult Approve(int id)
        {
            if (this.ModelState.IsValid)
            {
                this.service.Approve(id);
                return this.RedirectToAction("GetAllArticlesForApproval");
            }
            return this.View("Error");
        }

        [HttpPost]
        public ActionResult AddComment(int articleId)
        {
            if (this.ModelState.IsValid)
            {
                var model = new AddCommentViewModel { ArticleId = articleId };
                return this.PartialView("_CommentPartial", model);
            }
            return this.View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnForEdit([Bind] CommentBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddComment(model);
                return this.RedirectToAction("GetAllArticlesForApproval", "Administration", new { area = "Admin" });
            }

            return this.View("Error");
        }
    }
}