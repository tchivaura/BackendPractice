using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Application.RestaurantsData.DTO;
using AutoMapper;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.DishesData.Commands.CreateDish
{
    public class CreateDishCommandHandler(IRestaurantRepository restaurantsRepository, IDishesRepository dishesRepository, IMapper mapper, ILogger<CreateDishCommandHandler> logger) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish:{@DishRequest}", request);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            var dish = mapper.Map<Dish>(request);
            return await dishesRepository.Create(dish);

        }
    }
}