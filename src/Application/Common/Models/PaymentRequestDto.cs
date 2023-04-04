// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class PaymentRequestDto
{
    public string Email { get; set; }
    public string[] Items { get; set; }
    public float Price { get; set; }
    public string? Description { get; set; }
    public string Issuer { get; set; }
    public string SessionToken { get; set; } = "";
}