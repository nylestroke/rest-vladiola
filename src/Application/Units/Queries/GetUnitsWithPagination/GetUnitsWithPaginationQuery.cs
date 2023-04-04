// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Application.Common.Mappings;
using RestVladiola.Application.Common.Models;
using RestVladiola.Application.Units.Queries.GetCategoriesWithPagination;

namespace RestVladiola.Application.Units.Queries.GetUnitsWithPagination;

public record GetUnitsWithPaginationQuery : IRequest<PaginatedList<UnitBriefItem>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class
    GetUnitsWithPaginationQueryHandler : IRequestHandler<GetUnitsWithPaginationQuery, PaginatedList<UnitBriefItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUnitsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UnitBriefItem>> Handle(GetUnitsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Units
            .OrderBy(x => x.Id)
            .ProjectTo<UnitBriefItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}