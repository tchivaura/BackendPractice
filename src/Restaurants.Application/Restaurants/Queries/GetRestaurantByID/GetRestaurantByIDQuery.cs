using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurants.Application.RestaurantsData.DTO;
using MediatR;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantByID
{
    public class GetRestaurantByIDQuery : IRequest<RestaurantDTO>
    {
        public int Id { get; set; }
    }
}