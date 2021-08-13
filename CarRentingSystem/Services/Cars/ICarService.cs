
namespace CarRentingSystem.Services.Cars
{
    using CarRentingSystem.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        CarQueryServiceModel All(
            string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage);

        CarDetailsServiceModel Details(int id);

        int Create(
            string brand,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId,
            int dealerId);

        IEnumerable<CarServiceModel> ByUser(string userId);

        IEnumerable<string> AllBrands();

        IEnumerable<CarCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);
    }
}
