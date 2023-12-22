using Microsoft.EntityFrameworkCore;
using MinhaAgencia_Api.Data;
using MinhaAgencia_Api.Models;
using MinhaAgencia_Api.Repositorios.Interfaces;

namespace MinhaAgencia_Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
       
        
            private readonly MinhaAgencia_ApiDBContext _dbContext;

            public UsuarioRepositorio(MinhaAgencia_ApiDBContext minhaAgencia_ApiDBContext)
            {
                _dbContext = minhaAgencia_ApiDBContext;
            }


            public async Task<UsuarioModel> BuscarPorId(int id)
            {
                return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            }
            public async Task<List<UsuarioModel>> BuscarTodosUsuario()
            {
                return await _dbContext.Usuarios.ToListAsync();
            }
            public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
            {
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync();

                return usuario;
            }

            public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
            {
                UsuarioModel usuarioPorId = await BuscarPorId(id);

                if (usuarioPorId == null)
                {
                    throw new Exception($" Usuário de ID: {id} não foi encontrado no banco de dados!");
                }
                usuarioPorId.Nome = usuario.Nome;
                usuarioPorId.Cpf = usuario.Cpf;

                _dbContext.Usuarios.Update(usuarioPorId);
                await _dbContext.SaveChangesAsync();

                return usuarioPorId;


            }

            public async Task<bool> Deletar(int id)
            {
                UsuarioModel usuarioPorId = await BuscarPorId(id);

                if (usuarioPorId == null)
                {
                    throw new Exception($" Usuário de ID: {id} não foi encontrado no banco de dados!");
                }

                _dbContext.Usuarios.Remove(usuarioPorId);
                await _dbContext.SaveChangesAsync();
                return true;


            }

        }
    } 
