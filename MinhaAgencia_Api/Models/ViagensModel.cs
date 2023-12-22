using MinhaAgencia_Api.Enums;

namespace MinhaAgencia_Api.Models
{
    public class ViagensModel
    {
        public int Id { get; set; }
        public string? Destino { get; set; }
        public StatusViagens Status { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}
