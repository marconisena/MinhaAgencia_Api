using System.ComponentModel;

namespace MinhaAgencia_Api.Enums
{
    public enum  StatusViagens
    {
        [Description("Compra não Realizada")]
        AFazer = 1,
        [Description("Compra em Andamento")]
        EmAndamento = 2,
        [Description("Compra Finalizada")]
        Concluido = 3
    }
}
