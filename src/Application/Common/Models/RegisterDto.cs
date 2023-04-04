// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class RegisterDto
{
    public string Name { get; set; }
    public string Surame { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}