namespace Aritter.Manager.Web.Core.Aggregates
{
	public class RouteData
	{
		public string RequestArea { get; set; }
		public string RequestController { get; set; }
		public string RequestAction { get; set; }
		public bool RequestActionAllowAnonymous { get; set; }
		public string CurrentPath { get; set; }
	}
}
