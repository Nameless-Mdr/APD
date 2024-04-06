using APD.DAL.Interfaces;
using APD.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OfficeController : ControllerBase
{
    private readonly IOfficeRepo _officeRepo;

    public OfficeController(IOfficeRepo officeRepo)
    {
        _officeRepo = officeRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Office>> GetPageOffice()
    {
        return await _officeRepo.GetAllModels();
    }
}