// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestVladiola.Domain.Entities;

[Table("units", Schema = "shop")]
public class Unit : BaseAuditableEntity
{
    [Key]
    [Required]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [Column("abbreviation", TypeName = "varchar")]
    public string Abbreviation { get; set; }
}