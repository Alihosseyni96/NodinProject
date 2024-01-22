using Domain.ObjectMapping;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace NodinAPI.Common.Extensions
{
    public static class ProgramConfigurationsExtensions
    {
        public static void Config(this WebApplicationBuilder builder) 
        {
            //Context
            builder.Services.AddDbContext<NodinContext>(x =>
            {
                x.UseSqlServer(connectionString: builder.Configuration["ConnectionString:Nodin"]);
            });

            //Mapper
            builder.Services.AddAutoMapper(typeof(ProductMapper));

            //Mediator
            builder.Services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssemblies(typeof(Program).Assembly);
            });

            //Authentication 
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Name = "token";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                    options.SlidingExpiration = true;
                    options.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    };
                });
        }
    }
}
