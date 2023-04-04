// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Application.Common.Mappings;
using RestVladiola.Application.Common.Models;

namespace RestVladiola.Application.Producers.Queries.GetProducersWithPagination;

public record GetProducersWithPaginationQuery : IRequest<PaginatedList<ProducerBriefItem>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class
    GetProducersWithPaginationQueryHandler : IRequestHandler<GetProducersWithPaginationQuery,
        PaginatedList<ProducerBriefItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProducersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProducerBriefItem>> Handle(GetProducersWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Producers
            .OrderBy(x => x.Name)
            .ProjectTo<ProducerBriefItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}