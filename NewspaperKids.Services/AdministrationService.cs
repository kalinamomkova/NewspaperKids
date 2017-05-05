namespace NewspaperKids.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NewspaperKids.Models.BindingModels;
    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.ViewModels.Article;

    public class AdministrationService : Service
    {
        public IEnumerable<ArticleViewModel> GetArticlesForApproval()
        {
            var articlesForApproval = this.Context.Articles.Where(a => !a.IsApproved && !a.Redact);
            var viewModel = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articlesForApproval);

            return viewModel;
        }

        public void Approve(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);
            article.IsApproved = true;
            this.Context.SaveChanges();
        }

        public void AddComment(CommentBindingModel model)
        {
            var comment = Mapper.Map<CommentBindingModel, Comment>(model);
            this.Context.Comments.Add(comment);
            var article = this.Context.Articles.Find(model.ArticleId);
            article.Redact = true;
            this.Context.SaveChanges();
        }
    }
}