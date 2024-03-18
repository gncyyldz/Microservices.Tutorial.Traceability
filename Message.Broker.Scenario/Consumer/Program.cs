using Consumer.Consumers;
using MassTransit;
using NLog.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<ExampleMessageConsumer>();

    configurator.UsingRabbitMq((context, _configurator) =>
    {
        _configurator.Host("amqps://iftpampy:16V0VschvHJvMk92AK0hcF_x_ADaOt2b@woodpecker.rmq.cloudamqp.com/iftpampy");

        _configurator.ReceiveEndpoint("example-message-queue", e => e.ConfigureConsumer<ExampleMessageConsumer>(context));
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddNLog();

var host = builder.Build();
host.Run();
