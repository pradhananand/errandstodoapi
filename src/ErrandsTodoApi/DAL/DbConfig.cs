using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ErrandsTodoApi.DAL
{

    public class DbConfig : DbConfiguration
    {
        public DbConfig()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
