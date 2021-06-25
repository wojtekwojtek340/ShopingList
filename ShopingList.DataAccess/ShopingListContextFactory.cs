using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingList.DataAccess
{
    public class ShopingListContextFactory : IDesignTimeDbContextFactory<ShopingListContext>
    {
        public ShopingListContext CreateDbContext(string[] args)
        {
            var optionsBuildier = new DbContextOptionsBuilder<ShopingListContext>();

            optionsBuildier.UseSqlServer("Server=tcp:shopinglistserver.database.windows.net,1433;Initial Catalog=ShopingListDb;Persist Security Info=False;User ID=wojtekwojtowiczadmin;Password=EprVumKo3cQjeMwZaY94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ShopingListContext(optionsBuildier.Options);
        }
    }
}
