using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.DishesData.Commands.CreateDish
{
    public class CreateDishValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishValidator()
        {
            RuleFor(dish => dish.Price)  // Correct object reference
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative number");
        }
    }

}