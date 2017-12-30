using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SignalrCoreDemoWithSqlTableDependency.SqlTableDependencies;

namespace SignalrCoreDemoWithSqlTableDependency
{
    public static class UseSqlTableDependencyHelpers
    {
        public static void UseSqlTableDependency<T>(this IApplicationBuilder services, string connectionString) where T : IDatabaseSubscription
        {
            var serviceProvider = services.ApplicationServices;
            var subscription = serviceProvider.GetService<T>();
            subscription.Configure(connectionString);
        }
    }
}
