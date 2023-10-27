using SuperHeroAPI.Controllers.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroes();
        List<SuperHero>? GetSingleHero(int id);
        List<SuperHero> AddHero(SuperHero hero);
        List<SuperHero>? UpdateHero(int id, SuperHero request);
        List<SuperHero>? DeleteHero(int id);
    }
}
