// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class ReviewDto
{
    public int ProductId { set; get; }
    public int Opinion { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
}