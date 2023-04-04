// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Categories.EventHandlers;

public class CategoryCompletedEventHandler : INotificationHandler<CategoryCompletedEvent>
{
    private readonly ILogger<CategoryCompletedEventHandler> _logger;

    public CategoryCompletedEventHandler(ILogger<CategoryCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CategoryCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}