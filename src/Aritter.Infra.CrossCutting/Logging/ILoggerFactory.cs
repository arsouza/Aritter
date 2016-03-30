namespace Aritter.Infra.CrossCutting.Logging
{
	public interface ILoggerFactory
	{
		ILogger Create();
	}
}