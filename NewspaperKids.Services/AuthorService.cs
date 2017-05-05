namespace NewspaperKids.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;

    using NewspaperKids.Models.BindingModels;
    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.ViewModels.Article;
    using NewspaperKids.Models.ViewModels.Category;

    public class AuthorService : Service
    {
        public AddArticleViewModel GetAtricleViewModel(string userId)
        {
            var parentCategories = this.Context.ParentCategories.Entities;
            var viewModel =
                Mapper.Map<IEnumerable<ParentCategory>, IEnumerable<ParentCategoryViewModel>>(parentCategories);
            var authorId = this.Context.Authors.FirstOrDefault(a => a.UserId == userId).Id;
            var articleViewModel = new AddArticleViewModel { ParentCategories = viewModel, AuthorId = authorId };
            return articleViewModel;
        }

        public string GetAuthorName(int id)
        {
            var author = this.Context.Authors.Find(id);
            return $"{author.FirstName}_{author.LastName}";
        }

        public IEnumerable<BaseCategoryViewModel> GetSubCategories(int parentCategoryId)
        {
            var categories = this.Context.Categories.Where(c => c.ParentCategoryId == parentCategoryId);
            var categoriesViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<BaseCategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public void AddImage(ImageBindingModel model)
        {
            var image = Mapper.Map<ImageBindingModel, Image>(model);
            this.Context.Images.Add(image);
            this.Context.SaveChanges();
        }

        public int GetImageId(string imageName)
        {
            var imageId = this.Context.Images.FirstOrDefault(i => i.ImageName == imageName).Id;
            return imageId;
        }

        public void AddAtricle(AddAtricleBindingModel model)
        {
            var article = new Article
                              {
                                  CategoryId = model.SubCategory,
                                  AuthorId = model.AuthorId,
                                  CreationDate = model.CreationDate,
                                  IsApproved = model.IsApproved,
                                  ImageId = model.ImageId,
                                  Content = model.Content,
                                  Title = model.Title
                              };

            this.Context.Articles.Add(article);
            this.Context.SaveChanges();
        }

        public IEnumerable<ArticleViewModel> GetArticlesForRedaction(string userId)
        {
            var articlesForRedaction = this.Context.Articles.Where(a => a.Redact && a.Author.UserId == userId);
            var viewModel = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articlesForRedaction);

            return viewModel;
        }

        public EditArticleViewModel GetArticleDetails(int id)
        {
            var article = this.Context.Articles.Find(id);
            var lastComment = article.Comments.OrderByDescending(c => c.Id).Select(c => c.Content).FirstOrDefault();
            var editArticleViewModel = new EditArticleViewModel { Id = id, Comment = lastComment };
            return editArticleViewModel;
        }

        public void EditArticle(EditArticleBindingModel model)
        {
            var article = this.Context.Articles.Find(model.Id);
            if (model.Image != null && model.Image.ContentLength > 0)
            {
                var target = new MemoryStream();
                model.Image.InputStream.CopyTo(target);
                article.Image.Content = target.ToArray();
            }
            if (model.File!= null && model.File.ContentLength > 0)
            {
                var fileTarget = new MemoryStream();
                model.File.InputStream.CopyTo(fileTarget);
                article.Content = fileTarget.ToArray();
            }
            article.Redact = false;
            this.Context.SaveChanges();
        }
    }
}