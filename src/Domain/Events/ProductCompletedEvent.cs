// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class ProductCompletedEvent : BaseEvent
{
    public ProductCompletedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}