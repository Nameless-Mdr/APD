using APD.DAL.Interfaces;
using APD.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace APD.DAL.Implements;

public class OfficeRepo : IOfficeRepo
{
    private readonly DataContext _context;
    
    public OfficeRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Office entity)
    {
        await _context.Offices.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Office>> GetAllModels()
    {
        var offices = await _context.Offices.ToListAsync();

        return offices;
    }

    public async Task<bool> Delete(int id)
    {
        var office = await _context.Offices.FirstOrDefaultAsync(x => x.Id == id);

        if (office == null)
            throw new Exception($"{nameof(Office)} with Id: {id} not found");

        _context.Offices.Remove(office);
        return await _context.SaveChangesAsync() > 0;
    }
}