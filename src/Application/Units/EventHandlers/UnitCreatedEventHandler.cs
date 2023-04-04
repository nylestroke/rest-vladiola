// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Units.EventHandlers;

public class UnitCreatedEventHandler : INotificationHandler<UnitCreatedEvent>
{
    private readonly ILogger<UnitCreatedEventHandler> _logger;

    public UnitCreatedEventHandler(ILogger<UnitCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UnitCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}