using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.RepositoryContracts;
using UserAuth.Infrastructure.DbContexts;
using UserAuth.Infrastructure.Repository;

namespace UserAuth.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIfrastuctureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();

            return services;
        }
    }
}
