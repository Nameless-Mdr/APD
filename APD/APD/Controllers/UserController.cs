using APD.Common;
using APD.DAL.Interfaces;
using APD.Models.DTO.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;

    public UserController(IUserRepo userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<GetUserModel>> GetPageOffice()
    {
        var users = await _userRepo.GetAllModels();
        
        return _mapper.MapEnumerable<GetUserModel>(users);
    }
}