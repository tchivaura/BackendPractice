using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand
{
    public class UpdateRestaurantCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool HasDelivery { get; set; }
    }
}