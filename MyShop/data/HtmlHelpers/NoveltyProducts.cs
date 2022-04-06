using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.data.ModelViews;
using System.Text.Encodings.Web;

namespace MyShop.data.HtmlHelpers
{
    public static class NoveltyProducts
    {
        public static HtmlString GetNoveltyProducts(this IHtmlHelper html, ModelViewIndex model)
        {
            TagBuilder products_slick = new TagBuilder("div");
            products_slick.Attributes.Add("class", "products-slick");
            products_slick.Attributes.Add("data-nav", "#slick-nav-1");

            foreach (var item in model.products)
            {
                TagBuilder product = new TagBuilder("div");
                product.Attributes.Add("class", "product");

                TagBuilder product_img = new TagBuilder("div");
                product_img.Attributes.Add("class", "product-img");
                    TagBuilder img = new TagBuilder("img");
                    img.Attributes.Add("src", $"/img/{item.GetType().Name}/{item.brand.Name}/{item.Img}");
                    img.Attributes.Add("alt", "");
                    TagBuilder product_label = new TagBuilder("div");
                    product_label.Attributes.Add("class", "product-label");
                    TagBuilder span = new TagBuilder("span");
                        span.Attributes.Add("class", "new");
                        span.InnerHtml.Append("NEW");            
                    product_label.InnerHtml.AppendHtml(span);
                product_img.InnerHtml.AppendHtml(img);
                product_img.InnerHtml.AppendHtml(product_label);

                TagBuilder product_body = new TagBuilder("div");
                product_body.Attributes.Add("class", "product-body");
                    TagBuilder product_category = new TagBuilder("p");
                    product_category.Attributes.Add("class", "product-category");
                    product_category.InnerHtml.AppendHtml(item.brand.Name);
                    TagBuilder product_name = new TagBuilder("h3");
                    product_name.Attributes.Add("class", "product-name");
                        TagBuilder product_name_a = new TagBuilder("a");
                        product_name_a.Attributes.Add("href", "#");
                        product_name_a.InnerHtml.Append(item.Name);
                    product_name.InnerHtml.AppendHtml(product_name_a);
                    TagBuilder product_price = new TagBuilder("h4");
                    product_price.Attributes.Add("class", "product-price");
                    product_price.InnerHtml.Append(item.Price.ToString("c"));
                product_body.InnerHtml.AppendHtml(product_category);
                product_body.InnerHtml.AppendHtml(product_name);
                product_body.InnerHtml.AppendHtml(product_price);

                TagBuilder add_to_cart = new TagBuilder("div");
                add_to_cart.Attributes.Add("class", "add-to-cart");
                    TagBuilder add_to_cart_btn = new TagBuilder("button");
                    add_to_cart_btn.Attributes.Add("class", "add-to-cart-btn");
                        TagBuilder fa_shopping_cart = new TagBuilder("i");
                        fa_shopping_cart.Attributes.Add("class", "fa fa-shopping-cart");
                    add_to_cart_btn.InnerHtml.AppendHtml(fa_shopping_cart);
                    add_to_cart_btn.InnerHtml.Append(" В корзину");
                add_to_cart.InnerHtml.AppendHtml(add_to_cart_btn);

                product.InnerHtml.AppendHtml(product_img);
                product.InnerHtml.AppendHtml(product_body);
                product.InnerHtml.AppendHtml(add_to_cart);

                products_slick.InnerHtml.AppendHtml(product);
            }

            var writer = new System.IO.StringWriter();
            products_slick.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
