using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Controllers.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public ISuperHeroService _SuperHeroService { get; }

        public SuperHeroController(ISuperHeroService SuperHeroService)
        {
            _SuperHeroService = SuperHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _SuperHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var result = await _SuperHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not founf");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _SuperHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {

            var result = await _SuperHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not founf");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _SuperHeroService.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not founf");

            return Ok(result);
        }
    }
}
