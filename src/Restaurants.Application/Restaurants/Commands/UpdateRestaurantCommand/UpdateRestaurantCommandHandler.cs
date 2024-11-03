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


namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand
{
    public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            }
            restaurant.Name = request.Name;
            restaurant.Description = request.Description;
            restaurant.HasDelivery = request.HasDelivery;
            await restaurantsRepository.SaveChanges();

        }
    }
}