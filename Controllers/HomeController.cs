using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PCComponents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentesController : ControllerBase
    {
        private readonly IComponenteRepository _componenteRepository;

        public ComponentesController(IComponenteRepository componenteRepository)
        {
            _componenteRepository = componenteRepository;
        }

        [HttpGet]
        public IEnumerable<Componente> Get()
        {
            return _componenteRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var componente = _componenteRepository.GetById(id);
            if (componente == null)
            {
                return NotFound();
            }
            return Ok(componente);
        }

        [HttpPost]
        public IActionResult Create(Componente componente)
        {
            _componenteRepository.Create(componente);
            return CreatedAtAction(nameof(GetById), new { id = componente.Id }, componente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Componente componente)
        {
            if (id != componente.Id)
            {
                return BadRequest();
            }
            _componenteRepository.Update(componente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _componenteRepository.Delete(id);
            return NoContent();
        }
    }
}
