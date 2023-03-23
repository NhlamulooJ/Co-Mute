using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_MuteDB.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path); 
            var root = configBuilder.Build();
            var appsettings = root.GetSection("ConnectionStrings:co-muteDBConnection");
            sqlConnectionString = appsettings.Value;
        }
        public string sqlConnectionString { get; set; }
    }
}
