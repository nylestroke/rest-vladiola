// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.Security.Claims;
using RestVladiola.Application.Common.Interfaces;

namespace RestVladiola.WebGUI.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}