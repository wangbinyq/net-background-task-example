using System.Threading.Channels;
using BackgroundTask;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // services.AddHostedService<Worker>();
        // services.AddHostedService<SimpleWorker>();
        // services.AddHostedService<TimerWorker>();
        var queue = Channel.CreateBounded<int>(10);
        services.AddSingleton(queue);
        services.AddHostedService<ProducerWorker>();
        services.AddHostedService<ConsumerWorker>();
    })
    .Build();

await host.RunAsync();
