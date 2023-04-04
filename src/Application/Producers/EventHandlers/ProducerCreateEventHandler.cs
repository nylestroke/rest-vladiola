// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Producers.EventHandlers;

public class ProducerCreateEventHandler : INotificationHandler<ProducerCreatedEvent>
{
    private readonly ILogger<ProducerCreateEventHandler> _logger;

    public ProducerCreateEventHandler(ILogger<ProducerCreateEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProducerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}