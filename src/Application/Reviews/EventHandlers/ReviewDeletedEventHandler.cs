// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using Microsoft.Extensions.Logging;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Reviews.EventHandlers;

public class ReviewDeletedEventHandler : INotificationHandler<ReviewDeletedEvent>
{
    private readonly ILogger<ReviewDeletedEventHandler> _logger;

    public ReviewDeletedEventHandler(ILogger<ReviewDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ReviewDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RestVladiola Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}