using System.Data;
using System.Data.Common;

namespace CorporateQnA.DB
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}