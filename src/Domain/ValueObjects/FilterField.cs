// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Domain.ValueObjects;

public class FilterField : ValueObject
{
    static FilterField()
    {
    }

    private FilterField()
    {
    }

    private FilterField(string field)
    {
        Field = field;
    }

    public static FilterField From(string field)
    {
        var filterField = new FilterField { Field = field };

        if (!SupportedFilterFields.Contains(filterField))
        {
            throw new UnsupportedFilterFieldException(filterField);
        }

        return filterField;
    }

    public static FilterField CategoryId => new("category_id");

    public static FilterField HtmlTitle => new("html_title");

    public static FilterField Title => new("title");

    public static FilterField Price => new("price");

    public static FilterField Description => new("description");

    public string Field { get; private set; } = null!;

    public static implicit operator string(FilterField field)
    {
        return field.ToString();
    }

    public override string ToString()
    {
        return Field;
    }

    protected static IEnumerable<FilterField> SupportedFilterFields
    {
        get
        {
            yield return CategoryId;
            yield return HtmlTitle;
            yield return Title;
            yield return Price;
            yield return Description;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Field;
    }
}