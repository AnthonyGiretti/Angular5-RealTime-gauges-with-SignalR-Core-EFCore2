using SignalrCoreDemoWithSqlTableDependency.EF;
using SignalrCoreDemoWithSqlTableDependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrCoreDemoWithSqlTableDependency.Repository
{
    public class GaugeRepository : IGaugeRepository
    {
        private Func<GaugeContext> _contextFactory;

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
