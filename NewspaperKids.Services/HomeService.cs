namespace NewspaperKids.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.ViewModels.Article;

    public class HomeService : Service
    {
        public IEnumerable<ArticleViewModel> GetLatest(int numberOfLatest)
        {
            var atricles = this.Context.Articles.Entities.OrderByDescending(e => e.CreationDate).Take(numberOfLatest);
            var viewModel = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(atricles);

            return viewModel;
        }
    }
}