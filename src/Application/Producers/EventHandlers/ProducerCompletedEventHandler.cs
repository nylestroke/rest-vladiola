// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Producers.EventHandlers;

public class ProducerCompletedEventHandler : INotificationHandler<ProducerCompletedEvent>
{
    private readonly ILogger<ProducerCompletedEventHandler> _logger;

    public ProducerCompletedEventHandler(ILogger<ProducerCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProducerCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}