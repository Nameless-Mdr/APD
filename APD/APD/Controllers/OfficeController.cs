using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.Entity;
using APD.Models.DTO.Office;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]")]
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
    
    /// <summary>
    /// Метод получения списка филиалов
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /api/Office/GetPageOffice
    /// 
    /// </remarks>
    /// <returns>Данные полученных филалов в формате JSON</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
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