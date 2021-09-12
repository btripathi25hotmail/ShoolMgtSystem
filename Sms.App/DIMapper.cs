using Microsoft.Extensions.DependencyInjection;
using Sms.Repositories;
using Sms.Repositories.User;

namespace Sms.App
{
    public static class DIMapper
    {
        public static void MapDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbOperations, DbOperations>()
                .AddTransient<IUserRepository, UserRepository>();
        }
    }
}