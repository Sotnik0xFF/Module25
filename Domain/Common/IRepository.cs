using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Domain.Common
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        public IUnitOfWork UnitOfWork { get; }

        T? Get(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Delete(T entity);
    }
}
