using SignalrCoreDemoWithSqlTableDependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrCoreDemoWithSqlTableDependency.Repository
{
    public interface IGaugeRepository
    {
        Gauge Gauge { get; }
    }
}
