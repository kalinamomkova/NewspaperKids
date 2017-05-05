namespace NewspaperKids.Web.Areas.Author.Controllers
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.Services;

    using Microsoft.AspNet.Identity;

    using NewspaperKids.Models.BindingModels;
    using NewspaperKids.Services;

    using PagedList;

    [Authorize(Roles = "Author")]
    public class AuthorController : Controller
    {
        private readonly AuthorService service;

        public AuthorController()
        {
            this.service = new AuthorService();
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            var userId = this.User.Identity.GetUserId();
            var viewModel = this.service.GetAtricleViewModel(userId);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult AddArticle(
            [Bind(Exclude = "CreationDate, LocationPath, IsApproved, ImageId")] AddAtricleBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.Request.Files.Count > 0)
                {
                    model.CreationDate = DateTime.Now;
                    var authorName = this.service.GetAuthorName(model.AuthorId);
                    if (model.Image.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(model.Image.FileName);
                        var imageBm = new ImageBindingModel();
                        var target = new MemoryStream();
                        model.Image.InputStream.CopyTo(target);
                        imageBm.Content = target.ToArray();
                        imageBm.ImageName =
                            $"{authorName}/{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}/{fileName}";
                        this.service.AddImage(imageBm);
                        model.ImageId = this.service.GetImageId(imageBm.ImageName);
                    }
                    if (model.File.ContentLength > 0)
                    {
                        var target = new MemoryStream();
                        model.File.InputStream.CopyTo(target);
                        model.Content = target.ToArray();
                    }

                    model.IsApproved = false;
                    this.service.AddAtricle(model);
                    return this.RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            return this.View();
        }

        [WebMethod]
        public JsonResult LoadSubCategoreis(string parentCategoryId)
        {
            var arl = new ArrayList();

            var parentCategory = int.Parse(parentCategoryId);
            var subCategories = this.service.GetSubCategories(parentCategory);

            foreach (var subCategory in subCategories)
            {
                arl.Add(new { Value = subCategory.Id, Display = subCategory.Name });
            }

            return new JsonResult { Data = arl };
        }

        [HttpGet]
        public ActionResult GetArticlesForRedaction(int? page)
        {
            var userId = this.User.Identity.GetUserId();
            var model = this.service.GetArticlesForRedaction(userId);
            var pageSize = 2;
            var pageNumber = page ?? 1;
            var pr = model.ToPagedList(pageNumber, pageSize);
            return this.View(pr);
        }

        [HttpPost]
        public ActionResult Redact(int id)
        {
            if (this.ModelState.IsValid)
            {
                var model = this.service.GetArticleDetails(id);
                return this.View(model);
            }
            return this.View("Error");
        }

        [HttpPost]
        public ActionResult ReturnForApproval(EditArticleBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.Request.Files.Count > 0)
                {
                    this.service.EditArticle(model);
                }
                return this.RedirectToAction("GetArticlesForRedaction");
            }
            return this.View("Error");
        }
    }
}