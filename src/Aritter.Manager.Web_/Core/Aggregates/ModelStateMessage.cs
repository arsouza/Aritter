namespace Aritter.Manager.Web.Core.Aggregates
{
	public class ModelStateMessage
	{
		public ModelStateType Type { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
	}
}