// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Producers.Commands.CreateProducer;

public record CreateProducerCommand : IRequest<int>
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Keywords { get; init; }
}

public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProducerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Producer
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Keywords = request.Keywords,
            Title = request.Title
        };

        entity.AddDomainEvent(new ProducerCreatedEvent(entity));

        _context.Producers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}