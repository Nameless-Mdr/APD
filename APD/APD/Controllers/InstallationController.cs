using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.FilterExtension;
using APD.Models.DTO.Installation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class InstallationController : ControllerBase
{
    private readonly IInstallationRepo _installationRepo;
    private readonly IMapper _mapper;

    public InstallationController(IInstallationRepo installationRepo, IMapper mapper)
    {
        _installationRepo = installationRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GetInstallationModel>> GetPageInstallation([FromQuery] PaginationModel mdl)
    {
        var installations = await _installationRepo.GetInstallations(mdl);

        return _mapper.MapEnumerable<GetInstallationModel>(installations);
    }
}