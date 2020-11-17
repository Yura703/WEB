using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace WebLab.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        LinkGenerator _linkGenerator;  // номер текущей страницы
        public int PageCurrent { get; set; }  // общее количество страниц
        public int PageTotal { get; set; }   // дополнительный css класс пейджера
        public string PagerClass { get; set; }  // имя action
        public string Action { get; set; }  // имя контроллера
        public string Controller { get; set; }
        public int? GroupId { get; set; }

        public PagerTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)  // контейнер разметки пейджера
        {
            output.TagName = "nav"; // пейджер
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);
            for (int i = 1; i <= PageTotal; i++)
            {
                var url = _linkGenerator.GetPathByAction(Action, Controller, new 
                        {
                            pageNo = i, group = GroupId == 0 ? null : GroupId
                        });               
                var item = GetPagerItem(url: url, text: i.ToString(), active: i == PageCurrent, disabled: i == PageCurrent);    // получение разметки одной кнопки пейджера             
                ulTag.InnerHtml.AppendHtml(item);  // добавить кнопку в разметку пейджера
            }            
            output.Content.AppendHtml(ulTag); // добавить пейджер в контейнер
        }
        /// <summary>
        /// Генерирует разметку одной кнопки пейджера
        /// </summary>
        /// <param name="url">адрес</param>
        /// <param name="text">текст кнопки пейджера</param>
        /// <param name="active">признак текущей страницы</param>
        /// <param name="disabled">запретить доступ к кнопке</param>
        /// <returns>объект класса TagBuilder</returns>
        
        private TagBuilder GetPagerItem(string url, string text, bool active = false, bool disabled = false)
        {            
            var liTag = new TagBuilder("li"); // создать тэг <li>
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");            
            var aTag = new TagBuilder("a"); //liTag.AddCssClass(disabled ? "disabled" : "");// создать тэг <a>
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);           
            liTag.InnerHtml.AppendHtml(aTag); // добавить тэг <a> внутрь <li>
            return liTag;
        }
    }
}