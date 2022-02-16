using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var secret = "ThisIsMyPrivateKey";
var key = Encoding.ASCII.GetBytes(secret);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
    });

builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
builder.Host.ConfigureLogging(logging => logging.AddConsole());
if (builder.Environment.IsDevelopment())
{
    builder.Host.ConfigureAppConfiguration(config =>
        config.AddJsonFile("ocelot.development.json"));
}

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseAuthentication();
app.UseOcelot().Wait();
app.Run();
