// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class WarehouseCompletedEvent : BaseEvent
{
    public WarehouseCompletedEvent(Warehouse warehouse)
    {
        Warehouse = warehouse;
    }

    public Warehouse Warehouse { get; }
}