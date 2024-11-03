using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Restaurants.Domain.Entities;
using Restaurants.Application.DishesData.Commands.CreateDish;

namespace Restaurants.Application.DishesData.DTO
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDTO>();
            CreateMap<CreateDishCommand, Dish>();
        }
    }
}