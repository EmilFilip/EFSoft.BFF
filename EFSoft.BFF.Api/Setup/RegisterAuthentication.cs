namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterAuthentication
{
    [ExcludeFromCodeCoverage]
    public static AuthenticationBuilder RegisterLocalAuthentication(
        this IServiceCollection services,
             IConfiguration configuration)
    {
        var jwtSecret = configuration["JwtSecret"] ?? throw new ConfigNotFoundException("JwtSecret is either null or empty");

        var key = Encoding.ASCII.GetBytes(jwtSecret);
        return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Append("Token-Expired", "true");
                        }

                        return Task.CompletedTask;
                    },
                };
            });
    }
}
