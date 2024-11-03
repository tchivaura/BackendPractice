using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Application.DishesData.DTO;

namespace Restaurants.Application.DishesData.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get; } = restaurantId;

    }
}