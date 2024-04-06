using System.ComponentModel.DataAnnotations.Schema;

namespace APD.Domain.Entity;

[Table("Installation", Schema = "main")]
public class Installation
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = null!;
    
    [Column("SequenceNumber")]
    public int SequenceNumber { get; set; }
    
    [Column("IsDefault")]
    public bool IsDefault { get; set; }
    
    [Column("OfficeId")]
    public int OfficeId { get; set; }
    
    [Column("PrintDeviceId")]
    public int PrintDeviceId { get; set; }
    

    [ForeignKey($"{nameof(OfficeId)}")]
    public virtual Office Office { get; set; } = null!;
    
    [ForeignKey($"{nameof(PrintDeviceId)}")]
    public virtual PrintDevice PrintDevice { get; set; } = null!;
    
}