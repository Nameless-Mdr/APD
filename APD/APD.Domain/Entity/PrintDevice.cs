﻿using System.ComponentModel.DataAnnotations.Schema;

namespace APD.Domain.Entity;

[Table("PrintDevice", Schema = "main")]
public class PrintDevice
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = null!;

    [Column("TypeConnectId")]
    public int TypeConnectId { get; set; }

    [ForeignKey($"{nameof(TypeConnectId)}")]
    public virtual TypeConnect TypeConnect { get; set; } = null!;
}