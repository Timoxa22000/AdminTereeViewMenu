using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Text.Encodings.Web;
using AdminTereeViewMenu.Models;

namespace AdminTereeViewMenu.App_Code
{
    public static class TreeViewMenuHelper
    {
        public static HtmlString CreateBaseList(this IHtmlHelper html, Category baseCategory)
        {
            //Создаем блок div с классом box
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "box");
            //Создаем разметку для подкатегорий базового объекта
            foreach (var item in baseCategory.ChildCategories)
            {
                if (item.ChildCategories.Count() > 0)
                {
                    div.InnerHtml.AppendHtml(HCategories(item));
                }
                var res = LineHCategories(item);
                div.InnerHtml.AppendHtml(res);
            }

            var writer = new System.IO.StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }

        //Если в тег li будем добавлять ветвь
        private static TagBuilder LineLiCategories()
        {
            TagBuilder li = new TagBuilder("li");
            return li;
        }
        //Если категория не имеет подкатегорий
        private static TagBuilder LineLiCategories(Category category)
        {
            TagBuilder li = new TagBuilder("li");
            li.InnerHtml.Append(category.Name);
            li.InnerHtml.AppendHtml(GetLinkStick("rel-category", "🔀"));
            li.InnerHtml.AppendHtml(GetLinkStick("del-category", "🞬"));
            li.InnerHtml.AppendHtml(GetLinkStick("edit-category", "🖉"));
            li.InnerHtml.AppendHtml(GetLinkStick("add-category", "🞦"));

            return li;
        }

        //Тег h3 для элемента меню
        private static TagBuilder HCategories(Category category)
        {
            TagBuilder h3 = new TagBuilder("h3");
            h3.InnerHtml.Append(category.Name);
            TagBuilder spanH3 = new TagBuilder("span");
            spanH3.Attributes.Add("class", "expand");
            spanH3.InnerHtml.Append("🔽");
            h3.InnerHtml.AppendHtml(spanH3);

            h3.InnerHtml.AppendHtml(GetLinkStick("rel-category", "🔀"));
            h3.InnerHtml.AppendHtml(GetLinkStick("del-category", "🞬"));
            h3.InnerHtml.AppendHtml(GetLinkStick("edit-category", "🖉"));
            h3.InnerHtml.AppendHtml(GetLinkStick("add-category", "🞦"));

            return h3;
        }

        private static TagBuilder GetLinkStick(string nameClass, string simbol)
        {
            TagBuilder linkTag = new TagBuilder("a");
            linkTag.Attributes.Add("class", nameClass);
            linkTag.InnerHtml.Append(simbol);
            return linkTag;
        }

        private static TagBuilder LineHCategories(Category category)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes.Add("class", "categories");

            if (category.ChildCategories.Count() > 0)
            {
                foreach (var item in category.ChildCategories)
                {
                    if (item.ChildCategories.Count() > 0)
                    {
                        var li = LineLiCategories();
                        li.InnerHtml.AppendHtml(HCategories(item));
                        li.InnerHtml.AppendHtml(LineHCategories(item));
                        ul.InnerHtml.AppendHtml(li);
                    }
                    else
                    {
                        ul.InnerHtml.AppendHtml(LineLiCategories(item));
                    }
                }
            }
            else
            {
                ul.InnerHtml.AppendHtml(LineLiCategories(category));
            }

            return ul;
        }

    }
}
