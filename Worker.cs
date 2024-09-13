using FileWatching;

namespace FileWatching
{
    public class Worker : BackgroundService
    {
        //private readonly ILogger<Worker> _logger;

        //public Worker(ILogger<Worker> logger)
        //{
        //    _logger = logger;
        //}

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //        await Task.Delay(1000, stoppingToken);
        //    }
        //}

        private readonly ILogger<Worker> _logger;
        private readonly IMyFileWatcher _watcher;

        public Worker(ILogger<Worker> logger, IMyFileWatcher watcher)
        {
            _logger = logger;
            _watcher = watcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _watcher.Start();
            while (!stoppingToken.IsCancellationRequested)
            {

            }
        }
    }
}
