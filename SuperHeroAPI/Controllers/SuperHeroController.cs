using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Controllers.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
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

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x =>  x.Id == id);
            if(hero is null)
            {
                return NotFound("Sorry but this Hero doesn't exist.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return NotFound("Sorry but this Hero doesn't exist.");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return NotFound("Sorry but this Hero doesn't exist.");
            }

          superHeroes.Remove(hero);

            return Ok(superHeroes);
        }
    }
}
