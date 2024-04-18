namespace APD.Models.DTO.PrintDevice;

public class GetPrintDeviceModel
{
    public int Id { get; set; }
    
    public int TypeConnectId { get; set; }
    
    public string Name { get; set; }
    
    public string TypeConnect { get; set; }
}