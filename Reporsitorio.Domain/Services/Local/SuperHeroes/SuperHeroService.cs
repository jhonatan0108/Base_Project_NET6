using AutoMapper;
using Repositorio.Common.Classes.DTO.Local;
using Repositorio.Infraestructura.Repositories.Database.Entities.SuperHero;
using Repositorio.Infraestructura.Repositories.EntityFramework.Local.SuperHeroes;

namespace Repositorio.Domain.Services.Local.SuperHeroes
{
    public class SuperHeroService : ISuperHeroService
    {
        IMapper _mapper;
        ISuperHeroRepository _repository;
        public SuperHeroService(ISuperHeroRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SuperHeroDTO> SelectAll()
        {
            return _mapper.Map<List<SuperHeroDTO>>(_repository.SelectAll());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SuperHeroDTO FindbyId(int id)
        {
            return _mapper.Map<SuperHeroDTO>(_repository.FindbyId(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        public void Insert(SuperHeroDTO hero)
        {
            _repository.Insert(_mapper.Map<SuperHero>(hero));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        public void Update(SuperHeroDTO hero)
        {
            var _hero = _repository.FindbyId(hero.Id);
            if (_hero != null)
            {
                _hero.Id = hero.Id;
                _hero.Name = hero.Name;
                _hero.FirstName = hero.FirstName;
                _hero.LastName = hero.LastName;
                _hero.Place = hero.Place;
                _repository.Update(_hero);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var hero = FindbyId(id);
            if (hero != null)
                _repository.Delete(_mapper.Map<SuperHero>(hero));
        }
    }
}
