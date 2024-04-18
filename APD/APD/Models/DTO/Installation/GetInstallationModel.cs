namespace APD.Models.DTO.Installation;

public class GetInstallationModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string OfficeName { get; set; }
    
    public int SequenceNumber { get; set; }
    
    public string Default { get; set; }
    
    public string PrintDeviceName { get; set; }
    
    public int OfficeId { get; set; }
}