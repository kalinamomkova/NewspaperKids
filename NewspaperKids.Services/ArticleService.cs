namespace NewspaperKids.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.ViewModels.Article;

    public class ArticleService : Service
    {
        public IEnumerable<ArticleViewModel> GetAllArticlesForGivenCategory(int id)
        {
            var articles = this.Context.Articles.Where(a => a.CategoryId == id && a.IsApproved);
            var viewModel = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

            return viewModel;
        }
        public string GetCategoryName(int subCategoryId)
        {
            var name = this.Context.Categories.Find(subCategoryId).Name;
            return name;
        }

        public ArticleDetailsViewModel GetArticleDetails(int id)
        {
            var article = this.Context.Articles.Find(id);
            var viewModel = Mapper.Map<Article, ArticleDetailsViewModel>(article);
            return viewModel;
        }
    }
}