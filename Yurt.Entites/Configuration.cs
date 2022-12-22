using Microsoft.Extensions.Configuration;

namespace Yurt.Entites
{
    static public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Yurt.WebUI"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("yurt");
            }
        }
    }
}
