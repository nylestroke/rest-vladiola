// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Reviews.EventHandlers;

public class ReviewCreatedEventHandler : INotificationHandler<ReviewCreatedEvent>
{
    private readonly ILogger<ReviewCreatedEventHandler> _logger;

    public ReviewCreatedEventHandler(ILogger<ReviewCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ReviewCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}