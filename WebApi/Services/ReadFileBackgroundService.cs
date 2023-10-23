using Microsoft.Extensions.Hosting;

namespace MasjidKITA.Services
{
    public class ReadFileBackgroundService : BackgroundService
    {
        private readonly ReadFileWorkerQueue queue;

        public ReadFileBackgroundService(ReadFileWorkerQueue queue)
        {
            this.queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await queue.DequeueAsync(stoppingToken);
                await workItem(stoppingToken);
            }
        }
    }
}
