using APD.DAL.Interfaces;
using APD.Domain.FilterExtension.FilterPrintDevice;
using Microsoft.EntityFrameworkCore;

namespace APD.DAL.Implements;

public class PrintDeviceRepo : IPrintDeviceRepo
{
    private readonly DataContext _context;

    public PrintDeviceRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Entity.PrintDevice>> GetPrintDevices(FilterPrintDevice mdl)
    {
        return await _context.PrintDevices
            .Where(x => mdl.TypeConnectId == 0 ? true : x.TypeConnectId == mdl.TypeConnectId)
            .Skip((mdl.Page - 1) * mdl.PageSize)
            .Take(mdl.PageSize)
            .Include(x => x.TypeConnect)
            .ToListAsync();
    }
}