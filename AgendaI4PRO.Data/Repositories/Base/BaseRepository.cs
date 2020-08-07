using AgendaI4PRO.Data.Repositories.Interfaces;
using AgendaI4PRO.Domain.Models.Base;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace AgendaI4PRO.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entidade
    {
        private const string _nome = "Agenda.db";

        public ILiteDatabase ObterConexao() => new LiteDatabase(_nome);

        public virtual int Inserir(T entidade)
        {
            using var bd = ObterConexao();
            return bd.GetCollection<T>().Insert(entidade);
        }

        public virtual T Obter(int id)
        {
            using var bd = ObterConexao();
            return bd.GetCollection<T>().FindById(id);
        }

        public virtual IEnumerable<T> Obter()
        {
            using var bd = ObterConexao();
            return bd.GetCollection<T>().FindAll().ToList();
        }

        public virtual bool Alterar(T entidade)
        {
            using var bd = ObterConexao();
            return bd.GetCollection<T>().Update(entidade);
        }

        public virtual bool Remover(T entidade)
        {
            using var bd = ObterConexao();
            return bd.GetCollection<T>().Delete(entidade.Id);
        }
    }
}
