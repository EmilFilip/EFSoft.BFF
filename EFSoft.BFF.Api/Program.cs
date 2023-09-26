using EFSoft.BFF.Api.CustomerEndpoints;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    //var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    //builder.Configuration.AddAzureAppConfiguration(options =>
    //{
    //    options.Connect(appConfigurationConnectionString)
    //            .ConfigureRefresh(refresh =>
    //            {
    //                refresh.Register("Settings:Sentinel", refreshAll: true).SetCacheExpiration(new TimeSpan(0, 1, 0));
    //            });
    //});
}

builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BFF Microservice", Version = "v1" });
});
//builder.Services.RegisterLocalAuthentication(builder.Configuration);
builder.Services.RegisterHttpClientBuilder(builder.Configuration);
//builder.Services.AddSwaggerAuthentication();

builder.Logging.AddConsole();

var app = builder.Build();
app.MapCustomerEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF Microservice V1");
    });
}

app.MapGet("/", () => "Hello World!");

//app.UseAuthentication();
//app.UseAuthorization();

app.Run();
