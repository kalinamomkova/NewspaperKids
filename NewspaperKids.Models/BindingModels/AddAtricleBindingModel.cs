namespace NewspaperKids.Models.BindingModels
{
    using System;
    using System.Web;

    public class AddAtricleBindingModel
    {
        public string Title { get; set; }

        public int? CategoryId { get; set; }

        public int SubCategory { get; set; }

        public int AuthorId { get; set; }

        public DateTime CreationDate { get; set; }

        public byte[] Content { get; set; }

        public bool IsApproved { get; set; }

        public int ImageId { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}