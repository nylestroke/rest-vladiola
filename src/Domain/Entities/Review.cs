// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestVladiola.Domain.Entities;

[Table("reviews", Schema = "shop")]
public class Review : BaseAuditableEntity
{
    [Key]
    [Required]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [ForeignKey("Product")]
    [Required]
    [Column("product_id", TypeName = "integer")]
    public int ProductId { get; set; }

    [Required]
    [Column("opinion", TypeName = "integer")]
    public Opinions Opinion { get; set; } = Opinions.Bad;

    [Required]
    [Column("message", TypeName = "varchar")]
    public string Message { get; set; } = "";

    [Required]
    [Column("name", TypeName = "varchar")]
    public string Name { get; set; }

    [Required]
    [Column("email", TypeName = "varchar")]
    public string Email { get; set; }

    [Timestamp]
    [Required]
    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}