// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand : IRequest<int>
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

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Kgo = request.Kgo,
            Path = request.Path,
            Position = request.Position,
            ProductDimension = request.ProductDimension,
            ProductWeight = request.ProductWeight,
            ShortDescription = request.ShortDescription,
            Title = request.Title
        };

        entity.AddDomainEvent(new CategoryCreatedEvent(entity));

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}