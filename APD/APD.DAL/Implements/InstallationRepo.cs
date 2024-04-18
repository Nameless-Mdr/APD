using APD.DAL.Interfaces;
using APD.Domain.Entity;
using APD.Domain.FilterExtension;
using Microsoft.EntityFrameworkCore;

namespace APD.DAL.Implements;

public class InstallationRepo : IInstallationRepo
{
    private readonly DataContext _context;

    public InstallationRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Installation>> GetInstallations(PaginationModel model)
    {
        var installations = await _context.Installations
            .Skip((model.Page - 1) * model.PageSize)
            .Take(model.PageSize)
            .Include(x => x.PrintDevice)
            .ToListAsync();

        return installations;
    }
}