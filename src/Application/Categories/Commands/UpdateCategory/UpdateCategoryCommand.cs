// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Exceptions;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int Position { get; init; }

    public float ProductWeight { get; init; }

    public float ProductDimension { get; init; }

    public float Kgo { get; init; }

    public string Path { get; init; }

    public string? Title { get; init; }

    public string? ShortDescription { get; init; }

    public string? Description { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Kgo = request.Kgo;
        entity.Path = request.Path;
        entity.Position = request.Position;
        entity.ProductDimension = request.ProductDimension;
        entity.ProductWeight = request.ProductWeight;
        entity.ShortDescription = request.ShortDescription;
        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}