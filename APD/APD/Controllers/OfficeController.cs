using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.Entity;
using APD.Models.DTO.Office;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OfficeController : ControllerBase
{
    private readonly IOfficeRepo _officeRepo;
    private readonly IMapper _mapper;

    public OfficeController(IOfficeRepo officeRepo, IMapper mapper)
    {
        _officeRepo = officeRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GetOfficeModel>> GetPageOffice()
    {
        var offices = await _officeRepo.GetAllModels();
        
        return _mapper.MapEnumerable<GetOfficeModel>(offices);
    }
}