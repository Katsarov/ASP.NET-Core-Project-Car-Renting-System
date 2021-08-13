namespace CarRentingSystem.Services.Dealers
{

    public interface IDealerService
    {
        public bool IsDealer(string userId);    //Метода проверява дали текущия юзър е дилър или не. Връща TRUE or FALSE

        public int GetIdByUser(string userId);    //Id-то на юзъра
    }
}
