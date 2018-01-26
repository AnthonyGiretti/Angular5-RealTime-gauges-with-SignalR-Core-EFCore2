using SignalrCoreDemoWithSqlTableDependency.EF;
using SignalrCoreDemoWithSqlTableDependency.Models;
using System;
using System.Linq;

namespace SignalrCoreDemoWithSqlTableDependency.Repository
{
    public class GaugeRepository : IGaugeRepository
    {
        private readonly Func<GaugeContext> _contextFactory;

        public Gauge Gauge => GetGauge();

        public GaugeRepository(Func<GaugeContext> context)
        {
            _contextFactory = context;
        }

        private Gauge GetGauge()
        {
            using (var context = _contextFactory.Invoke())
            {
                return context.Gauges.FirstOrDefault();
            }
        }
    }
}
