using Microsoft.Extensions.Configuration;
using MininalApi.Infraestrutura.Db;
using System.Reflection;

namespace Teste_MinimalApi.Infraestrutura.Db
{
    public static class BaseDados
    {
        public static DbContexto CriarContexto()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));


            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);

        }
    }
}