// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class WarehouseCreatedEvent : BaseEvent
{
    public WarehouseCreatedEvent(Warehouse warehouse)
    {
        Warehouse = warehouse;
    }

    public Warehouse Warehouse { get; }
}