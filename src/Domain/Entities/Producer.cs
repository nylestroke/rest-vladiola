// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestVladiola.Domain.Entities;

[Table("producers", Schema = "shop")]
public class Producer : BaseAuditableEntity
{
    [Key]
    [Required]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [Column("name", TypeName = "varchar")]
    public string Name { get; set; }

    [Column("title", TypeName = "varchar")]
    public string? Title { get; set; }

    [Column("description", TypeName = "varchar")]
    public string? Description { get; set; }

    [Column("keywords", TypeName = "varchar")]
    public string? Keywords { get; set; }
}