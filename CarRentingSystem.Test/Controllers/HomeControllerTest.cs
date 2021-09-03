
namespace CarRentingSystem.Test.Controller
{
    using System.Linq;
    using CarRentingSystem.Controllers;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Services.Cars;
    using CarRentingSystem.Services.Statistics;
    using CarRentingSystem.Test.Mocks;
    using MyTested.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
            =>
            MyMvc
                .Pipeline()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index())
                .Which(controller => controller
                    .WithData(Enumerable.Range(0, 10).Select(i => new Car())))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IndexViewModel>()
                    .Passing(m => m.Cars.Count()));


        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            // Arrange
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            var cars = Enumerable
                .Range(0, 10)
                .Select(i => new Data.Models.Car());

            data.Cars.AddRange(cars);
            data.Users.Add(new Data.Models.User());

            data.SaveChanges();

            var carService = new CarService(data, mapper);
            var statisticsService = new StatisticsService(data);

            var homeController = new HomeController(carService, statisticsService);

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = viewResult.Model;

            var indexViewModel = Assert.IsType<IndexViewModel>(model);

            Assert.Equal(3, indexViewModel.Cars.Count);
            Assert.Equal(10, indexViewModel.TotalCars);
            Assert.Equal(1, indexViewModel.TotalUsers);
        }

        [Fact]
        public void ErrorShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(
                null, 
                null);

            // Act
            var result = homeController.Error();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }

}
