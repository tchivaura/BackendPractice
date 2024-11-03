using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurants.Application.RestaurantsData.DTO;
using MediatR;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetllAllRestaurantQuery : IRequest<IEnumerable<RestaurantDTO>>
    {

    }
}