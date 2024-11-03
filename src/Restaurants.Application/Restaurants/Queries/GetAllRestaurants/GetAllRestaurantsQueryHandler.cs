using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Application.RestaurantsData.DTO;
using AutoMapper;
using MediatR;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(IRestaurantRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetllAllRestaurantQuery, IEnumerable<RestaurantDTO>>
    {
        public async Task<IEnumerable<RestaurantDTO>> Handle(GetllAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await restaurantsRepository.GetAllAsync();
            var restaurantsDTOs = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);
            return restaurantsDTOs;
        }
    }
}