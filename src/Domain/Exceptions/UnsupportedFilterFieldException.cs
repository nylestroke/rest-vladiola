// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.Exceptions;

public class UnsupportedFilterFieldException : Exception
{
    public UnsupportedFilterFieldException(string field)
        : base($"Filter field \"{field}\" is unsupported.")
    {
    }
}