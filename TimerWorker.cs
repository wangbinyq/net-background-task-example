namespace BackgroundTask;

public class TimerWorker : IHostedService
{
    private int _count = 0;
    private ILogger<TimerWorker> _logger;
    private Timer? _timer;

    public TimerWorker(ILogger<TimerWorker> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timer Worker Start");
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timer Worker Stop");

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref _count);

        _logger.LogInformation($"count = {count}, time: {DateTimeOffset.Now}");
    }
}