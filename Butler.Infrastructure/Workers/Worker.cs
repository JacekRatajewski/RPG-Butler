using Butler.Infrastructure.Application.Abstracts.Workers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Butler.Infrastructure.Workers
{
    internal class Worker<T> : BackgroundService where T : IWorker
    {
        private IServiceProvider _services;

        public Worker(IServiceProvider services)
        {
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                var client = _services.GetRequiredService<T>();
                await client.ExecuteAsync();
            }
        }
    }
}
