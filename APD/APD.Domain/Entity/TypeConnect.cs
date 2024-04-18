using System.ComponentModel.DataAnnotations.Schema;

namespace APD.Domain.Entity;

[Table("TypeConnect", Schema = "main")]
public class TypeConnect
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = null!;
}