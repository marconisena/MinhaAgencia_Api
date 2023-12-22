using Microsoft.EntityFrameworkCore;
using MinhaAgencia_Api.Data;
using MinhaAgencia_Api.Models;
using MinhaAgencia_Api.Repositorios.Interfaces;

namespace MinhaAgencia_Api.Repositorios
{
    public class ViagensRepositorio : IViagensRepositorio
    {
        private readonly MinhaAgencia_ApiDBContext _dbContext;

        public ViagensRepositorio(MinhaAgencia_ApiDBContext  minhaAgencia_ApiDBContext )
        {
            _dbContext = minhaAgencia_ApiDBContext  ;
        }


        public async Task<ViagensModel> BuscarPorId(int id)
        {
            return await _dbContext.Viagens
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<ViagensModel>> BuscarDestinos()
        {
            return await _dbContext.Viagens
                .Include(x => x.Usuario)
                .ToListAsync();
        }
        public async Task<ViagensModel> AdicionarDestino(ViagensModel viagens)
        {
            await _dbContext.Viagens.AddAsync(viagens);
            await _dbContext.SaveChangesAsync();
            return viagens;
        }

        public async Task<ViagensModel> Atualizar(ViagensModel viagens, int id)
        {
            ViagensModel destinoPorId = await BuscarPorId(id);

            if (destinoPorId == null)
            {
                throw new Exception($" Destino de ID: {id} não foi encontrado no banco de dados!");
            }
            destinoPorId.Destino = viagens.Destino;
            destinoPorId.Status = viagens.Status;
            destinoPorId.UsuarioId = viagens.UsuarioId;

            _dbContext.Viagens.Update(destinoPorId);
            await _dbContext.SaveChangesAsync();

            return destinoPorId;


        }

        public async Task<bool> Deletar(int id)
        {
            ViagensModel destinoPorId = await BuscarPorId(id);

            if (destinoPorId == null)
            {
                throw new Exception($" Destino de ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Viagens.Remove(destinoPorId);
            await _dbContext.SaveChangesAsync();
            return true;


        }
      
    } 
}
