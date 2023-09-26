namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterAuthentication
{
    public static AuthenticationBuilder RegisterLocalAuthentication(
        this IServiceCollection services,
             IConfiguration configuration)
    {
        var jwtSecret = configuration["JwtSecret"] ?? throw new ConfigNotFoundException("JwtSecret is either null or empty");
        var jwtIssuer = configuration["JwtIssuer"] ?? throw new ConfigNotFoundException("JwtIssuer is either null or empty");
        var jwtAudiences = configuration.GetSection("JwtAudience").Value == null
            ? throw new ConfigNotFoundException("JwtAudience is either null or empty")
            : configuration.GetSection("JwtAudience").Value!.Split(" ");

        byte[] publicKeyBytes = Convert.FromBase64String(jwtSecret);
        RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(publicKeyBytes);

        RSAParameters rsaParameters = new()
        {
            Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
            Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned(),
        };

        return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudiences = jwtAudiences,
                IssuerSigningKey = new RsaSecurityKey(rsaParameters)
            };

            x.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }

                    return Task.CompletedTask;
                },
            };
        });
    }
}
