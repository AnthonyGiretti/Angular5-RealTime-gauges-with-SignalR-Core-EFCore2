using Microsoft.AspNetCore.SignalR;
using SignalrCoreDemoWithSqlTableDependency.Hubs;
using SignalrCoreDemoWithSqlTableDependency.Models;
using SignalrCoreDemoWithSqlTableDependency.Repository;
using System;
using TableDependency.Enums;
using TableDependency.EventArgs;
using TableDependency.SqlClient;

namespace SignalrCoreDemoWithSqlTableDependency.SqlTableDependencies
{
    public class GaugeDatabaseSubscription : IDatabaseSubscription
    {
        private bool _disposedValue;
        private readonly IGaugeRepository _repository;
        private readonly IHubContext<GaugeHub> _hubContext;
        private SqlTableDependency<Gauge> _tableDependency;

        public GaugeDatabaseSubscription(IGaugeRepository repository, IHubContext<GaugeHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public void Configure(string connectionString)
        {
            _tableDependency = new SqlTableDependency<Gauge>(connectionString);
            _tableDependency.OnChanged += Changed;
            _tableDependency.OnError += TableDependency_OnError;
            _tableDependency.Start();

            Console.WriteLine("Waiting for receiving notifications...");
        }

        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"SqlTableDependency error: {e.Error.Message}");
        }

        private void Changed(object sender, RecordChangedEventArgs<Gauge> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                _hubContext.Clients.All.InvokeAsync("GetGaugesData", _repository.Gauge);
            }
        }

        #region IDisposable

        ~GaugeDatabaseSubscription()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _tableDependency.Stop();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
