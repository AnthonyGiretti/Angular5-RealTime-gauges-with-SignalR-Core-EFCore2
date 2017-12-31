using Microsoft.EntityFrameworkCore;
using SignalrCoreDemoWithSqlTableDependency.Models;

namespace SignalrCoreDemoWithSqlTableDependency.EF
{
    public class GaugeContext : DbContext
    {
        public GaugeContext(DbContextOptions<GaugeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gauge> Gauges { get; set; }
    }
}
