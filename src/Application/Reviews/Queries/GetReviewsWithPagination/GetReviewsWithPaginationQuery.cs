// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Application.Common.Mappings;
using RestVladiola.Application.Common.Models;

namespace RestVladiola.Application.Reviews.Queries.GetReviewsWithPagination;

public record GetReviewsWithPaginationQuery : IRequest<PaginatedList<ReviewBriefItem>>
{
    public int ProductId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class
    GetReviewsWithPaginationQueryHandler : IRequestHandler<GetReviewsWithPaginationQuery,
        PaginatedList<ReviewBriefItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReviewsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ReviewBriefItem>> Handle(GetReviewsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Reviews
            .Where(x => x.ProductId == request.ProductId)
            .OrderBy(x => x.Id)
            .ProjectTo<ReviewBriefItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}