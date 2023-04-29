using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Phrases.Api.Services;

namespace Phrases.Api.Controllers;

public class PhrasesController : ControllerBase
{
    private readonly ILogger<PhrasesController> _logger;
    private readonly IPhraseService _phraseService;
    
    public PhrasesController(ILogger<PhrasesController> logger, IPhraseService phraseService)
    {
        _logger = logger;
        _phraseService = phraseService;
    }

    [HttpGet("day/{date}")]
    public IActionResult Get([FromRoute] DateTime date)
    {
        var dayOfWeek = date.ToString("dddd", CultureInfo.InvariantCulture);
        _logger.LogInformation("Getting phrase for {DayOfWeek}", dayOfWeek);

        try
        {
            return Ok(_phraseService.GetPhraseOfDay(dayOfWeek));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}