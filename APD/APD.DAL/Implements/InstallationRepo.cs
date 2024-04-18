using APD.DAL.Interfaces;
using APD.Domain.Entity;
using APD.Domain.FilterExtension.FilterInstallation;
using Microsoft.EntityFrameworkCore;

namespace APD.DAL.Implements;

public class InstallationRepo : IInstallationRepo
{
    private readonly DataContext _context;

    public InstallationRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<Installation> GetInstallationById(int id)
    {
        var installation = await _context.Installations
            .Include(x => x.Office)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (installation == null)
            throw new Exception($"{nameof(Installation)} with Id: {id} not found");
        
        return installation;
    }

    public async Task<IEnumerable<Installation>> GetInstallations(FilterInstallation mdl)
    {
        var installations = await _context.Installations
            .Where(x => mdl.OfficeId == 0 ? true : x.OfficeId == mdl.OfficeId)
            .Skip((mdl.Page - 1) * mdl.PageSize)
            .Take(mdl.PageSize)
            .Include(x => x.PrintDevice)
            .Include(x => x.Office)
            .ToListAsync();

        return installations;
    }

    public async Task<int> Create(Installation entity)
    {
        await _context.Installations.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Installation>> GetAllModels()
    {
        return await _context.Installations.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _context.Installations.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception($"{nameof(Installation)} with Id: {id} not found");

        if (entity.IsDefault)
        {
            var secondEntity = await _context.Installations
                .FirstOrDefaultAsync(x => x.Id != id && x.OfficeId == entity.OfficeId);
            
            if (secondEntity != null) 
                secondEntity.IsDefault = true;
        }

        _context.Installations.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> GetNextSequenceNumber(int officeId)
    {
        var maxNumber = await _context.Installations
            .Where(x => x.OfficeId == officeId)
            .MaxAsync(x => x.SequenceNumber);
        
        return maxNumber + 1;
    }

    public async Task<bool> CheckSequenceNumber(int officeId, int number)
    {
        return await _context.Installations
            .AnyAsync(x => x.OfficeId == officeId && x.SequenceNumber == number);
    }

    public async Task<bool> DefaultIsExists(int officeId)
    {
        return await _context.Installations
            .AnyAsync(x => x.IsDefault);
    }
}