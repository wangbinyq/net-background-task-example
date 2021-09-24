namespace BackgroundTask;

public class SimpleWorker : IHostedService
{
    private ILogger<SimpleWorker> _logger;

    public SimpleWorker(ILogger<SimpleWorker> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Simple Worker Start");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Simple Worker Stop");
        return Task.CompletedTask;
    }
}