// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class ListFilterDto
{
    public FilterItemDto[] Filter { get; set; }
    public string SortDirection { get; set; }
    public string[]? Sort { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}