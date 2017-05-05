namespace NewspaperKids.Models.ViewModels.Article
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class EditArticleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Коментар")]
        public string Comment { get; set; }

        [DisplayName("Снимка")]
        [RegularExpression("^.+(\\.jpg|\\.JPG)$", ErrorMessage = "Можете да качите само .jpg")]
        public HttpPostedFileBase Image { get; set; }

        [DisplayName("Файл")]
        [RegularExpression("^.+(\\.PDF|\\.pdf)$", ErrorMessage = "Можете да качите само .pdf")]
        public HttpPostedFileBase File { get; set; }
    }
}