using Microsoft.AspNetCore.Mvc;
using testAsqServer.model.DTO;

namespace testAsqServer.Controllers;

[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<FormController> _logger;

    public FormController(ILogger<FormController> logger)
    {
        _logger = logger;
    }
  
    [HttpPost(Name = "form")]
    public IActionResult Get([FromForm] FormDTO dto)
    {
        return Ok(dto);
    }
}

