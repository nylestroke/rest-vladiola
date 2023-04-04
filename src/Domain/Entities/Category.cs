// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestVladiola.Domain.Entities;

[Table("categories", Schema = "shop")]
public class Category : BaseAuditableEntity
{
    [Key]
    [Required]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [Column("name", TypeName = "varchar")]
    public string Name { get; set; }

    [Required]
    [Column("position", TypeName = "integer")]
    public int Position { get; set; }

    [Required]
    [Column("product_weight", TypeName = "float8")]
    public float ProductWeight { get; set; }

    [Required]
    [Column("product_dimension", TypeName = "float8")]
    public float ProductDimension { get; set; }

    [Required]
    [Column("kgo", TypeName = "float8")]
    public float Kgo { get; set; }

    [Required]
    [Column("path", TypeName = "varchar")]
    public string Path { get; set; }

    [Column("title", TypeName = "varchar")]
    public string? Title { get; set; }

    [Column("short_description", TypeName = "varchar")]
    public string? ShortDescription { get; set; }

    [Column("description", TypeName = "varchar")]
    public string? Description { get; set; }
}