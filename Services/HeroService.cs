using HeroTest.Dto;
using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Services;

public interface IHeroService
{
    Task<ICollection<HeroDto>> Get();
}

public class HeroService : IHeroService
{
    private readonly SampleContext _context;

    public HeroService(SampleContext context)
    {
        _context = context;
    }
    public async Task<ICollection<HeroDto>> Get()
    {
        return await _context.Heroes.Include(h => h.Brand)
            .Where(h => h.IsActive != false)
            .Select(h => new HeroDto(h.Id, h.Name, h.Alias, h.CreatedOn, h.UpdatedOn, h.BrandId, h.Brand.Name))
            .ToListAsync();
    }
}