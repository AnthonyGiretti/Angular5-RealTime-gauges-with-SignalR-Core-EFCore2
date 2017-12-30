using Microsoft.AspNetCore.SignalR;
using SignalrCoreDemoWithSqlTableDependency.Models;
using SignalrCoreDemoWithSqlTableDependency.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrCoreDemoWithSqlTableDependency.Hubs
{
    public class GaugeHub : Hub
    {
        private readonly IGaugeRepository _repository;

        public GaugeHub(IGaugeRepository repository)
        {
            _repository = repository;
        }

        public async Task GetGaugesData()
        {
            await Clients.All.InvokeAsync("GetGaugesData", _repository.Gauge);
        }
    }
}
