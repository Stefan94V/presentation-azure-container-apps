using Images.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Images.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomController : ControllerBase
{
    
    private readonly ILogger<RandomController> _logger;
    private readonly IRandomImageService _randomImageService;

    public RandomController(ILogger<RandomController> logger, IRandomImageService randomImageService)
    {
        _logger = logger;
        _randomImageService = randomImageService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Getting random image url");
        return Ok(_randomImageService.GetRandomImageUrl());
    }
}