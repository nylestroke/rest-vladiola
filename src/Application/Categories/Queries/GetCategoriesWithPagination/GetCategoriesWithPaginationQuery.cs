// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Application.Common.Mappings;
using RestVladiola.Application.Common.Models;

namespace RestVladiola.Application.Categories.Queries.GetCategoriesWithPagination;

public record GetCategoriesWithPaginationQuery : IRequest<PaginatedList<CategoryBriefItem>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class
    GetCategoriesWithPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery,
        PaginatedList<CategoryBriefItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CategoryBriefItem>> Handle(GetCategoriesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Categories
            .OrderBy(x => x.Title)
            .ProjectTo<CategoryBriefItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}