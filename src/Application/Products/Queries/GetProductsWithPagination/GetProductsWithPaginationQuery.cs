// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Application.Common.Mappings;
using RestVladiola.Application.Common.Models;

namespace RestVladiola.Application.Products.Queries.GetProductsWithPagination;

public record GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductBriefItem>>
{
    public int[]? CategoryIds { get; init; } = null;
    public string? HtmlTitle { get; init; } = null;
    public string? Description { get; init; } = null;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class
    GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery,
        PaginatedList<ProductBriefItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductBriefItem>> Handle(GetProductsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        if (request.HtmlTitle != null && request.Description != null && request.CategoryIds != null)
        {
            return await _context.Products
                .OrderBy(x => x.HtmlTitle.Contains(request.HtmlTitle) &&
                              x.Description.Contains(request.Description) && request.CategoryIds.Contains(x.CategoryId))
                .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        if (request.HtmlTitle != null && request.Description != null && request.CategoryIds == null)
        {
            return await _context.Products
                .OrderBy(x => x.HtmlTitle.Contains(request.HtmlTitle) &&
                              x.Description.Contains(request.Description))
                .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        if (request.HtmlTitle != null && request.Description == null && request.CategoryIds == null)
        {
            return await _context.Products
                .OrderBy(x => x.HtmlTitle.Contains(request.HtmlTitle))
                .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        if (request.HtmlTitle == null && request.Description != null && request.CategoryIds != null)
        {
            return await _context.Products
                .OrderBy(x => x.Description.Contains(request.Description) && request.CategoryIds.Contains(x.CategoryId))
                .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        if (request.HtmlTitle != null && request.Description == null && request.CategoryIds != null)
        {
            return await _context.Products
                .OrderBy(x => x.HtmlTitle.Contains(request.HtmlTitle) && request.CategoryIds.Contains(x.CategoryId))
                .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        if (request.HtmlTitle == null && request.Description == null && request.CategoryIds != null)
        {
            return await _context.Products
                .OrderBy(x => request.CategoryIds.Contains(x.CategoryId))
                .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        return await _context.Products
            .ProjectTo<ProductBriefItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}