namespace NewspaperKids.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using NewspaperKids.Data.Extensions;
    using NewspaperKids.Models.Entities;
    using NewspaperKids.Models.Roles;

    public sealed class Configuration : DbMigrationsConfiguration<NewspaperKids.Data.NewspaperKidsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewspaperKids.Data.NewspaperKidsContext context)
        {
            //context.Images.AddOrUpdate(i => i.LocationPath, new Image { LocationPath = "path" });
            //context.Images.AddOrUpdate(i => i.LocationPath, new Image { LocationPath = "path2" });

            //context.Articles.AddOrUpdate(
            //    a => a.Title,
            //    new Article { LocationPath = "p", Image = context.Images.Local[0], CreationDate = DateTime.Now });
            //context.Categories.AddOrUpdate(
            //    c => c.Name,
            //    new Category { Name = "Qurious", Articles = new List<Article> { context.Articles.Local[0] } });
            context.AddRole(Role.Admin);
            context.AddRole(Role.Author);
        }
    }
}
