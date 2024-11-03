using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurants.Application.RestaurantsData.DTO;
using FluentValidation;



namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {

        public CreateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name).Length(3, 100).WithMessage("Restaurant name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }

    }
}