var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    _ = builder.Configuration.AddAzureAppConfiguration(options =>
    {
        _ = options.Connect(appConfigurationConnectionString)
                .ConfigureRefresh(refresh =>
                {
                    _ = refresh.Register("Settings:Sentinel", refreshAll: true).SetRefreshInterval(new TimeSpan(0, 1, 0));
                });
    });
}

builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();

builder.Services.RegisterLocalAuthentication(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddLocalHttpClients(builder.Configuration);
builder.Services.AddSwaggerAuthentication();

builder.Services.AddHealthChecks();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();
builder.Services.RegisterLocalServices();

var app = builder.Build();
app.MapCarter();
app.MapHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF Microservice V1");
});

app.UseAuthentication();
app.UseAuthorization();

app.Run();
