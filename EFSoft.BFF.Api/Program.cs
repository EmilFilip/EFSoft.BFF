var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect(appConfigurationConnectionString)
                .ConfigureRefresh(refresh =>
                {
                    refresh.Register("Settings:Sentinel", refreshAll: true).SetCacheExpiration(new TimeSpan(0, 1, 0));
                });
    });
    builder.Logging.AddConsole();
}

builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();

builder.Services.RegisterLocalAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddLocalHttpClients(builder.Configuration);
builder.Services.AddSwaggerAuthentication();

var app = builder.Build();
app.MapLocalEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF Microservice V1");
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
