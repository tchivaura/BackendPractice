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


namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            }
            await restaurantsRepository.Delete(restaurant);

        }
    }
}