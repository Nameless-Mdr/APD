using ADP.Constants;
using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.Entity;
using APD.Domain.FilterExtension.FilterInstallation;
using APD.Models.DTO.Installation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstallationController : Controller
{
    private readonly IInstallationRepo _installationRepo;
    private readonly IMapper _mapper;

    public InstallationController(IInstallationRepo installationRepo, IMapper mapper)
    {
        _installationRepo = installationRepo;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод получения инсталляции по уникальному идентификатору
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     GET /api/Installation/GetInstallationById?id=1
    /// 
    /// </remarks>
    /// <param name="id">Уникальный идентификатор инсталляции</param>
    /// <returns>Данные инсталляции в формате JSON</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("GetInstallationById")]
    public async Task<IActionResult> GetInstallationById([FromQuery] int id)
    {
        try
        {
            var installation = await _installationRepo.GetInstallationById(id);

            return Json(_mapper.Map<GetInstallationModel>(installation));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Метод получения списка инсталляций с воможностью фильтрации по филиалу
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     GET /api/Installation/GetPageInstallation?OfficeId=4&amp;Page=1&amp;PageSize=10
    /// 
    /// </remarks>
    /// <param name="mdl">Модель для пагинации и фильтрации</param>
    /// <returns>Данные полученных инсталляций в формате JSON</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("GetPageInstallation")]
    public async Task<IActionResult> GetPageInstallation([FromQuery] FilterInstallation mdl)
    {
        try
        {
            var installations = await _installationRepo.GetInstallations(mdl);

            return Json(_mapper.MapEnumerable<GetInstallationModel>(installations));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    /// <summary>
    /// Метод создания инсталляции
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Installation/CreateInstallation
    ///     {
    ///         "name": "Дворец",
    ///         "officeId": 4,
    ///         "printDeviceId": 2,
    ///         "sequenceNumber": 0,
    ///         "default": "Нет"
    ///     }
    /// 
    /// </remarks>
    /// <param name="mdl">Модель для создания инсталляции</param>
    /// <returns>Уникальный идентификатор созданной инсталляции</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpPost("CreateInstallation")]
    public async Task<IActionResult> CreateInstallation([FromBody] CreateInstallationModel mdl)
    {
        try
        {
            var installation = _mapper.Map<Installation>(mdl);
            var checkSequenceNumber = await _installationRepo.CheckSequenceNumber(installation.OfficeId, installation.SequenceNumber);
            var defaultIsExists = await _installationRepo.DefaultIsExists(installation.OfficeId);

            switch (installation.SequenceNumber)
            {
                case < 0:
                    return Json($"Порядковый номер не может быть отрицательным");
                case > 0 when !checkSequenceNumber:
                    return Json($"Инсталляция в этом филиале с таким порядковым номером {installation.SequenceNumber} уже существует");
                case 0:
                    installation.SequenceNumber = await _installationRepo.GetNextSequenceNumber(installation.OfficeId);
                    break;
            }

            switch (installation.IsDefault)
            {
                case true when defaultIsExists:
                    return Json($"Инсталляция в этом филиале со значением По умолчанию: {InstallationConstants.DefaultYes} уже существует");
                case false when !defaultIsExists:
                    installation.IsDefault = true;
                    break;
            }

            return Json(await _installationRepo.Create(installation));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Метод удаления инсталляции
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     DELETE /api/Installation/DeleteInstallation/DeleteInstallation?id=10
    /// 
    /// </remarks>
    /// <param name="id">Уникальный идентификатор инсталляции</param>
    /// <returns>Результат выполнения операции удаления True/False</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpDelete("DeleteInstallation")]
    public async Task<IActionResult> DeleteInstallation(int id)
    {
        try
        {
            return Json(await _installationRepo.Delete(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}