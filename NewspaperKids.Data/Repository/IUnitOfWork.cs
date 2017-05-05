namespace NewspaperKids.Data.Repository
{
    using NewspaperKids.Models.Entities;

    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }

        IRepository<Author> Authors { get; }

        IRepository<ParentCategory> ParentCategories { get; }

        IRepository<Image> Images { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Article> Articles { get; }
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}