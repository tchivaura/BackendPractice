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
    public class GetDishesForRestaurantQueryHandler(IRestaurantRepository restaurantsRepository, IDishesRepository dishesRepository, IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDTO>>
    {
        public async Task<IEnumerable<DishDTO>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            var results = mapper.Map<IEnumerable<DishDTO>>(restaurant.Dish);
            return results;
        }
    }
}