// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Warehouses.EventHandlers;

public class WarehouseCompletedEventHandler : INotificationHandler<WarehouseCompletedEvent>
{
    private readonly ILogger<WarehouseCompletedEventHandler> _logger;

    public WarehouseCompletedEventHandler(ILogger<WarehouseCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(WarehouseCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}