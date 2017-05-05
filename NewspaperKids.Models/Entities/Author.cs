namespace NewspaperKids.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {
        public Author()
        {
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public bool ShouldChangePassword { get; set; }
    }
}