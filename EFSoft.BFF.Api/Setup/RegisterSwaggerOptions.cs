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
                Version = versionDescription.ApiVersion.ToString(),
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
