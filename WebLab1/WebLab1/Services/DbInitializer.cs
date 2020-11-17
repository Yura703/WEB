using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.PlaneGroups.Any())
            {
                context.PlaneGroups.AddRange(
                new List<PlaneGroup>
                {
                    new PlaneGroup {GroupName="Планеры"},
                    new PlaneGroup {GroupName="Пассажирские"},
                    new PlaneGroup {GroupName="Частные"},
                    new PlaneGroup {GroupName="Истребители"},
                    new PlaneGroup {GroupName="Бомбордировщики"},
                    new PlaneGroup {GroupName="Штурмовики"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Planes.Any())
            {
                context.Planes.AddRange(new List<Plane>
                {
                    new Plane {PlaneName="А320", Description="Максимальное количество пассажиров - 180", Speed =840, PlaneGroupId=2, Image="А320.jpg" },
                    new Plane {PlaneName="RF-01", Description="Летит без двигателя", Speed =250, PlaneGroupId=1, Image="planer.jpg" },
                    new Plane {PlaneName="Cessna-172", Description="Самый массовый самолет в истории авиации", Speed =226, PlaneGroupId=3, Image="Cessna_172rg.jpg" },
                    new Plane {PlaneName="B-2 Spirit", Description="Самый незаметный бомбардировщик в мире", Speed =1010, PlaneGroupId=5, Image="b-2_spirit.jpg" },
                    new Plane {PlaneName="МиГ-25", Description="Самый быстрый истребитель", Speed =3395, PlaneGroupId=4, Image="Миг-25.jpg" }                   
                });
                await context.SaveChangesAsync();
            }
        }

    }
}
