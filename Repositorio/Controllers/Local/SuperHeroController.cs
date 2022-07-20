using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Local;
using Repositorio.Domain.Services.Local;

namespace Repositorio.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> GetSuperHeroes()
        {
            var data = _superHeroService.SelectAll();
            return Ok(data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("GetSuperHero/{id}")]
        public async Task<IActionResult> GetSuperHero(int id)
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
        public async Task<IActionResult> CreateSuperHero([FromBody] SuperHeroDTO hero)
        {
            try
            {
                _superHeroService.Insert(hero);
                return Ok(_superHeroService.SelectAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateSuperHero")]
        public async Task<IActionResult> UpdateSuperHero([FromBody] SuperHeroDTO hero)
        {
            try
            {
                _superHeroService.Update(hero);
                return Ok(_superHeroService.FindbyId(hero.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteSuperHero/{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            _superHeroService.Delete(id);
            return Ok(_superHeroService.SelectAll());
        }
    }
}
