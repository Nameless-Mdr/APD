using System.ComponentModel.DataAnnotations;
using ADP.Constants;

namespace APD.Models.DTO.Installation;

public class CreateInstallationModel
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public int OfficeId { get; set; }
    
    [Required]
    public int PrintDeviceId { get; set; }
    
    public int SequenceNumber { get; set; }

    public string Default { get; set; } = InstallationConstants.DefaultYes;
}