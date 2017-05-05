namespace NewspaperKids.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    public static class HtmlExtentions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, byte[] imageUrl, string alt = null, string width = "150px",
            string height = "150px", params string[] cssClasses)
        {
            TagBuilder builder = new TagBuilder("img");
            var base64 = Convert.ToBase64String(imageUrl);
            var imgSrc = $"data:image/gif;base64,{base64}";
            builder.MergeAttribute("src",  imgSrc);
            if (alt != null)
            {
                builder.MergeAttribute("alt", alt);
            }
            foreach (string cssClass in cssClasses)
            {
                builder.AddCssClass(cssClass);
            }
            builder.MergeAttribute("width", width);
            builder.MergeAttribute("height", height);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Pdf(this HtmlHelper helper, byte[] pdf, params string[] cssClasses)
        {
            TagBuilder pdfBuilder = new TagBuilder("embed");
            var base64 = Convert.ToBase64String(pdf);
            var imgSrc = $"data:application/pdf;base64,{base64}";
            pdfBuilder.MergeAttribute("src", imgSrc);
            foreach (string cssClass in cssClasses)
            {
                pdfBuilder.AddCssClass(cssClass);
            }
            return new MvcHtmlString(pdfBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Table<T>(this HtmlHelper helper, IEnumerable<T> models, params string[] cssClasses)
        {
            TagBuilder table = new TagBuilder("table");
            StringBuilder tableInnerHtml = new StringBuilder();
            string[] propertyNames = typeof(T).GetProperties().Select(info => info.Name).ToArray();
            foreach (string cssClass in cssClasses)
            {
                table.AddCssClass(cssClass);
            }

            TagBuilder tableHeaderRow = new TagBuilder("tr");
            StringBuilder tableHeaderInnerHtml = new StringBuilder();
            foreach (string propertyName in propertyNames)
            {
                TagBuilder tableData = new TagBuilder("th");
                tableData.InnerHtml = propertyName;
                tableHeaderInnerHtml.Append(tableData);
            }
            tableHeaderRow.InnerHtml = tableHeaderInnerHtml.ToString();
            tableInnerHtml.Append(tableHeaderRow);

            foreach (var model in models)
            {
                TagBuilder tableDataRow = new TagBuilder("tr");
                StringBuilder tableDataRowInnerHtml = new StringBuilder();
                foreach (string propertyName in propertyNames)
                {
                    TagBuilder tableData = new TagBuilder("td");
                    tableData.InnerHtml = typeof(T).GetProperty(propertyName).GetValue(model).ToString();
                    tableDataRowInnerHtml.Append(tableData);
                }

                tableDataRow.InnerHtml = tableDataRowInnerHtml.ToString();
                tableInnerHtml.Append(tableDataRow);
            }
            table.InnerHtml = tableInnerHtml.ToString();
                                        
            return new MvcHtmlString(table.ToString(TagRenderMode.Normal));
        }
    }
}
