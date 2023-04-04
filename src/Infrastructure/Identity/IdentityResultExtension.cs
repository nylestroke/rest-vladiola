// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using Microsoft.AspNetCore.Identity;
using RestVladiola.Application.Common.Models;

namespace RestVladiola.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}