namespace NewspaperKids.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NewspaperKids.Data.Migrations;
    using NewspaperKids.Models.Entities;

    public class NewspaperKidsContext : IdentityDbContext<ApplicationUser>
    {
        public NewspaperKidsContext()
            : base("data source=.;initial catalog=NewspaperKidsDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewspaperKidsContext, Configuration>());
        }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<ParentCategory> ParentCategories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public static NewspaperKidsContext Create()
        {
            return new NewspaperKidsContext();
        }
    }
}