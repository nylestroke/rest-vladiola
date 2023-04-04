// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Exceptions;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Producers.Commands.UpdateProducer;

public record UpdateProducerCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Keywords { get; init; }
}

public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProducerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Producers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Producer), request.Id);
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Keywords = request.Keywords;
        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}