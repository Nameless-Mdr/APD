using System.ComponentModel.DataAnnotations.Schema;
using APD.Domain.Enum;

namespace APD.Domain.Entity;

[Table("PrintDevice", Schema = "main")]
public class PrintDevice
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = null!;

    [Column("TypeConnect")]
    public TypeConnect TypeConnect;
}