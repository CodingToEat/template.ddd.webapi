using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace MicroServiceName.App.Qry
{
    public interface IMicroServiceNameQry
    {
        Task<IEnumerable<MicroServiceNameModel>> GetAsync();
    }

    public class MicroServiceNameQry(IConfiguration configuration) : IMicroServiceNameQry
    {
        public const string ConnectionStringLabel = "ConnectionString";

        protected readonly string _connectionString = configuration[ConnectionStringLabel]
                                ?? throw new ArgumentNullException();

        public async Task<IEnumerable<MicroServiceNameModel>> GetAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT Id, Name FROM MicroServiceName WHERE IsActive = 1";
            return await connection.QueryAsync<MicroServiceNameModel>(query);
        }
    }

    public record MicroServiceNameModel(Guid Id, string Name);
}
