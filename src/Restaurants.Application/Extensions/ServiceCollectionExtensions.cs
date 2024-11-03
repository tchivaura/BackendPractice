using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
//using MediatR.Extensions;
using Restaurants.Application.Users;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationaseembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationaseembly));

            services.AddAutoMapper(applicationaseembly);
            services.AddValidatorsFromAssembly(applicationaseembly).AddFluentValidationAutoValidation();
            services.AddScoped<IUserContext, UserContext>();
            services.AddHttpContextAccessor();
        }
    }
}