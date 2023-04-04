// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Exceptions;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(int Id) : IRequest;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReviewCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Reviews
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Review), request.Id);
        }

        _context.Reviews.Remove(entity);

        entity.AddDomainEvent(new ReviewDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}