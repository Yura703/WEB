using WebLab.DAL.Entities;
using WebLab.Models;
using Xunit;
namespace WebLab.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Plane>.GetModel(TestData.GetPlanesList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Plane>.GetModel(TestData.GetPlanesList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Plane>.GetModel(TestData.GetPlanesList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].PlaneId);
        }
    }
}