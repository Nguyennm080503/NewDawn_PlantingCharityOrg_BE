using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EXE201_NEWDAWN_BE.Extensions
{
    public static class IdentityServicesExtensions
    {
        const string ADMIN_ID = "1";
        const string MEMBER_ID = "2";
        public static IServiceCollection IdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                          policy.RequireClaim("RoleId", ADMIN_ID));
                options.AddPolicy("Member", policy =>
                          policy.RequireClaim("RoleId", MEMBER_ID));
            });
            return services;
        }
    }
}
