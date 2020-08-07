using AgendaI4PRO.Domain.Models.Base;

namespace AgendaI4PRO.Domain.Models
{
    public class Telefone : Entidade
    {
        public int ContatoId { get; set; }

        public string Numero { get; set; }
    }
}
