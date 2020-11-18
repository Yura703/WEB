using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebLab.DAL.Entities;
using WebLab.Models;
using WebLab.Extensions;
using WebLab.DAL.Data;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace WebLab.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;

        private ILogger _logger;
        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }
       
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var groupName = group.HasValue ? _context.PlaneGroups.Find(group.Value)?.GroupName : "all groups";//--------------
            _logger.LogInformation($"info: group={group}, page={pageNo}");
            var planesFiltered = _context.Planes.Where(d => !group.HasValue || d.PlaneGroupId == group.Value);

            //public IActionResult Index(int? group, int pageNo = 1)
        
            
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.PlaneGroups;
            //var planesFiltered = _planes.Where(d => !group.HasValue || d.PlaneGroupId == group.Value);
            //ViewData["Groups"] = _planeGroups; // Поместить список групп во ViewData            
            ViewData["CurrentGroup"] = group ?? 0; // Получить id текущей группы и поместить в TempData

            var model = ListViewModel<Plane>.GetModel(planesFiltered, pageNo,_pageSize);
            //if (Request.Headers["x-requested-with"].ToString().ToLower().Equals("xmlhttprequest"))
            //    return PartialView("_listpartial", model);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }



        /// <summary>
        /// Инициализация списков
        /// </summary>

        //private void SetupData()
        //{
        //    _planeGroups = new List<PlaneGroup>
        //    {
        //        new PlaneGroup {PlaneGroupId=1, GroupName="Планеры"},
        //        new PlaneGroup {PlaneGroupId=2, GroupName="Пассажирские"},
        //        new PlaneGroup {PlaneGroupId=3, GroupName="Частные"},
        //        new PlaneGroup {PlaneGroupId=4, GroupName="Истребители"},
        //        new PlaneGroup {PlaneGroupId=5, GroupName="Бомбордировщики"},
        //        new PlaneGroup {PlaneGroupId=6, GroupName="Штурмовики"}
        //    };
        //    _planes = new List<Plane>
        //    {
        //        new Plane {PlaneId = 1, PlaneName="А320", Description="Максимальное количество пассажиров - 180", Speed =840, PlaneGroupId=2, Image="А320.jpg" },
        //        new Plane {PlaneId = 2, PlaneName="RF-01", Description="Летит без двигателя", Speed =250, PlaneGroupId=1, Image="planer.jpg" },
        //        new Plane {PlaneId = 3, PlaneName="Cessna-172", Description="Самый массовый самолет в истории авиации", Speed =226, PlaneGroupId=3, Image="Cessna_172rg.jpg" },
        //        new Plane {PlaneId = 4, PlaneName="B-2 Spirit", Description="Самый незаметный бомбардировщик в мире", Speed =1010, PlaneGroupId=5, Image="b-2_spirit.jpg" },
        //        new Plane {PlaneId = 5, PlaneName="МиГ-25", Description="Самый быстрый истребитель", Speed =3395, PlaneGroupId=4, Image="Миг-25.jpg" }
        //    };
        //}
    }
}
        
