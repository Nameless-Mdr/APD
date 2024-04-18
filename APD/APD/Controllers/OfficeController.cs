using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.Entity;
using APD.Models.DTO.Office;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OfficeController : Controller
{
    private readonly IOfficeRepo _officeRepo;
    private readonly IMapper _mapper;

    public OfficeController(IOfficeRepo officeRepo, IMapper mapper)
    {
        _officeRepo = officeRepo;
        _mapper = mapper;
    }

    [HttpGet("GetPageOffice")]
    public async Task<IActionResult> GetPageOffice()
    {
        try
        {
            var offices = await _officeRepo.GetAllModels();
        
            return Json(_mapper.MapEnumerable<GetOfficeModel>(offices));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}