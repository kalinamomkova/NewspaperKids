namespace NewspaperKids.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
    }
}