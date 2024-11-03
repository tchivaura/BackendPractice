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


namespace Restaurants.Application.DishesData.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(IRestaurantRepository restaurantsRepository, IDishesRepository dishesRepository, IMapper mapper) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDTO>
    {
        public async Task<DishDTO> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            var dish = restaurant.Dish.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }
            var result = mapper.Map<DishDTO>(dish);
            return result;
        }
    }
}