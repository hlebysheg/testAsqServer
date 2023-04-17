using Microsoft.AspNetCore.Mvc;
using testAsqServer.model.DTO;
using testAsqServer.service.formService;

namespace testAsqServer.Controllers;
//
[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase
{

    private readonly ILogger<FormController> _logger;
    private readonly IFormService _formService;

    public FormController(ILogger<FormController> logger, IFormService formService)
    {
        _logger = logger;
        _formService = formService;
    }
  
    [HttpPost(Name = "form")]
    public async Task<IActionResult> GetAsync([FromForm] FormDTO dto)
    {
        await _formService.SaveFormAsync(dto);
        return Ok(dto);
    }
}

