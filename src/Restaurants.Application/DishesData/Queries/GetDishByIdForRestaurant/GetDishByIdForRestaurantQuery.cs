using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Application.DishesData.DTO;
namespace Restaurants.Application.DishesData.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDTO>
    {
        public int RestaurantId { get; } = restaurantId;
        public int DishId { get; } = dishId;

    }
}