using APD.Common;
using APD.DAL.Interfaces;
using APD.Models.DTO.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
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
    
    [HttpGet]
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