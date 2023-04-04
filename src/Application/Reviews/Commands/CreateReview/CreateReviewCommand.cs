// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Enums;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Reviews.Commands.CreateReview;

public record CreateReviewCommand : IRequest<int>
{
    public int Id { get; init; }

    public int ProductId { get; init; }

    public Opinions Opinion { get; init; } = Opinions.Bad;

    public string Message { get; init; } = "";

    public string Name { get; init; }

    public string Email { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateReviewCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = new Review
        {
            Id = request.Id,
            Name = request.Name,
            Message = request.Message,
            ProductId = request.ProductId,
            Email = request.Email,
            Opinion = request.Opinion
        };

        entity.AddDomainEvent(new ReviewCreatedEvent(entity));

        _context.Reviews.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}