using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewspaperKids.Tests
{
    using System.Web.Mvc;

    using AutoMapper;

    using NewspaperKids.Models.BindingModels;
    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.ViewModels.Article;
    using NewspaperKids.Models.ViewModels.Author;
    using NewspaperKids.Models.ViewModels.Category;
    using NewspaperKids.Models.ViewModels.Image;
    using NewspaperKids.Web.Controllers;

    [TestClass]
    public class HomeControllerTests
    {
        public HomeController Contrroller;

        [TestMethod]
        public void Index_ShouldPass()
        {
            var result = this.Contrroller.Index() as ViewResult;
            var viewName = result.ViewName;
            Assert.AreEqual("Index", viewName, "Actual view name isn't as expected!");
        }

        [TestInitialize]
        public void SetUp()
        {
            this.Contrroller = new HomeController();
            Mapper.Initialize(
               expression =>
               {
                   expression.CreateMap<Category, CategoryViewModel>();
                   expression.CreateMap<Category, BaseCategoryViewModel>();
                   expression.CreateMap<ParentCategory, ParentCategoryViewModel>();
                   expression.CreateMap<ImageBindingModel, Image>();
                   expression.CreateMap<Image, ImageViewModel>();
                   expression.CreateMap<Author, AuthorViewModel>();
                   expression.CreateMap<Article, ArticleViewModel>();
                   expression.CreateMap<Article, ArticleDetailsViewModel>();
                   expression.CreateMap<CommentBindingModel, Comment>();
               });
        }
    }
}
