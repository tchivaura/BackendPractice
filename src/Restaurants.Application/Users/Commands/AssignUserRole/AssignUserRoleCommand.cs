using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommand : IRequest
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;

    }
}