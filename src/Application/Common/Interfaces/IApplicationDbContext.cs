// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using Microsoft.EntityFrameworkCore;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }

    DbSet<Producer> Producers { get; }

    DbSet<Unit> Units { get; }

    DbSet<Warehouse> Warehouses { get; }

    DbSet<Product> Products { get; }

    DbSet<Review> Reviews { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}