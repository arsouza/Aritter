namespace Ritter.Infra.Data.Seedwork
{
    public interface ISql
    {
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
