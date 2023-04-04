// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class ReviewCreatedEvent : BaseEvent
{
    public ReviewCreatedEvent(Review review)
    {
        Review = review;
    }

    public Review Review { get; }
}