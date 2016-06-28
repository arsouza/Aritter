namespace Aritter.Infra.Crosscutting.Logging
{
    public interface ILoggerFactory
	{
		ILogger Create();
	}
}