using ConcensionariaAPI.Interface;
using ConcensionariaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcensionariaAPI.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        // GET api/curso
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_marcaRepository.ListarTodos());   // 200 + lista em JSON
        }



        [HttpPost]
        public IActionResult Cadastrar(Marca marca)
        {
            _marcaRepository.Cadastrar(marca);
            return Created(); //201
        }


        //atualizar
        //api/curso/30
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Marca marca)
        {
            if (_marcaRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _marcaRepository.Atualizar(id, marca);
            return NoContent(); //204
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_marcaRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _marcaRepository.Deletar(id);
            return NoContent();

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Marca? curso = _marcaRepository.BuscarPorId(id);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);

        }
    }
}
