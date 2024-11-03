using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Restaurants.Domain.Entities;
using Restaurants.Application.Restaurants.Commands;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;

namespace Restaurants.Application.RestaurantsData.DTO

{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()




        {

            CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }
            ));
            CreateMap<Restaurant, RestaurantDTO>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(d => d.Dish, opt => opt.MapFrom(src => src.Dish));
        }


    }
}