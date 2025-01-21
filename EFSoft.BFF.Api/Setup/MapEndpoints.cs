namespace EFSoft.BFF.Api.Setup;

public static class MapEndpoints
{
    public static void MapAllEndpoints(this WebApplication app)
    {
        var apiVersionSet = app
            .NewApiVersionSet()
            .HasApiVersion(new ApiVersion(2))
            .HasApiVersion(new ApiVersion(1))
            //.HasDeprecatedApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var versionedGroup = app.MapGroup("api/v{apiVersion:apiVersion}/")
                                .WithApiVersionSet(apiVersionSet);
        _ = versionedGroup.MapCarter();
    }
}
