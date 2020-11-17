using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using WebLab.Controllers;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;
using WebLab.Models;
using Xunit;

namespace WebLab.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "testDb").Options;
        }

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            var controllerContext = new ControllerContext(); // Контекст контроллера            
            var moqHttpContext = new Mock<HttpContext>(); // Макет HttpContext
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;

            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context) { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(group: null, pageNo: page) as ViewResult;
                var model = result?.Model as List<Plane>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].PlaneId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }        

        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context) { ControllerContext = controllerContext };
                var comparer = Comparer<Plane>.GetComparer((d1, d2) => d1.PlaneId.Equals(d2.PlaneId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Plane>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Planes.ToArrayAsync().GetAwaiter().GetResult()[2], model[0], comparer);
            }
        }
    }
}



//var controllerContext = new ControllerContext(); // Контекст контроллера            
//            var moqHttpContext = new Mock<HttpContext>(); // Макет HttpContext
//            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
//            controllerContext.HttpContext = moqHttpContext.Object;
//            var controller = new ProductController()
//            { ControllerContext = controllerContext };
//            // arrange
//           // var controller = new ProductController();
//            var data = TestData.GetPlanesList();
//            controller._planes = data;
//            var comparer = Comparer<Plane>.GetComparer((d1, d2) => d1.PlaneId.Equals(d2.PlaneId));
//            // act
//            var result = controller.Index(2) as ViewResult; 
//            var model = result.Model as List<Plane>;
//            // assert
//            Assert.Equal(2, model.Count);
//            Assert.Equal(data[2], model[0], comparer);
//        }
//    }   
//}
