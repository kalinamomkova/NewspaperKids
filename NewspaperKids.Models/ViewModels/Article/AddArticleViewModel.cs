namespace NewspaperKids.Models.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using NewspaperKids.Models.ViewModels.Category;

    public class AddArticleViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        //[RegularExpression("[а-яА-Я\\ ]+", ErrorMessage = "Заглавието може да бъде само на кирилица")]
        [MinLength(2, ErrorMessage = "Заглавието трябва да бъде дълго поне 2 символа")]
        [DisplayName("Заглавие")]
        public string Title { get; set; }

        public IEnumerable<ParentCategoryViewModel> ParentCategories { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DisplayName("Снимка")]
        [RegularExpression("^.+(\\.jpg|\\.JPG)$", ErrorMessage = "Можете да качите само .jpg")]
        public HttpPostedFileBase Image { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DisplayName("Файл")]
        [RegularExpression("^.+(\\.PDF|\\.pdf)$", ErrorMessage = "Можете да качите само .pdf")]
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public int SubCategory { get; set; }

        public int AuthorId { get; set; }
    }
}