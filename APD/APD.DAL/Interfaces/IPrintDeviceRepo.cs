using APD.Domain.Entity;
using APD.Domain.FilterExtension.FilterPrintDevice;

namespace APD.DAL.Interfaces;

public interface IPrintDeviceRepo
{
    public Task<IEnumerable<PrintDevice>> GetPrintDevices(FilterPrintDevice mdl);
}