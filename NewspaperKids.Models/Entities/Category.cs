namespace NewspaperKids.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public ParentCategory ParentCategory { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}