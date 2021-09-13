using Microsoft.Extensions.DependencyInjection;
using Sms.DataSource;
using Sms.Repositories.User;

namespace Sms.App
{
    public static class DIMapper
    {
        public static void MapDependencies(this IServiceCollection services)
        {
            services.AddScoped<Sms.DataSource.IDataOperations, Sms.DataSource.DataOperations>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<Services.User.IUserService,Services.User.UserService>()
                .AddTransient<Repositories.Master.IRoleRepository,Repositories.Master.RoleRepository>()
                .AddTransient<Services.Master.IRoleService,Services.Master.RoleService>();
        }
    }
}