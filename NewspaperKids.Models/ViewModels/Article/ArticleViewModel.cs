namespace NewspaperKids.Models.ViewModels.Article
{
    using NewspaperKids.Models.ViewModels.Author;
    using NewspaperKids.Models.ViewModels.Category;
    using NewspaperKids.Models.ViewModels.Image;

    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AuthorViewModel Author { get; set; }

        public ImageViewModel Image { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}