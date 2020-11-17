using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Models
{
    public class TestData
    {
        public static List<Plane> GetPlanesList()
        {
            return new List<Plane>
            {
                new Plane{ PlaneId=1, PlaneGroupId=1},
                new Plane{ PlaneId=2, PlaneGroupId=1},
                new Plane{ PlaneId=3, PlaneGroupId=2},
                new Plane{ PlaneId=4, PlaneGroupId=2},
                new Plane{ PlaneId=5, PlaneGroupId=3}
            };
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }

        public static void FillContext(ApplicationDbContext context)
        {
            context.PlaneGroups.Add(new PlaneGroup { GroupName = "fake group" });
            context.AddRange(new List<Plane>
                {
                    new Plane{ PlaneId=1, PlaneGroupId=1},
                    new Plane{ PlaneId=2, PlaneGroupId=1},
                    new Plane{ PlaneId=3, PlaneGroupId=2},
                    new Plane{ PlaneId=4, PlaneGroupId=2},
                    new Plane{ PlaneId=5, PlaneGroupId=3}
                });
            context.SaveChanges();
        }
    }
}
