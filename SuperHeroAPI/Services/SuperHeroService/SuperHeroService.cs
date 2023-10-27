using SuperHeroAPI.Controllers.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {

        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "David Smart",
                    FirstName = "David",
                    LastName = "Semilore",
                    Place = "New York City"
                },
                 new SuperHero
                {
                    Id = 2,
                    Name = "AbiolaSoft",
                    FirstName = "Abiola",
                    LastName = "Olakunle",
                    Place = "Dallas Texas"
                 }
            };

        public List<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            superHeroes.Remove(hero);
            return superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public List<SuperHero>? GetSingleHero(int id)//List & <>
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            return superHeroes;//hero
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request) 
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return superHeroes;
        }
    }
}
