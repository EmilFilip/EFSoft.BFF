namespace EFSoft.BFF.Api.Helpers;

public static class HttpClientHelpers
{
    public static StringContent GetStringContent(object serializationObject)
    {
        string body = JsonSerializer.Serialize(serializationObject);
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return content;
    }
}
