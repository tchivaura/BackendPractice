using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Application.DishesData.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using AutoMapper;

namespace Restaurants.Application.DishesData.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler(IRestaurantRepository restaurantsRepository, IDishesRepository dishesRepository, IMapper mapper) : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            await dishesRepository.Delete(restaurant.Dish);
        }
    }
}