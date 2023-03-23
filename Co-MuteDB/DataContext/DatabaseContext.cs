using Co_MuteDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Co_MuteDB.DataContext
{
    public class DatabaseContext: DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                appConfiguration = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(appConfiguration.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            private AppConfiguration appConfiguration { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CarPool> CarPools { get; set; }
        public DbSet<OwnerCarPool> OwnerCarPools { get; set; }

    }
}
