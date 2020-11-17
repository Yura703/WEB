using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab.Models
{
    public class MenuItem  //параметры элементов меню сайта
    {
        // является ли страницей или методом контроллера
        public bool IsPage { get; set; } = false;
        // имя области
        public string Area { get; set; } = "";
        // имя действия контроллера
        public string Action { get; set; } = "";
        // имя контроллера
        public string Controller { get; set; } = "";
        // имя страницы
        public string Page { get; set; } = "";
        // класс CSS для текущего пункта меню
        public string Active { get; set; } = "";
        // текст надписи
        public string Text { get; set; } = "";
    }
}
