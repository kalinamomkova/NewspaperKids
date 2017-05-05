namespace NewspaperKids.Models.Entities
{
    using System.Collections.Generic;

    public class ParentCategory
    {
        public ParentCategory()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}