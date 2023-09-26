namespace EFSoft.BFF.Api.Exceptions;

public class ConfigNotFoundException : Exception
{
    public ConfigNotFoundException(string message)
        : base(message)
    {
    }
}
