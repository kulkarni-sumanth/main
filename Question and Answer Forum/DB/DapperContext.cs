using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Question_and_Answer_Forum.DB
{
    public class DapperContext : IDapperContext
    {
        public string ConnectionString { get; set; }
        public IConfiguration Configuration { get; set; }
        public DapperContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}