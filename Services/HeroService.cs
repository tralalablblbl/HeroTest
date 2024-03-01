using HeroTest.Dto;
using HeroTest.Models;
using HeroTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Services;

public interface IHeroService
{
    Task<ICollection<HeroDto>> Get();
    Task<HeroDto?> Get(int heroId);
    Task<HeroDto> Create(AddHeroModel model);
    Task<bool> Delete(int heroId);
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
        return await _context.Heroes
            .AsNoTracking()
            .Include(h => h.Brand)
            .Where(h => h.IsActive != false)
            .Select(h => new HeroDto(h.Id, h.Name, h.Alias, h.CreatedOn, h.UpdatedOn, h.BrandId, h.Brand.Name))
            .ToListAsync();
    }

    public async Task<HeroDto?> Get(int heroId)
    {
        return await _context.Heroes
            .AsNoTracking()
            .Include(h => h.Brand)
            .Where(h => h.IsActive != false && h.Id == heroId)
            .Select(h => new HeroDto(h.Id, h.Name, h.Alias, h.CreatedOn, h.UpdatedOn, h.BrandId, h.Brand.Name))
            .SingleOrDefaultAsync();
    }

    public async Task<HeroDto> Create(AddHeroModel model)
    {
        var brandName = model.Brand.Trim();
        var brand = await _context.Brands.SingleOrDefaultAsync(b => b.Name == brandName);
        if (brand == default)
        {
            brand = new Brand()
            {
                Name = brandName
            };
            await _context.Brands.AddAsync(brand);
        }

        var hero = new Hero()
        {
            Name = model.Name,
            Alias = model.Alias,
            BrandId = brand.Id,
            Brand = brand
        };
        await _context.Heroes.AddAsync(hero);
        await _context.SaveChangesAsync();
        return new HeroDto(hero.Id, hero.Name, hero.Alias, hero.CreatedOn, hero.UpdatedOn, hero.BrandId,
            hero.Brand.Name);
    }

    public async Task<bool> Delete(int heroId)
    {
        var hero = await _context.Heroes.SingleOrDefaultAsync(h => h.Id == heroId);
        if (hero == default)
            return false;
        hero.IsActive = false;
        hero.UpdatedOn = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}