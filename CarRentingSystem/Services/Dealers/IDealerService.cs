namespace CarRentingSystem.Services.Dealers
{

    public interface IDealerService
    {
        public bool IsDealer(string userId);    //Check if current user is dealer
    }
}
