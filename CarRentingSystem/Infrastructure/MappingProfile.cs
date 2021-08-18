
namespace CarRentingSystem.Infrastructure
{
    using AutoMapper;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Services.Cars.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CarDetailsServiceModel, CarFormModel>();
        }
    }
}
