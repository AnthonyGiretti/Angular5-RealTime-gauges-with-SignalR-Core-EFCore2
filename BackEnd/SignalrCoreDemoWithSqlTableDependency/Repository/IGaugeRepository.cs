using SignalrCoreDemoWithSqlTableDependency.Models;

namespace SignalrCoreDemoWithSqlTableDependency.Repository
{
    public interface IGaugeRepository
    {
        Gauge Gauge { get; }
    }
}
