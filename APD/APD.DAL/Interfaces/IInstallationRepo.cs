using APD.DAL.Base;
using APD.Domain.Entity;
using APD.Domain.FilterExtension.FilterInstallation;

namespace APD.DAL.Interfaces;

public interface IInstallationRepo : IBaseRepo<int, Installation>
{
    public Task<Installation> GetInstallationById(int id);
    
    public Task<IEnumerable<Installation>> GetInstallations(FilterInstallation mdl);

    public Task<int> GetNextSequenceNumber(int officeId);

    public Task<bool> CheckSequenceNumber(int officeId, int number);

    public Task<bool> DefaultIsExists(int officeId);
}