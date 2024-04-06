using System.ComponentModel.DataAnnotations.Schema;

namespace APD.Domain.Entity;

[Table("users", Schema = "main")]
public class User
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = null!;
}