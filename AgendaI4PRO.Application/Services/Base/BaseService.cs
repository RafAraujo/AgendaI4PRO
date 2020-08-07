using AgendaI4PRO.Application.Services.Interfaces;
using AgendaI4PRO.Data.Repositories.Interfaces;
using AgendaI4PRO.Domain.Models.Base;
using System.Collections.Generic;

namespace AgendaI4PRO.Application.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : Entidade
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual int Inserir(T entidade) => _repository.Inserir(entidade);

        public virtual T Obter(int id) => _repository.Obter(id);

        public virtual IEnumerable<T> Obter() => _repository.Obter();

        public virtual bool Alterar(T entidade) => _repository.Alterar(entidade);

        public virtual bool Remover(T entidade) => _repository.Remover(entidade);
    }
}
