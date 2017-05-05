namespace NewspaperKids.Models.ViewModels.Comment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AddCommentViewModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [MinLength(2, ErrorMessage = "Коментарът трябва да е с дължина поне 2 символа!")]
        [DisplayName("Коментар")]
        public string Content { get; set; }

        public int ArticleId { get; set; }
    }
}