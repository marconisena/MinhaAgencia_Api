using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAgencia_Api.Models;
using MinhaAgencia_Api.Repositorios;
using MinhaAgencia_Api.Repositorios.Interfaces;

namespace MinhaAgencia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagensController : ControllerBase
    {
        private readonly IViagensRepositorio _viagensRepositorio;

        public ViagensController(IViagensRepositorio viagensRepositorio)
        {
            _viagensRepositorio = viagensRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<ViagensModel>>> ListarDestinos()
        {
            List<ViagensModel> viagens = await _viagensRepositorio.BuscarDestinos();
            return Ok(viagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViagensModel>> BuscarPorId(int id)
        {
            ViagensModel viagens = await _viagensRepositorio.BuscarPorId(id);
            return Ok(viagens);
        }

        [HttpPost]
        public async Task<ActionResult<ViagensModel>> Cadastrar([FromBody] ViagensModel viagensModel)
        {
            ViagensModel viagens = await _viagensRepositorio.AdicionarDestino(viagensModel);

            return Ok(viagens);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ViagensModel>> Atualizar([FromBody] ViagensModel viagensModel, int id)
        {
            viagensModel.Id = id;
            ViagensModel viagens = await _viagensRepositorio.Atualizar(viagensModel, id);

            return Ok(viagens);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViagensModel>> Deletar(int id)
        {

            bool deletado = await _viagensRepositorio.Deletar(id);

            return Ok(deletado);
        }
    }
}
