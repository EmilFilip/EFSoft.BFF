namespace EFSoft.BFF.Api.Setup;

public class RegisterSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    : IConfigureNamedOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions swaggerGenOptions)
    {
        foreach (var versionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            var openApiInfo = new OpenApiInfo
            {
                Title = $"BFF Microservice v{versionDescription.ApiVersion}",
                Version = versionDescription.IsDeprecated
                    ? $"{versionDescription.ApiVersion.ToString()} This API version has been deprecated."
                    : versionDescription.ApiVersion.ToString(),
                Description = "BFF Service, the entry point to access the rest of the microservices"
            };

            swaggerGenOptions.SwaggerDoc(versionDescription.GroupName, openApiInfo);
        }
    }

    public void Configure(
        string? name,
        SwaggerGenOptions swaggerGenOptions)
    {
        Configure(swaggerGenOptions);
    }
}
