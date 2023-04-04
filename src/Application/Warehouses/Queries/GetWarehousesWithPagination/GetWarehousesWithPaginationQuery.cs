// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Application.Common.Mappings;
using RestVladiola.Application.Common.Models;

namespace RestVladiola.Application.Warehouses.Queries.GetWarehousesWithPagination;

public record GetWarehousesWithPaginationQuery : IRequest<PaginatedList<WarehouseBriefItem>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class
    GetWarehousesWithPaginationQueryHandler : IRequestHandler<GetWarehousesWithPaginationQuery,
        PaginatedList<WarehouseBriefItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWarehousesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<WarehouseBriefItem>> Handle(GetWarehousesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Warehouses
            .OrderBy(x => x.Name)
            .ProjectTo<WarehouseBriefItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}