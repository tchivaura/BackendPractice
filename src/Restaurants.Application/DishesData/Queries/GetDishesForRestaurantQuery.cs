using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Application.RestaurantsData.DTO;
using AutoMapper;
using Restaurants.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Application.DishesData.DTO;

namespace Restaurants.Application.DishesData.Queries
{
    public class GetDishesForRestaurantQuery(int restaurantID) : IRequest<IEnumerable<DishDTO>>
    {
        public int RestaurantId { get; } = restaurantID;
    }
}