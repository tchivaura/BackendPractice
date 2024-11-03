using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;


namespace Restaurants.Application.Users.Commands
{
    public class UpdateUserDetailsCommandHandler(IUserContext userContext, IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            var dbuser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
            if (dbuser == null)
            {
                throw new NotFoundException(nameof(User), user!.Id);
            }
            dbuser.Nationality = request.Nationality;
            dbuser.DateOfBirth = request.DateOfBirth;
            await userStore.UpdateAsync(dbuser, cancellationToken);

        }
    }
}