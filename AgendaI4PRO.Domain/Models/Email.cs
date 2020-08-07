using AgendaI4PRO.Domain.Models.Base;

namespace AgendaI4PRO.Domain.Models
{
    public class Email : Entidade
    {
        public int ContatoId { get; set; }

        public string Endereco { get; set; }
    }
}
