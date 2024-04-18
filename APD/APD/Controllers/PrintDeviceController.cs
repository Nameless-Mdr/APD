using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.FilterExtension.FilterPrintDevice;
using APD.Models.DTO.PrintDevice;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
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