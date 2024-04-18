using APD.Domain.Entity;

namespace APD.Models.DTO.Installation;

public class GetInstallationModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string TypeConnectName { get; set; }
}