namespace NewspaperKids.Data.Repository
{
    using NewspaperKids.Models.Entities;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewspaperKidsContext context;
        private IRepository<Category> categories;
        private IRepository<Author> authors;
        private IRepository<Article> articles;
        private IRepository<Image> images;
        private IRepository<ParentCategory> parentCategories;
        private IRepository<Comment> comments;
        private IRepository<ApplicationUser> users;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<Category> Categories
            => this.categories ?? (this.categories = new Repository<Category>(this.context.Categories));

        public IRepository<Author> Authors
            => this.authors ?? (this.authors = new Repository<Author>(this.context.Authors));

        public IRepository<Article> Articles
            => this.articles ?? (this.articles = new Repository<Article>(this.context.Articles));

        public IRepository<Image> Images
            => this.images ?? (this.images = new Repository<Image>(this.context.Images));

        public IRepository<ParentCategory> ParentCategories
            => this.parentCategories ?? (this.parentCategories = new Repository<ParentCategory>(this.context.ParentCategories));

        public IRepository<Comment> Comments
         => this.comments ?? (this.comments = new Repository<Comment>(this.context.Comments));

        public IRepository<ApplicationUser> Users
         => this.users ?? (this.users = new Repository<ApplicationUser>(this.context.Users));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
