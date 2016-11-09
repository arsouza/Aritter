namespace Aritter.Infra.Crosscutting.Logging
{
    public interface ILoggerFactory : Microsoft.Extensions.Logging.ILoggerFactory
    {
        ILogger Create();
    }
}
