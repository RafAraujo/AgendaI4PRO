using AgendaI4PRO.Domain.Models.Base;
using System.Collections.Generic;

namespace AgendaI4PRO.Domain.Models
{
    public class Contato : Entidade
    {
        public string Nome { get; set; }

        public List<Email> Emails { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}
