﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PostService.Extensions
{
    public static class AddAuthBarrier
    {
        public static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration.GetSection("JWToptions:Audience").Value,
                    ValidIssuer = builder.Configuration.GetSection("JWToptions:Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtOptions:SecretKey").Value))
                };
            });
            return builder;
        }
    }
}
