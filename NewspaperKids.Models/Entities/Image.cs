namespace NewspaperKids.Models.Entities
{
    using System.Collections.Generic;

    public class Image
    {
        public Image()
        {
            this.Articles = new HashSet<Article>();
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        public string ImageName { get; set; }

        public byte[] Content { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}