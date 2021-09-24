namespace BackgroundTask;

using System.Threading.Channels;

public class ProducerWorker : BackgroundService
{
    private int _count = 0;
    private Channel<int> _queue;

    public ProducerWorker(Channel<int> queue)
    {
        _queue = queue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var count = Interlocked.Increment(ref _count);
            await _queue.Writer.WriteAsync(count, stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}