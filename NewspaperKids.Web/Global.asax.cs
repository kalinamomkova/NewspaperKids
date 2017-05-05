using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewspaperKids.Web
{
    using System.Data.Entity.Migrations;

    using AutoMapper;

    using NewspaperKids.Data.Migrations;
    using NewspaperKids.Models.BindingModels;
    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.ViewModels;
    using NewspaperKids.Models.ViewModels.Article;
    using NewspaperKids.Models.ViewModels.Author;
    using NewspaperKids.Models.ViewModels.Category;
    using NewspaperKids.Models.ViewModels.Image;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
            this.CongigureMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void CongigureMapper()
        {
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
