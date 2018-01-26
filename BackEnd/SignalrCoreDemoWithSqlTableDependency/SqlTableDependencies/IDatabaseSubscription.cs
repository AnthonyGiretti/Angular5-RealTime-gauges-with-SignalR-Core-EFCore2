namespace SignalrCoreDemoWithSqlTableDependency.SqlTableDependencies
{
    public interface IDatabaseSubscription
    {
        void Configure(string connectionString);
    }
}
