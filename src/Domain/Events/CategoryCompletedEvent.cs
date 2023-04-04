// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Events;

public class CategoryCompletedEvent : BaseEvent
{
    public CategoryCompletedEvent(Category category)
    {
        Category = category;
    }

    public Category Category { get; }
}