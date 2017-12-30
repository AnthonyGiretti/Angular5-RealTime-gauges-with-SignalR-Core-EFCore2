using Microsoft.EntityFrameworkCore;
using SignalrCoreDemoWithSqlTableDependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
