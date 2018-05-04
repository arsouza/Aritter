namespace Ritter.Infra.Data
{
    public interface ISql
    {
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
