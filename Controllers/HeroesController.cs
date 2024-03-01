using HeroTest.Services;
using HeroTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly IHeroService _heroService;

    public HeroesController(IHeroService heroService)
    {
        _heroService = heroService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var heroes = await _heroService.Get();
        return Ok(heroes);
    }

    [HttpGet("{heroId:int}")]
    public async Task<IActionResult> Get(int heroId)
    {
        var hero = await _heroService.Get(heroId);
        return Ok(hero);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddHeroModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var hero = await _heroService.Create(model);
        return Created(Url.Action(nameof(Get), new {heroId = hero.Id})!, hero);
    }

    [HttpDelete("{heroId:int}")]
    public async Task<IActionResult> Delete(int heroId)
    {
        var deleted = await _heroService.Delete(heroId);
        if (deleted)
            return Ok();
        return NotFound();
    }
}

