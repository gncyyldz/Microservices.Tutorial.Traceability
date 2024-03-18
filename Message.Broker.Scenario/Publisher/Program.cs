using MassTransit;
using NLog.Extensions.Logging;
using Publisher.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddMassTransit(configurator =>
{
    configurator.UsingRabbitMq((context, _configurator) =>
    {
        _configurator.Host("amqps://iftpampy:16V0VschvHJvMk92AK0hcF_x_ADaOt2b@woodpecker.rmq.cloudamqp.com/iftpampy");
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddNLog();

builder.Services.AddHostedService<PublishMessageService>(provider =>
{
    using IServiceScope scope = provider.CreateScope();
    IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>();
    var logger = scope.ServiceProvider.GetService<ILogger<PublishMessageService>>();
    return new(publishEndpoint, logger);
});

var host = builder.Build();
host.Run();