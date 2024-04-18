using APD.Common;
using APD.DAL.Interfaces;
using APD.Models.DTO.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;

    public UserController(IUserRepo userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Метод получения списка пользователей
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /api/User/GetPageOffice
    /// 
    /// </remarks>
    /// <returns>Данные полученных пользователей в формате JSON</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("GetPageOffice")]
    public async Task<IActionResult> GetPageOffice()
    {
        try
        {
            var users = await _userRepo.GetAllModels();
        
            return Json(_mapper.MapEnumerable<GetUserModel>(users));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}