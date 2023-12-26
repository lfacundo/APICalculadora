using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infra
{
    public class BDsession : IDisposable
    {
        public IDbConnection Connection { get; }
        public BDsession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString(@"DefaultConnection"));
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}