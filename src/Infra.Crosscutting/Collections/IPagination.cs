namespace Ritter.Infra.Crosscutting.Collections
{
	public interface IPagination
	{
		int PageIndex { get; }

		int PageSize { get; }

		string OrderByName { get; }

		bool Ascending { get; }
	}
}
