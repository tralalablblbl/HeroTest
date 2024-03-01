using HeroTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;
[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{

    private readonly ILogger<HeroesController> _logger;
    private readonly IHeroService _heroService;

    public HeroesController(ILogger<HeroesController> logger, IHeroService heroService)
    {
        _logger = logger;
        _heroService = heroService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var heroes = await _heroService.Get();
        return Ok(heroes);
    }
}

