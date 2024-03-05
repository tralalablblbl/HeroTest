using System.ComponentModel.DataAnnotations;

namespace HeroTest.ViewModels;

public record AddHeroModel
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Alias { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Brand { get; set; } = null!;
}