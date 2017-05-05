namespace NewspaperKids.Models.BindingModels
{
    using System.Web;

    public class EditArticleBindingModel
    {
        public int Id { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}