using Microsoft.AspNetCore.Mvc;
using MinhaAgencia_Api.Models;
using MinhaAgencia_Api.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAgencia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuario()
        {
            try
            {
                List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuario();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                // Lidar com exceções, registrar, etc.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Lidar com exceções, registrar, etc.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Lidar com exceções, registrar, etc.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            try
            {
                usuarioModel.Id = id;
                UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Lidar com exceções, registrar, etc.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            try
            {
                bool deletado = await _usuarioRepositorio.Deletar(id);
                return Ok(deletado);
            }
            catch (Exception ex)
            {
                // Lidar com exceções, registrar, etc.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}