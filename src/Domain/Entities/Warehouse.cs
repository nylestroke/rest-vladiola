// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestVladiola.Domain.Entities;

[Table("warehouses", Schema = "shop")]
public class Warehouse : BaseAuditableEntity
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
    [Column("allowed_orders_zero", TypeName = "integer")]
    public int AllowedOrdersZero { get; set; }

    [Required]
    [Column("default", TypeName = "boolean")]
    public bool Default { get; set; }

    [Required]
    [Column("description", TypeName = "varchar")]
    public string Description { get; set; }
}