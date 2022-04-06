using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.data.ModelViews;
using System.Text.Encodings.Web;

namespace MyShop.data.HtmlHelpers
{
    public static class ChoiceBrands
    {
        public static HtmlString GetChoiceBrands(this IHtmlHelper html, ModelViewIndex model)
        {
            TagBuilder row = new TagBuilder("div");
            row.Attributes.Add("class", "row");

            foreach (var item in model.brands)
            {
                TagBuilder col = new TagBuilder("div");
                col.Attributes.Add("class", "col-md-4 col-xs-6");
                    TagBuilder shop = new TagBuilder("div");
                    shop.Attributes.Add("class", "shop");
                        TagBuilder shop_img = new TagBuilder("div");
                        shop_img.Attributes.Add("class", "shop-img");
                            TagBuilder img = new TagBuilder("img");
                            img.Attributes.Add("src", $"/img/{item.GetType().Name}/{item.Img}");
                            img.Attributes.Add("alt", "");
                        shop_img.InnerHtml.AppendHtml(img);
                        TagBuilder shop_body = new TagBuilder("div");
                        shop_body.Attributes.Add("class", "shop-body");
                            TagBuilder h3 = new TagBuilder("h3");
                            h3.InnerHtml.Append(item.Name);
                            TagBuilder a = new TagBuilder("a");
                            a.Attributes.Add("class", "cta-btn");
                            a.Attributes.Add("href", "#");
                            a.InnerHtml.Append("Подробнее ");
                                TagBuilder i = new TagBuilder("i");
                                i.Attributes.Add("class", "fa fa-arrow-circle-right");
                            a.InnerHtml.AppendHtml(i);
                        shop_body.InnerHtml.AppendHtml(h3);
                        shop_body.InnerHtml.AppendHtml(a);
                    shop.InnerHtml.AppendHtml(shop_img);
                    shop.InnerHtml.AppendHtml(shop_body);
                col.InnerHtml.AppendHtml(shop);
                row.InnerHtml.AppendHtml(col);
            }

            var writer = new System.IO.StringWriter();
            row.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
