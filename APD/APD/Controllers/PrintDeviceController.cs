using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.FilterExtension.FilterPrintDevice;
using APD.Models.DTO.PrintDevice;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrintDeviceController : Controller
{
    private readonly IPrintDeviceRepo _printDevice;
    private readonly IMapper _mapper;

    public PrintDeviceController(IPrintDeviceRepo printDevice, IMapper mapper)
    {
        _printDevice = printDevice;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод получения списка устройств печати
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /api/PrintDevice/GetPagePrintDevice?TypeConnectId=1&amp;Page=1&amp;PageSize=1
    /// 
    /// </remarks>
    /// <param name="mdl">Модель для пагинации и фильтрации</param>
    /// <returns>Данные полученных устройств печати в формате JSON</returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("GetPagePrintDevice")]
    public async Task<IActionResult> GetPagePrintDevice([FromQuery] FilterPrintDevice mdl)
    {
        try
        {
            var printDevices = await _printDevice.GetPrintDevices(mdl);

            return Json(_mapper.MapEnumerable<GetPrintDeviceModel>(printDevices));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}