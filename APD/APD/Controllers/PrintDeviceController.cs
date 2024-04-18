using APD.Common;
using APD.DAL.Interfaces;
using APD.Domain.FilterExtension.FilterPrintDevice;
using APD.Models.DTO.PrintDevice;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APD.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PrintDeviceController : ControllerBase
{
    private readonly IPrintDeviceRepo _printDevice;
    private readonly IMapper _mapper;

    public PrintDeviceController(IPrintDeviceRepo printDevice, IMapper mapper)
    {
        _printDevice = printDevice;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GetPrintDeviceModel>> GetPagePrintDevice([FromQuery] FilterPrintDevice mdl)
    {
        var printDevices = await _printDevice.GetPrintDevices(mdl);

        return _mapper.MapEnumerable<GetPrintDeviceModel>(printDevices);
    }
}