using APD.Domain.Entity;
using APD.Domain.FilterExtension;

namespace APD.DAL.Interfaces;

public interface IInstallationRepo
{
    public Task<IEnumerable<Installation>> GetInstallations(PaginationModel model);
}