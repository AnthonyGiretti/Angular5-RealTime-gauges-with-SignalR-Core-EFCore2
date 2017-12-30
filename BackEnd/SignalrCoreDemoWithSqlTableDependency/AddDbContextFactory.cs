using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SignalrCoreDemoWithSqlTableDependency
{
    public static class AddDbContextFactoryHelper
    {
        public static void AddDbContextFactory<DataContext>(this IServiceCollection services, string connectionString) where DataContext : DbContext
        {
            services.AddSingleton<Func<DataContext>>((ctx) =>
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(connectionString)
                    .Options;

                return () => (DataContext)Activator.CreateInstance(typeof(DataContext), options);
            });
        }
    }
}
