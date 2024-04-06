using System.ComponentModel.DataAnnotations.Schema;

namespace APD.Domain.Entity;

[Table("Office", Schema = "main")]
public class Office
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = null!;
}