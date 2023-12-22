using MinhaAgencia_Api.Models;

namespace MinhaAgencia_Api.Repositorios.Interfaces
{
    public interface IViagensRepositorio
    {
        Task<List<ViagensModel>> BuscarDestinos();
        Task<ViagensModel> BuscarPorId(int id);
        Task<ViagensModel> AdicionarDestino(ViagensModel viagens);
        Task<ViagensModel> Atualizar(ViagensModel viagens, int id);
        Task<bool> Deletar(int id);
    }
}
