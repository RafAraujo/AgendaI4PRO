using AgendaI4PRO.Domain.Models.Base;
using System.Collections;
using System.Collections.Generic;

namespace AgendaI4PRO.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Entidade
    {
        int Inserir(T entidade);

        T Obter(int id);

        IEnumerable<T> Obter();

        bool Alterar(T entidade);

        bool Remover(T entidade);
    }
}
