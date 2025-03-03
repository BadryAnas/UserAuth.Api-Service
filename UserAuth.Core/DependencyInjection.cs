using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Dtos;
using UserAuth.Core.Mapper;
using UserAuth.Core.Services;
using UserAuth.Core.ServicesContract;
using UserAuth.Core.Validators;

namespace UserAuth.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            services.AddValidatorsFromAssemblyContaining<LoginDtoValidators>();

            return services;
        }
    }
}
