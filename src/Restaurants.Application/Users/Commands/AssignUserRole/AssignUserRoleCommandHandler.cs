using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Entities;
using MediatR;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException(nameof(Users), request.UserEmail);
            var role = await roleManager.FindByNameAsync(request.RoleName) ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.AddToRoleAsync(user, role.Name!);


        }
    }
}