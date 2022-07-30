using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Local;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Domain.Services.Local.SuperHeroes;

namespace Repositorio.Controllers.Local.SuperHeroes
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuperHeroController : ControllerBase
    {
        protected IConfiguration _configuration;
        protected ISuperHeroService _superHeroService;

        public SuperHeroController(IConfiguration configuration, ISuperHeroService superHeroService)
        {
            _configuration = configuration;
            _superHeroService = superHeroService;
        }

        /// <summary>
        /// Obtiene la lista de SuperHeroes del sistema
        /// </summary>
        /// <returns>respuesta json</returns>
        [HttpGet]
        [Route("GetSuperHeroes")]
        public IActionResult GetSuperHeroes()
        {
            var data = _superHeroService.SelectAll();
            return Ok(data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("GetSuperHero/{id}")]
        public IActionResult GetSuperHero(int id)
        {
            var data = _superHeroService.FindbyId(id);
            return Ok(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateSuperHero")]
        public IActionResult CreateSuperHero([FromBody] SuperHeroDTO hero)
        {
            _superHeroService.Insert(hero);
            return Ok(_superHeroService.SelectAll());
        }
        [HttpPut]
        [Route("UpdateSuperHero")]
        public IActionResult UpdateSuperHero([FromBody] SuperHeroDTO hero)
        {
            _superHeroService.Update(hero);
            return Ok(_superHeroService.FindbyId(hero.Id));
        }
        [HttpDelete]
        [Route("DeleteSuperHero/{id}")]
        public IActionResult DeleteSuperHero(int id)
        {
            _superHeroService.Delete(id);
            return Ok(_superHeroService.SelectAll());
        }
    }
}
