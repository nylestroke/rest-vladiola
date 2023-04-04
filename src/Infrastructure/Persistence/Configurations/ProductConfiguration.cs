// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(t => t.Id)
            .IsRequired();

        builder.Property(t => t.CategoryId)
            .IsRequired();

        builder.Property(t => t.UnitId)
            .IsRequired();

        builder.Property(t => t.WarehouseId)
            .IsRequired();
    }
}