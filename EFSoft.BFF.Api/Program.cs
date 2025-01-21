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
builder.Services.AddFeatureManagement();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Version"));
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<RegisterSwaggerOptions>();
builder.Services.AddHealthChecks();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();
builder.Services.RegisterCqrs(typeof(GetCustomerQuery).Assembly);

var app = builder.Build();

app.MapAllEndpoints();

app.MapHealthChecks("/health");
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
