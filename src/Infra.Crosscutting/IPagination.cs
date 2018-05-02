namespace Ritter.Infra.Crosscutting
{
	public interface IPagination
	{
		int PageIndex { get; }

		int PageSize { get; }

		string OrderByName { get; }

		bool Ascending { get; }
	}
}
