namespace HeroTest.Dto;

public record HeroDto(int Id,  string Name, string? Alias, DateTime CreatedOn, DateTime UpdatedOn, int BrandId, string BrandName);