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


namespace Restaurants.Application.Restaurants.Queries.GetRestaurantByID
{
    public class GetRestaurantByIDQueryHandler(IRestaurantRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetRestaurantByIDQuery, RestaurantDTO>
    {
        public async Task<RestaurantDTO> Handle(GetRestaurantByIDQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            var restaurantDT0 = mapper.Map<RestaurantDTO>(restaurant);
            return restaurantDT0;
        }
    }
}