namespace NewspaperKids.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime CreationDate { get; set; }

        public int? AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public byte[] Content { get; set; }

        public bool IsApproved { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public bool Redact { get; set; }
    }
}