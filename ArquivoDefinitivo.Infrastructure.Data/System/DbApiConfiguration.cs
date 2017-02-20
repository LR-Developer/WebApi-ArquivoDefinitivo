using System.Configuration;

namespace ArquivoDefinitivo.Infrastructure.Data.System
{
    public class DbApiConfiguration
    {
        public static string Schema => ConfigurationManager.AppSettings["DB_SCHEMA"];
    }
}
