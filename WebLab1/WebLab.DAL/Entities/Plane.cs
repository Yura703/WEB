using System;
using System.Collections.Generic;
using System.Text;

namespace WebLab.DAL.Entities
{
    public class Plane
    {
        public int PlaneId { get; set; } // id 
        public string PlaneName { get; set; } // название 
        public string Description { get; set; } // описание 
        public int Speed { get; set; } // скорость
        public string Image { get; set; } // имя файла изображения
                                          // Навигационные свойства
        /// <summary>
        /// группа самолетов (например военные, частные и т.д.)
        /// </summary>
        public int PlaneGroupId { get; set; }
        public PlaneGroup Group { get; set; }
    }

    public class PlaneGroup
    {
        public int PlaneGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Plane> Planes { get; set; }
    }
}
