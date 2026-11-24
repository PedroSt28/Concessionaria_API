using ConcensionariaAPI.Interface;
using ConcensionariaAPI.Models;
using ConcensionariaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcensionariaAPI.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {

        

         private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        // GET api/curso
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_veiculoRepository.ListarTodos());   // 200 + lista em JSON
        }



        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            _veiculoRepository.Cadastrar(veiculo);
            return Created(); //201
        }


        //atualizar
        //api/curso/30
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Veiculo veiculo)
        {
            if (_veiculoRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _veiculoRepository.Atualizar(id,veiculo);
            return NoContent(); //204
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_veiculoRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _veiculoRepository.Deletar(id);
            return NoContent();

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Veiculo? veiculo = _veiculoRepository.BuscarPorId(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);

        }
    }
}

           
