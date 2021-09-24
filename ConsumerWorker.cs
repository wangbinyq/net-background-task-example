namespace BackgroundTask;

using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

public class ConsumerWorker : BackgroundService
{
    private Channel<int> _queue;
    private ILogger<ConsumerWorker> _logger;

    public ConsumerWorker(Channel<int> queue, ILogger<ConsumerWorker> logger)
    {
        _queue = queue;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var count = await _queue.Reader.ReadAsync(stoppingToken);

            _logger.LogInformation($"do work for: {count}");
        }
    }
}