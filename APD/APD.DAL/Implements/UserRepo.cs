using APD.DAL.Interfaces;
using APD.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace APD.DAL.Implements;

public class UserRepo : IUserRepo
{
    private readonly DataContext _context;

    public UserRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<int> Create(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<User>> GetAllModels()
    {
        var users = await _context.Users
            .Include(x => x.Office)
            .ToListAsync();

        return users;
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new Exception($"{nameof(User)} with Id: {id} not found");

        _context.Users.Remove(user);
        return await _context.SaveChangesAsync() > 0;
    }
}