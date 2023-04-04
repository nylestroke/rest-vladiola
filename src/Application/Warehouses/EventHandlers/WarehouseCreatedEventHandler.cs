// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Warehouses.EventHandlers;

public class WarehouseCreatedEventHandler : INotificationHandler<WarehouseCreatedEvent>
{
    private readonly ILogger<WarehouseCreatedEventHandler> _logger;

    public WarehouseCreatedEventHandler(ILogger<WarehouseCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(WarehouseCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}