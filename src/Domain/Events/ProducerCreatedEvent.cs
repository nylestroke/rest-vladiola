// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class ProducerCreatedEvent : BaseEvent
{
    public ProducerCreatedEvent(Producer producer)
    {
        Producer = producer;
    }

    public Producer Producer { get; }
}