// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class ResetPasswordDto
{
    public string Email { get; set; }
    public string RecoverToken { get; set; }
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
}