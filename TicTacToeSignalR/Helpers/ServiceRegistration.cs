using Microsoft.AspNetCore.Identity;
using TicTacToeSignalR.DataBaseAccess;
using TicTacToeSignalR.Models;

namespace TicTacToeSignalR.Helpers
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddIdentities(this IServiceCollection services)
        {

            services.AddIdentity<User, IdentityRole>(opt =>
            { 
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Lockout.MaxFailedAccessAttempts = 1111;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<GameDBContext>();
            return services;
        }
    }
}
