// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Interfaces;

namespace RestVladiola.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}