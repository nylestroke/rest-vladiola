// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
}