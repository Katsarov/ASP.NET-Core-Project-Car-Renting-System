namespace CarRentingSystem.Test.Services
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Services.Dealers;
    using CarRentingSystem.Test.Mocks;
    using Xunit;


    public class DealerServiceTest
    {
        private const string UserId = "TestUserId";

        [Fact]
        public void IsDealerShouldReturnTrueWhenUserIsDealer()
        {
            // Arrange
            using var data = this.GetDealerData();

            var dealerService = new DealerService(data);

            // Act
            var result = dealerService.IsDealer(UserId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDealerShouldReturnFalseWhenUserIsNotDealer()
        {
            // Arrange
            using var data = this.GetDealerData();

            var dealerService = new DealerService(data);

            // Act
            var result = dealerService.IsDealer("AnotherUserId");

            // Assert
            Assert.False(result);
        }

        private CarRentingDbContext GetDealerData()
        {
            var data = DatabaseMock.Instance;

            data.Dealers.Add(new Dealer { UserId = UserId });
            data.SaveChanges();

            return data;
        }
    }
}
