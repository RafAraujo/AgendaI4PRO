using AgendaI4PRO.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaI4PRO.Application.Services.Interfaces
{
    public interface IBaseService<T> where T : Entidade
    {
        int Inserir(T entidade);

        T Obter(int id);

        IEnumerable<T> Obter();

        bool Alterar(T entidade);

        bool Remover(T entidade);
    }
}
