using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Application.RestaurantsData.DTO;
using AutoMapper;
using MediatR;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.DishesData.Commands.CreateDish
{
    public class CreateDishCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public int RestaurantId { get; set; }

    }
}