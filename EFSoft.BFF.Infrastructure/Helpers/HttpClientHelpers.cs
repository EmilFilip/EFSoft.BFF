namespace EFSoft.BFF.Infrastructure.Helpers;

public static class HttpClientHelpers
{
    public static StringContent GetStringContent(object serializationObject)
    {
        var json = JsonSerializer.Serialize(serializationObject);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return content;
    }
}
