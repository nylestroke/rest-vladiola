// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class ChangePasswordDto
{
    public string Id { get; set; }
    public string Current { get; set; }
    public string Password { get; set; }
}