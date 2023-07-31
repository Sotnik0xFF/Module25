using Module25.Domain.BookAggregate;
using Module25.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Domain.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        void UpdateName(int id, string name);
        bool IsOwned(Book book);
    }
}
