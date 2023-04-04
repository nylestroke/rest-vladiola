// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestVladiola.Domain.Entities;

[Table("products", Schema = "shop")]
public class Product : BaseAuditableEntity
{
    [Key]
    [Required]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Category")]
    [Column("category_id", TypeName = "integer")]
    public int CategoryId { get; set; }

    [ForeignKey("Producer")]
    [Column("producer_id", TypeName = "integer")]
    public int? ProducerId { get; set; }

    [Required]
    [ForeignKey("Warehouse")]
    [Column("warehouse_id", TypeName = "integer")]
    public int WarehouseId { get; set; }

    [Required]
    [ForeignKey("Unit")]
    [Column("unit_id", TypeName = "integer")]
    public int UnitId { get; set; }

    [Column("price", TypeName = "float8")] public float? Price { get; set; }

    [Column("display", TypeName = "boolean")]
    public bool? Display { get; set; }

    [Column("kit", TypeName = "integer")] public int? Kit { get; set; }

    [Column("previous_price", TypeName = "float8")]
    public float? PreviousPrice { get; set; }

    [Column("var_rate", TypeName = "float8")]
    public float? VatRate { get; set; }

    [Column("count", TypeName = "float8")] public float? Count { get; set; }

    [Column("weight", TypeName = "float8")]
    public float? Weight { get; set; }

    [Column("dimensions", TypeName = "varchar")]
    public string? Dimensions { get; set; }

    [Column("price1", TypeName = "float8")]
    public float? Price1 { get; set; }

    [Column("price2", TypeName = "float8")]
    public float? Price2 { get; set; }

    [Column("count_accuracy", TypeName = "float8")]
    public float? CountAccuracy { get; set; }

    [Column("count_min", TypeName = "float8")]
    public float? CountMin { get; set; }

    [Column("count_increment", TypeName = "float8")]
    public float? CountIncrement { get; set; }

    [Column("to_comparisons", TypeName = "boolean")]
    public bool? ToComparisons { get; set; }

    [Column("title", TypeName = "varchar")]
    public string? Title { get; set; }

    [Column("vendor_code", TypeName = "varchar")]
    public string? VendorCode { get; set; }

    [Column("producer_code", TypeName = "varchar")]
    public string? ProducerCode { get; set; }

    [Column("product_symbol", TypeName = "varchar")]
    public string? ProductSymbol { get; set; }

    [Column("html_title", TypeName = "varchar")]
    public string? HtmlTitle { get; set; }

    [Column("description", TypeName = "varchar")]
    public string? Description { get; set; }

    [Column("category_promotion", TypeName = "varchar")]
    public string? CategoryPromotion { get; set; }

    [Column("delivery", TypeName = "varchar")]
    public string? Delivery { get; set; }

    [Column("photos", TypeName = "jsonb")] public object[]? Photos { get; set; }

    [Column("warehouse_count", TypeName = "jsonb")]
    public object[]? WarehouseCount { get; set; }

    [Column("discount", TypeName = "integer")]
    public int? Discount { get; set; }
}