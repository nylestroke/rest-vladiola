// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class UnitCreatedEvent : BaseEvent
{
    public UnitCreatedEvent(Unit unit)
    {
        Unit = unit;
    }

    public Unit Unit { get; }
}