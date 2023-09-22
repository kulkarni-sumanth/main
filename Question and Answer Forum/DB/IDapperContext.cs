using System.Data;
using System.Data.Common;

namespace Question_and_Answer_Forum.DB
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}