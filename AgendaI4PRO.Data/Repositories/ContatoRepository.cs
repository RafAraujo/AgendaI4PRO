using AgendaI4PRO.Data.Repositories.Base;
using AgendaI4PRO.Data.Repositories.Interfaces;
using AgendaI4PRO.Domain.Models;
using System.Linq;

namespace AgendaI4PRO.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IBaseRepository<Contato>
    {
        public override Contato Obter(int id)
        {
            var contato = base.Obter(id);

            using (var bd = ObterConexao())
            {
                contato.Emails = bd.GetCollection<Email>().Find(e => e.ContatoId == contato.Id).ToList();
                contato.Telefones = bd.GetCollection<Telefone>().Find(e => e.ContatoId == contato.Id).ToList();
            }

            return contato;
        }
    }
}
